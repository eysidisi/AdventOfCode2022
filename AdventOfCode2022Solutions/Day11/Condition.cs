namespace AdventOfCode2022Tests.Day11
{
    public class Condition
    {
        public Condition(int divisibleBy, int trueConditionMonkeyId, int falseConditionMonkeyId)
        {
            DivisibleBy = divisibleBy;
            TrueConditionMonkeyId = trueConditionMonkeyId;
            FalseConditionMonkeyId = falseConditionMonkeyId;
        }

        public int DivisibleBy { get; }
        public int TrueConditionMonkeyId { get; }
        public int FalseConditionMonkeyId { get; }

        public int GetMonkeyIdToThrow(Item item2)
        {
            return item2.GetRemainder(DivisibleBy) == 0 ? TrueConditionMonkeyId : FalseConditionMonkeyId;
        }

        //"Test: divisible by 5" "If true: throw to monkey 1"  "If false: throw to monkey 6";
        public static Condition Create(string[] splittedString)
        {
            string divisibleByString = splittedString[0].Split(" ", StringSplitOptions.RemoveEmptyEntries).Last();
            string trueConditionMonkeyId = splittedString[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Last();
            string falseConditionMonkeyId = splittedString[2].Split(" ", StringSplitOptions.RemoveEmptyEntries).Last();

            return new Condition(int.Parse(divisibleByString), int.Parse(trueConditionMonkeyId), int.Parse(falseConditionMonkeyId));
        }
    }
}
