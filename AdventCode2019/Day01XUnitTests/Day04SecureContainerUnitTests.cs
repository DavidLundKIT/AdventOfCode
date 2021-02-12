using Xunit;

namespace AdventOfCode2019XUnitTests
{
    public class Day04SecureContainerUnitTests
    {
         [Fact]
        public void Day04_CheckPwd_111111_Ok()
        {
            int pwd = 111111;
            bool actual = CheckPassword(pwd);
            Assert.True(actual);
        }

        [Fact]
        public void Day04_CheckPwd_223450_Ok()
        {
            int pwd = 223450;
            bool actual = CheckPassword(pwd);
            Assert.False(actual);
        }

        [Fact]
        public void Day04_CheckPwd_123789_Ok()
        {
            int pwd = 123789;
            bool actual = CheckPassword(pwd);
            Assert.False(actual);
        }

        [Fact]
        public void Day04_CheckPwd2_112233_Ok()
        {
            int pwd = 112233;
            bool actual = CheckPassword2(pwd);
            Assert.True(actual);
        }

        [Fact]
        public void Day04_CheckPwd2_123444_Ok()
        {
            int pwd = 123444;
            bool actual = CheckPassword2(pwd);
            Assert.False(actual);
        }

        [Fact]
        public void Day04_CheckPwd2_111122_Ok()
        {
            int pwd = 111122;
            bool actual = CheckPassword2(pwd);
            Assert.True(actual);
        }

        [Fact]
        public void Day04Part1_TestSolution()
        {
            int okPwds = 0;

            for (int pwd = 134564; pwd <= 585159; pwd++)
            {
                if (CheckPassword(pwd))
                {
                    okPwds++;
                }
            }

            Assert.Equal(1929, okPwds);
        }


        [Fact]
        public void Day04Part2_TestSolution()
        {
            int okPwds = 0;

            for (int pwd = 134564; pwd <= 585159; pwd++)
            {
                if (CheckPassword2(pwd))
                {
                    okPwds++;
                }
            }

            Assert.Equal(1306, okPwds);
        }
        private bool CheckPassword(int pwd)
        {
            bool hasDouble = false;
            string spwd = pwd.ToString();

            char[] chars = spwd.ToCharArray();
            for (int idx = 0; idx < chars.Length - 1; idx++)
            {
                if (chars[idx].CompareTo(chars[idx + 1]) > 0)
                {
                    return false;
                }
                if (chars[idx].CompareTo(chars[idx + 1]) == 0)
                {
                    hasDouble = true;
                }
            }
            return hasDouble;
        }

        private bool CheckPassword2(int pwd)
        {
            string spwd = pwd.ToString();

            char[] chars = spwd.ToCharArray();
            for (int idx = 0; idx < chars.Length - 1; idx++)
            {
                if (chars[idx].CompareTo(chars[idx + 1]) > 0)
                {
                    // not increasing
                    return false;
                }
            }

            bool validDouble = false;
            bool hasDouble = false;
            char dch = ' ';
            int didx = -1;
            for (int idx = 0; idx < chars.Length - 1; idx++)
            {
                if (chars[idx].CompareTo(chars[idx + 1]) == 0)
                {
                    if (!hasDouble)
                    {
                        //
                        hasDouble = true;
                        dch = chars[idx];
                        didx = idx;
                    }
                    else
                    {
                        // already had a double

                    }
                }
                else
                {
                    // not a match
                    if (hasDouble)
                    {
                        if (didx == idx -1)
                        {
                            validDouble = true;
                        }
                    }
                    hasDouble = false;
                    dch = ' ';
                    didx = -1;
                }
            }
            if (hasDouble && didx == 4)
            {
                validDouble = true;
            }

            return validDouble;
        }

    }
}
