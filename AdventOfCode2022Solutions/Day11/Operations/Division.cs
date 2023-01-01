namespace AdventOfCode2022Solutions.Day11.Operations
{
    public class Division : Operation
    {
        public Division(int number) : base(number)
        {
        }

        public override int Execute(int itemValue)
        {
            return itemValue % Number;
        }
    }
}
