using System;
using System.Collections.Generic;
using System.Text;

namespace ADS.DataStructures.SpeedTests.Models
{
    internal class GeoLocation
    {
        internal double Latitude { get; set; }
        internal double Longitude { get; set; }

        internal GeoLocation(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
