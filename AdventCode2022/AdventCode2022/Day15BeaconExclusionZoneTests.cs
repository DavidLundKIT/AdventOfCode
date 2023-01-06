using AdventCode2022.Models;

namespace AdventCode2022
{
    public class Day15BeaconExclusionZoneTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day15.txt");
            int actual = lines.Length;
            Assert.Equal(27, actual);

            var sut = new BeaconSensorCalculator(lines);
            actual = sut.SensorBeaconDict.Count;
            Assert.Equal(27, actual);
        }

        [Fact]
        public void ReadInDataFile_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day15test.txt");
            int actual = lines.Length;
            Assert.Equal(14, actual);
            var sut = new BeaconSensorCalculator(lines);
            actual = sut.SensorBeaconDict.Count;
            Assert.Equal(14, actual);
        }

        [Fact]
        public void PlacesBeaconCannotBe_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day15test.txt");
            long actual = lines.Length;
            Assert.Equal(14, actual);
            var sut = new BeaconSensorCalculator(lines);
            actual = sut.SensorBeaconDict.Count;
            Assert.Equal(14, actual);

            actual = sut.PlacesBeaconCannotBeOnRow(10);

            Assert.Equal(26, actual);
        }

        [Fact]
        public void PlacesBeaconCannotBe_Part1_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day15.txt");
            long actual = lines.Length;
            Assert.Equal(27, actual);
            var sut = new BeaconSensorCalculator(lines);
            actual = sut.SensorBeaconDict.Count;
            Assert.Equal(27, actual);

            actual = sut.PlacesBeaconCannotBeOnRow(2000000);
            // 3291350 too low
            // 4930721 too low
            // 4930720 too low
            Assert.Equal(4985193, actual);
        }

        [Fact]
        public void BeaconFindFrequency_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day15test.txt");
            long actual = lines.Length;
            Assert.Equal(14, actual);
            var sut = new BeaconSensorCalculator(lines);
            actual = sut.SensorBeaconDict.Count;
            Assert.Equal(14, actual);

            actual = sut.FindFrequency(0, 20);

            Assert.Equal(56000011, actual);
        }

        [Fact(Skip ="Too long")]
        public void BeaconFindFrequency_Part2_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day15.txt");
            long actual = lines.Length;
            Assert.Equal(27, actual);
            var sut = new BeaconSensorCalculator(lines);
            actual = sut.SensorBeaconDict.Count;
            Assert.Equal(27, actual);

            actual = sut.FindFrequency(0, 4000000);

            Assert.Equal(0, actual);
        }

        [Fact(Skip ="Not much smaller cube")]
        public void BeaconFindFrequency_FindBounds_Part2_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day15.txt");
            long actual = lines.Length;
            Assert.Equal(27, actual);
            var sut = new BeaconSensorCalculator(lines);
            actual = sut.SensorBeaconDict.Count;
            Assert.Equal(27, actual);

            long xMin = Math.Min(sut.SensorBeaconDict.Keys.Min(t => t.Item1), sut.SensorBeaconDict.Values.Min(t => t.Item1));
            long xMax = Math.Max(sut.SensorBeaconDict.Keys.Max(t => t.Item1), sut.SensorBeaconDict.Values.Max(t => t.Item1));
            long yMin = Math.Min(sut.SensorBeaconDict.Keys.Min(t => t.Item2), sut.SensorBeaconDict.Values.Min(t => t.Item2));
            long yMax = Math.Max(sut.SensorBeaconDict.Keys.Max(t => t.Item2), sut.SensorBeaconDict.Values.Max(t => t.Item2));
            //actual = sut.FindFrequency(0, 4000000);

            Assert.Equal(0, actual);
        }

        //[Fact()]
        //public void BeaconFindFrequency_FindOpenSpace_Test_OK()
        //{
        //    var lines = Utils.ReadLinesFromFile("Day15test.txt");
        //    long actual = lines.Length;
        //    Assert.Equal(14, actual);
        //    var sut = new BeaconSensorCalculator(lines);
        //    actual = sut.SensorBeaconDict.Count;
        //    Assert.Equal(14, actual);

        //    sut.FindPointsBetweenSensorsSingle();

        //    Assert.Equal(0, actual);
        //}

        [Fact()]
        public void BeaconFindFrequency_FindOutOfRangeByOne_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day15test.txt");
            long actual = lines.Length;
            Assert.Equal(14, actual);
            var sut = new BeaconSensorCalculator(lines);
            actual = sut.SensorBeaconDict.Count;
            Assert.Equal(14, actual);

            actual = sut.FindPointsBetweenSensors(0, 20);

            Assert.Equal(56000011, actual);
        }

        [Fact(Skip ="Takes 3.5 - 3.6 minutes")]
        public void BeaconFindFrequency_FindOutOfRangeByOne_Part2_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day15.txt");
            long actual = lines.Length;
            Assert.Equal(27, actual);
            var sut = new BeaconSensorCalculator(lines);
            actual = sut.SensorBeaconDict.Count;
            Assert.Equal(27, actual);

            actual = sut.FindPointsBetweenSensors(0, 4000000);
            // 7.1 minutes with out removing sensed points
            // 4.0 minutes with removing points after sensing points in second loop
            // 3.5 minutes with sensing and removing points in the first loop too. Not much gain.
            Assert.Equal(11583882601918, actual);
        }
    }
}
