using FluentAssertions;
using System.Collections.ObjectModel;
using Xunit;

namespace AdventOfCode2022Tests.Day05
{
    public class Part1
    {
        [Fact]
        public void StacksHaveCrates()
        {
            Stack stack = new();
            stack.AddCreate('A');
        }

        [Fact]
        public void CratesCanBeMovedFromOneStackToOther()
        {
            Stack stack1 = new();
            stack1.AddCreate('A');
            Stack stack2 = new();
            stack1.MoveCratesToOtherStack(1, stack2);

            List<char> expectedCreatesInStack2 = new()
            {'A' };

            expectedCreatesInStack2.Should().BeEquivalentTo(stack2.Crates());
        }

        [Fact]
        public void WeCanViewTopCratesInStacks()
        {
            Stack stack = new();
            stack.AddCreate('A');
            stack.AddCreate('B');

            Assert.Equal('B', stack.TopCrate);
        }

        [Fact]
        public void InitializeStacksUsingInputFile()
        {
            Stack stack1 = new();
            stack1.AddCreate('Z');
            stack1.AddCreate('N');

            Stack stack2 = new();
            stack2.AddCreate('M');
            stack2.AddCreate('C');
            stack2.AddCreate('D');

            Stack stack3 = new();
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

            ReadOnlyCollection<Stack> actualStacks = cargo.Stacks();

            for (int i = 0; i < expectedStacks.Count; i++)
            {
                expectedStacks.ElementAt(i).Crates().Should().Equal(actualStacks[i].Crates());
            }
        }

        [Fact]
        public void MoveCratesFromStacksUsingInputFile()
        {
            Stack stack1 = new();
            stack1.AddCreate('C');

            Stack stack2 = new();
            stack2.AddCreate('M');

            Stack stack3 = new();
            stack3.AddCreate('P');
            stack3.AddCreate('D');
            stack3.AddCreate('N');
            stack3.AddCreate('Z');

            List<Stack> expectedStacks = new()
            {
                stack1,
                stack2,
                stack3
            };

            string filePath = @"TestFiles/Day05/ShortInput.txt";

            Cargo cargo = new(filePath);

            cargo.CreateStacks();

            cargo.MoveCrates();

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

            cargo.MoveCrates();

            string expectedTopCrates = "CMZ";

            string actualTopCrates = cargo.GetTopCrates();

            Assert.Equal(expectedTopCrates, actualTopCrates);
        }

        [Fact]
        public void ExerciseSolution()
        {
            string filePath = @"TestFiles/Day05/ExerciseInput.txt";

            Cargo cargo = new(filePath);

            cargo.CreateStacks();

            cargo.MoveCrates();

            string expectedTopCrates = "WCZTHTMPS";

            string actualTopCrates = cargo.GetTopCrates();

            Assert.Equal(expectedTopCrates, actualTopCrates);
        }
    }
}
