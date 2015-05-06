using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Model
{
    [Table("OWM_Current_Clouds")]
    [DataContract]
    public class OWM_Current_Clouds
    {
        public string Separator = ";";
        public OWM_Current_Clouds()
        {

        }

        public string ToCSV()
        {
            string retVal = "";
            retVal = all+Separator;
            return retVal;
        }

        public int Id { get; set; }
        [DataMember]
        public int all { get; set; }
    }
}
