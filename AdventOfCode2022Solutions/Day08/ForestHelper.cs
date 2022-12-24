namespace AdventOfCode2022Tests.Day08
{
    public class ForestHelper
    {
        public static int[,] ConvertStringArrToIntMatrix(string[] strArr)
        {
            int numberOfColums = strArr[0].Length;
            int numberOfRows = strArr.Count();

            int[,] intArr = new int[numberOfRows, numberOfColums];

            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColums; j++)
                {
                    string element = strArr[i].ElementAt(j).ToString();
                    intArr[i, j] = int.Parse(element);
                }
            }

            return intArr;
        }
        public static bool IsVisibleInTheArr(int treeIndex, int[] treeHeights)
        {
            if (treeIndex == 0 || treeIndex == treeHeights.Length - 1)
                return true;

            bool isTreeVisibleFromLeft = IsTreeVisibleFromLeft(treeIndex, treeHeights);

            if (isTreeVisibleFromLeft == true)
                return true;

            bool isTreeVisibleFromRight = IsTreeVisibleFromRight(treeIndex, treeHeights);

            if (isTreeVisibleFromRight == true)
                return true;

            return false;
        }

        private static bool IsTreeVisibleFromLeft(int treeIndex, int[] treeHeights)
        {
            for (int i = 0; i < treeIndex; i++)
            {
                if (treeHeights[i] >= treeHeights[treeIndex])
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsTreeVisibleFromRight(int treeIndex, int[] treeHeights)
        {
            for (int i = treeIndex + 1; i < treeHeights.Length; i++)
            {
                if (treeHeights[i] >= treeHeights[treeIndex])
                {
                    return false;
                }
            }

            return true;
        }

        public static int[] GetColumn(int[,] treeHeights, int columnIndex)
        {
            List<int> result = new();

            for (int rowIndex = 0; rowIndex < treeHeights.GetLength(0); rowIndex++)
            {
                result.Add(treeHeights[rowIndex, columnIndex]);
            }

            return result.ToArray();
        }

        public static int[] GetRow(int[,] treeHeights, int rowIndex)
        {
            List<int> result = new();

            for (int colIndex = 0; colIndex < treeHeights.GetLength(1); colIndex++)
            {
                result.Add(treeHeights[rowIndex, colIndex]);
            }

            return result.ToArray();
        }

        public static int FindNumberOfTreesSeenOnLeft(int treeIndex, int[] treeArr)
        {
            int treeHeight = treeArr[treeIndex];

            int numberOfTreesSeen = 0;

            for (int i = treeIndex - 1; 0 <= i; i--)
            {
                numberOfTreesSeen++;

                if (treeArr[i] >= treeHeight)
                    break;
            }

            return numberOfTreesSeen;
        }

        public static int FindNumberOfTreesSeenOnRight(int treeIndex, int[] treeArr)
        {
            int treeHeight = treeArr[treeIndex];

            int numberOfTreesSeen = 0;

            for (int i = treeIndex + 1; i < treeArr.Length; i++)
            {
                numberOfTreesSeen++;

                if (treeArr[i] >= treeHeight)
                    break;
            }

            return numberOfTreesSeen;
        }
    }

}
