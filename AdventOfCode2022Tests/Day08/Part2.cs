using FluentAssertions;
using Xunit;

namespace AdventOfCode2022Tests.Day08
{
    public class Part2
    {
        [Fact]
        public void FindMaxScenicScoreOfAnEdge()
        {
            string[] trees = new string[]
            {
            "30373",
            };

            Forest forest = new(trees);

            int expectedMaxScenicScore = 0;

            int actualScenicScore = forest.FindMaxScenicScore();

            Assert.Equal(expectedMaxScenicScore, actualScenicScore);
        }

        [Fact]
        public void FindMaxScenicScoreOfAThreeByThreeForest()
        {
            string[] trees = new string[]
            {
            "303",
            "343",
            "343",
            };

            Forest forest = new(trees);

            int expectedMaxScenicScore = 1;

            int actualScenicScore = forest.FindMaxScenicScore();

            Assert.Equal(expectedMaxScenicScore, actualScenicScore);
        }

        [Fact]
        public void FindMaxScenicScoreOfATSimpleForest()
        {
            string[] trees = new string[]
            {
            "30373",
            "25512",
            "65332",
            "33549",
            "35390",
            };

            Forest forest = new(trees);

            int expectedMaxScenicScore = 8;

            int actualScenicScore = forest.FindMaxScenicScore();

            Assert.Equal(expectedMaxScenicScore, actualScenicScore);
        }


        [Fact]
        public void FindNumberOfTreesSeeOnLeft()
        {
            int[] rowArr = new[] { 9, 4, 5, 5, 7, 8 };

            int[] expectedNumberOfTreesSeen = new int[] { 0, 1, 2, 1, 4, 5 };
            List<int> actualNumberOfTreesSeen = new();
            for (int i = 0; i < rowArr.Length; i++)
            {
                actualNumberOfTreesSeen.Add(ForestHelper.FindNumberOfTreesSeenOnLeft(i, rowArr));
            }

            expectedNumberOfTreesSeen.Should().Equal(actualNumberOfTreesSeen.ToArray());
        }

        [Fact]
        public void FindNumberOfTreesSeeOnRight()
        {
            int[] rowArr = new[] { 8, 7, 5, 5, 4, 9 };

            int[] expectedNumberOfTreesSeen = new int[] { 5, 4, 1, 2, 1, 0 };
            List<int> actualNumberOfTreesSeen = new();
            for (int i = 0; i < rowArr.Length; i++)
            {
                actualNumberOfTreesSeen.Add(ForestHelper.FindNumberOfTreesSeenOnRight(i, rowArr));
            }

            expectedNumberOfTreesSeen.Should().Equal(actualNumberOfTreesSeen.ToArray());
        }

        [Fact]
        public void ExerciseSolution()
        {
            string filePath = @"TestFiles/Day08/ExerciseInput.txt";
            string[] trees = File.ReadAllLines(filePath);

            Forest forest = new(trees);

            int expectedMaxScenicScore = 536625;

            int actualScenicScore = forest.FindMaxScenicScore();

            Assert.Equal(expectedMaxScenicScore, actualScenicScore);
        }
    }
}
