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
    [Table("OWM_Historical_Main")]
    [DataContract]
    public class OWM_Historical_Main
    {
        public OWM_Historical_Main()
        {

        }

        [Key]
        public int Id { get; set; }

        [DataMember]
        public double temp { get; set; }

        [DataMember]
        public double humidity { get; set; }

        [DataMember]
        public double pressure { get; set; }

        [DataMember]
        public double temp_min { get; set; }

        [DataMember]
        public double temp_max { get; set; }
    }
}
