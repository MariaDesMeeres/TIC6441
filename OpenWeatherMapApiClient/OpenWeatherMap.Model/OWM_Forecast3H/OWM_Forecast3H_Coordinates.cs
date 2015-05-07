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
    [Table("OWM_Forecast3H_Coordinates")]
    [DataContract]
    public class OWM_Forecast3H_Coordinates
    {
        public OWM_Forecast3H_Coordinates()
        { }

        [Key]
        public int Id { get; set; }

        [DataMember]
        public double lon { get; set; }

        [DataMember]
        public double lat { get; set; }

    }
}
