using AdventOfCode2022Solutions.Day11.Operations;

namespace AdventOfCode2022Tests.Day11
{
    public class Square : Operation
    {
        public Square() : base(0)
        {

        }

        public override int Execute(int itemValue)
        {
            return itemValue * itemValue;
        }
    }
}