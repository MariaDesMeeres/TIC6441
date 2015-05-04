using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OpenWeatherMapApiClient
{
    [DataContract]
    internal class OWM_Historical
    {
        [DataMember]
        internal string message;

        [DataMember]
        internal int cod;

        [DataMember]
        internal ulong city_id;

        [DataMember]
        internal double calctime;

        [DataMember]
        internal int cnt;

        [DataMember]
        internal List<OWM_Historical_ListElement> list;
    }

    [DataContract]
    internal class OWM_Historical_ListElement
    {
        [DataMember]
        internal OWM_Historical_Main main;

        [DataMember]
        internal OWM_Historical_Wind wind;

        [DataMember]
        internal OWM_Historical_Clouds clouds;

        [DataMember]
        internal List<OWM_Historical_WeatherElement> weather;

        [DataMember]
        internal ulong dt;
    }

    [DataContract]
    internal class OWM_Historical_Main
    {
        [DataMember]
        internal double temp;

        [DataMember]
        internal double humidity;

        [DataMember]
        internal double pressure;

        [DataMember]
        internal double temp_min;

        [DataMember]
        internal double temp_max;
    }

    [DataContract]
    internal class OWM_Historical_Wind
    {
        [DataMember]
        internal double speed;

        [DataMember]
        internal double gust;

        [DataMember]
        internal double deg;
    }

    [DataContract]
    internal class OWM_Historical_Clouds
    {
        [DataMember]
        internal int all;
    }

    [DataContract]
    internal class OWM_Historical_WeatherElement
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

    //[DataContract]
    //internal class OWM_Historical_Snow
    //{
    //    [DataMember]
    //    internal double 3h;
    //}
}
