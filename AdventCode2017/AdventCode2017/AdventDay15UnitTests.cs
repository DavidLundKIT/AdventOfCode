using AdventCodeLib;

namespace AdventCode2017;

public class AdventDay15UnitTests
{
    public Generator genA { get; set; }
    public Generator genB { get; set; }
    long factorA = 16807;
    long factorB = 48271;

    public AdventDay15UnitTests()
    {
        genA = new Generator(65, factorA);
        genB = new Generator(8921, factorB);
    }

    [Fact]
    public void Day15_TestRun01()
    {
        // --Gen.A--   --Gen.B--
        //   1092455    430625591
        Assert.Equal(1092455, genA.Generate());
        Assert.Equal(430625591, genB.Generate());
        Assert.False(Generator.Match(genA, genB));
        // 1181022009  1233683848
        Assert.Equal(1181022009, genA.Generate());
        Assert.Equal(1233683848, genB.Generate());
        Assert.False(Generator.Match(genA, genB));
        // 245556042   1431495498
        Assert.Equal(245556042, genA.Generate());
        Assert.Equal(1431495498, genB.Generate());
        Assert.True(Generator.Match(genA, genB));
        // 1744312007   137874439
        Assert.Equal(1744312007, genA.Generate());
        Assert.Equal(137874439, genB.Generate());
        Assert.False(Generator.Match(genA, genB));
        // 1352636452   285222916
        Assert.Equal(1352636452, genA.Generate());
        Assert.Equal(285222916, genB.Generate());
        Assert.False(Generator.Match(genA, genB));
    }

    [Fact]
    public void Day15_TestRun02()
    {
        long expected = 588;
        long actual = 0;
        int length = 40000000;

        for (int i = 0; i < length; i++)
        {
            genA.Generate();
            genB.Generate();
            if (Generator.Match(genA, genB))
            {
                actual++;
            }
        }
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Day15_TestRun03()
    {
        genA.Check = 4;
        genB.Check = 8;
        // --Gen.A----Gen.B--
        // 1352636452  1233683848
        Assert.Equal(1352636452, genA.Generate2());
        Assert.Equal(1233683848, genB.Generate2());
        Assert.False(Generator.Match(genA, genB));
        // 1992081072   862516352
        Assert.Equal(1992081072, genA.Generate2());
        Assert.Equal(862516352, genB.Generate2());
        Assert.False(Generator.Match(genA, genB));
        //  530830436  1159784568
        Assert.Equal(530830436, genA.Generate2());
        Assert.Equal(1159784568, genB.Generate2());
        Assert.False(Generator.Match(genA, genB));
        // 1980017072  1616057672
        Assert.Equal(1980017072, genA.Generate2());
        Assert.Equal(1616057672, genB.Generate2());
        Assert.False(Generator.Match(genA, genB));
        //  740335192   412269392
        Assert.Equal(740335192, genA.Generate2());
        Assert.Equal(412269392, genB.Generate2());
        Assert.False(Generator.Match(genA, genB));
    }

    [Fact]
    public void Day15_TestRun04()
    {
        genA.Check = 4;
        genB.Check = 8;

        for (int i = 0; i < 1056; i++)
        {
            genA.Generate2();
            genB.Generate2();
        }
        Assert.True(Generator.Match(genA, genB));
    }

    [Fact]
    public void Day15_TestRun05()
    {
        long expected = 309;
        long actual = 0;
        int length = 5000000;
        genA.Check = 4;
        genB.Check = 8;

        for (int i = 0; i < length; i++)
        {
            genA.Generate2();
            genB.Generate2();
            if (Generator.Match(genA, genB))
            {
                actual++;
            }
        }
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Day15_TestSolutionA()
    {
        genA = new Generator(703, factorA);
        genB = new Generator(516, factorB);
        long expected = 594;
        long actual = 0;
        int length = 40000000;

        for (int i = 0; i < length; i++)
        {
            genA.Generate();
            genB.Generate();
            if (Generator.Match(genA, genB))
            {
                actual++;
            }
        }
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Day15_TestSolutionB()
    {
        genA = new Generator(703, factorA);
        genB = new Generator(516, factorB);
        long expected = 328;
        long actual = 0;
        int length = 5000000;
        genA.Check = 4;
        genB.Check = 8;

        for (int i = 0; i < length; i++)
        {
            genA.Generate2();
            genB.Generate2();
            if (Generator.Match(genA, genB))
            {
                actual++;
            }
        }
        Assert.Equal(expected, actual);
    }
}
