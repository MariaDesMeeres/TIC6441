using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Model
{
    [DataContract]
    public class OWM_Current
    {
        [DataMember]
        public OWM_Current_Coord coord;

        [DataMember]
        public OWM_Current_Sys sys;

        [DataMember]
        public List<OWM_Current_Weather> weather;

        [DataMember]
        public string @base;

        [DataMember]
        public OWM_Current_Main main;

        [DataMember]
        public OWM_Current_Wind wind;

        [DataMember]
        public OWM_Current_Clouds clouds;

        [DataMember]
        public ulong dt;

        [DataMember]
        public ulong id;

        [DataMember]
        public string name;

        [DataMember]
        public string cod;
    }
}
