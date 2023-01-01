using AdventOfCode2022Solutions.Day11.Operations;

namespace AdventOfCode2022Tests.Day11
{
    public class Monkey
    {
        public int Id { get; private set; }
        public int NumberOfInspectedItems { get; internal set; } = 0;
        public Condition Condition { get; private set; }
        public IReadOnlyList<Item> Items => new List<Item>(items);

        private Queue<Item> items = new();
        private Item currentInspectingItem;
        private Operation operation;

        public void InspectNextItem(bool valueReduced)
        {
            NumberOfInspectedItems++;
            currentInspectingItem = items.Dequeue();
            currentInspectingItem.Execute(operation);
            if (valueReduced)
            {
                currentInspectingItem.Execute(new Division(3));
            }
        }

        public int GetCurrentItemsDestMonkeyId()
        {
            return Condition.GetMonkeyIdToThrow(currentInspectingItem);
        }

        public Item GetCurrentInspectingItem()
        {
            return currentInspectingItem;
        }

        public void AddItem(Item item)
        {
            items.Enqueue(item);
        }

        //"Monkey 0:\r\n  " +
        //"Starting items: 52, 78, 79, 63, 51, 94\r\n  " +
        //"Operation: new = old * 13\r\n  " +
        //"Test: divisible by 5\r\n    " +
        //"If true: throw to monkey 1\r\n    " +
        //"If false: throw to monkey 6\r\n";

        public static Monkey Create(string monkeyInfo, List<int> divisors)
        {
            string[] infos = monkeyInfo.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            int id = GetId(infos[0]);
            Operation operation = Operation.Create(infos[2]);
            Condition condition = Condition.Create(infos.TakeLast(3).ToArray());
            List<Item> items = Item.Create(infos[1]);
            divisors.ForEach(d => items.ForEach(i => i.AddDivisor(d)));

            Monkey monkey = new()
            {
                operation = operation,
                Condition = condition,
                Id = id,
                items = new Queue<Item>(items)
            };

            return monkey;
        }

        private static int GetId(string line)
        {
            string idWithColon = line.Split(" ")[1];
            string id = idWithColon.Substring(0, idWithColon.Length - 1);
            return int.Parse(id);
        }
    }
}
