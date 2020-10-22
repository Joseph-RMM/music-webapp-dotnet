using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNaverMusic.Controllers
{
    class APIDeezerController
    {
        private string url = "https://api.deezer.com/search?q=awake";

        public void GetDataFromDeezer()
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";

            HttpWebResponse reponse = null;
            reponse = (HttpWebResponse)request.GetResponse();

            string resultAPI;
            using (Stream stream = reponse.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                resultAPI = sr.ReadToEnd();
                sr.Close();
            }
        }
    }
}
