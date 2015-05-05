using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Model
{
    [DataContract]
    public class OWM_Historical_WeatherElement
    {
        [DataMember]
        public ulong id;

        [DataMember]
        public string main;

        [DataMember]
        public string description;

        [DataMember]
        public string icon;
    }
}
