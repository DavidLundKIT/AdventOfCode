using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2019XUnitTests
{
    public class DayDataUtilities
    {
        /// <summary>
        /// Assumes the path of Basedirectory\Data\
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string[] ReadLinesFromFile(string filename)
        {
            string baseDir = AppContext.BaseDirectory;
            string filePath = $"{baseDir}\\Data\\{filename}";
            string[] orbits = File.ReadAllLines(filePath);
            return orbits;
        }

        /// <summary>
        /// This is to read in program files for the Magic Smoke IntCode computer
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static List<long> ReadMagicSmokePgmFromFile(string filename)
        {
            string cmdsbulk = ReadBigStringFromFile(filename);
            List<long> pgm = StringBlobToIntCodePgm(cmdsbulk);
            return pgm;
        }

        public static List<long> StringBlobToIntCodePgm(string cmdsbulk)
        {
            List<long> pgm = (new List<string>(cmdsbulk.Split(','))).Select(s => long.Parse(s)).ToList();
            return pgm;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string ReadBigStringFromFile(string filename)
        {
            string baseDir = AppContext.BaseDirectory;
            string filePath = $"{baseDir}\\Data\\{filename}";
            string cmdsbulk = File.ReadAllText(filePath);
            return cmdsbulk;
        }

        public static List<int> ReadSIFdata(string filename)
        {
            string sifBlob = ReadBigStringFromFile(filename);
            List<int> sifbytes = sifBlob.ToCharArray().Select(c => int.Parse(c.ToString())).ToList();
            return sifbytes;
        }
    }
}
