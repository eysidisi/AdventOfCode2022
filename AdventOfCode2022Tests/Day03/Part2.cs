using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2022Tests.Day03
{
    public class Part2
    {
        private readonly ITestOutputHelper output;

        public Part2(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ElfGroupHasThreeRucksacks()
        {
            List<Rucksack> rucksacks = new() {
            new("vJrwpWtwJgWrhcsFMMfFFhFp"),
            new("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL"),
            new("PmmdzqPrVvPwwTWBwg"),
            };

            ElfGroup elfGroup = new(rucksacks);
        }

        [Fact]
        public void WeCanFindBadgeInElfGroup1()
        {
            List<Rucksack> rucksacks = new() {
            new("vJrwpWtwJgWrhcsFMMfFFhFp"),
            new("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL"),
            new("PmmdzqPrVvPwwTWBwg"),
            };

            ElfGroup elfGroup = new(rucksacks);
            char expectedBadge = 'r';

            char actualBadge = elfGroup.FindBadge();

            Assert.Equal(expectedBadge, actualBadge);
        }

        [Fact]
        public void WeCanFindBadgePriorityValueInElfGroup()
        {
            List<Rucksack> rucksacks = new() {
            new("vJrwpWtwJgWrhcsFMMfFFhFp"),
            new("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL"),
            new("PmmdzqPrVvPwwTWBwg"),
            };

            IItemPriorityCalculator defaultPriorityCalculator = new DefaultPriorityCalculator();

            ElfGroup elfGroup = new(rucksacks, defaultPriorityCalculator);
            int expectedBadegPriorityValue = 18;
            int actualBadgePriorityvalue = elfGroup.FindBadgePriorityValue();

            Assert.Equal(expectedBadegPriorityValue, actualBadgePriorityvalue);
        }

        [Fact]
        public void ReadElfGroupsFromFile()
        {
            string filePath = @"TestFiles/Day03/SmallFile.txt";
            string[] lines = File.ReadAllLines(filePath);
            IItemPriorityCalculator defaultPriorityCalculator = new DefaultPriorityCalculator();

            List<Rucksack> rucksacks = new();

            foreach (string items in lines)
            {
                Rucksack rucksack = new(items, defaultPriorityCalculator);
                rucksacks.Add(rucksack);
            }

            List<ElfGroup> elfGroups = new();
            List<Rucksack> rucksacksInGroup = new();
            int numberOfAggragatedRucksacks = 0;

            foreach (Rucksack rucksack in rucksacks)
            {
                if (numberOfAggragatedRucksacks == 3)
                {
                    elfGroups.Add(new ElfGroup(rucksacksInGroup, defaultPriorityCalculator));
                    rucksacksInGroup = new List<Rucksack>();
                    numberOfAggragatedRucksacks = 0;
                }
                rucksacksInGroup.Add(rucksack);
                numberOfAggragatedRucksacks++;
            }
            elfGroups.Add(new ElfGroup(rucksacksInGroup, defaultPriorityCalculator));

            int expectedTotalPriority = 70;

            int actualTotalPriority = 0;

            foreach (ElfGroup elfGroup in elfGroups)
            {
                actualTotalPriority += elfGroup.FindBadgePriorityValue();
            }

            Assert.Equal(expectedTotalPriority, actualTotalPriority);
        }

        [Fact]
        public void ExerciseSolution()
        {
            string filePath = @"TestFiles/Day03/ExerciseInput.txt";
            string[] lines = File.ReadAllLines(filePath);
            IItemPriorityCalculator defaultPriorityCalculator = new DefaultPriorityCalculator();

            List<Rucksack> rucksacks = new();

            foreach (string items in lines)
            {
                Rucksack rucksack = new(items, defaultPriorityCalculator);
                rucksacks.Add(rucksack);
            }

            List<ElfGroup> elfGroups = new();
            List<Rucksack> rucksacksInGroup = new();
            int numberOfAggragatedRucksacks = 0;

            foreach (Rucksack rucksack in rucksacks)
            {
                if (numberOfAggragatedRucksacks == 3)
                {
                    elfGroups.Add(new ElfGroup(rucksacksInGroup, defaultPriorityCalculator));
                    rucksacksInGroup = new List<Rucksack>();
                    numberOfAggragatedRucksacks = 0;
                }
                rucksacksInGroup.Add(rucksack);
                numberOfAggragatedRucksacks++;
            }
            elfGroups.Add(new ElfGroup(rucksacksInGroup, defaultPriorityCalculator));

            int actualTotalPriority = 0;

            foreach (ElfGroup elfGroup in elfGroups)
            {
                actualTotalPriority += elfGroup.FindBadgePriorityValue();
            }

            output.WriteLine(actualTotalPriority.ToString());
        }
    }
}
