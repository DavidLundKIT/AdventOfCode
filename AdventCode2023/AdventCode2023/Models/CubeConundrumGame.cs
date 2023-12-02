using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventCode2023.Models
{
    public class CubeConundrumGame
    {
        public int GameNr { get; set; }
        public List<CubeHand> Hands { get; set; }

        public CubeConundrumGame(string gameLine)
        {
            Hands = new List<CubeHand>();
            var temp = gameLine.Split(':', StringSplitOptions.RemoveEmptyEntries);
            GameNr = int.Parse(Regex.Match(temp[0], @"\d+").Value);

            var hands = temp[1].Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (var hand in hands)
            {
                Hands.Add(new CubeHand(hand));
            }
        }

        public bool PossibleGame(int redCubes, int blueCubes, int greenCubes)
        {
            foreach (var hand in Hands) 
            {
                if (!hand.Possible(redCubes, blueCubes, greenCubes))
                    return false;
            }
            return true;
        }
    }

    public class CubeHand
    {
        public int Blue { get; set; }
        public int Green { get; set; }
        public int Red { get; set; }

        public CubeHand(string hand)
        {
            var cubes = hand.Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach (var c in cubes)
            {
                int count = int.Parse(Regex.Match(c, @"\d+").Value);
                if (c.Contains("blue"))
                {
                    Blue = count;
                }
                else if (c.Contains("green"))
                {
                    Green = count;
                }
                else if (c.Contains("red"))
                {
                    Red = count;
                } else
                {
                    throw new Exception("Huh?");
                }
            }
        }

        public bool Possible(int redCubes, int blueCubes, int greenCubes)
        {
            return (Red <= redCubes && Blue <= blueCubes && Green <= greenCubes);
        }
    }
}
