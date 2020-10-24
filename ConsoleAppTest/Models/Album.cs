using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Models
{
    class Album
    {
        public string id { get; set; }
        public string title { get; set; }
        public string cover { get; set; }
        public string cover_small { get; set; }
        public string cover_medium { get; set; }
        public string cover_big { get; set; }
        public string cover_xl { get; set; }
        public string md5_image { get; set; }
        public string tracklist { get; set; }
        public string type { get; set; }
    }
}
