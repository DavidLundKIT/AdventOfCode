using System;
using System.IO;

namespace AdventCodeLib
{
    public class DataTools
    {

        public static string[] ReadAllLines(string filename)
        {
            var fullPath = String.Format("{0}\\Data\\{1}", AppContext.BaseDirectory, filename);
            var lines = File.ReadAllLines(fullPath);
            return lines;
        }
    }
}
