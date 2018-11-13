using ADS.DataStructures.SpeedTests.DynamicArray;
using ADS.DataStructures.SpeedTests.MinHeap;
using System;

namespace ADS.ConsoleClient
{
    internal class SpeedTestsRunner
    {
        private const string PASSED_INDICATOR = "PASSED";
        private const string FAILED_INDICATOR = "FAILED";
        private const string OUTPUT_END_INDICATOR = "=============================================================";

        internal void RunAll()
        {
            Console.WriteLine($"Running speed tests...{Environment.NewLine}");
            DynamicArray();
            MinHeap();
            Console.WriteLine($"Running speed tests finished!{Environment.NewLine}");
        }

        internal void DynamicArray()
        {
            PrintClassName("DynamicArray");
            Console.WriteLine();

            DynamicArraySpeedTests dynamicArraySpeedTests = new DynamicArraySpeedTests();

            bool addPassed = dynamicArraySpeedTests.Add();
            PrintTestResult("Add", addPassed);

            bool accessPassed = dynamicArraySpeedTests.Access();
            PrintTestResult("Access", accessPassed);

            Console.WriteLine(OUTPUT_END_INDICATOR);
            Console.WriteLine();
        }

        internal void MinHeap()
        {
            PrintClassName("MinHeap");
            Console.WriteLine();

            MinHeapSpeedTests minHeapSpeedTests = new MinHeapSpeedTests();

            bool insertPassed = minHeapSpeedTests.Insert();
            PrintTestResult("Insert", insertPassed);

            bool popMinPassed = minHeapSpeedTests.PopMin();
            PrintTestResult("PopMin", popMinPassed);

            Console.WriteLine(OUTPUT_END_INDICATOR);
            Console.WriteLine();
        }

        private void PrintClassName(string name)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(name);
            Console.ResetColor();
        }

        private void PrintTestResult(string method, bool passed)
        {
            Console.Write("Method: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(method);
            Console.ResetColor();
            Console.Write("\t\tResult: ");
            Console.ForegroundColor = passed ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(passed ? PASSED_INDICATOR : FAILED_INDICATOR);
            Console.ResetColor();
        }
    }
}
