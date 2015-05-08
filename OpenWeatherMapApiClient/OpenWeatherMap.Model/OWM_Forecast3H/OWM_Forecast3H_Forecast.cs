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
    [Table("OWM_Forecast3H_Forecast", Schema = "public")]
    [DataContract]
    public class OWM_Forecast3H_Forecast
    {
        private string _separator = ";";
        public OWM_Forecast3H_Forecast()
        {
            weather = new List<OWM_Forecast3H_Weather>();
        }

        public string ToCSV()
        {
            string retVal = "";

            retVal=dt+_separator+dt_txt+_separator;

            if(main!=null)
            {
                retVal += main.ToCSV();
            }

            retVal += _separator;

            if((weather==null)||(weather.Count==0))
            {
                retVal += _separator;
            }
            else
            {
                foreach(var weat in weather)
                {
                    retVal+=weat.ToCSV();
                }
            }
            if(clouds!=null)
            {
                retVal += clouds.ToCSV();
            }

            retVal += _separator;

            if(wind!=null)
            {
                retVal+=wind.ToCSV();
            }

            retVal += _separator;

            if(sys!=null)
            {
                retVal += sys.ToCSV();
            }

            retVal+=_separator;
            return retVal;
        }

        [Key]
        public int Id { get; set; }

        [DataMember]
        public ulong dt;

        [DataMember]
        public string dt_txt;

        [DataMember]
        public virtual OWM_Forecast3H_Main main { get; set; }

        [DataMember]
        public virtual List<OWM_Forecast3H_Weather> weather { get; set; }

        [DataMember]
        public virtual OWM_Forecast3H_Clouds clouds { get; set; }

        [DataMember]
        public virtual OWM_Forecast3H_Wind wind { get; set; }

        [DataMember]
        public virtual OWM_Forecast3H_Sys sys { get; set; }
    }
}
