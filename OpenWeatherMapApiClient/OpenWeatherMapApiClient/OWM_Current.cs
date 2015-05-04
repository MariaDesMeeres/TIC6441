using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OpenWeatherMapApiClient
{
    [DataContract]
    internal class OWM_Current
    {
        [DataMember]
        internal OWM_Current_Coord coord;

        [DataMember]
        internal OWM_Current_Sys sys;

        [DataMember]
        internal List<OWM_Current_Weather> weather;

        [DataMember]
        internal string @base;

        [DataMember]
        internal OWM_Current_Main main;

        [DataMember]
        internal OWM_Current_Wind wind;

        [DataMember]
        internal OWM_Current_Clouds clouds;

        [DataMember]
        internal ulong dt;

        [DataMember]
        internal ulong id;

        [DataMember]
        internal string name;

        [DataMember]
        internal string cod;
    }

    [DataContract]
    internal class OWM_Current_Coord
    {
        [DataMember]
        internal double lon;

        [DataMember]
        internal double lat;
    }

    [DataContract]
    internal class OWM_Current_Sys
    {
        [DataMember]
        internal string message;

        [DataMember]
        internal string country;

        [DataMember]
        internal ulong sunrise;

        [DataMember]
        internal ulong sunset;
    }

    [DataContract]
    internal class OWM_Current_Weather
    {
        [DataMember]
        internal ulong id;

        [DataMember]
        internal string main;

        [DataMember]
        internal string description;

        [DataMember]
        internal string icon;
    }

    [DataContract]
    internal class OWM_Current_Main
    {
        [DataMember]
        internal double temp;

        [DataMember]
        internal double temp_min;

        [DataMember]
        internal double temp_max;

        [DataMember]
        internal double pressure;

        [DataMember]
        internal double sea_level;

        [DataMember]
        internal double grnd_level;

        [DataMember]
        internal double humidity;
    }

    [DataContract]
    internal class OWM_Current_Wind
    {
        [DataMember]
        internal double speed;

        [DataMember]
        internal double deg;
    }

    [DataContract]
    internal class OWM_Current_Clouds
    {
        [DataMember]
        internal int all;
    }




}
