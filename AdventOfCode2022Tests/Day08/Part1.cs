using Xunit;

namespace AdventOfCode2022Tests.Day08
{
    public class Part1
    {
        [Fact]
        public void ConvertStringArrayToIntMatrix()
        {
            string[] trees = new string[]
            {
            "30373",
            "25512",
            "65332",
            "33549",
            "35390",
            };

            int[,] expectedMatrix = new int[,]
            {
                { 3, 0, 3, 7, 3 },
                { 2, 5, 5, 1, 2},
                { 6, 5, 3, 3, 2},
                { 3, 3, 5, 4, 9},
                { 3, 5, 3, 9, 0},
            };

            int[,] actualMatrix = ForestHelper.ConvertStringArrToIntMatrix(trees);

            Assert.Equal(expectedMatrix, actualMatrix);
        }

        [Fact]
        public void FindVisibleTreesInOneDimArr()
        {
            int[] treeHeights = new int[] { 2, 4, 1, 3, 5 };

            bool[] expectedVisibilities = new bool[] { true, true, false, false, true };

            for (int i = 0; i < treeHeights.Length; i++)
            {
                bool actualVisibility = ForestHelper.IsVisibleInTheArr(i, treeHeights);
                Assert.Equal(expectedVisibilities[i], actualVisibility);
            }
        }

        [Fact]
        public void GetColumnValuesFrom2DArray()
        {
            int[,] treeHeights = new int[,]
            {
                { 3, 0},
                { 2, 5},
                { 6, 5},
                { 3, 3},
                { 3, 5},
            };

            int[] expectedFirstColumn = new int[]
            {
                3,2,6,3,3
            };

            int[] expectedSecondColumn = new int[]
            {
                0,5,5,3,5
            };

            int[] actualFirstColumn = ForestHelper.GetColumn(treeHeights, 0);
            int[] actualSecondColumn = ForestHelper.GetColumn(treeHeights, 1);

            Assert.Equal(expectedFirstColumn, actualFirstColumn);
            Assert.Equal(expectedSecondColumn, actualSecondColumn);
        }

        [Fact]
        public void FindNumberOfVisibleTrees()
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

            int expectedNumberOfVisibleTrees = 21;

            int actualNumberOfVisibleTrees = forest.FindNumOfVisibleTrees();

            Assert.Equal(expectedNumberOfVisibleTrees, actualNumberOfVisibleTrees);
        }

        [Fact]
        public void ExerciseSolution()
        {
            string filePath = @"TestFiles/Day08/ExerciseInput.txt";
            string[] trees = File.ReadAllLines(filePath);

            Forest forest = new(trees);

            int expectedNumberOfVisibleTrees = 1679;

            int actualNumberOfVisibleTrees = forest.FindNumOfVisibleTrees();

            Assert.Equal(expectedNumberOfVisibleTrees, actualNumberOfVisibleTrees);
        }
    }
}
