using ADS.DataStructures.SpeedTests.DataProviders;
using ADS.DataStructures.SpeedTests.Models;
using System.Diagnostics;

namespace ADS.DataStructures.SpeedTests.MinHeap
{
    public class MinHeapSpeedTests
    {
        GeoLocation[] geoLocations;

        public MinHeapSpeedTests()
        {
            this.geoLocations = DataProvider.GetGeolocations();
        }

        public bool Insert()
        {
            //Prepare
            MinHeap<GeoLocation> minHeap = new MinHeap<GeoLocation>();

            //Execute

            //N = 10
            for (int i = 0; i < 10; i++)
                minHeap.Insert(geoLocations[i]);
            Stopwatch nTenTimer = Stopwatch.StartNew();
            minHeap.Insert(geoLocations[10]);
            nTenTimer.Stop();
            long nTenTime = nTenTimer.ElapsedMilliseconds;

            //N = 1000
            for (int i = 11; i < 1000; i++)
                minHeap.Insert(geoLocations[i]);
            Stopwatch nKTimer = Stopwatch.StartNew();
            minHeap.Insert(geoLocations[1000]);
            nKTimer.Stop();
            long nKTime = nKTimer.ElapsedMilliseconds;

            for (int i = 1001; i < 999999; i++)
                minHeap.Insert(geoLocations[i]);
            Stopwatch nMTimer = Stopwatch.StartNew();
            minHeap.Insert(geoLocations[999999]);
            nMTimer.Stop();
            long nMTime = nMTimer.ElapsedMilliseconds;


            //Analyze
            bool nTenPassed = nTenTime < 2;
            long nTenNonZeroTime = nTenTime == 0 ? 1 : nTenTime;
            bool nKPassed = nKTime < nTenNonZeroTime * 10; //Because log(1000) ~ 10
            long nKNonZeroTime = nKTime == 0 ? 1 : nKTime;
            bool nMPassed = nMTime < nKNonZeroTime * 2; //Because log(M) ~ 2 * log(K)
            bool passed = nTenPassed && nKPassed && nMPassed;
            return passed;
        }

        public bool PopMin()
        {
            //Prepare
            MinHeap<GeoLocation> minHeap = new MinHeap<GeoLocation>();

            //Execute

            //N = 10
            for (int i = 0; i < 10; i++)
                minHeap.Insert(geoLocations[i]);
            Stopwatch nTenTimer = Stopwatch.StartNew();
            GeoLocation poppedTen = minHeap.PopMin();
            nTenTimer.Stop();
            long nTenTime = nTenTimer.ElapsedMilliseconds;

            //N = 1000
            for (int i = 11; i < 1000; i++)
                minHeap.Insert(geoLocations[i]);
            Stopwatch nKTimer = Stopwatch.StartNew();
            GeoLocation poppedK = minHeap.PopMin();
            nKTimer.Stop();
            long nKTime = nKTimer.ElapsedMilliseconds;

            for (int i = 1001; i < 999999; i++)
                minHeap.Insert(geoLocations[i]);
            Stopwatch nMTimer = Stopwatch.StartNew();
            GeoLocation poppedM = minHeap.PopMin();
            nMTimer.Stop();
            long nMTime = nMTimer.ElapsedMilliseconds;


            //Analyze
            bool nTenPassed = nTenTime < 2;
            long nTenNonZeroTime = nTenTime == 0 ? 1 : nTenTime;
            bool nKPassed = nKTime < nTenNonZeroTime * 10; //Because log(1000) ~ 10
            long nKNonZeroTime = nKTime == 0 ? 1 : nKTime;
            bool nMPassed = nMTime < nKNonZeroTime * 2; //Because log(M) ~ 2 * log(K)
            bool passed = nTenPassed && nKPassed && nMPassed;
            return passed;
        }
    }
}
