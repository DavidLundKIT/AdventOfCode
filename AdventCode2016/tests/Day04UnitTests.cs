using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using Xunit;

namespace tests
{
    public class Day04UnitTests
    {
        private const string _indatafile = @"C:\Repos\AdventOfCode\Advent2016\data\day04.txt";
        private const string _outdatafile = @"C:\Repos\AdventOfCode\Advent2016\data\day04out.txt";

        [Fact]
        public void Day04ValidRoomSumPart1()
        {
            var rooms = File.ReadAllLines(_indatafile);
            Assert.Equal(991, rooms.Length);

            int totalSectorID = 0;

            foreach (var room in rooms)
            {
                if(!string.IsNullOrWhiteSpace(room))
                {
                    totalSectorID += CheckValidRoom(room);
                }
            }
            Assert.Equal(278221, totalSectorID);
        }

        [Theory]
        [InlineData("aaaaa-bbb-z-y-x-123[abxyz]", true, 123)]
        [InlineData("a-b-c-d-e-f-g-h-987[abcde]", true, 987)]
        [InlineData("not-a-real-room-404[oarel]", true, 404)]
        [InlineData("totally-real-room-200[decoy]", false, 0)]
        public void CheckValidRoomExamples(string room, bool isValid, int sectorId)
        {
            int actual = CheckValidRoom(room);
            Assert.Equal(isValid, (actual> 0));
            Assert.Equal(sectorId, actual);
        }

        [Fact]
        public void Day04ValidRoomNamesPart2()
        {
            string roomName;
            string expectedRoomName = "northpole object storage";
            int totalSectorID = 0;
            int sectorId;
            var rooms = File.ReadAllLines(_indatafile);
            using (var roomNames = File.CreateText(_outdatafile))
            {
                Assert.Equal(991, rooms.Length);

                foreach (var room in rooms)
                {
                    if(!string.IsNullOrWhiteSpace(room))
                    {
                        sectorId = CheckValidRoom(room);
                        if (sectorId > 0)
                        {
                            totalSectorID += sectorId;
                            roomName = DecryptRoomName(room, sectorId);
                            roomNames.WriteLine(roomName);
                            if (string.Equals(expectedRoomName, roomName))
                            {
                                Assert.Equal(267, sectorId);
                            }
                        }
                    }
                }
                roomNames.Flush();
                roomNames.Close();
            }
            Assert.Equal(278221, totalSectorID);
        }

        [Fact]
        public void Day04Part2DecryptRoomName()
        {
            string room = "qzmt-zixmtkozy-ivhz-343";
            int sectorId = 343;
            string expectedRoomName = "very encrypted name";
            string roomName = DecryptRoomName(room, sectorId);

            Assert.Equal(expectedRoomName, roomName);
        }

        public string DecryptRoomName(string room, int sectorId)
        {
            int chOffset = sectorId % 26;
            string [] parts = room.Split("-");
            StringBuilder roomName = new StringBuilder();
            for (int i = 0; i < parts.Length - 1; i++)
            {
                char[] chs = parts[i].ToCharArray();
                foreach (var ch in chs)
                {
                    int ich = ((((int)ch - (int)'a') + chOffset) % 26) + (int)'a';
                    char chNew = (char)ich;
                    roomName.Append(chNew);
                }
                roomName.Append(" ");
            }

            return roomName.ToString().Trim();
        }

        public int CheckValidRoom(string room)
        {
            SortedDictionary<char, int> letterDict = new SortedDictionary<char, int>();
            string [] parts = room.Split("-");
            int braceIndex = parts[parts.Length - 1].IndexOf("[");
            string checksum = parts[parts.Length - 1].Substring(braceIndex+1, parts[parts.Length - 1].Length - (braceIndex + 2));
            int sectorId = int.Parse(parts[parts.Length -1].Substring(0, braceIndex));

            for (int i = 0; i < parts.Length - 1; i++)
            {
                char[] letters = parts[i].ToCharArray();
                foreach (char ch in letters)
                {
                    if (letterDict.ContainsKey(ch))
                    {
                        letterDict[ch]++;
                    }
                    else
                    {
                        letterDict.Add(ch, 1);
                    }
                }
            }
            List<int> letterCounts = new List<int>( letterDict.Values);
            letterCounts.Sort();
            List<int> max5letters = letterCounts.TakeLast(5).Reverse().ToList();
            StringBuilder calcCheckSum= new StringBuilder();

            for (int i = 0; i < 5; i++)
            {
                foreach (var item in letterDict)
                {
                    if (item.Value == max5letters[i])
                    {
                        calcCheckSum.Append(item.Key);
                        letterDict.Remove(item.Key);
                        break;
                    }
                }
            }

            if (string.Equals(checksum, calcCheckSum.ToString()))
            {
                return sectorId;
            }

            return 0;
        }

    }
}