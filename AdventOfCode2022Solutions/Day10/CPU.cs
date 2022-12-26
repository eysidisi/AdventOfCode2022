namespace AdventOfCode2022Tests.Day10
{
    public class CPU
    {
        private Register registerX = new(1);
        private List<int> registerXValuesInCycles = new();
        private CRT crt;
        private int currentCycle = 1;

        public CPU()
        {
        }

        public CPU(CRT crt)
        {
            this.crt = crt;
        }

        public void ExecuteInstruction(string instructionString)
        {
            Instruction currentInstruction = ParseInstruction(instructionString);

            for (int cycles = currentInstruction.CycleTime; cycles != 0; cycles--)
            {
                int pixelToDraw = currentCycle - 1;
                crt?.DrawSprite(pixelToDraw, registerX.Value);
                registerXValuesInCycles.Add(registerX.Value);
                currentCycle++;
            }

            currentInstruction.Execute();
        }

        private Instruction ParseInstruction(string instructionString)
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

            return currentInstruction;
        }

        public int GetSignalStrengthInCycle(int cycleNumber)
        {
            return registerXValuesInCycles.ElementAt(cycleNumber - 1) * cycleNumber;
        }
    }
}
