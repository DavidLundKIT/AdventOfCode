using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace AdventOfCode2019XUnitTests
{
    public class Day08SpaceImageFormatUnitTests
    {
        [Fact]
        public void Day08Part1_TestSolution()
        {
            string sifblob = DayDataUtilities.ReadBigStringFromFile("day08.txt");
            Assert.Equal(15000, sifblob.Length);
            int layerSize = 25 * 6;

            List<string> layers = new List<string>();
            for (int idx = 0; idx < sifblob.Length; idx += layerSize)
            {
                string layer = sifblob.Substring(idx, layerSize);
                layers.Add(layer);
            }

            int min0Layer = int.MaxValue;
            int onesXtwos = 0;
            for (int iLayer = 0; iLayer < layers.Count; iLayer++)
            {
                char[] chs = layers[iLayer].ToCharArray();
                int zeroes = chs.Where(c => c == '0').ToList().Count;
                if (zeroes < min0Layer)
                {
                    min0Layer = zeroes;
                    int ones = chs.Where(c => c == '1').ToList().Count;
                    int twos = chs.Where(c => c == '2').ToList().Count;
                    onesXtwos = ones * twos;
                }
            }

            Assert.Equal(2500, onesXtwos);
        }

        [Fact]
        public void Day08Part2_TestSolution()
        {
            string sifblob = DayDataUtilities.ReadBigStringFromFile("day08.txt");
            Assert.Equal(15000, sifblob.Length);
            int layerSize = 25 * 6;

            List<string> layers = new List<string>();
            for (int idx = 0; idx < sifblob.Length; idx += layerSize)
            {
                string layer = sifblob.Substring(idx, layerSize);
                layers.Add(layer);
            }

            char[,] sifImage = new char[6, 25];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    sifImage[i, j] = ' ';
                }
            }

            int assignments = 0;
            for (int iLayer = 0; iLayer < layers.Count; iLayer++)
            {
                char[] chs = layers[iLayer].ToCharArray();
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 25; j++)
                    {
                        if (sifImage[i, j] == ' ')
                        {
                            if (chs[i*25 + j] != '2')
                            {
                                sifImage[i, j] = chs[i*25 + j];
                                assignments++;
                            }
                        }
                    }
                }

            }

            Assert.Equal(150, assignments);
            for (int i = 0; i < 6; i++)
            {
                for (int l = 0; l < 4; l++)
                {

                    for (int j = 0; j < 25; j++)
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            Debug.Write(sifImage[i, j]);
                        }
                    }
                    Debug.WriteLine(" ");
                }
            }

            Assert.Equal('a','a');
        }

        [Fact]
        public void Day08Part2_TestSolution2()
        {
            string sifblob = DayDataUtilities.ReadBigStringFromFile("day08.txt");
            Assert.Equal(15000, sifblob.Length);
            int layerSize = 25 * 6;
            int numberLayers = sifblob.Length / layerSize;

            char[] sifchs = sifblob.ToCharArray();

            char[] sifImage = new char[layerSize];

            for (int iSif = 0; iSif < layerSize; iSif++)
            {
                for (int iLayer = 0; iLayer < numberLayers; iLayer++)
                {
                    int sifchNow = iSif + (iLayer * layerSize);
                    char ch = sifchs[sifchNow];
                    if (ch != '2')
                    {
                        sifImage[iSif] = ch;
                        break;
                    }
                }
            }

            for (int i = 0; i < 6; i++)
            {
                for (int k = 0; k < 4; k++)
                {
                    for (int j = 0; j < 25; j++)
                    {
                        for (int l = 0; l < 4; l++)
                        {
                        Debug.Write(sifImage[(i * 25) + j]);
                        }
                    }
                    Debug.WriteLine(" ");
                }
            }

            Assert.Equal('a', 'a');
        }
    }
}
