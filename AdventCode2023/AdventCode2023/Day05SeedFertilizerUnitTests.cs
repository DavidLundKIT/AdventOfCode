using AdventCode2023.Models;

namespace AdventCode2023
{
    public class Day05SeedFertilizerUnitTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day05.txt");
            int expected = 254;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new SeedFertilizerMapper();
            sut.ParseData(lines);
            Assert.Equal(20, sut.Seeds.Count);
            Assert.Equal(42, sut.HumidityLocation.Count);
        }

        [Fact]
        public void ReadInDataFile_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day05test.txt");
            int expected = 33;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new SeedFertilizerMapper();
            sut.ParseData(lines);
            Assert.Equal(4, sut.Seeds.Count);
            Assert.Equal(2, sut.SeedSoil.Count);
            Assert.Equal(3, sut.SoilFertilizer.Count);
            Assert.Equal(4, sut.FertilizerWater.Count);
            Assert.Equal(2, sut.WaterLight.Count);
            Assert.Equal(3, sut.LightTemperature.Count);
            Assert.Equal(2, sut.TemperatureHumidity.Count);
            Assert.Equal(2, sut.HumidityLocation.Count);

            long location = sut.FindNearestSeedLocation();
            Assert.Equal(35, location);

            location = sut.FindNearestSeedRangesLocation();
            Assert.Equal(46, location);
        }

        [Theory]
        [InlineData(79, 81)]
        [InlineData(14, 14)]
        [InlineData(55, 57)]
        [InlineData(13, 13)]
        public void SeedToSoil_Test_OK(long seed, long soil)
        {
            var lines = Utils.ReadLinesFromFile("Day05test.txt");
            int expected = 33;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new SeedFertilizerMapper();
            sut.ParseData(lines);
            long actualSoil = sut.MapToDestination(seed, sut.SeedSoil);
            Assert.Equal(soil, actualSoil);
        }

        [Theory]
        [InlineData(79, 82)]
        [InlineData(14, 43)]
        [InlineData(55, 86)]
        [InlineData(13, 35)]
        public void SeedToLocation_Test_OK(long seed, long location)
        {
            var lines = Utils.ReadLinesFromFile("Day05test.txt");
            int expected = 33;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new SeedFertilizerMapper();
            sut.ParseData(lines);
            long actualSoil = sut.FromSeedToLocation(seed);
            Assert.Equal(location, actualSoil);
        }

        [Fact]
        public void Day05_Part1_SeedFertilizer_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day05.txt");
            int expected = 254;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new SeedFertilizerMapper();
            sut.ParseData(lines);
            Assert.Equal(20, sut.Seeds.Count);
            Assert.Equal(42, sut.HumidityLocation.Count);

            long location = sut.FindNearestSeedLocation();
            Assert.Equal(174137457, location);
        }

        [Fact(Skip = "Took 99.6 minutes")]
        public void Day05_Part2_SeedFertilizer_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day05.txt");
            int expected = 254;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new SeedFertilizerMapper();
            sut.ParseData(lines);
            Assert.Equal(20, sut.Seeds.Count);
            Assert.Equal(42, sut.HumidityLocation.Count);

            long location = sut.FindNearestSeedRangesLocation();
            Assert.Equal(1493866, location);
        }
    }
}
