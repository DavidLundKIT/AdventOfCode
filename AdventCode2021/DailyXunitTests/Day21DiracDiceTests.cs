using AdventCode2021;
using Xunit;

namespace DailyXunitTests
{
    /// <summary>
    /// Real:
    /// Player 1 starting position: 6
    /// Player 2 starting position: 8
    /// </summary>
    public class Day21DiracDiceTests
    {
        [Fact]
        public void DiracDice_DeterminedTest_OK()
        {
            var sut = new DiracDice(4, 8);

            long actual = sut.GameDetermined();
            Assert.Equal(739785, actual);
        }

        [Fact]
        public void Day01_Puzzle1_OK()
        {
            var sut = new DiracDice(6, 8);

            long actual = sut.GameDetermined();
            Assert.Equal(757770, actual);
        }

        [Fact]
        public void DiracDice_QuantumTest_OK()
        {
            var sut = new DiracDice(4, 8);

            long actual = sut.GameQuantum();
            Assert.Equal(444356092776315, actual);
        }

        [Fact]
        public void Day01_Puzzle2_OK()
        {
            var sut = new DiracDice(6, 8);

            long actual = sut.GameQuantum();
            Assert.Equal(0, actual);
        }
    }
}
