﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Model
{
    [Table("OWM_Current", Schema = "public")]
    [DataContract]
    public class OWM_Current
    {
        public string Separator = ";";
        public OWM_Current()
        {
            weather = new List<OWM_Current_Weather>();
        }

        public string ToCSV() 
        {
            string retVal = "";
            
            if(coord!=null)
            {
                retVal = coord.ToCSV();
            }
            retVal += Separator;
            if(sys!=null)
            {
                retVal+= sys.ToCSV();
            }
            retVal += Separator;

            if ((weather == null) || (weather.Count == 0))
            {
                retVal += Separator;
            }
            else
            {
                foreach (var elem in weather)
                {
                    retVal += elem.ToCSV() + Separator;
                }
            }

            retVal += @base + Separator;

            if(main!=null)
            {
                retVal += main.ToCSV();
            }

            retVal += Separator;
            if(wind!=null)
            {
                retVal += wind.ToCSV();
            }

            retVal += Separator;

            if(clouds!=null)
            {
                retVal += clouds.ToCSV();
            }

            retVal += Separator;

            retVal += dt + Separator + id + Separator + name + Separator+cod+Separator;
 
            return retVal;
        }

        public int Id { get; set; }

        [DataMember]
        public virtual OWM_Current_Coord coord{get;set;}

        [DataMember]
        public virtual OWM_Current_Sys sys { get; set; }

        [DataMember]
        public virtual List<OWM_Current_Weather> weather { get; set; }

        [DataMember]
        public string @base { get; set; }

        [DataMember]
        public virtual OWM_Current_Main main { get; set; }

        [DataMember]
        public virtual OWM_Current_Wind wind { get; set; }

        
        public int CurrentClouds_FK { get; set; }

        [DataMember]
        [ForeignKey("CurrentClouds_FK")]
        public virtual OWM_Current_Clouds clouds { get; set; }

        [DataMember]
        public ulong dt { get; set; }

        [DataMember]
        public ulong id { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string cod { get; set; }
    }
}
