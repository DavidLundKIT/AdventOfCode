using AdventCode2025.Models;

namespace AdventCode2025;

public class Day02GiftShopUnitTests
{
    private readonly string TestData = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";
    private readonly string PuzzleData = "5542145-5582046,243-401,884211-917063,1174-1665,767028-791710,308275-370459,285243789-285316649,3303028-3361832,793080-871112,82187-123398,7788-14096,21-34,33187450-33443224,2750031-2956556,19974-42168,37655953-37738891,1759-2640,55544-75026,9938140738-9938223673,965895186-966026269,502675-625082,11041548-11204207,1-20,3679-7591,8642243-8776142,40-88,2872703083-2872760877,532-998,211488-230593,3088932-3236371,442734-459620,8484829519-8484873271,5859767462-5859911897,9987328-10008767,656641-673714,262248430-262271846";


    [Theory]
    [InlineData(11, 22, 2)]
    [InlineData(95, 115, 1)]
    [InlineData(998, 1012, 1)]
    [InlineData(1188511880, 1188511890, 1)]
    [InlineData(222220, 222224, 1)]
    [InlineData(1698522, 1698528, 0)]
    [InlineData(446443, 446449, 1)]
    [InlineData(38593856, 38593862, 1)]
    [InlineData(565653, 565659, 0)]
    [InlineData(824824821, 824824827, 0)]
    [InlineData(2121212118, 2121212124, 0)]
    public void InvalidDoubleSequenceIds_TestData_OK(long startId, long endId, int expectedCount)
    {
        var invalidIds = GSProductIdValidator.InvalidInDoubleSequenceIds(startId, endId);
        Assert.Equal(expectedCount, invalidIds.Count);
    }

    [Fact]
    public void InvalidDoubleSequenceIds_TestData_Sum_OK()
    {
        var allInvalidIds = new List<long>();
        var ranges = TestData.Split(',');
        foreach (var range in ranges)
        {
            var parts = range.Split('-');
            long startId = long.Parse(parts[0]);
            long endId = long.Parse(parts[1]);
            var invalidIds = GSProductIdValidator.InvalidInDoubleSequenceIds(startId, endId);
            if (invalidIds.Count > 0)
            {
                allInvalidIds.AddRange(invalidIds);
            }
        }
        var totalInvalidIds = allInvalidIds.Sum();
        Assert.Equal(1227775554, totalInvalidIds);
    }

    [Fact]
    public void Day02_Part1_Sum_OK()
    {
        var allInvalidIds = new List<long>();
        var ranges = PuzzleData.Split(',');
        foreach (var range in ranges)
        {
            var parts = range.Split('-');
            long startId = long.Parse(parts[0]);
            long endId = long.Parse(parts[1]);
            var invalidIds = GSProductIdValidator.InvalidInDoubleSequenceIds(startId, endId);
            if (invalidIds.Count > 0)
            {
                allInvalidIds.AddRange(invalidIds);
            }
        }
        var totalInvalidIds = allInvalidIds.Sum();
        Assert.Equal(20223751480, totalInvalidIds);
    }
}
