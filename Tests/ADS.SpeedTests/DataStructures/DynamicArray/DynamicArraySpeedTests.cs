using ADS.DataStructures.SpeedTests.DataProviders;
using ADS.DataStructures.SpeedTests.Models;
using System.Diagnostics;

namespace ADS.DataStructures.SpeedTests.DynamicArray
{
    public class DynamicArraySpeedTests
    {
        GeoLocation[] geoLocations;

        public DynamicArraySpeedTests()
        {
            this.geoLocations = DataProvider.GetGeolocations();
        }

        public bool Add()
        {
            //Prepare
            DynamicArray<GeoLocation> dynamicArray = new DynamicArray<GeoLocation>();

            //Execute

            //N = 10
            for (int i = 0; i < 10; i++)
                dynamicArray.Add(geoLocations[i]);
            Stopwatch nTenTimer = Stopwatch.StartNew();
            dynamicArray.Add(geoLocations[10]);
            nTenTimer.Stop();
            long nTenTime = nTenTimer.ElapsedMilliseconds;

            //N = 1000
            for (int i = 11; i < 1000; i++)
                dynamicArray.Add(geoLocations[i]);
            Stopwatch nKTimer = Stopwatch.StartNew();
            dynamicArray.Add(geoLocations[1000]);
            nKTimer.Stop();
            long nKTime = nKTimer.ElapsedMilliseconds;

            for (int i = 1001; i < 999999; i++)
                dynamicArray.Add(geoLocations[i]);
            Stopwatch nMTimer = Stopwatch.StartNew();
            dynamicArray.Add(geoLocations[999999]);
            nMTimer.Stop();
            long nMTime = nMTimer.ElapsedMilliseconds;


            //Analyze
            bool passed = nTenTime < 2 && nKTime < 2 && nMTime < 2;
            return passed;
        }

        public bool Access()
        {
            //Prepare
            DynamicArray<GeoLocation> dynamicArray = new DynamicArray<GeoLocation>();

            //Execute

            //N = 10
            for (int i = 0; i < 10; i++)
                dynamicArray.Add(geoLocations[i]);
            Stopwatch nTenTimer = Stopwatch.StartNew();
            GeoLocation geoLocationTen = dynamicArray[5];
            nTenTimer.Stop();
            long nTenTime = nTenTimer.ElapsedMilliseconds;

            //N = 1000
            for (int i = 10; i < 1000; i++)
                dynamicArray.Add(geoLocations[i]);
            Stopwatch nKTimer = Stopwatch.StartNew();
            GeoLocation geoLocationK = dynamicArray[800];
            nKTimer.Stop();
            long nKTime = nKTimer.ElapsedMilliseconds;

            for (int i = 1001; i < 1000000; i++)
                dynamicArray.Add(geoLocations[i]);
            Stopwatch nMTimer = Stopwatch.StartNew();
            GeoLocation geoLocationM = dynamicArray[900000];
            nMTimer.Stop();
            long nMTime = nMTimer.ElapsedMilliseconds;


            //Analyze
            bool passed = nTenTime < 2 && nKTime < 2 && nMTime < 2;
            return passed;
        }
    }
}
