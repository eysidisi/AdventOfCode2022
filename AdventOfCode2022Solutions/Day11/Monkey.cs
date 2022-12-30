using AdventOfCode2022Solutions.Day11.Operations;

namespace AdventOfCode2022Tests.Day11
{
    public class Monkey
    {
        public int Id { get; private set; }
        public List<long> ItemValues => new(itemValues);

        public int NumberOfInspectedItems { get; internal set; } = 0;

        private readonly Operation operation;
        private readonly Condition condition;
        private Queue<long> itemValues = new();

        public Monkey(Operation operation = null, Condition condition = null, int id = 0)
        {
            this.operation = operation;
            this.condition = condition;
            Id = id;
        }

        public void AddItem(long itemValue)
        {
            itemValues.Enqueue(itemValue);
        }

        public Item Throw()
        {
            NumberOfInspectedItems++;

            long itemValue = itemValues.Dequeue();
            long newValue = (long)Math.Floor(operation.Execute(itemValue) / 3.0);

            if (newValue % condition.DivisibleBy == 0)
                return new Item(newValue, condition.TrueConditionMonkeyId);
            else
                return new Item(newValue, condition.FalseConditionMonkeyId);
        }

        //"Monkey 0:\r\n  " +
        //"Starting items: 52, 78, 79, 63, 51, 94\r\n  " +
        //"Operation: new = old * 13\r\n  " +
        //"Test: divisible by 5\r\n    " +
        //"If true: throw to monkey 1\r\n    " +
        //"If false: throw to monkey 6\r\n";

        public static Monkey Create(string monkeyInfo)
        {
            string[] infos = monkeyInfo.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            int id = GetId(infos[0]);
            Queue<long> newMonkeyItemValues = GetItems(infos[1]);
            Operation operation = Operation.Create(infos[2]);
            Condition condition = Condition.Create(infos.TakeLast(3).ToArray());
            return new(operation, condition, id) { itemValues = newMonkeyItemValues };
        }

        private static Queue<long> GetItems(string line)
        {
            line = line.Replace("Starting items:", "");
            line = line.Replace(",", "");

            string[] parsedItemValues = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Queue<long> itemValues = new();

            foreach (string parsedItemValue in parsedItemValues)
            {
                itemValues.Enqueue(int.Parse(parsedItemValue));
            }

            return itemValues;
        }

        private static int GetId(string line)
        {
            string idWithColon = line.Split(" ")[1];
            string id = idWithColon.Substring(0, idWithColon.Length - 1);
            return int.Parse(id);
        }
    }
}
