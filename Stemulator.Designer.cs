namespace Stemulator
{
    partial class Stemulator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.albumList = new System.Windows.Forms.ComboBox();
            this.trackList = new System.Windows.Forms.ListBox();
            this.vocalsEnable = new System.Windows.Forms.CheckBox();
            this.vocalsVolume = new System.Windows.Forms.TrackBar();
            this.exportVocals = new System.Windows.Forms.Button();
            this.exportInstrumental = new System.Windows.Forms.Button();
            this.instrumentalVolume = new System.Windows.Forms.TrackBar();
            this.instrumentsEnable = new System.Windows.Forms.CheckBox();
            this.exportBass = new System.Windows.Forms.Button();
            this.bassVolume = new System.Windows.Forms.TrackBar();
            this.bassEnable = new System.Windows.Forms.CheckBox();
            this.exportDrums = new System.Windows.Forms.Button();
            this.drumsVolume = new System.Windows.Forms.TrackBar();
            this.drumsEnable = new System.Windows.Forms.CheckBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.playPauseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.vocalsVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.instrumentalVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bassVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drumsVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // albumList
            // 
            this.albumList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.albumList.FormattingEnabled = true;
            this.albumList.Location = new System.Drawing.Point(12, 12);
            this.albumList.Name = "albumList";
            this.albumList.Size = new System.Drawing.Size(184, 21);
            this.albumList.TabIndex = 0;
            this.albumList.SelectedIndexChanged += new System.EventHandler(this.albumList_SelectedIndexChanged);
            // 
            // trackList
            // 
            this.trackList.FormattingEnabled = true;
            this.trackList.Location = new System.Drawing.Point(12, 39);
            this.trackList.Name = "trackList";
            this.trackList.Size = new System.Drawing.Size(184, 303);
            this.trackList.TabIndex = 1;
            this.trackList.DoubleClick += new System.EventHandler(this.trackList_DoubleClick);
            // 
            // vocalsEnable
            // 
            this.vocalsEnable.AutoSize = true;
            this.vocalsEnable.Checked = true;
            this.vocalsEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vocalsEnable.Enabled = false;
            this.vocalsEnable.Location = new System.Drawing.Point(226, 46);
            this.vocalsEnable.Name = "vocalsEnable";
            this.vocalsEnable.Size = new System.Drawing.Size(58, 17);
            this.vocalsEnable.TabIndex = 2;
            this.vocalsEnable.Text = "Vocals";
            this.vocalsEnable.UseVisualStyleBackColor = true;
            this.vocalsEnable.CheckedChanged += new System.EventHandler(this.UpdateVocalsVolume);
            // 
            // vocalsVolume
            // 
            this.vocalsVolume.Enabled = false;
            this.vocalsVolume.Location = new System.Drawing.Point(226, 69);
            this.vocalsVolume.Maximum = 100;
            this.vocalsVolume.Name = "vocalsVolume";
            this.vocalsVolume.Size = new System.Drawing.Size(352, 45);
            this.vocalsVolume.TabIndex = 3;
            this.vocalsVolume.Value = 100;
            this.vocalsVolume.Scroll += new System.EventHandler(this.UpdateVocalsVolume);
            // 
            // exportVocals
            // 
            this.exportVocals.Enabled = false;
            this.exportVocals.Location = new System.Drawing.Point(503, 42);
            this.exportVocals.Name = "exportVocals";
            this.exportVocals.Size = new System.Drawing.Size(75, 23);
            this.exportVocals.TabIndex = 4;
            this.exportVocals.Text = "Export...";
            this.exportVocals.UseVisualStyleBackColor = true;
            // 
            // exportInstrumental
            // 
            this.exportInstrumental.Enabled = false;
            this.exportInstrumental.Location = new System.Drawing.Point(503, 122);
            this.exportInstrumental.Name = "exportInstrumental";
            this.exportInstrumental.Size = new System.Drawing.Size(75, 23);
            this.exportInstrumental.TabIndex = 7;
            this.exportInstrumental.Text = "Export...";
            this.exportInstrumental.UseVisualStyleBackColor = true;
            // 
            // instrumentalVolume
            // 
            this.instrumentalVolume.Enabled = false;
            this.instrumentalVolume.Location = new System.Drawing.Point(226, 149);
            this.instrumentalVolume.Maximum = 100;
            this.instrumentalVolume.Name = "instrumentalVolume";
            this.instrumentalVolume.Size = new System.Drawing.Size(352, 45);
            this.instrumentalVolume.TabIndex = 6;
            this.instrumentalVolume.Value = 100;
            this.instrumentalVolume.Scroll += new System.EventHandler(this.UpdateInstrumentalVolume);
            // 
            // instrumentsEnable
            // 
            this.instrumentsEnable.AutoSize = true;
            this.instrumentsEnable.Checked = true;
            this.instrumentsEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.instrumentsEnable.Enabled = false;
            this.instrumentsEnable.Location = new System.Drawing.Point(226, 126);
            this.instrumentsEnable.Name = "instrumentsEnable";
            this.instrumentsEnable.Size = new System.Drawing.Size(83, 17);
            this.instrumentsEnable.TabIndex = 5;
            this.instrumentsEnable.Text = "Instrumental";
            this.instrumentsEnable.UseVisualStyleBackColor = true;
            this.instrumentsEnable.CheckedChanged += new System.EventHandler(this.UpdateInstrumentalVolume);
            // 
            // exportBass
            // 
            this.exportBass.Enabled = false;
            this.exportBass.Location = new System.Drawing.Point(503, 200);
            this.exportBass.Name = "exportBass";
            this.exportBass.Size = new System.Drawing.Size(75, 23);
            this.exportBass.TabIndex = 10;
            this.exportBass.Text = "Export...";
            this.exportBass.UseVisualStyleBackColor = true;
            // 
            // bassVolume
            // 
            this.bassVolume.Enabled = false;
            this.bassVolume.Location = new System.Drawing.Point(226, 227);
            this.bassVolume.Maximum = 100;
            this.bassVolume.Name = "bassVolume";
            this.bassVolume.Size = new System.Drawing.Size(352, 45);
            this.bassVolume.TabIndex = 9;
            this.bassVolume.Value = 100;
            this.bassVolume.Scroll += new System.EventHandler(this.UpdateBassVolume);
            // 
            // bassEnable
            // 
            this.bassEnable.AutoSize = true;
            this.bassEnable.Checked = true;
            this.bassEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bassEnable.Enabled = false;
            this.bassEnable.Location = new System.Drawing.Point(226, 204);
            this.bassEnable.Name = "bassEnable";
            this.bassEnable.Size = new System.Drawing.Size(49, 17);
            this.bassEnable.TabIndex = 8;
            this.bassEnable.Text = "Bass";
            this.bassEnable.UseVisualStyleBackColor = true;
            this.bassEnable.CheckedChanged += new System.EventHandler(this.UpdateBassVolume);
            // 
            // exportDrums
            // 
            this.exportDrums.Enabled = false;
            this.exportDrums.Location = new System.Drawing.Point(503, 276);
            this.exportDrums.Name = "exportDrums";
            this.exportDrums.Size = new System.Drawing.Size(75, 23);
            this.exportDrums.TabIndex = 13;
            this.exportDrums.Text = "Export...";
            this.exportDrums.UseVisualStyleBackColor = true;
            // 
            // drumsVolume
            // 
            this.drumsVolume.Enabled = false;
            this.drumsVolume.Location = new System.Drawing.Point(226, 303);
            this.drumsVolume.Maximum = 100;
            this.drumsVolume.Name = "drumsVolume";
            this.drumsVolume.Size = new System.Drawing.Size(352, 45);
            this.drumsVolume.TabIndex = 12;
            this.drumsVolume.Value = 100;
            this.drumsVolume.Scroll += new System.EventHandler(this.UpdateDrumsVolume);
            // 
            // drumsEnable
            // 
            this.drumsEnable.AutoSize = true;
            this.drumsEnable.Checked = true;
            this.drumsEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.drumsEnable.Enabled = false;
            this.drumsEnable.Location = new System.Drawing.Point(226, 280);
            this.drumsEnable.Name = "drumsEnable";
            this.drumsEnable.Size = new System.Drawing.Size(56, 17);
            this.drumsEnable.TabIndex = 11;
            this.drumsEnable.Text = "Drums";
            this.drumsEnable.UseVisualStyleBackColor = true;
            this.drumsEnable.CheckedChanged += new System.EventHandler(this.UpdateDrumsVolume);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(12, 347);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(37, 13);
            this.statusLabel.TabIndex = 14;
            this.statusLabel.Text = "Status";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 363);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(184, 14);
            this.progressBar.TabIndex = 15;
            // 
            // playPauseButton
            // 
            this.playPauseButton.Enabled = false;
            this.playPauseButton.Location = new System.Drawing.Point(503, 13);
            this.playPauseButton.Name = "playPauseButton";
            this.playPauseButton.Size = new System.Drawing.Size(75, 23);
            this.playPauseButton.TabIndex = 19;
            this.playPauseButton.Text = "Play";
            this.playPauseButton.UseVisualStyleBackColor = true;
            this.playPauseButton.Click += new System.EventHandler(this.playPauseButton_Click);
            // 
            // Stemulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 390);
            this.Controls.Add(this.playPauseButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.exportDrums);
            this.Controls.Add(this.drumsVolume);
            this.Controls.Add(this.drumsEnable);
            this.Controls.Add(this.exportBass);
            this.Controls.Add(this.bassVolume);
            this.Controls.Add(this.bassEnable);
            this.Controls.Add(this.exportInstrumental);
            this.Controls.Add(this.instrumentalVolume);
            this.Controls.Add(this.instrumentsEnable);
            this.Controls.Add(this.exportVocals);
            this.Controls.Add(this.vocalsVolume);
            this.Controls.Add(this.vocalsEnable);
            this.Controls.Add(this.trackList);
            this.Controls.Add(this.albumList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Stemulator";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stemulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vocalsVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.instrumentalVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bassVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drumsVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void TrackList_DoubleClick(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.ComboBox albumList;
    private System.Windows.Forms.ListBox trackList;
    private System.Windows.Forms.CheckBox vocalsEnable;
    private System.Windows.Forms.TrackBar vocalsVolume;
    private System.Windows.Forms.Button exportVocals;
    private System.Windows.Forms.Button exportInstrumental;
    private System.Windows.Forms.TrackBar instrumentalVolume;
    private System.Windows.Forms.CheckBox instrumentsEnable;
    private System.Windows.Forms.Button exportBass;
    private System.Windows.Forms.TrackBar bassVolume;
    private System.Windows.Forms.CheckBox bassEnable;
    private System.Windows.Forms.Button exportDrums;
    private System.Windows.Forms.TrackBar drumsVolume;
    private System.Windows.Forms.CheckBox drumsEnable;
    private System.Windows.Forms.Label statusLabel;
    private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button playPauseButton;
    }
}

