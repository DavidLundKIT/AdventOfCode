using System;
using System.IO;

namespace tests
{
    public class DataUtils 
    {
        public const string BaseDir = @"C:\Work\AdventOfCode\AdventCode2016\tests\data";
        
        public static string[] ReadAllLines(string filename)
        {

            var path = $"{AppContext.BaseDirectory}\\data\\{filename}";
            var lines = File.ReadAllLines(path);
            return lines;
        }

        public static string ReadAllText(string filename)
        {
            var path = $"{AppContext.BaseDirectory}\\data\\{filename}";
            var lines = File.ReadAllText(path);
            return lines;
        }
    }
}