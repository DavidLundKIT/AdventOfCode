namespace AdventCode2022.Models
{
    public class Monkey2
    {
        public static SortedList<int, Monkey2> Monkeys { get; set; } = new SortedList<int, Monkey2>();

        public int MonkeyID { get; set; }
        public Queue<long> Items { get; set; }
        public long WorryFactor { get; set; }
        public string WorryOperand { get; set; }
        public long TestFactor { get; set; }
        public int TestTrueMonkey { get; set; }
        public int TestFalseMonkey { get; set; }
        public long Inspections { get; set; }


        public Monkey2(int monkeyId, long[] items, string worryOperand, long worryFactor, long testFactor, int trueMonkey, int falseMonkey)
        {
            MonkeyID = monkeyId;
            Items = new Queue<long>();
            foreach (var item in items)
            {
                Items.Enqueue(item);
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
                long item = Items.Dequeue();
                Inspections++;
                long worryLevel = item;
                if (WorryOperand == "*")
                    worryLevel *= WorryFactor;
                if (WorryOperand == "+")
                    worryLevel += WorryFactor;
                if (WorryOperand == "old")
                    worryLevel *= item;

                // monkey bored
                //worryLevel = (int) Math.Floor(worryLevel/3.0);
                //worryLevel = (long)worryLevel / 3;

                if (worryLevel % TestFactor == 0)
                {
                    // true
                    Monkey2.Monkeys[TestTrueMonkey].Items.Enqueue(worryLevel);
                }
                else
                {
                    // false
                    Monkey2.Monkeys[TestFalseMonkey].Items.Enqueue(worryLevel);
                }
            }
        }

        public static void DoRound()
        {
            foreach (var kvp in Monkey2.Monkeys)
            {
                kvp.Value.DoTurn();
            }
        }

        public static long MonkeyBusiness()
        {
            var vals = Monkey2.Monkeys.Values.Select(m => m.Inspections).ToList().OrderByDescending(m => m).Take(2);
            long total = 1;
            foreach (var item in vals)
            {
                total *= item;
            }
            return total;
        }

        public static void InitTest()
        {
            Monkey2.Monkeys = new SortedList<int, Monkey2>
            {
                { 0, new Monkey2(0, new long[] { 79L, 98L }, "*", 19L, 23L, 2, 3) },
                { 1, new Monkey2(1, new long[] { 54L, 65L, 75L, 74L }, "+", 6L, 19L, 2, 0) },
                { 2, new Monkey2(2, new long[] { 79L, 60L, 97L }, "old", 0L, 13L, 1, 3) },
                { 3, new Monkey2(3, new long[] { 74L }, "+", 3L, 17L, 0, 1) }
            };
        }

        public static void InitPuzzle()
        {
            Monkey2.Monkeys = new SortedList<int, Monkey2>
            {
                { 0, new Monkey2(0, new long[] { 72, 64, 51, 57, 93, 97, 68 },        "*", 19, 17, 4, 7) },
                { 1, new Monkey2(1, new long[] { 62 },                                "*", 11, 3, 3, 2) },
                { 2, new Monkey2(2, new long[] { 57, 94, 69, 79, 72 },                "+", 6, 19, 0, 4) },
                { 3, new Monkey2(3, new long[] { 80, 64, 92, 93, 64, 56 },            "+", 5, 7, 2, 0) },
                { 4, new Monkey2(4, new long[] { 70, 88, 95, 99, 78, 72, 65, 94 },    "+", 7, 2, 7, 5) },
                { 5, new Monkey2(5, new long[] { 57, 95, 81, 61 },                    "old", 0, 5, 1, 6) },
                { 6, new Monkey2(6, new long[] { 79, 99 },                            "+", 2, 11, 3, 1) },
                { 7, new Monkey2(7, new long[] { 68, 98, 62 },                        "+", 3, 13, 5, 6) },
            };
        }
    }
}
