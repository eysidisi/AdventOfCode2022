namespace AdventOfCode2022Tests.Day03
{
    public class ElfGroup
    {
        private List<Rucksack> rucksacks;
        private IItemPriorityCalculator priorityCalculator;

        public ElfGroup(List<Rucksack> rucksacks)
        {
            this.rucksacks = rucksacks;
        }

        public ElfGroup(List<Rucksack> rucksacks, IItemPriorityCalculator priorityCalculator) : this(rucksacks)
        {
            this.priorityCalculator = priorityCalculator;
        }

        public char FindBadge()
        {
            List<HashSet<char>> uniqueItemsInRucksacks = new();
            foreach (Rucksack rucksack in rucksacks)
            {
                HashSet<char> uniqueItems = rucksack.FindUniqueItems();
                uniqueItemsInRucksacks.Add(uniqueItems);
            }

            foreach (char itemInRucksack1 in uniqueItemsInRucksacks.First())
            {
                if (uniqueItemsInRucksacks.All(items => items.Contains(itemInRucksack1)))
                    return itemInRucksack1;
            }

            throw new Exception("No badge presents!");
        }

        public int FindBadgePriorityValue()
        {
            char badge = FindBadge();

            return priorityCalculator.CalculatePriority(badge);
        }
    }
}
