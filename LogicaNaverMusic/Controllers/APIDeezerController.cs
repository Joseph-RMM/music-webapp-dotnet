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
        private string urlTrack = "https://api.deezer.com/track/";

        public List<Data> GetDataFromSearchDeezer(string busqueda)
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

            DeezerObject reponseFromSearch;
            reponseFromSearch = JsonConvert.DeserializeObject<DeezerObject>(resultAPI);

            return reponseFromSearch.data;
        }

        public Data GetTrack(int idTrack)
        {
            WebRequest request = WebRequest.Create(urlTrack + idTrack.ToString());
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
