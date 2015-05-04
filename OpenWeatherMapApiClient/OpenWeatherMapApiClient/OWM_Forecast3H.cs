using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OpenWeatherMapApiClient
{
    [DataContract]
    internal class OWM_Forecast3H
    {
        [DataMember]
        internal string cod;

        [DataMember]
        internal string message;

        //internal string city;
        [DataMember]
        internal OWM_Forecast3H_City city;

        [DataMember]
        internal int cnt;

        [DataMember]
        internal List<OWM_Forecast3H_Forecast> list;
    }

    [DataContract]
    internal class OWM_Forecast3H_City
    {
        [DataMember]
        internal ulong id;

        [DataMember]
        internal string name;

        [DataMember]
        internal OWM_Forecast3H_Coordinates coord;

        [DataMember]
        internal string country;

        [DataMember]
        internal ulong population;
    }

    [DataContract]
    internal class OWM_Forecast3H_Coordinates
    {
        [DataMember]
        internal double lon;

        [DataMember]
        internal double lat;

    }

    [DataContract]
    internal class OWM_Forecast3H_Forecast
    {
        [DataMember]
        internal ulong dt;

        [DataMember]
        internal string dt_txt;

        [DataMember]
        internal OWM_Forecast3H_Main main;

        [DataMember]
        internal List<OWM_Forecast3H_Weather> weather;

        [DataMember]
        internal OWM_Forecast3H_Clouds clouds;

        [DataMember]
        internal OWM_Forecast3H_Wind wind;

        [DataMember]
        internal OWM_Forecast3H_Sys sys;
    }

    [DataContract]
    internal class OWM_Forecast3H_Main
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

        [DataMember]
        internal double temp_kf;
    }

    [DataContract]
    internal class OWM_Forecast3H_Weather
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
    internal class OWM_Forecast3H_Clouds
    {
        [DataMember]
        internal int all;
    }

    [DataContract]
    internal class OWM_Forecast3H_Wind
    {
        [DataMember]
        internal double speed;

        [DataMember]
        internal double deg;
    }

    [DataContract]
    internal class OWM_Forecast3H_Sys
    {
        [DataMember]
        internal string pod;
    }

}
