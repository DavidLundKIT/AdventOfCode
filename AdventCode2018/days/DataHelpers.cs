using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
    }
}
