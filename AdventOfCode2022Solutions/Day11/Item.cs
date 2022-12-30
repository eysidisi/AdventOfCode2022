namespace AdventOfCode2022Tests.Day11
{
    public class Item
    {
        public long Value { get; }
        public int MonkeyToThrow { get; }

        public Item(long value, int monkeyToThrow)
        {
            Value = value;
            MonkeyToThrow = monkeyToThrow;
        }
    }
}
