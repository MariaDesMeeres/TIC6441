using log4net;
using log4net.Config;
using OpenWeatherMap.Common;
using OpenWeatherMapApi.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Timers;
using System.Xml.Serialization;

namespace OpenWeatherMapApiClient
{
    class Program
    {
        Timer _currentTimer;
        public enum QUERYTYPE { NULL, CURRENT, FORECAST3H, FORECASTDAILY, HISTORICAL };
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            int argsCount;
            XmlConfigurator.Configure();
            Log.Debug("Starting application");
            DateTime now = DateTime.Now;

            Configuration retVal= CommonFile.ReadConfiguration();
            args = new string[] { "/F" ,"/I","2514256" };
            argsCount = args.Length;


            OpenWeatherMapApi.Domain.OWM_Base.DataMode mode=OpenWeatherMapApi.Domain.OWM_Base.DataMode.JSON;
            Current_Domain current = new Current_Domain();
            current.GetByCity(retVal.Cities, mode);
            ForeCast3H_Domain foreCast = new ForeCast3H_Domain();
            foreCast.GetByCity(retVal.Cities, mode);
            Historical_Domain historical = new Historical_Domain();
            historical.GetByCity(retVal.Cities, mode);
           
        }

        private void Run()
        {
            RunCurrentOwmTask();
            RunForecast3HOwmTask();
            RunHistoricalOwmTask();
        }

        private void RunCurrentOwmTask()
        {
            OpenWeatherMapApi.Domain.OWM_Base.DataMode mode = OpenWeatherMapApi.Domain.OWM_Base.DataMode.JSON;
            Configuration retVal = (Configuration) CommonFile.ReadConfiguration();
            Current_Domain current = new Current_Domain();
            current.GetByCity(retVal.Cities, mode);
        }

        private void RunForecast3HOwmTask()
        {
            OpenWeatherMapApi.Domain.OWM_Base.DataMode mode = OpenWeatherMapApi.Domain.OWM_Base.DataMode.JSON;
            Configuration retVal = CommonFile.ReadConfiguration();
            ForeCast3H_Domain foreCast = new ForeCast3H_Domain();
            foreCast.GetByCity(retVal.Cities, mode);
        }

        private void RunHistoricalOwmTask()
        {
            OpenWeatherMapApi.Domain.OWM_Base.DataMode mode = OpenWeatherMapApi.Domain.OWM_Base.DataMode.JSON;
            Configuration retVal =CommonFile.ReadConfiguration();
            Historical_Domain historical = new Historical_Domain();
            historical.GetByCity(retVal.Cities, mode);
        }
    }
}
