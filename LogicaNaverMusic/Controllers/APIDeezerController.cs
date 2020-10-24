using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using LogicaNaverMusic.Models;
using Newtonsoft.Json;

namespace LogicaNaverMusic.Controllers
{
    public class APIDeezerController
    {
        private string url = "https://api.deezer.com/search?q=";

        public Data GetDataFromSearchDeezer(string busqueda)
        {
            WebRequest request = WebRequest.Create(url+busqueda);
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

            Data reponseFromSearch;
            reponseFromSearch = JsonConvert.DeserializeObject<Data>(resultAPI);

            return reponseFromSearch;
        }
    }
}
