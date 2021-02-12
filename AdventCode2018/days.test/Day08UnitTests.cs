using days.day08;
using Xunit;

namespace days.test
{
    public class Day08UnitTests
    {
        [Fact(Skip="Answers Day 8")]
        public void Day08_ParseData_OK()
        {
            string datapath = "day08.txt";
            var row = DataHelpers.ReadTextFromFile(datapath);
            Day08Input src = new Day08Input(row);

            NavigationNode root = new NavigationNode(src);
            int sum = root.MetaDataSum();
            Assert.Equal(41454, sum);
            int rootNodeSum = root.NodeSum();
            Assert.Equal(25752, rootNodeSum);
        }

        [Theory(Skip = "Done")]
        [InlineData("2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2", 138, 66)]
        public void Day08_ParseTestData(string row, int expected, int expectedNodeSum)
        {
            Day08Input src = new Day08Input(row);

            NavigationNode root = new NavigationNode(src);

            Assert.Equal(2, root.NumberNodes);
            Assert.Equal(3, root.NumberMetaData);
            int actual = root.MetaDataSum();
            Assert.Equal(expected, actual);
            int rootNodeSum = root.NodeSum();
            Assert.Equal(expectedNodeSum, rootNodeSum);
        }
    }
}
