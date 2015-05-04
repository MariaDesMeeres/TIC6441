using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;

namespace OpenWeatherMapApiClient
{
    class OpenWeatherMapProto
    {
        public enum DataMode {JSON, XML };
     
        //**********************************************************************
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

        
        //**********************************************************************
        private static Stream CopyAndClose(Stream inputStream)
        {
            const int readSize = 256;
            byte[] buffer = new byte[readSize];
            MemoryStream ms = new MemoryStream();

            int count = inputStream.Read(buffer, 0, readSize);
            while (count > 0)
            {
                ms.Write(buffer, 0, count);
                count = inputStream.Read(buffer, 0, readSize);
            }
            ms.Position = 0;
            inputStream.Close();
            return ms;
        }


        //**********************************************************************
        private static void GetResponseStringAndStream(string url, out string responseString, out Stream responseStream)
        {
            WebResponse response = GetResponse(url);

            Stream responseStream1 = response.GetResponseStream();

            responseStream = CopyAndClose(responseStream1);

            StreamReader sr = new StreamReader(responseStream);

            responseString = sr.ReadToEnd();

            responseStream.Position = 0;
        }


        //**********************************************************************
        private static WebResponse GetResponse(string url)
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


        public static DateTime UnixTimeStampToDateTime(ulong unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }


        private static string UnixDateToString(ulong unixTimeStamp)
        {
            DateTime date1 = UnixTimeStampToDateTime(unixTimeStamp);

            return date1.Year.ToString() + "/" + date1.Month.ToString().PadLeft(2, '0') + "/" + date1.Day.ToString().PadLeft(2, '0') + " " + date1.Hour.ToString().PadLeft(2, '0') + ":" + date1.Minute.ToString().PadLeft(2, '0');
        }


        //**********************************************************************
        //CURRENT DATA PARAMETERS
        //id	City identification
        //dt	Data receiving time, unix time, GMT
        //name	City name

        //coord
        //lat	City geo location, lat
        //lon	City geo location, lon
        
        //sys
        //message	System parameter, do not use it
        //country	Country (GB, JP etc.)
        //sunrise	Sunrise time, unix, UTC
        //sunset	Sunset time, unix, UTC
        
        //main
        //temp	Temperature, Kelvin (subtract 273.15 to convert to Celsius)
        //humidity	Humidity, %
        //temp_min	Minimum temperature at the moment. This is deviation from current temp that is possible for large cities and megalopolises geographically expanded (use these parameter optionally)
        //temp_max	Maximum temperature at the moment. This is deviation from current temp that is possible for large cities and megalopolises geographically expanded (use these parameter optionally)
        //pressure	Atmospheric pressure (on the sea level, if there is no sea_level or grnd_level data), hPa
        //sea_level	Atmospheric pressure on the sea level, hPa
        //grnd_level	Atmospheric pressure on the ground level, hPa
        
        //wind
        //speed	Wind speed, mps
        //deg	Wind direction, degrees (meteorological)
        //gust	Wind gust, mps
        
        //clouds
        //all	Cloudiness, %
        //weather (more info Weather condition codes)
        //id	Weather condition id
        //main	Group of weather parameters (Rain, Snow, Extreme etc.)
        //description	Weather condition within the group
        //icon	Weather icon id
        
        //rain
        //3h	Precipitation volume for last 3 hours, mm
        
        //snow
        //3h	Snow volume for last 3 hours, mm


        //Respuesta: 
        //<?xml version="1.0" encoding="utf-8"?>
        //<current>
        //<city id="2514256" name="Malaga">
        //<coord lon="-4.42" lat="36.72"/>
        //<country>ES</country>
        //<sun rise="2015-01-16T07:28:45" set="2015-01-16T17:26:16"/>
        //</city>
        //<temperature value="12.783" min="12.783" max="12.783" unit="celsius"/>
        //<humidity value="100" unit="%"/>
        //<pressure value="1014.84" unit="hPa"/>
        //<wind>
        //<speed value="7.61" name="Moderate breeze"/>
        //<direction value="309.501" code="NW" name="Northwest"/>
        //</wind>
        //<clouds value="0" name="clear sky"/>
        //<visibility/>
        //<precipitation mode="no"/>
        //<weather number="800" value="Sky is Clear" icon="01d"/>
        //<lastupdate value="2015-01-16T15:25:34"/>
        //</current>

