using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Model
{
    [DataContract]
    public class OWM_Historical_ListElement
    {
        [DataMember]
        public OWM_Historical_Main main;

        [DataMember]
        public OWM_Historical_Wind wind;

        [DataMember]
        public OWM_Historical_Clouds clouds;

        [DataMember]
        public List<OWM_Historical_WeatherElement> weather;

        [DataMember]
        public ulong dt;
    }
}
