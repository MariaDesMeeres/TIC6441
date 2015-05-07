using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Common
{
    public static class CommonNetwork
    {
        public static void GetResponseStringAndStream(string url, out string responseString, out Stream responseStream)
        {
            WebResponse response = GetResponse(url);

            Stream responseStream1 = response.GetResponseStream();

            responseStream = CommonFile.Copy(responseStream1);

            StreamReader sr = new StreamReader(responseStream);

            responseString = sr.ReadToEnd();

            responseStream.Position = 0;
        }


        //**********************************************************************
        public static WebResponse GetResponse(string url)
        {
            url += "&lang=es";

            System.Console.WriteLine("Pidiendo URL: \n" + url);
            WebResponse response = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            try
            {
                response = (HttpWebResponse)request.GetResponse();

                //Response jsonResponse = objResponse as Response;
                //return jsonResponse;
                //responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                //System.Console.WriteLine("Respuesta: " + responseString);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
            return response;
        }
    }
}
