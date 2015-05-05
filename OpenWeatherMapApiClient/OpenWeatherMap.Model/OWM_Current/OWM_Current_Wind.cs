using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Model
{
    [DataContract]
    public class OWM_Current_Wind
    {
        [DataMember]
        public double speed;

        [DataMember]
        public double deg;
    }
}
