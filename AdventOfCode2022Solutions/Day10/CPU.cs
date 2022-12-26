namespace AdventOfCode2022Tests.Day10
{
    public class CPU
    {
        Register registerX = new(1);
        List<int> registerXValuesInCycles = new();

        public CPU()
        {
        }

        public void ExecuteInstruction(string instructionString)
        {
            string[] splittedInstruction = instructionString.Split(" ");
            Instruction currentInstruction = null;

            if (instructionString == "noop")
            {
                currentInstruction = Instruction.CreateNoop();
            }

            else if (splittedInstruction[0] == "addx")
            {
                currentInstruction = Instruction.CreateAddx(ref registerX, int.Parse(splittedInstruction[1]));
            }

            for (int cycles = currentInstruction.CycleTime; cycles != 0; cycles--)
            {
                registerXValuesInCycles.Add(registerX.Value);
            }

            currentInstruction.Execute();
        }

        public int GetSignalStrengthInCycle(int cycleNumber)
        {
            return registerXValuesInCycles.ElementAt(cycleNumber - 1) * cycleNumber;
        }
    }
}
