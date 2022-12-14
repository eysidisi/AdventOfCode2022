using FluentAssertions;
using System.Collections.ObjectModel;
using Xunit;

namespace AdventOfCode2022Tests.Day05
{
    public class Part2
    {
        [Fact]
        public void MoveCratesFromStacksUsingInputFile()
        {
            Stack stack1 = new();
            stack1.AddCreate('M');

            Stack stack2 = new();
            stack2.AddCreate('C');

            Stack stack3 = new();
            stack3.AddCreate('D');
            stack3.AddCreate('N');
            stack3.AddCreate('Z');
            stack3.AddCreate('P');

            List<Stack> expectedStacks = new()
            {
                stack1,
                stack2,
                stack3
            };

            string filePath = @"TestFiles/Day05/ShortInput.txt";

            Cargo cargo = new(filePath);

            cargo.CreateStacks();

            cargo.MoveCrates9001();

            ReadOnlyCollection<Stack> actualStacks = cargo.Stacks();

            for (int i = 0; i < expectedStacks.Count; i++)
            {
                expectedStacks.ElementAt(i).Crates().Should().BeEquivalentTo(actualStacks[i].Crates());
            }
        }

        [Fact]
        public void GetTopCratesUsingInputFile()
        {
            string filePath = @"TestFiles/Day05/ShortInput.txt";

            Cargo cargo = new(filePath);

            cargo.CreateStacks();

            cargo.MoveCrates9001();

            string expectedTopCrates = "MCD";

            string actualTopCrates = cargo.GetTopCrates();

            Assert.Equal(expectedTopCrates, actualTopCrates);
        }

        [Fact]
        public void ExerciseSolution()
        {
            string filePath = @"TestFiles/Day05/ExerciseInput.txt";

            Cargo cargo = new(filePath);

            cargo.CreateStacks();

            cargo.MoveCrates9001();

            string expectedTopCrates = "BLSGJSDTS";

            string actualTopCrates = cargo.GetTopCrates();

            Assert.Equal(expectedTopCrates, actualTopCrates);
        }

    }
}
