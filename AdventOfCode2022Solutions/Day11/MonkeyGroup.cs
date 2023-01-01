namespace AdventOfCode2022Tests.Day11
{
    //"Monkey 0:\r\n  " +
    //"Starting items: 52, 78, 79, 63, 51, 94\r\n  " +
    //"Operation: new = old * 13\r\n  " +
    //"Test: divisible by 5\r\n    " +
    //"If true: throw to monkey 1\r\n    " +
    //"If false: throw to monkey 6\r\n";

    public class MonkeyGroup
    {
        public int NumberOfMonkeys => monkeys.Count;

        public List<Monkey> monkeys = new();

        public MonkeyGroup(string[] lines)
        {
            List<int> divisors = GetAllDivisors(lines);

            foreach (string monkeyString in lines)
            {
                Monkey newMonkey = Monkey.Create(monkeyString, divisors);
                monkeys.Add(newMonkey);
            }
        }
        public void PlayOneRound(bool reduceValue = false)
        {
            foreach (Monkey monkey in monkeys)
            {
                while (monkey.Items.Count != 0)
                {
                    monkey.InspectNextItem(reduceValue);
                    int monkeyIdToThrow = monkey.GetCurrentItemsDestMonkeyId();
                    Item item = monkey.GetCurrentInspectingItem();
                    monkeys.Find(m => m.Id == monkeyIdToThrow).AddItem(item);
                }
            }
        }

        private List<int> GetAllDivisors(string[] lines)
        {
            List<int> divisors = new();

            foreach (string monkeyString in lines)
            {
                string[] infos = monkeyString.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
                int divisor = GetDivisor(infos[3]);
                divisors.Add(divisor);
            }

            return divisors;
        }

        //"Test: divisible by 5" 
        private int GetDivisor(string line)
        {
            string[] splittedLine = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            return int.Parse(splittedLine.Last());
        }

        public long GetMonkeyBussiness()
        {
            IOrderedEnumerable<Monkey> sortedMonkeys = monkeys.OrderByDescending(m => m.NumberOfInspectedItems);

            return sortedMonkeys.ElementAt(0).NumberOfInspectedItems * (long)sortedMonkeys.ElementAt(1).NumberOfInspectedItems;
        }
    }
}
