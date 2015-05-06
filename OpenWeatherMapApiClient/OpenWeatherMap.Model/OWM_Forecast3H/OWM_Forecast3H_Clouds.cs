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
    [Table("OWM_Forecast3H_Clouds")]
    [DataContract]
    public class OWM_Forecast3H_Clouds
    {
        public OWM_Forecast3H_Clouds()
        { }

        [Key]
        public int Id { get; set; }

        [DataMember]
        public int all { get; set; }
    }
}