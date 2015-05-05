using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Model
{
    [DataContract]
    public class OWM_Forecast3H
    {
        [DataMember]
        public string cod;

        [DataMember]
        public string message;

        //internal string city;
        [DataMember]
        public OWM_Forecast3H_City city;

        [DataMember]
        public int cnt;

        [DataMember]
        public List<OWM_Forecast3H_Forecast> list;
    }
}
