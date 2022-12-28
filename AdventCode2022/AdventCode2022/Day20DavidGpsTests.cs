using AdventCode2022.Models;

namespace AdventCode2022
{
    public class Day20DavidGpsTests
    {
        public List<int> TestData { get; set; } = new List<int> { 1, 2, -3, 3, -2, 0, 4 };

        [Fact]
        public void ReadInDataFile_OK()
        {
            var lines = Utils.ReadIntsFromFile("Day20.txt");
            int actual = lines.Count;
            Assert.Equal(5000, actual);

            GpsNode root = GpsNode.FileToNodes(lines);

            Assert.Equal(5000, GpsNode.Count(root));

            //var listZeros = lines.Where(l => l == 0).ToList();
            //Assert.Equal(1, listZeros.Count);
        }

        [Fact]
        public void FindGroveCoords_Test_OK()
        {
            GpsNode root = GpsNode.FileToNodes(TestData);

            Assert.Equal(7, GpsNode.Count(root));



        //    for (int i = 0; i < 7; i++)
        //    {
        //        gps.DoMove(i);
        //    }

        //    List<int> expected = new List<int>() { 1, 2, -3, 4, 0, 3, -2 };
        //    var actual = gps.OrderList.Select(n => n.Item2).ToList();
        //    var results = expected.Zip(actual).Select(p => p.First == p.Second);
        //    foreach (var result in results)
        //    {
        //        Assert.True(result);
        //    }
        }
    }
}
