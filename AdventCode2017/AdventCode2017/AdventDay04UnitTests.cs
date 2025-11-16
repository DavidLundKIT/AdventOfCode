using AdventCodeLib;

namespace AdventCode2017;

public class AdventDay04UnitTests
{
    public Day04PassPhrase sut { get; set; }

    public AdventDay04UnitTests()
    {
        sut = new Day04PassPhrase();
    }

    [Fact]
    public void Day04_TestRun01()
    {
        string phrase = "aa bb cc dd ee";

        bool isValid = sut.CheckPassPhrase(phrase);
        Assert.True(isValid);
    }

    [Fact]
    public void Day04_TestRun02()
    {
        string phrase = "aa bb cc dd aa";

        bool isValid = sut.CheckPassPhrase(phrase);
        Assert.False(isValid);
    }

    [Fact]
    public void Day04_TestRun03()
    {
        string phrase = "aa bb cc dd aaa";

        bool isValid = sut.CheckPassPhrase(phrase);
        Assert.True(isValid);
    }

    [Fact]
    public void Day04_TestRun04_SolutionA()
    {
        string path = "AdventDay04.txt";
        int expected = 455;
        int actual = sut.NumberValidPassPhrasesInFile(path);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Day04_TestRun05()
    {
        string phrase = "abcde fghij";

        bool isValid = sut.CheckPassPhraseAnagrams(phrase);
        Assert.True(isValid);
    }

    [Fact]
    public void Day04_TestRun06()
    {
        string phrase = "abcde xyz ecdab";

        bool isValid = sut.CheckPassPhraseAnagrams(phrase);
        Assert.False(isValid);
    }

    [Fact]
    public void Day04_TestRun07()
    {
        string phrase = "a ab abc abd abf abj";

        bool isValid = sut.CheckPassPhraseAnagrams(phrase);
        Assert.True(isValid);
    }

    [Fact]
    public void Day04_TestRun08()
    {
        string phrase = "iiii oiii ooii oooi oooo";

        bool isValid = sut.CheckPassPhraseAnagrams(phrase);
        Assert.True(isValid);
    }

    [Fact]
    public void Day04_TestRun09()
    {
        string phrase = "oiii ioii iioi iiio";

        bool isValid = sut.CheckPassPhraseAnagrams(phrase);

        Assert.False(isValid);
    }

    [Fact]
    public void Day04_TestRun10_SolutionB()
    {
        string path = "AdventDay04.txt";
        int expected = 186;
        int actual = sut.NumberValidPassPhrasesInFile2(path);
        Assert.Equal(expected, actual);
    }
}
