using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class DailyDataUtilities
    {
        public static string[] ReadLinesFromFile(string filename)
        {
            string baseDir = AppContext.BaseDirectory;
            string filePath = $"{baseDir}\\Data\\{filename}";
            string[] orbits = File.ReadAllLines(filePath);
            return orbits;
        }

        public static List<int> ReadIntsFromFile(string filename)
        {
            List<string> lines = ReadLinesFromFile(filename).ToList();
            return lines.Select(s => int.Parse(s)).ToList();
        }

        public static List<long> ReadLongsFromFile(string filename)
        {
            List<string> lines = ReadLinesFromFile(filename).ToList();
            return lines.Select(s => long.Parse(s)).ToList();
        }
    }
}
