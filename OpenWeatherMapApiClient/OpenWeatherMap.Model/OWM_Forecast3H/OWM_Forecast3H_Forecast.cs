using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Model
{
    [DataContract]
    public class OWM_Forecast3H_Forecast
    {
        [DataMember]
        public ulong dt;

        [DataMember]
        public string dt_txt;

        [DataMember]
        public OWM_Forecast3H_Main main;

        [DataMember]
        public List<OWM_Forecast3H_Weather> weather;

        [DataMember]
        public OWM_Forecast3H_Clouds clouds;

        [DataMember]
        public OWM_Forecast3H_Wind wind;

        [DataMember]
        public OWM_Forecast3H_Sys sys;
    }
}
