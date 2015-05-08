using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Model
{
    [DataContract]
    public class Group_OWM_Current
    {
        [DataMember]
        public int cnt { get; set; }

        [DataMember]
        public List<OWM_Current> list { get; set; }

        public Group_OWM_Current()
        {
            list = new List<OWM_Current>();
        }
    }
}
