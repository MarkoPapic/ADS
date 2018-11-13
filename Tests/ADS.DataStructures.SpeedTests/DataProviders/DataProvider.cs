using ADS.DataStructures.SpeedTests.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ADS.DataStructures.SpeedTests.DataProviders
{
    internal static class DataProvider
    {
        private const string CITIES_PATH = "D:\\Marko\\Workspace\\ads_test_data\\cities_huge.csv"; //Enter the path to the cities CSV file

        private static GeoLocation[] geoLocations;

        internal static GeoLocation[] GetGeolocations()
        {
            if (geoLocations == null)
            {
                List<GeoLocation> tempData = new List<GeoLocation>();
                using (FileStream fs = File.OpenRead(CITIES_PATH))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        sr.ReadLine(); //Skip the headers

                        string line;
                        int counter = 0;
                        while (counter < 1000000)
                        {
                            line = sr.ReadLine();
                            string[] lineTokens = line.Split(',');
                            string city = lineTokens[0];
                            double latitude = double.Parse(lineTokens[1]);
                            double longitude = double.Parse(lineTokens[2]);
                            GeoLocation geoLocation = new GeoLocation(latitude, longitude);
                            tempData.Add(geoLocation);
                            counter++;
                        }
                    }
                }
                geoLocations = tempData.ToArray();
            }

            return geoLocations;
        }
    }
}
