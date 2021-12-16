using AdventCode2021;
using Xunit;

namespace DailyXunitTests
{
    public class Day16PaketDecoderTests
    {
        public const string Data = "2056FA18025A00A4F52AB13FAB6CDA779E1B2012DB003301006A35C7D882200C43289F07A5A192D200C1BC011969BA4A485E63D8FE4CC80480C00D500010F8991E23A8803104A3C425967260020E551DC01D98B5FEF33D5C044C0928053296CDAFCB8D4BDAA611F256DE7B945220080244BE59EE7D0A5D0E6545C0268A7126564732552F003194400B10031C00C002819C00B50034400A70039C009401A114009201500C00B00100D00354300254008200609000D39BB5868C01E9A649C5D9C4A8CC6016CC9B4229F3399629A0C3005E797A5040C016A00DD40010B8E508615000213112294749B8D67EC45F63A980233D8BCF1DC44FAC017914993D42C9000282CB9D4A776233B4BF361F2F9F6659CE5764EB9A3E9007ED3B7B6896C0159F9D1EE76B3FFEF4B8FCF3B88019316E51DA181802B400A8CFCC127E60935D7B10078C01F8B50B20E1803D1FA21C6F300661AC678946008C918E002A72A0F27D82DB802B239A63BAEEA9C6395D98A001A9234EA620026D1AE5CA60A900A4B335A4F815C01A800021B1AE2E4441006A0A47686AE01449CB5534929FF567B9587C6A214C6212ACBF53F9A8E7D3CFF0B136FD061401091719BC5330E5474000D887B24162013CC7EDDCDD8E5E77E53AF128B1276D0F980292DA0CD004A7798EEEC672A7A6008C953F8BD7F781ED00395317AF0726E3402100625F3D9CB18B546E2FC9C65D1C20020E4C36460392F7683004A77DB3DB00527B5A85E06F253442014A00010A8F9106108002190B61E4750004262BC7587E801674EB0CCF1025716A054AD47080467A00B864AD2D4B193E92B4B52C64F27BFB05200C165A38DDF8D5A009C9C2463030802879EB55AB8010396069C413005FC01098EDD0A63B742852402B74DF7FDFE8368037700043E2FC2C8CA00087C518990C0C015C00542726C13936392A4633D8F1802532E5801E84FDF34FCA1487D367EF9A7E50A43E90";

        [Fact]
        public void Day16_TestDecoder_GetBits_OK()
        {
            string hexInput = "D2FE28";
            //string expectedBinary = "110100101111111000101000";

            var sut = new PaketDecoder(hexInput);

            string actual = sut.GetBits(3);
            Assert.Equal("110", actual);
            actual = sut.GetBits(3);
            Assert.Equal("100", actual);
            actual = sut.GetBits(5);
            Assert.Equal("10111", actual);
            actual = sut.GetBits(5);
            Assert.Equal("11110", actual);
            actual = sut.GetBits(5);
            Assert.Equal("00101", actual);
            actual = sut.Flush();
            Assert.Equal("000", actual);
        }

        [Fact]
        public void Day16_TestDecoder_GetLiteralValuePaket_OK()
        {
            string hexInput = "D2FE28";

            var sut = new PaketDecoder(hexInput);

            var paket = sut.ParsePaket();
            LiteralValue lv = paket as LiteralValue;
            Assert.Equal(6, lv.Version);
            Assert.Equal(4, lv.TypeID);
            Assert.Equal(2021, lv.Value);
        }

        [Fact]
        public void Day16_TestDecoder_GetOperatorPaket0_OK()
        {
            string hexInput = "38006F45291200";

            var sut = new PaketDecoder(hexInput);

            var paket = sut.ParsePaket();
            OperatorPacket op = paket as OperatorPacket;
            Assert.NotNull(op);
            Assert.Equal(1, op.Version);
            Assert.Equal(6, op.TypeID);
            Assert.False(op.Iflag);
            OperatorLenBits olb = paket as OperatorLenBits;
            Assert.NotNull(olb);
            Assert.Equal(27, olb.LenBits);
            Assert.Equal(2, olb.Packets.Count);
        }

        [Fact]
        public void Day16_TestDecoder_GetOperatorPaket1_OK()
        {
            string hexInput = "EE00D40C823060";

            var sut = new PaketDecoder(hexInput);

            var paket = sut.ParsePaket();
            OperatorPacket op = paket as OperatorPacket;
            Assert.NotNull(op);
            Assert.Equal(7, op.Version);
            Assert.Equal(3, op.TypeID);
            Assert.True(op.Iflag);
            OperatorSubPackets olb = paket as OperatorSubPackets;
            Assert.NotNull(olb);
            Assert.Equal(3, olb.SubPackets);
            Assert.Equal(3, olb.Packets.Count);
        }

        [Theory]
        [InlineData("8A004A801A8002F478", 16)]
        [InlineData("620080001611562C8802118E34", 12)]
        [InlineData("C0015000016115A2E0802F182340", 23)]
        [InlineData("A0016C880162017C3686B18A3D4780", 31)]
        public void Day16_TestDecoder_VersionSums_OK(string hexInput, int expected)
        {
            var sut = new PaketDecoder(hexInput);

            sut.ParseAllPackets();
            int actual = sut.VersionSum();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Day16_Puzzle1_OK()
        {
            var sut = new PaketDecoder(Data);
            sut.ParseAllPackets();
            int actual = sut.VersionSum();
            Assert.Equal(917, actual);
        }

        [Theory]
        [InlineData("C200B40A82", 3)]
        [InlineData("04005AC33890", 54)]
        [InlineData("880086C3E88112", 7)]
        [InlineData("CE00C43D881120", 9)]
        [InlineData("D8005AC2A8F0", 1)]
        [InlineData("F600BC2D8F", 0)]
        [InlineData("9C005AC2F8F0", 0)]
        [InlineData("9C0141080250320F1802104A08", 1)]
        public void Day16_TestDecoder_Calculate_OK(string hexInput, long expected)
        {
            var sut = new PaketDecoder(hexInput);

            sut.ParseAllPackets();
            long actual = sut.Packets[0].GetValue();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Day16_Puzzle2_OK()
        {
            var sut = new PaketDecoder(Data);
            sut.ParseAllPackets();
            long actual = sut.Packets[0].GetValue();
            Assert.Equal(2536453523344, actual);
        }

    }
}
