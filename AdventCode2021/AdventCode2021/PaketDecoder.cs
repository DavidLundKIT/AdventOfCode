using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventCode2021
{
    public class PaketDecoder
    {
        public List<Packet> Packets { get; set; }
        public StringReader HexDigits { get; set; }
        public string BitBuffer { get; set; }
        public int BitCounter { get; set; }

        public PaketDecoder(string hexInputString)
        {
            HexDigits = new StringReader(hexInputString);
            Packets = new List<Packet>();
            BitCounter = 0;
            BitBuffer = string.Empty;
        }

        public string GetBits(int numBits)
        {
            string sval;
            while (BitBuffer.Length < numBits)
            {
                char ch = (char)HexDigits.Read();
                sval = Convert.ToString(Convert.ToInt32(ch.ToString(), 16), 2).PadLeft(4, '0');
                BitBuffer = string.Concat(BitBuffer, sval);
            }
            sval = BitBuffer.Substring(0, numBits);
            BitBuffer = BitBuffer.Remove(0, numBits);
            BitCounter += numBits;
            return sval;
        }

        public string Flush()
        {
            return BitBuffer;
        }

        public void ParseAllPackets()
        {
            try
            {
                while (HexDigits.Peek() != -1)
                {
                    Packet p = ParsePaket();
                    Packets.Add(p);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public Packet ParsePaket()
        {
            int ver = Convert.ToInt32(GetBits(3), 2);
            int typ = Convert.ToInt32(GetBits(3), 2);
            Packet paket = PaketFactory(ver, typ);
            return paket;
        }

        public Packet PaketFactory(int ver, int typ)
        {
            if (typ == 4)
            {
                long val = ParseLiteralValue();
                LiteralValue lv = new LiteralValue(ver, typ, val);
                return lv;
            }
            // operator paket
            bool iflag = (GetBits(1) == "1");
            if (!iflag)
            {
                int lenBits = Convert.ToInt32(GetBits(15), 2);
                OperatorLenBits olb = new OperatorLenBits(ver, typ, iflag, lenBits);
                int maxBits = lenBits + BitCounter;
                while (BitCounter < maxBits)
                {
                    Packet p = ParsePaket();
                    olb.Packets.Add(p);
                }
                return olb;
            }
            int subPackCount = Convert.ToInt32(GetBits(11), 2);
            OperatorSubPackets osp = new OperatorSubPackets(ver, typ, iflag, subPackCount);
            for (int i = 0; i < subPackCount; i++)
            {
                Packet p = ParsePaket();
                osp.Packets.Add(p);
            }
            return osp;
        }

        private long ParseLiteralValue()
        {
            StringBuilder sb = new StringBuilder();
            bool done = false;
            do
            {
                string buf = GetBits(5);
                done = ('0' == buf[0]);
                sb.Append(buf.Substring(1, 4));
            } while (!done);
            long val = Convert.ToInt64(sb.ToString(), 2);
            return val;
        }

        public int VersionSum()
        {
            int sum = 0;
            foreach (var p in Packets)
            {
                sum += p.VersionSum();
            }
            return sum;
        }
    }

    public abstract class Packet
    {
        public int Version { get; set; }
        public int TypeID { get; set; }
        public abstract int VersionSum();
        public abstract long GetValue();

        public Packet(int ver, int typ)
        {
            Version = ver;
            TypeID = typ;
        }
    }

    public class LiteralValue : Packet
    {
        public long Value { get; set; }

        public LiteralValue(int ver, int typ, long val)
            : base(ver, typ)
        {
            Value = val;
        }

        public override int VersionSum()
        {
            return Version;
        }

        public override long GetValue()
        {
            return Value;
        }
    }

    public abstract class OperatorPacket : Packet
    {
        public bool Iflag { get; set; }
        public List<Packet> Packets { get; set; }

        public OperatorPacket(int ver, int typ, bool iflag)
            : base(ver, typ)
        {
            Packets = new List<Packet>();
            Iflag = iflag;
        }

        public override int VersionSum()
        {
            int sum = Version;
            foreach (var p in Packets)
            {
                sum += p.VersionSum();
            }
            return sum;
        }
        public override long GetValue()
        {
            long val = 0;

            switch (TypeID)
            {
                case 0:
                    // sum
                    val = Packets.Sum(p => p.GetValue());
                    break;
                case 1:
                    // product
                    val = 1;
                    val = Packets.Aggregate(val, (total, next) => total *= next.GetValue());
                    break;
                case 2:
                    // min
                    val = Packets.Min(p => p.GetValue());
                    break;
                case 3:
                    // min
                    val = Packets.Max(p => p.GetValue());
                    break;
                case 5:
                    // greater than
                    val = (Packets[0].GetValue() > Packets[1].GetValue()) ? 1 : 0;
                    break;
                case 6:
                    // less than
                    val = (Packets[0].GetValue() < Packets[1].GetValue()) ? 1 : 0;
                    break;
                case 7:
                    // equal
                    val = (Packets[0].GetValue() == Packets[1].GetValue()) ? 1 : 0;
                    break;
                default:
                    break;
            }
            return val;
        }
    }

    public class OperatorLenBits : OperatorPacket
    {
        public int LenBits { get; set; }
        public OperatorLenBits(int ver, int typ, bool iflag, int lenBits)
            : base(ver, typ, iflag)
        {
            LenBits = lenBits;
        }
    }

    public class OperatorSubPackets : OperatorPacket
    {
        public int SubPackets { get; set; }
        public OperatorSubPackets(int ver, int typ, bool iflag, int num)
            : base(ver, typ, iflag)
        {
            SubPackets = num;
        }
    }
}
