namespace AdventOfCode2022Tests.Day10
{
    internal class Noop : Instruction
    {
        internal Noop()
        {
        }

        public override int CycleTime => 1;

        public override void Execute()
        {

        }
    }
}
