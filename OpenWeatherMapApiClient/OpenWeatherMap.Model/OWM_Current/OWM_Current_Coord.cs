﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Model
{
    [Table("OWM_Current_Coord")]
    [DataContract]
    public class OWM_Current_Coord
    {
        public string Separator = ";";
        public OWM_Current_Coord()
        {

        }

        public string ToCSV()
        {
            string retVal = "";

            retVal = lon + Separator + lat+Separator;

            return retVal;
        }
        public int Id { get; set; } 
        [DataMember]
        public double lon { get; set; }

        [DataMember]
        public double lat { get; set; }
    }
}
