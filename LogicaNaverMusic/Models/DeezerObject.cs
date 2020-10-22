using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNaverMusic.Models
{
    class DeezerObject
    {
        public IList<Data> data { get; set; }
        public int total { get; set; }
        public string next { get; set; }
    }
}
