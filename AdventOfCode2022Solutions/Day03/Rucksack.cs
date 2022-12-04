namespace AdventOfCode2022Tests.Day03
{
    public class Rucksack
    {
        private string items;
        private IItemPriorityCalculator itemPriorityCalculator;

        public string Compartmant1 { get; internal set; }
        public string Compartmant2 { get; internal set; }


        public Rucksack(string items)
        {
            this.items = items;
            int halfLength = items.Length / 2;
            Compartmant1 = items.Substring(0, halfLength);
            Compartmant2 = items.Substring(halfLength);
        }

        public Rucksack(string items, IItemPriorityCalculator itemPriorityCalculator) : this(items)
        {
            this.itemPriorityCalculator = itemPriorityCalculator;
        }

        public string FindCommonItems()
        {
            HashSet<char> items = new();

            foreach (char item in Compartmant1)
            {
                items.Add(item);
            }

            List<char> commonItems = new();

            foreach (char item in Compartmant2)
            {
                if (items.Contains(item))
                    commonItems.Add(item);
            }

            return new string(commonItems.ToArray().Distinct().ToArray());
        }

        public int CalculateTotalPriority()
        {
            int totalPriority = 0;

            foreach (char item in FindCommonItems())
            {
                totalPriority += itemPriorityCalculator.CalculatePriority(item);
            }

            return totalPriority;
        }
    }
}