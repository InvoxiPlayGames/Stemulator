using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stemulator
{
    public partial class Stemulator: Form
    {
        public Stemulator()
        {
            InitializeComponent();
        }

        private string sessionDeviceID = "000000000000000000000000";
        private string tempDLPath = Path.Combine(Path.GetTempPath(), "stemulator");
        private AlbumsContent albums;
        private StemPlayerTrack selectedTrack;
        private string selectedFormat = "mp3";
        private WaveOut vocalsOut;
        private WaveOut instrumentalOut;
        private WaveOut bassOut;
        private WaveOut drumsOut;
        private Mp3FileReader vocalsReader;
        private Mp3FileReader instrumentalReader;
        private Mp3FileReader bassReader;
        private Mp3FileReader drumsReader;
        private VolumeSampleProvider vocalsVolumeP;
        private VolumeSampleProvider instrumentalVolumeP;
        private VolumeSampleProvider bassVolumeP;
        private VolumeSampleProvider drumsVolumeP;
        private HttpClient client = new HttpClient();
        private HttpStatusCode LastResponseCode; // oh no
        // do synchronous async lmao
        private string GETRequest(string URL)
        {
            Task<HttpResponseMessage> reqtask = client.GetAsync(URL);
            reqtask.Wait();
            HttpResponseMessage response = reqtask.Result;
            Task<string> contenttask = response.Content.ReadAsStringAsync();
            contenttask.Wait();
            string content = contenttask.Result;
            LastResponseCode = response.StatusCode;
            return content;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client.BaseAddress = new Uri("https://api.stemplayer.com");
            Task.Run(LoadAlbumData);
        }

        private void UpdateStatusUnthreaded(string status, ProgressBarStyle style, int done, int max)
        {
            Invoke((MethodInvoker)delegate
            {
                statusLabel.Text = status;
                progressBar.Style = style;
                progressBar.Maximum = max;
                progressBar.Value = done;
            });
        }
        private void AlbumListAddUnthreaded(object add)
        {
            Invoke((MethodInvoker)delegate { albumList.Items.Add(add); });
        }

        private void LoadAlbumData()
        {
            UpdateStatusUnthreaded("Downloading album list...", ProgressBarStyle.Marquee, 0, 10);
            string albumsjson = GETRequest("/content/albums");
            if (LastResponseCode != HttpStatusCode.OK)
            {
                Console.WriteLine(LastResponseCode);
                Console.WriteLine(albumsjson);
                MessageBox.Show("Failed to download album list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            albums = JsonSerializer.Deserialize<AlbumsContent>(albumsjson);
            foreach(string album in albums.data.Keys)
            {
                AlbumListAddUnthreaded(albums.data[album]);
            }
            UpdateStatusUnthreaded("Ready", ProgressBarStyle.Blocks, 0, 0);
            Invoke((MethodInvoker)delegate { albumList.SelectedIndex = 0; });
        }

        private void UpdateDLStatus(long[] totalStemSize, long[] totalStemDL)
        {
            long totalSize = 0;
            long totalDL = 0;
            for (int i = 0; i < totalStemSize.Length; i++)
            {
                totalSize += totalStemSize[i];
                totalDL += totalStemDL[i];
            }
            UpdateStatusUnthreaded($"Downloading stems ({Math.Round((double)totalDL / totalSize * 100, 2)}%)", ProgressBarStyle.Blocks, (int)totalDL, (int)totalSize);
        }

        private void EnableControls(bool enable)
        {
            Invoke((MethodInvoker)delegate {
                playPauseButton.Enabled = enable;
                vocalsEnable.Enabled = enable;
                instrumentsEnable.Enabled = enable;
                drumsEnable.Enabled = enable;
                bassEnable.Enabled = enable;
                vocalsVolume.Enabled = enable;
                instrumentalVolume.Enabled = enable;
                drumsVolume.Enabled = enable;
                bassVolume.Enabled = enable;
                playPauseButton.Text = "Play";
            });
        }

        private void StopPlayback()
        {
            if (vocalsOut == null) return;
            vocalsOut.Stop(); vocalsOut.Dispose(); vocalsReader.Dispose(); vocalsVolumeP = null; vocalsOut = null;
            drumsOut.Stop(); drumsOut.Dispose(); drumsReader.Dispose();  drumsVolumeP = null;  drumsOut = null;
            instrumentalOut.Stop(); instrumentalOut.Dispose(); instrumentalReader.Dispose();  instrumentalVolumeP = null; instrumentalOut = null;
            bassOut.Stop(); bassOut.Dispose(); bassReader.Dispose(); bassVolumeP = null; bassOut = null;
        }

        async private void LoadTrackData()
        {
            StopPlayback();
            EnableControls(false);
            Directory.CreateDirectory(tempDLPath);
            UpdateStatusUnthreaded("Downloading track data...", ProgressBarStyle.Marquee, 0, 10);
            string stemsjson = GETRequest($"/content/stems?track_id={selectedTrack.id}&version={selectedTrack.version}&codec={selectedFormat}&device_id={sessionDeviceID}");
            if (LastResponseCode != HttpStatusCode.OK)
            {
                Console.WriteLine(LastResponseCode);
                Console.WriteLine(stemsjson);
                UpdateStatusUnthreaded("Failed to download track data.", ProgressBarStyle.Blocks, 0, 0);
                MessageBox.Show("Failed to download track data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            StemURLObject stemURLs = JsonSerializer.Deserialize<StemURLObject>(stemsjson);
            long[] totalStemSize = new long[4];
            long[] totalStemDL = new long[4];
            Task[] tasks = new Task[4];
            for (int i = 0; i < 4; i++)
            {
                string outPath = Path.Combine(tempDLPath, $"{i}.{selectedFormat}");
                HttpClientDownloadWithProgress dlClient = new HttpClientDownloadWithProgress(i, stemURLs.data[i + 1], outPath);
                dlClient.ProgressChanged += (id, totalFileSize, totalBytesDownloaded) => {
                    totalStemDL[id] = totalBytesDownloaded;
                    totalStemSize[id] = totalFileSize ?? 0;
                    UpdateDLStatus(totalStemSize, totalStemDL);
                };
                tasks[i] = dlClient.StartDownload();
            }
            Task.WaitAll(tasks);
            UpdateStatusUnthreaded("Initialising playback...", ProgressBarStyle.Marquee, 0, 10);
            vocalsOut = new WaveOut();
            vocalsVolumeP = new VolumeSampleProvider((vocalsReader = new Mp3FileReader(Path.Combine(tempDLPath, $"1.{selectedFormat}"))).ToSampleProvider());
            vocalsOut.Init(vocalsVolumeP);
            bassOut = new WaveOut();
            bassVolumeP = new VolumeSampleProvider((bassReader = new Mp3FileReader(Path.Combine(tempDLPath, $"2.{selectedFormat}"))).ToSampleProvider());
            bassOut.Init(bassVolumeP);
            instrumentalOut = new WaveOut();
            instrumentalVolumeP = new VolumeSampleProvider((instrumentalReader = new Mp3FileReader(Path.Combine(tempDLPath, $"3.{selectedFormat}"))).ToSampleProvider());
            instrumentalOut.Init(instrumentalVolumeP);
            drumsOut = new WaveOut();
            drumsVolumeP = new VolumeSampleProvider((drumsReader = new Mp3FileReader(Path.Combine(tempDLPath, $"3.{selectedFormat}"))).ToSampleProvider());
            drumsOut.Init(drumsVolumeP);
            EnableControls(true);
            UpdateStatusUnthreaded("Ready!", ProgressBarStyle.Blocks, 0, 0);
        }

        private void trackList_DoubleClick(object sender, EventArgs e)
        {
            if (trackList.SelectedIndex == -1) return;
            selectedTrack = (StemPlayerTrack)trackList.SelectedItem;
            Task.Run(LoadTrackData);
        }

        private void albumList_SelectedIndexChanged(object sender, EventArgs e)
        {
            trackList.Items.Clear();
            string albumTitle = ((StemPlayerAlbum)albumList.SelectedItem).title;
            trackList.Items.AddRange(albums.data[albums.data.Keys.ToArray()[albumList.SelectedIndex]].tracks);
        }

        private void playPauseButton_Click(object sender, EventArgs e)
        {
            if (vocalsOut.PlaybackState == PlaybackState.Playing)
            {
                vocalsOut.Pause();
                drumsOut.Pause();
                instrumentalOut.Pause();
                bassOut.Pause();
                playPauseButton.Text = "Play";
            } else
            {
                vocalsOut.Play();
                drumsOut.Play();
                instrumentalOut.Play();
                bassOut.Play();
                playPauseButton.Text = "Pause";
            }
        }

        private void UpdateVocalsVolume(object sender, EventArgs e)
        {
            vocalsVolumeP.Volume = vocalsEnable.Checked ? ((float)vocalsVolume.Value / vocalsVolume.Maximum) : 0.0f;
        }

        private void UpdateInstrumentalVolume(object sender, EventArgs e)
        {
            instrumentalVolumeP.Volume = instrumentsEnable.Checked ? ((float)instrumentalVolume.Value / instrumentalVolume.Maximum) : 0.0f;
        }
        private void UpdateBassVolume(object sender, EventArgs e)
        {
            bassVolumeP.Volume = bassEnable.Checked ? ((float)bassVolume.Value / bassVolume.Maximum) : 0.0f;
        }
        private void UpdateDrumsVolume(object sender, EventArgs e)
        {
            drumsVolumeP.Volume = drumsEnable.Checked ? ((float)drumsVolume.Value / drumsVolume.Maximum) : 0.0f;
        }
    }
}
