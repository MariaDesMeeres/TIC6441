﻿using OpenWeatherMap.Common;
using OpenWeatherMap.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMapApi.Domain
{
    public class Current_Domain:OWM_Base
    {
        private OWM_Current _owm_Current;

        public Current_Domain()
        { }
        public Current_Domain(OWM_Current owm_Current)
        {
            _owm_Current = owm_Current;
        }

        public void GetByCity(ulong cityId, DataMode mode)
        {
            Url = "/weather?";
            Url += "id=" + cityId;
            Url += "&mode=" + GetDataModeStr(mode);
            Url += "&units=metric";
            //"http://api.openweathermap.org/data/2.5/weather?id=2514256&mode=xml&units=metric"

            try
            {
                base.GetResponse();

                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(OWM_Current));

                object objResponse = jsonSerializer.ReadObject(ResponseStream);

                OWM_Current current = (OWM_Current)objResponse;
            }
            catch(Exception ex)
            {

            }

        }
        public string ToString()
        {
            string retVal = "",newLine=Environment.NewLine;
            retVal = "Respuesta: Cod: " + _owm_Current.cod + "; Dt: " + _owm_Current.dt+ newLine;
            retVal += "Id: " + _owm_Current.id + "; Name: " + _owm_Current.name+newLine;
            retVal += "Coord: Lon: " + _owm_Current.coord.lon + "; Lat: " + _owm_Current.coord.lat+newLine;
            retVal +="Base: " + _owm_Current.@base+newLine;

            if (_owm_Current.weather != null)
            {
                retVal+= "Weather: "+newLine;
                for (int w = 0; w < _owm_Current.weather.Count; w++)
                {
                    retVal+="Id: " + _owm_Current.weather[w].id + "; Main: " + _owm_Current.weather[w].main + "; Description: " + _owm_Current.weather[w].description + "; Icon: " + _owm_Current.weather[w].icon+newLine;
                }
            }

            retVal+= "Sys: Message:" + _owm_Current.sys.message + "; Country: " + _owm_Current.sys.country + "; Sunrise: " + _owm_Current.sys.sunrise + "; Sunset: " + _owm_Current.sys.sunset+newLine;
            retVal+="Sys: Sunrise: " + CommonDate.UnixDateToString(_owm_Current.sys.sunrise) + "; Sunset: " + CommonDate.UnixDateToString(_owm_Current.sys.sunset)+newLine;
            retVal+= "Wind: Speed: " + _owm_Current.wind.speed + "; Deg: " + _owm_Current.wind.deg+newLine;
            retVal+= "Clouds: All: " + _owm_Current.clouds.all+newLine;

            return retVal;
        }
    }
}
