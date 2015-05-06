﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Model
{
    [Table("OWM_Forecast3H_Sys")]
    [DataContract]
    public class OWM_Forecast3H_Weather
    {
        private string _separator = ";";

        public OWM_Forecast3H_Weather()
        { }

        public string ToCSV()
        {
            string retVal = "";

            retVal = id + _separator + main + _separator + description + _separator + icon + _separator;

            return retVal;
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