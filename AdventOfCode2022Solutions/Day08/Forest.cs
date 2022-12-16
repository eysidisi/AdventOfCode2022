namespace AdventOfCode2022Tests.Day08
{
    public class Forest
    {
        private int[,] treeHeights;

        public Forest(string[] trees)
        {
            treeHeights = ForestHelper.ConvertStringArrToIntMatrix(trees);
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
