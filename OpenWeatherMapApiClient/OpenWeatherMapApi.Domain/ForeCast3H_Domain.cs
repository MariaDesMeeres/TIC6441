﻿using OpenWeatherMap.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMapApi.Domain
{
    public class ForeCast3H_Domain
    {
        public OWM_Forecast3H _owm_forecast3h;
        public ForeCast3H_Domain(OWM_Forecast3H foreCast3H)
        {
            _owm_forecast3h = foreCast3H;
        }

        public string ToString()
        {
            string reTval = "", newLine=System.Environment.NewLine;
            reTval = "Respuesta: Cod: " + _owm_forecast3h.cod + "; Message: " + _owm_forecast3h.message + newLine;
            reTval += "City: Id: " + _owm_forecast3h.city.id + "; Name: " + _owm_forecast3h.city.name + "; Country: " + _owm_forecast3h.city.country + "; Population: " + _owm_forecast3h.city.population + newLine;
            reTval += "City: Lon: " + _owm_forecast3h.city.coord.lon + "; Lat: " + _owm_forecast3h.city.coord.lat + newLine;
            reTval += "Cnt: " + _owm_forecast3h.cnt + newLine;

            if (_owm_forecast3h.list != null)
            {
                reTval += "List: " + newLine;
                for (int f = 0; f < _owm_forecast3h.list.Count; f++)
                {
                    reTval += "Dt: " + _owm_forecast3h.list[f].dt + "; Dt_txt: " + _owm_forecast3h.list[f].dt_txt + newLine;

                    if (_owm_forecast3h.list[f].weather != null)
                    {
                        for (int w = 0; w < _owm_forecast3h.list[f].weather.Count; w++)
                        {
                            OWM_Forecast3H_Weather wea = _owm_forecast3h.list[f].weather[w];
                            reTval += "Weather: Id:" + wea.id + "; Main: " + wea.main + "; Description: " + wea.description + "; Icon: " + wea.icon + newLine;
                        }
                    }

                    reTval += "Clouds: All: " + _owm_forecast3h.list[f].clouds.all + newLine;
                    reTval += "Wind: Speed: " + _owm_forecast3h.list[f].wind.speed + "; Deg:" + _owm_forecast3h.list[f].wind.deg + newLine;
                    reTval += "Sys: Pod: " + _owm_forecast3h.list[f].sys.pod + newLine;
                }
            }

            return reTval;
        }
    }
}