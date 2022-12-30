namespace AdventOfCode2022Solutions.Day11.Operations
{
    public class Multiplication : Operation
    {
        public Multiplication(int number) : base(number)
        {
        }

        public override long Execute(long itemValue)
        {
            return Number * itemValue;
        }
    }
}
