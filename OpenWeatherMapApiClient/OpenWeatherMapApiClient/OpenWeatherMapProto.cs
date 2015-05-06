using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using OpenWeatherMap.Model;
using OpenWeatherMap.Common;

namespace OpenWeatherMapApiClient
{
    class OpenWeatherMapProto
    {
        public enum DataMode {JSON, XML };
     
        //*******************************CONSTRUCTOR***************************************
        public OpenWeatherMapProto()
        {

        }


        //**********************************************************************
        private static string getDataModeStr(DataMode dm)
        {
            switch (dm)
            {
                case DataMode.JSON: return "JSON";
                    break;
                case DataMode.XML: return "XML";
                    break;
                default: return "JSON";
                    break;
            }
        }

        public static string GetCurrentDataByCityId(ulong cityid, DataMode mode)
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?";
            url += "id=" + cityid;
            url += "&mode=" + getDataModeStr(mode);
            url += "&units=metric";
            //"http://api.openweathermap.org/data/2.5/weather?id=2514256&mode=xml&units=metric"

            string responseString = "";
            Stream responseStream;

            try
            {
                CommonNetwork.GetResponseStringAndStream(url, out responseString, out responseStream);

                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(OWM_Current));

                object objResponse = jsonSerializer.ReadObject(responseStream);

                OWM_Current current = (OWM_Current)objResponse;

                //System.Console.WriteLine("Respuesta: " + responseString);

                ShowCurrent(current);

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error en GetCurrentDataByCityId: " + ex.Message);
            }

            return responseString;

        }


        //**********************************************************************
        private static void ShowCurrent(OWM_Current current)
        {
            Console.WriteLine(current.ToString());
        }

        //**********************************************************************
        //**********************************************************************
        // FORECAST 3H
        //**********************************************************************
        //**********************************************************************
        public static string GetEvery3HoursForecastDataByCityId(ulong cityid, DataMode mode)
        {
            string url = "http://api.openweathermap.org/data/2.5/forecast?";
            url += "id=" + cityid;
            url += "&mode=" + getDataModeStr(mode);
            url += "&units=metric";
            //http://api.openweathermap.org/data/2.5/forecast?id=524901

            string responseString = "";
            Stream responseStream;

            try
            {
                CommonNetwork.GetResponseStringAndStream(url, out responseString, out responseStream);

                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(OWM_Forecast3H));

                object objResponse = jsonSerializer.ReadObject(responseStream);

                OWM_Forecast3H forecast = (OWM_Forecast3H)objResponse;

                ShowForecast3H(forecast);

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error en GetEvery3HoursForecastDataByCityId: " + ex.Message);
            }
            
            return responseString;
        }


        //**********************************************************************
        private static void ShowForecast3H(OWM_Forecast3H forecast)
        {
            Console.WriteLine(forecast.ToString());
        }


        //**********************************************************************
        //**********************************************************************
        //DAILY
        //**********************************************************************
        //**********************************************************************
        public static string GetDailyForecastDataByCityId(ulong cityid, DataMode mode)
        {
            string url = "http://api.openweathermap.org/data/2.5/forecast?";
            url += "id=" + cityid;
            url += "&mode=" + getDataModeStr(mode);
            url += "&units=metrics";
            //http://api.openweathermap.org/data/2.5/forecast?id=524901

            return "";
        }


        //**********************************************************************
        //**********************************************************************
        //HISTORICAL
        //**********************************************************************
        //**********************************************************************
        public static string GetDailyHistoricalDataByCityId(ulong cityid, DataMode mode)
        {
            string url = "http://api.openweathermap.org/data/2.5/history/city?";
            url += "id=" + cityid;
            url += "&mode=" + getDataModeStr(mode);
            url += "&type=hour";
            url += "&units=metrics";
            //http://api.openweathermap.org/data/2.5/history/city?id=2885679&type=hour

            string responseString = "";
            Stream responseStream;

            try
            {
                CommonNetwork.GetResponseStringAndStream(url, out responseString, out responseStream);

                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(OWM_Historical));

                object objResponse = jsonSerializer.ReadObject(responseStream);

                OWM_Historical historical = (OWM_Historical)objResponse;

                ShowHistorical(historical);

                System.Console.WriteLine("Respuesta: " + responseString);

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error en GetEvery3HoursForecastDataByCityId: " + ex.Message);
            }

            return responseString;

        }


        //**********************************************************************
        private static void ShowHistorical(OWM_Historical historical)
        {
            Console.WriteLine(historical.ToString());
        }


    }
}
