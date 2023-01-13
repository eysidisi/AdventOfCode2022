internal static class ListComparerHelpers
{
    public static List<string> GetItemsInList(string list)
    {
        list = RemoveParanthesis(list);

        List<string> result = new();

        for (int index = 0; index < list.Length; index++)
        {
            int endIndex;

            if (list[index] == '[')
            {
                endIndex = GetListEndingIndex(list, index);
            }

            else if (char.IsDigit(list[index]))
            {
                endIndex = GetIntegerEndingIndex(list, index);
            }

            else
            {
                throw new Exception("Invalid input!");
            }

            string newItem = list.Substring(index, endIndex - index);
            result.Add(newItem);
            index = endIndex;
        }

        return result;
    }

    private static int GetIntegerEndingIndex(string list, int index)
    {
        int endIndex = index + 1;
        while (endIndex < list.Length && char.IsDigit(list[endIndex]))
        {
            endIndex++;
        }

        return endIndex;
    }

    private static int GetListEndingIndex(string list, int startingIndex)
    {
        int recursiveLevel = 0;
        int endIndex = startingIndex + 1;

        while (recursiveLevel != 0 || list[endIndex] != ']')
        {
            if (list[endIndex] == '[')
            {
                recursiveLevel++;
            }

            else if (list[endIndex] == ']')
            {
                recursiveLevel--;
            }

            endIndex++;
        }

        return endIndex + 1;
    }

    public static int CalculateNumberOfItemsInList(string list)
    {
        list = RemoveParanthesis(list);

        if (string.IsNullOrEmpty(list))
        {
            return 0;
        }

        int recursiveListNum = 0;
        int numberOfElements = 1;

        for (int i = 0; i < list.Length; i++)
        {
            if (list[i] == '[')
            {
                recursiveListNum++;
            }

            if (list[i] == ',' && recursiveListNum == 0)
            {
                numberOfElements++;
            }

            if (list[i] == ']')
            {
                recursiveListNum--;
            }
        }

        return numberOfElements;
    }

    public static string CreateListFromNumber(int firstNum, int numberOfElements)
    {
        string newList2 = "[" + string.Join(",", Enumerable.Repeat(firstNum, numberOfElements));

        newList2 += "]";
        return newList2;
    }

    public static bool ItemIsList(string item)
    {
        return item[0] == '[';
    }

    public static string RemoveParanthesis(string str)
    {
        str = str.Remove(0, 1);
        str = str.Remove(str.Length - 1, 1);
        return str;
    }
}