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

        [Fact]
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
    }
}
