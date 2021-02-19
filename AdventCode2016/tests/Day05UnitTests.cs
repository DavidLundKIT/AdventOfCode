using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.Encodings;
using System.Security.Cryptography;
using Xunit;

namespace tests
{
    public class Day05UnitTests
    {
        public string DoorID { get; set; }

        public Day05UnitTests()
        {
            DoorID = "uqwqemis";
        }

        [Theory]
        [InlineData("abc", 3231929, 1, "1")]
        [InlineData("abc", 5017308, 8, "8")]
        [InlineData("abc", 5278568, 15, "f")]
        public void Day05_GeneratePasswordHash(string doorId, long index, int passwordDigit, string pwdCh)
        {
            MD5 md5 = MD5.Create();
            string temp = string.Empty;
            string input = $"{doorId}{index}";
            byte[] inputBytes  = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            if (hash[0] == 0 && hash[1] == 0 && hash[2] < 16)
            {
                temp = hash[2].ToString("x");
            }
            Assert.Equal(passwordDigit, hash[2]);
            Assert.Equal(pwdCh, temp);
        }

        [Fact]
        public void Day05_GeneratePart1ExamplePassword()
        {
            string doorId = "abc";
            string expectedPassword = "18f";
            StringBuilder pwd = new StringBuilder();

            using (MD5 md5 = MD5.Create())
            {
                long index = 0;
                do
                {
                    index++;
                    string input = $"{doorId}{index}";
                    byte[] inputBytes  = Encoding.ASCII.GetBytes(input);
                    byte[] hash = md5.ComputeHash(inputBytes);
                    if (hash[0] == 0 && hash[1] == 0 && hash[2] < 16)
                    {
                        pwd.Append(hash[2].ToString("x"));
                    }
                } while (pwd.Length != 3);
            }
            Assert.Equal(expectedPassword, pwd.ToString());
        }

        //[Fact(Skip = "This is the answer to day 5 part 1. Takes 17s.")]
        [Fact]
        public void Day05_GeneratePart1DoorPassword()
        {
            string doorId = "uqwqemis";
            string expectedPassword = "1a3099aa";
            StringBuilder pwd = new StringBuilder();

            using (MD5 md5 = MD5.Create())
            {
                long index = 0;
                do
                {
                    index++;
                    string input = $"{doorId}{index}";
                    byte[] inputBytes  = Encoding.ASCII.GetBytes(input);
                    byte[] hash = md5.ComputeHash(inputBytes);
                    if (hash[0] == 0 && hash[1] == 0 && hash[2] < 16)
                    {
                        pwd.Append(hash[2].ToString("x"));
                    }
                } while (pwd.Length != 8);
            }
            Assert.Equal(expectedPassword, pwd.ToString());
        }

        [Theory]
        [InlineData("abc", 3231929, 1, "5")]
        [InlineData("abc", 5017308, 8, "")]
        [InlineData("abc", 5278568, 15, "")]
        [InlineData("abc", 5357525, 4, "e")]
        public void Day05_GeneratePasswordAndIndexHash(string doorId, long index, int passwordDigit, string pwdCh)
        {
            MD5 md5 = MD5.Create();
            string temp = string.Empty;
            string input = $"{doorId}{index}";
            byte[] inputBytes  = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            if (hash[0] == 0 && hash[1] == 0 && hash[2] < 16)
            {
                int idx = hash[2];
                if (idx > 7)
                {
                    temp = "";
                }
                else
                {
                    temp = hash[3].ToString("x2").Substring(0,1);
                }
            }
            Assert.Equal(passwordDigit, hash[2]);
            Assert.Equal(pwdCh, temp);
        }


        //[Fact(Skip = "Answer day 5 part 2 takes 20s.")]
        [Fact]
        public void Day05_GeneratePart2DoorPassword()
        {
            string doorId = "uqwqemis";
            string expectedPassword = "694190cd";
            string pwd = "qqqqqqqq";
            char[] pwdchs = pwd.ToCharArray();
            int ich = 0;
            int pwdLength = 0;

            using (MD5 md5 = MD5.Create())
            {
                long index = 0;
                do
                {
                    index++;
                    string input = $"{doorId}{index}";
                    byte[] inputBytes  = Encoding.ASCII.GetBytes(input);
                    byte[] hash = md5.ComputeHash(inputBytes);
                    if (hash[0] == 0 && hash[1] == 0 && hash[2] < 16)
                    {
                        ich = hash[2];
                        if (ich < 8 && pwdchs[ich] == 'q')
                        {
                            pwdchs[ich] = hash[3].ToString("x2").ToCharArray()[0];
                            pwdLength++;
                        }
                    }
                } while (pwdLength != 8);
            }
            StringBuilder pwdSb = new StringBuilder();
            foreach (var ch in pwdchs)
            {
                pwdSb.Append(ch);
            }
            Assert.Equal(expectedPassword, pwdSb.ToString());
        }

    }
}