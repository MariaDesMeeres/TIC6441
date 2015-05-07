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
    [Table("OWM_Historical_ListElement")]
    [DataContract]
    public class OWM_Historical_ListElement
    {
        public OWM_Historical_ListElement()
        {
            weather = new List<OWM_Historical_WeatherElement>();
        }

        [Key]
        public int Id { get; set; }

        [DataMember]
        public virtual OWM_Historical_Main main { get; set; }

        [DataMember]
        public virtual OWM_Historical_Wind wind { get; set; }

        [DataMember]
        public virtual OWM_Historical_Clouds clouds { get; set; }

        [DataMember]
        public virtual List<OWM_Historical_WeatherElement> weather { get; set; }

        [DataMember]
        public ulong dt { get; set; }
    }
}