        //**********************************************************************
        //**********************************************************************
        //CURRENT
        //**********************************************************************
        //**********************************************************************
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
                GetResponseStringAndStream(url, out responseString, out responseStream);

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
            System.Console.WriteLine("Respuesta: Cod: " + current.cod + "; Dt: " + current.dt);
            System.Console.WriteLine("Id: " + current.id + "; Name: " + current.name);
            System.Console.WriteLine("Coord: Lon: " + current.coord.lon + "; Lat: " + current.coord.lat);
            System.Console.WriteLine("Base: " + current.@base);

            if (current.weather != null)
            {
                System.Console.WriteLine("Weather: ");
                for (int w = 0; w < current.weather.Count; w++)
                {
                    System.Console.WriteLine("Id: " + current.weather[w].id + "; Main: " + current.weather[w].main + "; Description: " + current.weather[w].description + "; Icon: " + current.weather[w].icon);
                }
            }

            System.Console.WriteLine("Sys: Message:" + current.sys.message + "; Country: " + current.sys.country + "; Sunrise: " + current.sys.sunrise + "; Sunset: " + current.sys.sunset);
            System.Console.WriteLine("Sys: Sunrise: " + UnixDateToString(current.sys.sunrise) + "; Sunset: " + UnixDateToString(current.sys.sunset));
            System.Console.WriteLine("Wind: Speed: " + current.wind.speed + "; Deg: " + current.wind.deg);
            System.Console.WriteLine("Clouds: All: " + current.clouds.all);

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
                GetResponseStringAndStream(url, out responseString, out responseStream);

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
            System.Console.WriteLine("Respuesta: Cod: " + forecast.cod + "; Message: " + forecast.message);
            System.Console.WriteLine("City: Id: " + forecast.city.id + "; Name: " + forecast.city.name + "; Country: " + forecast.city.country + "; Population: " + forecast.city.population);
            System.Console.WriteLine("City: Lon: " + forecast.city.coord.lon + "; Lat: " + forecast.city.coord.lat);
            System.Console.WriteLine("Cnt: " + forecast.cnt);

            if (forecast.list != null)
            {
                System.Console.WriteLine("List: ");
                for (int f = 0; f < forecast.list.Count; f++)
                {
                    System.Console.WriteLine("Dt: " + forecast.list[f].dt + "; Dt_txt: " + forecast.list[f].dt_txt);

                    if (forecast.list[f].weather != null)
                    {
                        for (int w = 0; w < forecast.list[f].weather.Count; w++)
                        {
                            OWM_Forecast3H_Weather wea = forecast.list[f].weather[w];
                            System.Console.WriteLine("Weather: Id:" + wea.id + "; Main: " + wea.main + "; Description: " + wea.description + "; Icon: " + wea.icon);
                        }
                    }

                    System.Console.WriteLine("Clouds: All: " + forecast.list[f].clouds.all);
                    System.Console.WriteLine("Wind: Speed: " + forecast.list[f].wind.speed + "; Deg:" + forecast.list[f].wind.deg);
                    System.Console.WriteLine("Sys: Pod: " + forecast.list[f].sys.pod);
                }
            }
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
                GetResponseStringAndStream(url, out responseString, out responseStream);

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
            OWM_Historical_ListElement element;
            OWM_Historical_WeatherElement weatherElement;

            System.Console.WriteLine("Respuesta: Message: " + historical.message + "; Cod: " + historical.cod + "; CityId: " + historical.city_id + "; Calctime: " + historical.calctime);
            System.Console.WriteLine("Cnt: " + historical.cnt);

            if (historical.list != null)
            {
                for (int h = 0; h < historical.list.Count; h++)
                {
                    element = historical.list[h];
                    System.Console.WriteLine("Main: Temp: " + element.main.temp + "; Temp_min: " + element.main.temp_min + "; Temp_max: " + element.main.temp_max + "; Humidity: " + element.main.humidity + "; Pressure: " + element.main.pressure);
                    System.Console.WriteLine("Wind: Speed: " + element.wind.speed + "; Gust: " + element.wind.gust + "; Deg: " + element.wind.deg);
                    System.Console.WriteLine("Clouds: All: " + element.clouds.all);

                    if (element.weather != null)
                    {
                        for (int w = 0; w < element.weather.Count; w++)
                        {
                            weatherElement = element.weather[w];
                            System.Console.WriteLine("Weather: Id: " + weatherElement.id + "; Main: " + weatherElement.main + "; Description: " + weatherElement.description + "; Icon: " + weatherElement.icon);

                        }
                    }
                    System.Console.WriteLine("Dt: " + element.dt + " Dt(date): " + UnixDateToString(element.dt));
                }
            }
        }


    }
}
