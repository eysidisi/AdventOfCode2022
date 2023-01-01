using AdventOfCode2022Solutions.Day11.Operations;

namespace AdventOfCode2022Tests.Day11
{
    public class Item
    {
        Dictionary<int, int> divisorToRemainings = new();

        public Item(int value)
        {
            Value = value;
        }

        public int Value { get; }

        internal static List<Item> Create(string line)
        {
            line = line.Replace("Starting items:", "");
            line = line.Replace(",", "");

            string[] parsedItemValues = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            List<Item> items = new();

            foreach (string parsedItemValue in parsedItemValues)
            {
                items.Add(new(int.Parse(parsedItemValue)));
            }

            return items;
        }

        public void AddDivisor(int newDivisor)
        {
            divisorToRemainings.Add(newDivisor, Value % newDivisor);
        }

        public void Execute(Operation operation)
        {
            Dictionary<int, int> newDivisorToRemainings = new();

            foreach (KeyValuePair<int, int> divisorToRemaining in divisorToRemainings)
            {
                int newRemaining = ((int)operation.Execute(divisorToRemaining.Value) % divisorToRemaining.Key);
                newDivisorToRemainings.Add(divisorToRemaining.Key, newRemaining);
            }
            divisorToRemainings = newDivisorToRemainings;
        }

        public int GetRemainder(int divisor)
        {
            return divisorToRemainings[divisor];
        }
    }
}
