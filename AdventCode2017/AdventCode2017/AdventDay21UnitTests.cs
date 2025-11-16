using AdventCodeLib;

namespace AdventCode2017;

public class AdventDay21UnitTests
{
    private readonly string pathdata = "Adventday21.txt";

    public Day21FractalArt sut { get; set; }

    public AdventDay21UnitTests()
    {
        sut = new Day21FractalArt();
    }

    [Fact]
    public void Day21_TestRun01()
    {
        var lines = new string[]
        {
            "../.# => ##./#../...",
            ".#./..#/### => #..#/..../..../#..#"
        };

        Assert.Equal(2, lines.Length);

        sut.ParseData(lines);
        Assert.Equal(2, sut.Rules.Count);

        var key = sut.MakeKey(3, sut.ArtWork);

        sut.DumpMatrix(sut.ArtWork);
        Assert.Equal(".#./..#/###", key);
        var rotate = sut.RotateMatrix(sut.ArtWork);
        var rotateKey = sut.MakeKey(3, rotate);
        sut.DumpMatrix(rotate);
        Assert.Equal(".##/#.#/..#", rotateKey);
        var flipHor = sut.FlipHori(sut.ArtWork);
        var flipHorKey = sut.MakeKey(3, flipHor);
        sut.DumpMatrix(flipHor);
        Assert.Equal(".#./#../###", flipHorKey);
        var flipVert = sut.FlipVert(sut.ArtWork);
        var flipVertKey = sut.MakeKey(3, flipVert);
        sut.DumpMatrix(flipVert);
        Assert.Equal("###/..#/.#.", flipVertKey);

        Assert.Equal(5, sut.CountPixels(sut.ArtWork));
        sut.DoIteration();
        sut.DumpMatrix(sut.ArtWork);
        sut.DoIteration();
        sut.DumpMatrix(sut.ArtWork);
        Assert.Equal(12, sut.CountPixels(sut.ArtWork));
    }

    [Fact]
    public void Day21_Solution_PartA()
    {
        var lines = DataTools.ReadAllLines(pathdata);
        Assert.Equal(108, lines.Length);

        sut.ParseData(lines);
        Assert.Equal(108, sut.Rules.Count);
        sut.DumpMatrix(sut.ArtWork);
        for (int i = 0; i < 5; i++)
        {
            sut.DoIteration();
            sut.DumpMatrix(sut.ArtWork);
        }
        Assert.Equal(197, sut.CountPixels(sut.ArtWork));
    }

    // takes 2.6 minutes
    [Fact]
    public void Day21_Solution_PartB()
    {
        var lines = DataTools.ReadAllLines(pathdata);
        Assert.Equal(108, lines.Length);

        sut.ParseData(lines);
        Assert.Equal(108, sut.Rules.Count);
        sut.DumpMatrix(sut.ArtWork);
        for (int i = 0; i < 18; i++)
        {
            sut.DoIteration();
            sut.DumpMatrix(sut.ArtWork);
        }
        Assert.Equal(3081737, sut.CountPixels(sut.ArtWork));
    }
}
