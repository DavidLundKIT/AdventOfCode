using AdventOfCode2019;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xunit;

namespace AdventOfCode2019XUnitTests
{
    public class Day06UniversalOrbitMapUnitTests
    {
        [Fact]
        public void Day06Part1_Example1()
        {
            string[] orbits = new string[] {
                                            "COM)B",
                                            "B)C",
                                            "C)D",
                                            "D)E",
                                            "E)F",
                                            "B)G",
                                            "G)H",
                                            "D)I",
                                            "E)J",
                                            "J)K",
                                            "K)L"
                                            };
            NameValueCollection orbitMap = OrbitalMapper.FillOrbitMap(orbits);
            OrbitalMapper.PrintKeysAndValues(orbitMap);
            int totalOrbits = 0;
            int orbitsNow = 0;
            foreach (var orb in orbitMap.AllKeys)
            {
                orbitsNow = OrbitalMapper.CountOrbits(orbitMap, orb, 0);
                totalOrbits += orbitsNow;
            }

            Assert.Equal(42, totalOrbits);
        }


        [Fact]
        public void Day06Part2_Example2()
        {
            string[] orbits = new string[] {
                                            "COM)B",
                                            "B)C",
                                            "C)D",
                                            "D)E",
                                            "E)F",
                                            "B)G",
                                            "G)H",
                                            "D)I",
                                            "E)J",
                                            "J)K",
                                            "K)L",
                                            "K)YOU",
                                            "I)SAN"
                                            };
            NameValueCollection orbitMap = OrbitalMapper.FillOrbitMap(orbits);
            OrbitalMapper.PrintKeysAndValues(orbitMap);
            
            List<string> youOrbits = new List<string>();
            youOrbits = OrbitalMapper.GetOrbits(orbitMap, "YOU", youOrbits);
            List<string> santaOrbits = new List<string>();
            santaOrbits = OrbitalMapper.GetOrbits(orbitMap, "SAN", santaOrbits);
            var notInSanta = santaOrbits.Except(youOrbits).ToList();
            var notInYou = youOrbits.Except(santaOrbits).ToList();
            int totalOrbits = notInSanta.Count + notInYou.Count;
            Assert.Equal(4, totalOrbits);
        }


        [Fact(Skip ="Working but takes a minute")]
        public void Day06Part1_TestSolution()
        {
            string[] orbits = DayDataUtilities.ReadLinesFromFile("day06.txt");
            Assert.Equal(1656, orbits.Length);

            NameValueCollection orbitMap = OrbitalMapper.FillOrbitMap(orbits);
            OrbitalMapper.PrintKeysAndValues(orbitMap);
            int totalOrbits = 0;
            int orbitsNow = 0;
            foreach (var orb in orbitMap.AllKeys)
            {
                orbitsNow = OrbitalMapper.CountOrbits(orbitMap, orb, 0);
                totalOrbits += orbitsNow;
            }

            Assert.Equal(271151, totalOrbits);
        }

        [Fact]
        public void Day06Part2_TestSolution()
        {
            string[] orbits = DayDataUtilities.ReadLinesFromFile("day06.txt");
            Assert.Equal(1656, orbits.Length);

            NameValueCollection orbitMap = OrbitalMapper.FillOrbitMap(orbits);
            Assert.Equal(1657, orbitMap.Count);

            List<string> youOrbits = new List<string>();
            youOrbits = OrbitalMapper.GetOrbits(orbitMap, "YOU", youOrbits);
            List<string> santaOrbits = new List<string>();
            santaOrbits = OrbitalMapper.GetOrbits(orbitMap, "SAN", santaOrbits);
            var notInSanta = santaOrbits.Except(youOrbits).ToList();
            var notInYou = youOrbits.Except(santaOrbits).ToList();
            int totalOrbits = notInSanta.Count + notInYou.Count;
            Assert.Equal(388, totalOrbits);
        }
    }
}
