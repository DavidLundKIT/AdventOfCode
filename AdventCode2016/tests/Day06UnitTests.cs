using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.Encodings;
using System.Security.Cryptography;
using Xunit;

namespace tests
{
    public class Day06UnitTests
    {

        public void Day06_TestRepitionCode()
        {
            string [] codeLines = { 
                                    "eedadn",
                                    "drvtee",
                                    "eandsr",
                                    "raavrd",
                                    "atevrs",
                                    "tsrnev",
                                    "sdttsa",
                                    "rasrtv",
                                    "nssdts",
                                    "ntnada",
                                    "svetve",
                                    "tesnvt",
                                    "vntsnd",
                                    "vrdear",
                                    "dvrsen",
                                    "enarar" 
                                    };
            
            string expected = "easter";
            StringBuilder sbText = new StringBuilder();
            for (int idx = 0; idx < 6; idx++)
            {
                Dictionary<char, int> chCountDict = new Dictionary<char, int>();
                foreach (var line in codeLines)
                {
                    char[]chs = line.ToCharArray();
                    if (chCountDict.ContainsKey(chs[idx]))
                    {
                        // have the key 
                        chCountDict[chs[idx]]++;
                    }
                    else
                    {
                        chCountDict.Add(chs[idx], 1);
                    }
                }
                foreach (var item in chCountDict)
                {
                    // TDOD
                }
            }
        }

    }


}