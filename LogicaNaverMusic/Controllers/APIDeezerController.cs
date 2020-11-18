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
        private string url = "https://api.deezer.com/";
        private string urlTrack = "https://api.deezer.com/track/";
        private string urlAlbum = "https://api.deezer.com/album/  https://api.deezer.com/artist/27";


        public List<Data> GetDataFromSearchDeezer(string busqueda)
        {
            WebRequest request = WebRequest.Create(url+ "search?q=" + busqueda);
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
            WebRequest request = WebRequest.Create(url + "track/" + idTrack);
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

        public Album GetAlbum(int idAlbum)
        {
            WebRequest request = WebRequest.Create(url + "album/" + idAlbum);
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

            Album reponseFromSearch;
            reponseFromSearch = JsonConvert.DeserializeObject<Album>(resultAPI);

            return reponseFromSearch;
        }
    }

    
}
