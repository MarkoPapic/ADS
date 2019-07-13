using System;
using System.Collections.Generic;
using System.Text;

namespace ADS.DataStructures.SpeedTests.Models
{
    internal class GeoLocation : IComparable
    {
        internal double Latitude { get; set; }
        internal double Longitude { get; set; }

        internal GeoLocation(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public int CompareTo(object obj)
        {
            GeoLocation other = (GeoLocation)obj;
            double aSum = this.Latitude + this.Longitude;
            double bSum = other.Latitude + other.Longitude;

            if (aSum < bSum)
                return -1;
            else if (aSum == bSum)
                return 0;
            return 1;
        }
    }
}
