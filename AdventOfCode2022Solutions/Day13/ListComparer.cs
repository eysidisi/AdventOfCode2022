namespace AdventOfCode2022Tests.Day13
{
    public class ListComparer
    {
        public bool? CompareLists(string list1, string list2)
        {
            List<string> itemsInList1 = ListComparerHelper.GetItemsInList(list1);
            List<string> itemsInList2 = ListComparerHelper.GetItemsInList(list2);

            if (itemsInList1.Count() == 0 && itemsInList2.Count() == 0)
            {
                return null;
            }

            if (itemsInList1.Count() == 0)
            {
                return true;
            }

            if (itemsInList2.Count() == 0)
            {
                return false;
            }

            for (int currentItemIndex = 0; currentItemIndex < itemsInList1.Count(); currentItemIndex++)
            {
                if (currentItemIndex >= itemsInList2.Count())
                {
                    return false;
                }

                string item1 = itemsInList1.ElementAt(currentItemIndex);
                string item2 = itemsInList2.ElementAt(currentItemIndex);
                bool? result = CompareItems(item1, item2);

                if (result == null)
                {
                    continue;
                }

                return result.Value;
            }

            if (itemsInList2.Count() > itemsInList1.Count())
            {
                return true;
            }

            return null;
        }

        private bool? CompareItems(string item1, string item2)
        {
            if (IsList(item1) && IsList(item2))
            {
                return CompareLists(item1, item2);
            }

            else if (IsList(item1))
            {
                int number = int.Parse(item2);
                string createdList2 = $"[{number}]";
                return CompareLists(item1, createdList2);
            }

            else if (IsList(item2))
            {
                int number = int.Parse(item1);
                string createdList1 = $"[{number}]";
                return CompareLists(createdList1, item2);
            }

            else
            {
                if (int.Parse(item2) > int.Parse(item1))
                {
                    return true;
                }

                else if (int.Parse(item2) < int.Parse(item1))
                {
                    return false;
                }
                else
                {
                    return null;
                }
            }
        }

        private bool IsList(string str)
        {
            return str[0] == '[';
        }
    }
}
