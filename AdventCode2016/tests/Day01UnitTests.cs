using System;
using System.IO;
using Xunit;
using tests;

namespace tests
{
    public class Day01UnitTests
    {
        private const string _indatafile = "day01.txt";
        
        public Day01UnitTests()
        {
            
        }

        [Fact]
        public void Day01DistanceFirstPart()
        {
            string indata = DataUtils.ReadAllText(_indatafile);

            Assert.NotNull(indata);
            DistanceCalculator sut = new DistanceCalculator();

            var cmds = indata.Split(',');
            foreach (string cmd in cmds)
            {
                var tcmd = cmd.Trim();
                sut.Turn(tcmd.Substring(0, 1));
                sut.Walk(int.Parse(tcmd.Substring(1)));
            }
            Assert.Equal(301, sut.Distance());
        }

        [Theory]
        [InlineData("R2, L3", 5)]
        [InlineData("R2, R2, R2", 2)]
        [InlineData("R5, L5, R5, R3", 12)]
        public void Day01DistancesExamples(string input, int distance)
        {
            DistanceCalculator sut = new DistanceCalculator();

            var cmds = input.Split(',');
            foreach (string cmd in cmds)
            {
                var tcmd = cmd.Trim();
                sut.Turn(tcmd.Substring(0, 1));
                sut.Walk(int.Parse(tcmd.Substring(1)));
            }
            Assert.Equal(sut.Distance(), distance);
        }

        [Theory]
        [InlineData("R8, R4, R4, R8", 4)]
        public void Day01FirstRepeatVisit(string input, int distance)
        {
            DistanceCalculator sut = new DistanceCalculator();
            int crossingDistance = 0;

            var cmds = input.Split(',');
            foreach (string cmd in cmds)
            {
                var tcmd = cmd.Trim();
                sut.Turn(tcmd.Substring(0, 1));
                sut.Walk(int.Parse(tcmd.Substring(1)));
                if (sut.CrossPath())
                {
                    crossingDistance = sut.CrossingDistance;
                    break;
                }
            }
            Assert.Equal(distance, crossingDistance);
        }

        [Fact]
        public void Day01DistancesecondPart()
        {
            string indata = DataUtils.ReadAllText(_indatafile);
            Assert.NotNull(indata);
            int crossingDistance = 0;
            DistanceCalculator sut = new DistanceCalculator();

            var cmds = indata.Split(',');
            foreach (string cmd in cmds)
            {
                var tcmd = cmd.Trim();
                sut.Turn(tcmd.Substring(0, 1));
                sut.Walk(int.Parse(tcmd.Substring(1)));
                if (sut.CrossPath())
                {
                    crossingDistance = sut.CrossingDistance;
                    break;
                }
            }
            Assert.Equal(130, crossingDistance);
        }


        [Fact]
        public void Day01MinMaxPoint_Y_equalOK()
        {
            DistanceCalculator sut = new DistanceCalculator();
            Point p1 = new Point(-3, 0);
            Point p2 = new Point(8, 0);

            Point pMin = sut.GetMin(p1, p2);
            Assert.Equal(-3, pMin.X);
            Assert.Equal(0, pMin.Y);

            Point pMax = sut.GetMax(p1, p2);
            Assert.Equal(8, pMax.X);
            Assert.Equal(0, pMax.Y);
        }

        [Fact]
        public void Day01MinMaxPoint_X_equalOK()
        {
            DistanceCalculator sut = new DistanceCalculator();
            Point p1 = new Point(0, 8);
            Point p2 = new Point(0, -3);

            Point pMin = sut.GetMin(p1, p2);
            Assert.Equal(-3, pMin.Y);
            Assert.Equal(0, pMin.X);

            Point pMax = sut.GetMax(p1, p2);
            Assert.Equal(8, pMax.Y);
            Assert.Equal(0, pMax.X);
        }
    }
}
