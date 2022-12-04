namespace AdventOfCode2022Tests.Day03
{
    internal class DefaultPriorityCalculator : IItemPriorityCalculator
    {
        const int StartingValueForLowerCase = 1;
        const int StartingValueForUpperCase = 27;

        public int CalculatePriority(char item)
        {
            if (char.IsUpper(item))
            {
                return (item - 'A') + StartingValueForUpperCase;
            }
            else
            {
                return (item - 'a') + StartingValueForLowerCase;
            }
        }
    }
}
;