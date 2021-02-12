using System;
using day02;

namespace testrunner
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sns = new string[]{
                "abcde",
                "fghij",
                "klmno",
                "pqrst",
                "fguij",
                "axcye",
                "wvxyz"
            };
            var sut1 = new Day02SerialNumber();
            var actual = sut1.FindClosestMatch(sns);
            Console.WriteLine($"actual: {actual}");

            string datapath = @"C:\Work\fun\AdventCode2018\data\day02a.txt";
            var sut = new Day02SerialNumber();

            sns = sut.ParseData(datapath);
            actual = sut.FindClosestMatch(sns);
            Console.WriteLine($"actual: {actual}");
        }
    }
}
