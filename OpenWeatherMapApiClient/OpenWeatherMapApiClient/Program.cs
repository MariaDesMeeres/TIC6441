using OpenWeatherMapApi.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OpenWeatherMapApiClient
{
    class Program
    {
        public static string CURRENT1 = "/C";
        public static string CURRENT2 = "/CURRENT";
        
        public static string FORECAST3H1 = "/F";
        public static string FORECAST3H2 = "/FORECAST3H";
        
        public static string FORECASTDAILY1 = "/D";
        public static string FORECASTDAILY2 = "/DAILY";

        public static string HISTORICAL1 = "/H";
        public static string HISTORICAL2 = "/HISTORICAL";

        public static string CITYID1 = "/I";
        public static string CITYID2 = "/CITYID";


        public enum QUERYTYPE { NULL, CURRENT, FORECAST3H, FORECASTDAILY, HISTORICAL };

        private static Configuration ReadConfiguration()
        {
            Configuration retVal = new Configuration();

            XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
            StreamReader reader = new StreamReader("Configuration.xml");
            retVal=(Configuration)serializer.Deserialize(reader);
            reader.Close();


            return retVal;
        }

        static void Main(string[] args)
        {
            int argsCount;
            int argIndex;
            QUERYTYPE querytype = QUERYTYPE.NULL;
            string argUpper;
            int numDaysForecastDaily;
            ulong cityId = 0; 
            string fileContent = "";

            string filePrefix;
            string strDate;
            string filename;
            DateTime now = DateTime.Now;

            Configuration retVal= ReadConfiguration();
            args = new string[] { "/F" ,"/I","2514256" };
            argsCount = args.Length;


            OpenWeatherMapApi.Domain.OWM_Base.DataMode mode=OpenWeatherMapApi.Domain.OWM_Base.DataMode.JSON;
            Current_Domain current = new Current_Domain();
            current.GetByCity(2514256, mode);
            ForeCast3H_Domain foreCast = new ForeCast3H_Domain();
            foreCast.GetByCity(2514256, mode);
            Historical_Domain historical = new Historical_Domain();
            historical.GetByCity(2514256, mode);
           
        }
    }
}
