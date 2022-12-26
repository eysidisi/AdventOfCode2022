namespace AdventOfCode2022Tests.Day10
{
    abstract class Instruction
    {
        public abstract int CycleTime { get; }
        public abstract void Execute();

        internal static Instruction CreateAddx(ref Register register, int numberToAdd)
        {
            return new Addx(ref register, numberToAdd);
        }

        internal static Instruction CreateNoop()
        {
            return new Noop();
        }
    }
}
