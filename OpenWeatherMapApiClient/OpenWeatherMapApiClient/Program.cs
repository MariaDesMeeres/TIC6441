using OpenWeatherMapApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            string usageText = "USO: OpenWeatherMapApiClient.exe [OPTIONS]\nOPTIONS:\n";
            usageText += "  /i or /cityid n     set city id number\n";
            usageText += "  /c or /current      set current weather query type\n";
            usageText += "  /h or /forecast3h   set 3 hours interval forecast query type\n";
            usageText += "  /d or /daily        set daily forecast query type\n";

            args = new string[] { "/F" ,"/I","2514256" };
            argsCount = args.Length;

            OpenWeatherMapApi.Domain.OWM_Base.DataMode mode=OpenWeatherMapApi.Domain.OWM_Base.DataMode.JSON;
            Current_Domain current = new Current_Domain();
            current.GetByCity(2514256, mode);
            ForeCast3H_Domain foreCast = new ForeCast3H_Domain();
            foreCast.GetByCity(2514256, mode);
            Historical_Domain historical = new Historical_Domain();
            historical.GetByCity(2514256, mode);
            /*System.Console.WriteLine("Arguments number: " + args.Length);
            foreach (string arg in args)
            {
                System.Console.WriteLine("Argument: " + arg);
            }

            if (argsCount == 0)
            {
                System.Console.WriteLine(usageText);
            }
            else if (argsCount > 0)
            {
                for (argIndex= 0; argIndex < argsCount; argIndex ++)
                {
                    argUpper = args[argIndex].ToUpper();

                    //CURRENT *******************************
                    if ((argUpper.CompareTo(CURRENT1) == 0) || (argUpper.CompareTo(CURRENT2) == 0))
                    {
                        querytype = QUERYTYPE.CURRENT;
                    }

                    //FORECAST 3H ***************************
                    if ((argUpper.CompareTo(FORECAST3H1) == 0) || (argUpper.CompareTo(FORECAST3H2) == 0))
                    {
                        querytype = QUERYTYPE.FORECAST3H;
                    }

                    //FORECASTDAILY *************************
                    if ((argUpper.CompareTo(FORECASTDAILY1) == 0) || (argUpper.CompareTo(FORECASTDAILY2) == 0))
                    {
                        if (argsCount > argIndex + 1)
                        {
                            if (int.TryParse(args[argIndex + 1], out numDaysForecastDaily))
                            {
                                querytype = QUERYTYPE.FORECASTDAILY;
                            }
                        }
                    }

                    //FORECAST 3H ***************************
                    if ((argUpper.CompareTo(HISTORICAL1) == 0) || (argUpper.CompareTo(HISTORICAL2) == 0))
                    {
                        querytype = QUERYTYPE.HISTORICAL;
                    }

                    //CITYID ********************************
                    if (argUpper.CompareTo(CITYID1) == 0)
                    {
                        if (argsCount > argIndex + 1)
                        {
                            if (!ulong.TryParse(args[argIndex + 1], out cityId))
                            {
                                cityId = 0;
                            }
                        }
                    }
                } //END FOR

                if (cityId == 0)
                {
                    querytype = QUERYTYPE.NULL;
                }

                //EXECUTE APPROPIATE METHOD
                //****************************

                if (querytype != QUERYTYPE.NULL)
                {
                    if (querytype == QUERYTYPE.CURRENT)
                    {
                        fileContent = OpenWeatherMapProto.GetCurrentDataByCityId(cityId, OpenWeatherMapProto.DataMode.JSON);
                        filePrefix = "CURRENT";
                    }
                    else if (querytype == QUERYTYPE.FORECAST3H)
                    {
                        fileContent = OpenWeatherMapProto.GetEvery3HoursForecastDataByCityId(cityId, OpenWeatherMapProto.DataMode.JSON);
                        filePrefix = "FORECAST3H";
                    }
                    else if (querytype == QUERYTYPE.FORECASTDAILY)
                    {
                        fileContent = OpenWeatherMapProto.GetDailyForecastDataByCityId(cityId, OpenWeatherMapProto.DataMode.JSON);
                        filePrefix = "FORECASTDAILY";
                    }
                    else if (querytype == QUERYTYPE.HISTORICAL)
                    {
                        fileContent = OpenWeatherMapProto.GetDailyHistoricalDataByCityId(cityId, OpenWeatherMapProto.DataMode.JSON);
                        filePrefix = "HISTORICAL";
                    }
                    else
                    {
                        filePrefix = "NULL";
                    }

                    if (fileContent != "")
                    {

                        strDate = now.Year + now.Month.ToString().PadLeft(2, '0') + now.Day.ToString().PadLeft(2, '0') + now.Hour.ToString().PadLeft(2, '0') + now.Minute.ToString().PadLeft(2, '0');
                        filename = filePrefix + "_" + strDate + ".json";
                        FileManager.WriteFile(filename, fileContent);
                    }
                }
                else 
                {
                    System.Console.WriteLine("Error en los parámetros...");
                }
            }*/
        }
    }
}
