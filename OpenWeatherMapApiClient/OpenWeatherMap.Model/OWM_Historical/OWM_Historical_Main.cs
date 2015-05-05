using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Model
{
    [DataContract]
    public class OWM_Historical_Main
    {
        [DataMember]
        public double temp;

        [DataMember]
        public double humidity;

        [DataMember]
        public double pressure;

        [DataMember]
        public double temp_min;

        [DataMember]
        public double temp_max;
    }
}
