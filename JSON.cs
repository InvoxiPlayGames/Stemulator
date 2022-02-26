using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stemulator
{
    public class AlbumsContent
    {
        public Dictionary<string, StemPlayerAlbum> data { get; set; }
    }

    public class StemPlayerAlbum
    {
        public string artist { get; set; }
        public string[] artists { get; set; }
        public bool paid_content { get; set; }
        public string title { get; set; }
        public StemPlayerTrack[] tracks { get; set; }
        public string version { get; set; }
        public override string ToString()
        {
            return $"{title} - {artist}";
        }
    }

    public class StemPlayerTrack
    {
        public string[] formats { get; set; }
        public string id { get; set; }
        public StemPlayerMetadata metadata { get; set; }
        public bool paid_content { get; set; }
        public string stems_version { get; set; }
        public string version { get; set; }
        public override string ToString()
        {
            return $"{metadata.title}";
        }
    }

    public class StemPlayerMetadata
    {
        public string[] artists { get; set; }
        public string[] color { get; set; }
        public float gain { get; set; }
        public Dictionary<int, int> stem_size { get; set; }
        public StemPlayerTempos[] tempos { get; set; }
        public string title { get; set; }
        public string version { get; set; }
    }

    public class StemPlayerTempos
    {
        public int tempo_bpm { get; set; }
        public int time_ms { get; set; }
    }


    public class StemURLObject
    {
        public Dictionary<int, string> data { get; set; }
    }

}
