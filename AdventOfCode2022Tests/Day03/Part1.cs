using Moq;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2022Tests.Day03
{
    public class Part1
    {
        private readonly ITestOutputHelper output;

        public Part1(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void RucksackHasItems()
        {
            string items = "vJrwpWtwJgWrhcsFMMfFFhFp";
            Rucksack rucksack = new(items);
        }

        [Fact]
        public void RucksackHasCompartments()
        {
            string compartment1Items = "abcd";
            string compartment2Items = "efgh";
            string items = compartment1Items + compartment2Items;

            Rucksack rucksack = new(items);

            Assert.True(compartment1Items.Equals(rucksack.Compartmant1));
            Assert.True(compartment2Items.Equals(rucksack.Compartmant2));
        }

        [Fact]
        public void CompartmentsDontHaveCommonItems()
        {
            string compartment1Items = "abcde";
            string compartment2Items = "fghij";
            string items = compartment1Items + compartment2Items;
            string commonItems = string.Empty;

            Rucksack rucksack = new(items);

            Assert.True(commonItems.Equals(rucksack.FindCommonItems()));
        }

        [Theory]
        [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", "L")]
        [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", "p")]
        public void CompartmentsHaveCommonItems(string items, string commonItems)
        {
            Rucksack rucksack = new(items);

            Assert.True(commonItems.Equals(rucksack.FindCommonItems()));
        }

        [Fact]
        public void RucksackCalculatesTotalPriorityOfCommonItems()
        {
            string compartment1Items = "abcde";
            string compartment2Items = "axcye";
            string items = compartment1Items + compartment2Items;

            Mock<IItemPriorityCalculator> itemValueCalculator = new();
            itemValueCalculator.Setup(i => i.CalculatePriority('a')).Returns(1);
            itemValueCalculator.Setup(i => i.CalculatePriority('c')).Returns(3);
            itemValueCalculator.Setup(i => i.CalculatePriority('e')).Returns(5);

            Rucksack rucksack = new(items, itemValueCalculator.Object);

            int expectedTotalPriority = 9;

            Assert.Equal(expectedTotalPriority, rucksack.CalculateTotalPriority());
        }

        [Fact]
        public void DefaultPriorityCalculatorImplementation()
        {
            IItemPriorityCalculator defaultPriorityCalculator = new DefaultPriorityCalculator();
            Dictionary<char, int> itemsToValues = new()
            {
                {'a',1 },
                {'z',26 },
                {'A',27 },
                {'Z',52},
                {'p',16 },
                {'L',38 }
            };

            foreach (KeyValuePair<char, int> itemToValue in itemsToValues)
            {
                Assert.Equal(itemToValue.Value, defaultPriorityCalculator.CalculatePriority(itemToValue.Key));
            }
        }

        [Fact]
        public void RucksackCalculatesTotalPriorityOfCommonItemsConceretePriorityCalculator()
        {
            IItemPriorityCalculator defaultPriorityCalculator = new DefaultPriorityCalculator();
            string items = "vJrwpWtwJgWrhcsFMMfFFhFp";

            Rucksack rucksack = new(items, defaultPriorityCalculator);
            int expectedPriority = 16;

            Assert.Equal(expectedPriority, rucksack.CalculateTotalPriority());
        }

        [Fact]
        public void ReadItemsFromFileSmallFile()
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

            int expectedTotalPriority = 157;

            int actualTotalPriority = 0;

            foreach (Rucksack rucksack in rucksacks)
            {
                actualTotalPriority += rucksack.CalculateTotalPriority();
            }

            Assert.Equal(expectedTotalPriority, actualTotalPriority);
        }

        [Fact]
        public void ExrciseSolution()
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

            int actualTotalPriority = 0;

            foreach (Rucksack rucksack in rucksacks)
            {
                actualTotalPriority += rucksack.CalculateTotalPriority();
            }

            output.WriteLine(actualTotalPriority.ToString());
        }
    }
}