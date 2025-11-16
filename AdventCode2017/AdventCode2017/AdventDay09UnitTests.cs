using AdventCodeLib;

namespace AdventCode2017;

public class AdventDay09UnitTests
{
    string pathdata = "Adventday09.txt";
    public Day09GroupGarbage sut { get; set; }

    public AdventDay09UnitTests()
    {
        sut = new Day09GroupGarbage();
    }

    [Fact]
    public void Day09_TestRun01()
    {
        string s = "{}";
        int score = 0;
        int junkChars = 0;
        int groups = sut.GroupCount(s, out score, out junkChars);
        Assert.Equal(1, groups);
        Assert.Equal(1, score);

        s = "{{{}}}";
        groups = sut.GroupCount(s, out score, out junkChars);
        Assert.Equal(3, groups);
        Assert.Equal(6, score);

        s = "{{},{}}";
        groups = sut.GroupCount(s, out score, out junkChars);
        Assert.Equal(3, groups);
        Assert.Equal(5, score);

        s = "{{},{}}";
        groups = sut.GroupCount(s, out score, out junkChars);
        Assert.Equal(3, groups);
        Assert.Equal(5, score);

        s = "{{{},{},{{}}}}";
        groups = sut.GroupCount(s, out score, out junkChars);
        Assert.Equal(6, groups);
        Assert.Equal(16, score);

        s = "{<{},{},{{}}>}";
        groups = sut.GroupCount(s, out score, out junkChars);
        Assert.Equal(1, groups);
        Assert.Equal(1, score);

        s = "{<a>,<a>,<a>,<a>}";
        groups = sut.GroupCount(s, out score, out junkChars);
        Assert.Equal(1, groups);
        Assert.Equal(1, score);

        s = "{{<a>},{<a>},{<a>},{<a>}}";
        groups = sut.GroupCount(s, out score, out junkChars);
        Assert.Equal(5, groups);
        Assert.Equal(9, score);

        s = "{{<!>},{<!>},{<!>},{<a>}}";
        groups = sut.GroupCount(s, out score, out junkChars);
        Assert.Equal(2, groups);
        Assert.Equal(3, score);

        s = "{{{},{},{{}}}}";
        groups = sut.GroupCount(s, out score, out junkChars);
        Assert.Equal(16, score);

        s = "{{<ab>},{<ab>},{<ab>},{<ab>}}";
        groups = sut.GroupCount(s, out score, out junkChars);
        Assert.Equal(9, score);

        s = "{{<!!>},{<!!>},{<!!>},{<!!>}}";
        groups = sut.GroupCount(s, out score, out junkChars);
        Assert.Equal(9, score);
    }

    [Fact]
    public void Day09_TestJunkCount()
    {
        string s = "<>";
        int score;
        int junk;
        int groups = sut.GroupCount(s, out score, out junk);
        Assert.Equal(0, junk);

        s = "<random characters>";
        groups = sut.GroupCount(s, out score, out junk);
        Assert.Equal(17, junk);

        s = "<{oi!a,<{i<a>";
        groups = sut.GroupCount(s, out score, out junk);
        Assert.Equal(9, junk);
    }

    [Fact]
    public void Day09_TestRun_SolutionA()
    {
        string data = sut.ReadData(pathdata);
        Assert.False(string.IsNullOrWhiteSpace(data));
        Assert.Equal(22329, data.Length);
        int score = 0;
        int junkChars = 0;
        int groups = sut.GroupCount(data, out score, out junkChars);
        Assert.Equal(1889, groups);
        Assert.Equal(16869, score);
    }
}
