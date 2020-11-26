using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNaverMusic.Models
{
    public class Data
    {
        public string id { get; set; }
        public bool readable { get; set; }
        public string title { get; set; }
        public string title_short { get; set; }
        public string title_version { get; set; }
        public string link { get; set; }
        public string duration { get; set; }
        public string rank { get; set; }
        public bool explicit_lyrics { get; set; }
        public int explicit_content_lyrics { get; set; }
        public int explicit_content_cover { get; set; }
        public string preview { get; set; }
        public string md5_image { get; set; }
        public Artist artist { get; set; }
        public AlbumModel album { get; set; }
        public string type { get; set; }
    }
}
