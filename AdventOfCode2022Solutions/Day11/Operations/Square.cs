using AdventOfCode2022Solutions.Day11.Operations;

namespace AdventOfCode2022Tests.Day11
{
    internal class Square : Operation
    {
        public Square()
        {

        }
        public override long Execute(long itemValue)
        {
            return itemValue * itemValue;
        }
    }
}