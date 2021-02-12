using System;
using System.IO;

namespace days
{
    public class DataHelpers
    {
        public static string[] ReadLinesFromFile(string filename)
        {
            string baseDir = AppContext.BaseDirectory;
            string filePath = $"{baseDir}\\Data\\{filename}";
            string[] orbits = File.ReadAllLines(filePath);
            return orbits;
        }

        public static string ReadTextFromFile(string filename)
        {
            string baseDir = AppContext.BaseDirectory;
            string filePath = $"{baseDir}\\Data\\{filename}";
            string orbits = File.ReadAllText(filePath);
            return orbits;
        }
    }
}
