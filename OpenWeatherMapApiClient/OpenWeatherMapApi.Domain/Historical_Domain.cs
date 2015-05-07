using OpenWeatherMap.Common;
using OpenWeatherMap.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMapApi.Domain
{
    public class Historical_Domain:OWM_Base
    {
        public OWM_Historical _historical;

        public Historical_Domain(OWM_Historical historical):this()
        {
            _historical = historical;
            
        }
        public Historical_Domain():base()
        { }

        public void GetByCity(ulong cityId, DataMode mode)
        {
            Url += "history/city?";
            Url += "id=" + cityId;
            Url += "&mode=" + GetDataModeStr(mode);
            Url += "&type=hour";
            Url += "&units=metrics";
            //http://api.openweathermap.org/data/2.5/history/city?id=2885679&type=hour


            try
            {
                base.GetResponse();
                //CommonNetwork.GetResponseStringAndStream(url, out responseString, out responseStream);

                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(OWM_Forecast3H));

                object objResponse = jsonSerializer.ReadObject(ResponseStream);

                _historical = (OWM_Historical)objResponse;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error en GetCurrentDataByCityId: " + ex.Message);
            }
        }

        public string ToString()
        {
            string retVal = "",newLine=System.Environment.NewLine;
            OWM_Historical_ListElement element;
            OWM_Historical_WeatherElement weatherElement;


            retVal="Respuesta: Message: " + _historical.message + "; Cod: " + _historical.cod + "; CityId: " + _historical.city_id + "; Calctime: " + _historical.calctime+newLine;
            retVal+= "Cnt: " + _historical.cnt+newLine;

            if (_historical.list != null)
            {
                for (int h = 0; h < _historical.list.Count; h++)
                {
                    element = _historical.list[h];
                    retVal+="Main: Temp: " + element.main.temp + "; Temp_min: " + element.main.temp_min + "; Temp_max: " + element.main.temp_max + "; Humidity: " + element.main.humidity + "; Pressure: " + element.main.pressure+newLine;
                    retVal += "Wind: Speed: " + element.wind.speed + "; Gust: " + element.wind.gust + "; Deg: " + element.wind.deg + newLine;
                    retVal += "Clouds: All: " + element.clouds.all + newLine;

                    if (element.weather != null)
                    {
                        for (int w = 0; w < element.weather.Count; w++)
                        {
                            weatherElement = element.weather[w];
                            retVal+="Weather: Id: " + weatherElement.id + "; Main: " + weatherElement.main + "; Description: " + weatherElement.description + "; Icon: " + weatherElement.icon+newLine;

                        }
                    }
                    retVal += "Dt: " + element.dt + " Dt(date): " + CommonDate.UnixDateToString(element.dt) + newLine;
                }
            }

            return retVal;
        }
    }
}
