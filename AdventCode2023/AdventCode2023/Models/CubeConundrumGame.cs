using System.Text.RegularExpressions;

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

        public int MinimumPowerCalculation()
        {
            int minBlueNeeded = Hands.Select(h => h.Blue).Max();
            int minGreenNeeded = Hands.Select(h => h.Green).Max();
            int minRedNeeded = Hands.Select(h => h.Red).Max();
            return minBlueNeeded * minGreenNeeded * minRedNeeded;
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
                }
                else
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
