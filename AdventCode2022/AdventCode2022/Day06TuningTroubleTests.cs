namespace AdventCode2022
{
    public class Day06TuningTroubleTests
    {
        private string inputData = "qfmfhmhjmjggwbbvdvwvlvrrtsrsccwsslvlffjrrtprprjjvmmclmmghhddpvddclctcqtccgbgdbgdgsdgghqhtqtvvptvppwrwprpvrrrhpphththvhhrnnhnlnslnlhnhnhgnhnpnqqsmsgsllprlprrlzzqzffmzztctbtnbtthlttqvqcqmcmpcpbbczzbqbgghcghchhvwvllfrfnnbssfzsszpsplpglpprnpnfnbnhbnbtbzzvbvpbbhjjlzzbtbvbppczppbwppqwwnwlwccglgvgrgmmdwmwrmrppnfnhhhhqthqthqqrhrshhhqbhqqjgjvjllzvzbzhbbpttjsszvzqqtzzmbmddpldpdcdnccrmcrmmpwprplrrqssvddmpdmmwfwwlrljrrdsssmhsspnpffjggqllnzlnlhnnmddfrfpfbbvssjsrrznngcghgchcmhmrrrtzztjzzhchssslsmlmvvpwpqpjqjdddmsdmmtgtmgtglttfbbgrrcprrqffmmjnjttcmczzgbzggthhsttpggrmmgwwnpnqnqvnqvqppmlpmlpmpjpljljmmtpptfppfrppfdpfdppddmdttgzgzzdbzdzhzhnnsqssvmvbbpjjzwwvnwvvzmvzmzpmpttvrvccqddpgdppgmmthmthtggsfsbbvfbvfvhfvhvvpwpddqrqgqhghnnfmfbbwrbrgbgbvgbbdttffrddqbqpqzzmttlhhsqhsqhsqhhlplttpnpsstpthhpfhpfplprrgfrgffjppghgppghgdggjmmcgmccjvvsrvsrrwgrgmrrngrgttvbtbltthrthrttmfffjpfpssncnrngrrltrltlggjgcgllrzzllhwwjwrwgrgsrgrhrphrhhqwqsqmqlmqlmqmqrmrnnwnhwnhwhzwzjwwgbghhsjspszsznzfztfzfpzzlczztctsstctqtfqfqcfqqjrjccttmqqfpfdfnfwnffqbfbblpbpfpcfcwfccblbwwmqwqrrgprpccngnhghpppwmpplcppfrfjjgmmbzbhbcbzzgdgsdsvvqllzlppnfnlnlslsljlppcscqqfjjjwzwppfgfjjsvvsggjbjljpjpzjzrzjrzzfnfpnfpnfpnfnsnggmpggdllpmmrhhdqqppttgqqcsqsjsbjsjrsrqrbqqmbmcbmcbmbfmfvfqqdbdppmrprnrggmjjhnhbhdhbbfcbbcjjdhhwjwmjmssjswscswcwzccbgbqqmqgmmsdsjsbsdbsddvttjpppcqpcqcgqqslqsssczszrzvvrtvvjppswwhnnwlwtwhhwwzfwwpfpddlvvnvnnvlnntjtqjqjzzjttvvbqbhqbhbbbwnwhnwnppdbpdpvddrqdqjjlvlqqdfdhdjhdjdcjcrcjjggfmfvvfllvfvgglzllmhmzmdddfwddqjjqjfqfcfrrstrssptsstllrflfwwgswslwlbwbwjjvhvfvhfhffhsslwsllbnbblccbwwjqwqqdllrdrnrnffcbbqqpnqqdmdndtntvvrjvvsvmvgvnnmjlwgnjcwljgwnrwpqlztwrpmpgqtwlhrcwsrrhqhjhznrtpqfdnzbfqrzwslptdbdcnqvcllpjsfdvmzqwvzbpnmfcfcjnbmhtwhttjgtnczwctpdthhwmzvzrrgsnmbflgmszgsbvghbzgcmcmszgsbfmlmpbdspqlftmqrcjtmvgcrzznlfwjcbmddplsqrfflqnqfsldwhnncczdmfrrrsbjjqsdzrsgbdbwjbslfcqglsqfddhdsrcdrgqfqthgmfjvnfdfgdncfzpvqcpscnpmfgvqbfwszwzgmqvmcrdrwplfshdgqrchmccpqfznbmfvlhdpctlqgjslrwhjfjlmqfblgjrdlnzdtwlpwhnrhrcrpfwqpmjlgrdbgpbljntmbqlblqqqpgrnjtmjqvjpzvsqdpgtchmmwbhtmgcjqdplrtptqcvdjjpqdzsrcjhcwvdcghlwrdhtdfctmqfcjcqhcvvbzgsvlggcrdgqbtznwwmnbgsfrjprqgcmlswftlwpqqqvshdprldrsghmhrqvmqmvglbvzpvtrjbhcvhqmvdtcvsllznqzjmhpnlbhmlzthbwwhhvdtcdfdcdzhnbsrnqqjvzzsvfjhbsdlsbdlqjnlpnhfcjtdppzmphghltztzcdvzwbftbvwhvgmrllqfzrpbltptdtjjqtfwjfmczzgdvclqbsbftgtlhnhrrvbpvdltstdnhqvpvtjhmghptvsfnlspslmfsftzdrwljrgblgmcbmlszmhnlfdtmsrnjqwrfmsnfgpcqgzmlwppffrmbvhnlstfpgzwwmwffrqpdfvrspbczbrclwljgzfhpsrwwpdndfgjwbjtftnjrqvmtmzvjmtlmjhhptmgjvfrlzncmhnmpfcwpjbcpftqfzvmtldqhjpwvzrdnvnwnscgzslvfgjjpcvjshctmmpjbgdwtdjtlmztsbmwrjtmltnlsmwmjnpcgpprnfwcqdldbbqbfmdnvprzqwvntgzdbrsgdpgdjbcblmqpdphmwgvbgwlpblflphvjgjsjfshbjdftcqmsdnrzbgngcvddddjvrndhdcscqqswrnvslfrlvvncqjhzlbhdqhtrlvdsvjsbglhfzfphmzfmzqdvjqdwhjgfdwmzsdmbjzstjddfmfqjhmbdgdbvvhbqgstrzpvhpthhbwljczzrmvgsmbqvzdrmhvvjlmphzjfbmfqvwhtnrlfnfmqnnjvnwjswzshwgljmfjhrwbwgtpdqnqgqdzbssbjfbsgwmfzpfjdrtrnmsdffhnbgnrdlbjzfjrvtjgjgcvvzgllljrcrshczvpfqgnwnjjnhbwgvzwrptrgrdgtczjfzzndsqhqpmtqsvmcncfszsjllzzsjjmwgplpjwlhnhgbhctrttgzqbbcflzqvqgmhgdtlvfpbtncbwsjgnzpmbspcqzzwfplfprqlnbctwwrzpjtpfrmnpvnjrjppqrzjrcmggfmhrstzhmsjllcgjhwrbhcrvdvgmvjqqgmczlmhstmthzphlvrrvqmhjzzfzbhphstflhfjdlwqvzlsszctrdchwjssdfjjfzszlqdtwwthfjdqprpfftgdrpdhhcsdcpjbhdrgzwbgjspmffcmgcjnpmwsqwsvpfwzddlcpvlgpvctrssghndhvdmmmgndcjvhdjwttqphsjpgfbsdczmplfpwpzzjlbhrjptmsshfttnmhzdzmjctbltqjmfnpndqgwjzwdwrgdjdmcbtvjqwjngrtbfrwcttpdvcqtwqndznbchjqcqttrhjpjgwdbwzvwgmdsdfmpdwctvntvnsdmfnznfrsdcllpgpnstrrfrwrfrwnhbclnqhltrcdwqwzzldgbbtzmcvnbzmwcmntqpbscqrpzcjnbgbrzpcrcmdmdfsfgdpmgvwccqjrltrgfvjdgbhjndnmtnjjhzvghscdhnhflwplrqdzrnlnsvrtrdnphgqwjwqcjvtfdfshqdwbsvgrqbdlncjmhdmrlsvdnrhztznczzllsvpqlvwgqjvgvvwgrjcvtjvhrsgbdgvlmmtjbwrnftzphnqslcpggztgsdbjsbdtzwprsbcljpbwjhcrffnvtplcdlgmbtcgbllbdmwhwcllbqstnqqvdbcjrglwbmcfqvlvtpqncbspbphflvvrrsprlhqspfmqrsdtdlftsfzrqwdfffbhccvpfdtlptqzllfsbbrfnhjgwhlfcwmmjgjndcwfhdzvvvrzmwllthwsdmbbsrfrzmqnlnqnjnfpgfvrhsbzhjftmvzrzpqpmlcbnwmbssmvssmmqpvwnsjppdhmnhpntlvqmjnbmtvjnmtbpbzrcfhjfhvztnwrmthbswwthjddjmsdnjmzhhpjdllgscdrgmhfpljfzsmszqsqqgrznddhfmstzdcqpgztgwwqpvrghtmqlgdddlqqwwwtnpldbqtf";

        public Day06TuningTroubleTests()
        {

        }

        [Theory]
        [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
        [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
        [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
        [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
        [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
        public void FindFirstStartPacket_OK(string input, int expected)
        {
            int actual = FindFirstUniquePacket(input, 4);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TuningTroubles_Part1_OK()
        {
            int actual = FindFirstUniquePacket(inputData, 4);
            Assert.Equal(1598, actual);
        }

        [Theory]
        [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
        [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
        [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)]
        [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
        [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
        public void FindFirstStartMessage_OK(string input, int expected)
        {
            int actual = FindFirstUniquePacket(input, 14);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TuningTroubles_Part2_OK()
        {
            int actual = FindFirstUniquePacket(inputData, 14);
            Assert.Equal(2414, actual);
        }

        public int FindFirstUniquePacket(string input, int size)
        {
            for (int i = 0; i < input.Length - size; i++)
            {
                var hs = new HashSet<char>(input.Substring(i, size));
                if (hs.Count == size)
                    return i + size;
            }
            return -1;
        }
    }
}
