using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Model
{
    [DataContract]
    public class OWM_Forecast3H_City
    {
        [DataMember]
        public ulong id;

        [DataMember]
        public string name;

        [DataMember]
        public OWM_Forecast3H_Coordinates coord;

        [DataMember]
        public string country;

        [DataMember]
        public ulong population;
    }
}
