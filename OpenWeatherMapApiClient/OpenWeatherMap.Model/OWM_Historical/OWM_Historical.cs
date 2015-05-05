using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Model
{
    [DataContract]
    public class OWM_Historical
    {
        [DataMember]
        public string message;

        [DataMember]
        public int cod;

        [DataMember]
        public ulong city_id;

        [DataMember]
        public double calctime;

        [DataMember]
        public int cnt;

        [DataMember]
        public List<OWM_Historical_ListElement> list;
    }
}
