using System.Numerics;

namespace AdventCode2022.Models
{
    internal class BigMonkey
    {
        public static SortedList<int, BigMonkey> Monkeys { get; set; } = new SortedList<int, BigMonkey>();

        public int MonkeyID { get; set; }
        public Queue<BigInteger> Items { get; set; }
        public BigInteger WorryFactor { get; set; }
        public string WorryOperand { get; set; }
        public BigInteger TestFactor { get; set; }
        public int TestTrueMonkey { get; set; }
        public int TestFalseMonkey { get; set; }
        public BigInteger Inspections { get; set; }


        public BigMonkey(int monkeyId, long[] items, string worryOperand, long worryFactor, long testFactor, int trueMonkey, int falseMonkey)
        {
            MonkeyID = monkeyId;
            Items = new Queue<BigInteger>();
            foreach (var item in items)
            {
                BigInteger bi = new BigInteger(item);
                Items.Enqueue(bi);
            }
            WorryFactor = worryFactor;
            WorryOperand = worryOperand;
            TestFactor = testFactor;
            TestTrueMonkey = trueMonkey;
            TestFalseMonkey = falseMonkey;
            Inspections = 0;
        }

        public void DoTurn()
        {
            while (Items.Count > 0)
            {
                BigInteger item = Items.Dequeue();
                Inspections++;
                BigInteger worryLevel = item;
                if (WorryOperand == "*")
                    worryLevel *= WorryFactor;
                if (WorryOperand == "+")
                    worryLevel += WorryFactor;
                if (WorryOperand == "old")
                    worryLevel *= item;

                // monkey bored

                if (worryLevel % TestFactor == 0)
                {
                    // true
                    BigMonkey.Monkeys[TestTrueMonkey].Items.Enqueue(worryLevel);
                }
                else
                {
                    // false
                    BigMonkey.Monkeys[TestFalseMonkey].Items.Enqueue(worryLevel);
                }
            }
        }

        public static void DoRound()
        {
            foreach (var kvp in BigMonkey.Monkeys)
            {
                kvp.Value.DoTurn();
            }
        }

        public static BigInteger MonkeyBusiness()
        {
            var vals = BigMonkey.Monkeys.Values.Select(m => m.Inspections).ToList().OrderByDescending(m => m).Take(2);
            BigInteger total = 1;
            foreach (var item in vals)
            {
                total *= item;
            }
            return total;
        }

        public static void InitTest()
        {
            BigMonkey.Monkeys = new SortedList<int, BigMonkey>
            {
                { 0, new BigMonkey(0, new long[] { 79, 98 }, "*", 19, 23, 2, 3) },
                { 1, new BigMonkey(1, new long[] { 54, 65, 75, 74 }, "+", 6, 19, 2, 0) },
                { 2, new BigMonkey(2, new long[] { 79, 60, 97 }, "old", 0, 13, 1, 3) },
                { 3, new BigMonkey(3, new long[] { 74 }, "+", 3, 17, 0, 1) }
            };
        }

        public static void InitPuzzle()
        {
            BigMonkey.Monkeys = new SortedList<int, BigMonkey>
            {
                { 0, new BigMonkey(0, new long[] { 72, 64, 51, 57, 93, 97, 68 },        "*", 19, 17, 4, 7) },
                { 1, new BigMonkey(1, new long[] { 62 },                                "*", 11, 3, 3, 2) },
                { 2, new BigMonkey(2, new long[] { 57, 94, 69, 79, 72 },                "+", 6, 19, 0, 4) },
                { 3, new BigMonkey(3, new long[] { 80, 64, 92, 93, 64, 56 },            "+", 5, 7, 2, 0) },
                { 4, new BigMonkey(4, new long[] { 70, 88, 95, 99, 78, 72, 65, 94 },    "+", 7, 2, 7, 5) },
                { 5, new BigMonkey(5, new long[] { 57, 95, 81, 61 },                    "old", 0, 5, 1, 6) },
                { 6, new BigMonkey(6, new long[] { 79, 99 },                            "+", 2, 11, 3, 1) },
                { 7, new BigMonkey(7, new long[] { 68, 98, 62 },                        "+", 3, 13, 5, 6) },
            };
        }
    }
}
