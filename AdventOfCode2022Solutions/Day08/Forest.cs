namespace AdventOfCode2022Tests.Day08
{
    public class Forest
    {
        private int[,] treeHeights;

        public Forest(string[] trees)
        {
            treeHeights = ForestHelper.ConvertStringArrToIntMatrix(trees);
        }

        public int FindMaxScenicScore()
        {
            int maxScenicScore = 0;

            for (int rowIndex = 1; rowIndex < treeHeights.GetLength(0) - 1; rowIndex++)
            {
                for (int colIndex = 1; colIndex < treeHeights.GetLength(1) - 1; colIndex++)
                {
                    int[] rowArrOfTheTree = ForestHelper.GetRow(treeHeights, rowIndex);
                    int[] colArrOfTheTree = ForestHelper.GetColumn(treeHeights, colIndex);

                    int treesItCanSeeOnLeft = ForestHelper.FindNumberOfTreesSeenOnLeft(colIndex, rowArrOfTheTree);
                    int treesItCanSeeOnRight = ForestHelper.FindNumberOfTreesSeenOnRight(colIndex, rowArrOfTheTree);

                    int tresItCanSeeUp = ForestHelper.FindNumberOfTreesSeenOnLeft(rowIndex, colArrOfTheTree);
                    int treesItCanSeeDown = ForestHelper.FindNumberOfTreesSeenOnRight(rowIndex, colArrOfTheTree);

                    int scenicScore = treesItCanSeeOnLeft * treesItCanSeeOnRight * tresItCanSeeUp * treesItCanSeeDown;

                    maxScenicScore = Math.Max(maxScenicScore, scenicScore);
                }
            }

            return maxScenicScore;
        }

        public int FindNumOfVisibleTrees()
        {
            int numOfVisibleTrees = 0;

            for (int rowIndex = 1; rowIndex < treeHeights.GetLength(0) - 1; rowIndex++)
            {
                for (int colIndex = 1; colIndex < treeHeights.GetLength(1) - 1; colIndex++)
                {
                    int[] rowOfTheTree = ForestHelper.GetRow(treeHeights, rowIndex);
                    int[] columnOfTheTree = ForestHelper.GetColumn(treeHeights, colIndex);

                    if (ForestHelper.IsVisibleInTheArr(colIndex, rowOfTheTree) ||
                        ForestHelper.IsVisibleInTheArr(rowIndex, columnOfTheTree))
                        numOfVisibleTrees++;
                }
            }

            return numOfVisibleTrees + 2 * (treeHeights.GetLength(0) + treeHeights.GetLength(1)) - 4;
        }


    }
}
