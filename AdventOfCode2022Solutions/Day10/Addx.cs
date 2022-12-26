namespace AdventOfCode2022Tests.Day10
{
    internal class Addx : Instruction
    {
        private readonly int numberToAdd;
        private Register register;

        internal Addx(ref Register register, int numberToAdd)
        {
            this.register = register;
            this.numberToAdd = numberToAdd;
        }

        public override int CycleTime => 2;

        public override void Execute()
        {
            register.Value = register.Value + numberToAdd;
        }
    }
}
