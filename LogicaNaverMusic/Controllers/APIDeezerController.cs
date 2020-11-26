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

        public AlbumModel GetAlbum(int idAlbum)
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

            AlbumModel reponseFromSearch;
            reponseFromSearch = JsonConvert.DeserializeObject<AlbumModel>(resultAPI);

            return reponseFromSearch;
        }

        public Artist GetArtist(int idArtist)
        {
            WebRequest request = WebRequest.Create(url + "artist/" + idArtist);
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

            Artist reponseFromSearch;
            reponseFromSearch = JsonConvert.DeserializeObject<Artist>(resultAPI);

            return reponseFromSearch;
        }
    }

    
}
