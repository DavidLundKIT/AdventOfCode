namespace AdventCode2023
{
    public class Day06WaitForITUnitTests
    {
        [Theory]
        [InlineData(7, 9, 4)]
        [InlineData(15, 40, 8)]
        [InlineData(30, 200, 9)]
        public void TestRaceCombos_OK(long timeMs, long raceRecord, long combos)
        {
            long actual = RaceCombosBetterThanRecord(timeMs, raceRecord);
            Assert.Equal(actual, combos);
        }

        [Fact]
        public void Day06_Part1_WaitForIt_OK()
        {
            List<Tuple<long, long>> Races = RealRaceData();

            long combosMultiSum = 1;
            foreach (var race in Races)
            {
                combosMultiSum *= RaceCombosBetterThanRecord(race.Item1, race.Item2);
            }
            Assert.Equal(140220, combosMultiSum);
        }

        [Fact]
        public void TestPart2_OK()
        {
            long actual = RaceCombosBetterThanRecord(71530, 940200);
            Assert.Equal(71503, actual);
        }

        [Fact]
        public void Day06_Part2_WaitForIt_OK()
        {
            // This is my puzzle data
            // Time:        53     83     72     88
            // Distance:    333   1635   1289   1532
            long actual = RaceCombosBetterThanRecord(53837288, 333163512891532);
            Assert.Equal(39570185, actual);
        }

        public List<Tuple<long, long>> RealRaceData()
        {
            // This is my puzzle data
            // Time:        53     83     72     88
            // Distance:    333   1635   1289   1532
            List<Tuple<long, long>> Races = new List<Tuple<long, long>>();
            Races.Add(new Tuple<long, long>(53, 333));
            Races.Add(new Tuple<long, long>(83, 1635));
            Races.Add(new Tuple<long, long>(72, 1289));
            Races.Add(new Tuple<long, long>(88, 1532));
            return Races;
        }

        public long RaceCombosBetterThanRecord(long timeMs, long raceRecord)
        {
            long combos = 0;

            for (long ms = 0; ms <= timeMs; ms++)
            {
                long distance = (timeMs - ms) * ms;
                if (distance > raceRecord)
                    combos++;
            }
            return combos;
        }
    }
}
