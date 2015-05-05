using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Model
{
    [DataContract]
    public class OWM_Current_Sys
    {
        [DataMember]
        public string message;

        [DataMember]
        public string country;

        [DataMember]
        public ulong sunrise;

        [DataMember]
        public ulong sunset;
    }
}
