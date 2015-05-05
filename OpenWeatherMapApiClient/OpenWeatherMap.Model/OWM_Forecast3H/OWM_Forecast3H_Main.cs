using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Model
{
    [DataContract]
    public class OWM_Forecast3H_Main
    {
        [DataMember]
        public double temp;

        [DataMember]
        public double temp_min;

        [DataMember]
        public double temp_max;

        [DataMember]
        public double pressure;

        [DataMember]
        public double sea_level;

        [DataMember]
        public double grnd_level;

        [DataMember]
        public double humidity;

        [DataMember]
        public double temp_kf;
    }
}
