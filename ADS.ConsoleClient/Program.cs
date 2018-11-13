using System;
using ADS.DataStructures;

namespace ADS.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            SpeedTestsRunner speedTestsRunner = new SpeedTestsRunner();
            speedTestsRunner.RunAll();

            Console.ReadKey();
        }
    }
}
