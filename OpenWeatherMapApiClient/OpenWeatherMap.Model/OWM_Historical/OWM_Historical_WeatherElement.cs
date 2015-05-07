using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Model
{
    [Table("OWM_Historical_WeatherElement")]
    [DataContract]
    public class OWM_Historical_WeatherElement
    {
        public OWM_Historical_WeatherElement()
        {

        }

        [Key]
        public int Id { get; set; }

        [DataMember]
        public ulong id { get; set; }

        [DataMember]
        public string main { get; set; }

        [DataMember]
        public string description { get; set; }

        [DataMember]
        public string icon { get; set; }
    }
}
