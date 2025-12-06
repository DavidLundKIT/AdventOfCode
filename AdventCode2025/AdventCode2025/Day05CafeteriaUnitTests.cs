using AdventCode2025.Models;

namespace AdventCode2025;

public class Day05CafeteriaUnitTests
{
    [Fact]
    public void Day05_TestData_Find13_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day05test.txt");
        Assert.Equal(11, lines.Length);

        var sut = new FoodChecker(lines);
        Assert.Equal(6, sut.Ingredients.Count);
        Assert.Equal(4, sut.IngredientRanges.Count);

        var freshCount = sut.FindFreshIngredients();
        Assert.Equal(3, freshCount);
    }

    [Fact]
    public void Day05_Part1_Solution_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day05.txt");
        Assert.Equal(1178, lines.Length);

        var sut = new FoodChecker(lines);
        Assert.Equal(167, sut.IngredientRanges.Count);
        Assert.Equal(1000, sut.Ingredients.Count);

        var freshCount = sut.FindFreshIngredients();
        Assert.Equal(707, freshCount);
    }

    [Fact]
    public void Day05_TestData_FindValidIngedients_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day05test.txt");
        Assert.Equal(11, lines.Length);

        var sut = new FoodChecker(lines);
        Assert.Equal(6, sut.Ingredients.Count);
        Assert.Equal(4, sut.IngredientRanges.Count);

        var freshCount = sut.FindValidIngredients();
        Assert.Equal(14, freshCount);
    }

    [Fact]
    public void Day05_Part2_Solution_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day05.txt");
        Assert.Equal(1178, lines.Length);

        var sut = new FoodChecker(lines);
        Assert.Equal(167, sut.IngredientRanges.Count);
        Assert.Equal(1000, sut.Ingredients.Count);

        var freshCount = sut.FindValidIngredients();
        Assert.Equal(361615643045059, freshCount);
    }
}
