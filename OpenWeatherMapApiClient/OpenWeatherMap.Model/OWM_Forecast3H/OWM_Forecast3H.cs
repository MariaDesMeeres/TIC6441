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
     [Table("OWM_Current_Wind")]
    [DataContract]
    public class OWM_Forecast3H
    {
         public OWM_Forecast3H()
         {
             list = new List<OWM_Forecast3H_Forecast>();
         }

         [Key]
         public int Id { get; set; }

        [DataMember]
         public string cod { get; set; }

        [DataMember]
        public string message { get; set; }

        //internal string city;
        [DataMember]
        public virtual OWM_Forecast3H_City city { get; set; }

        [DataMember]
        public int cnt { get; set; }

        [DataMember]
        public virtual List<OWM_Forecast3H_Forecast> list { get; set; }
    }
}
