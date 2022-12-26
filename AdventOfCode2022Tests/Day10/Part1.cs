using Xunit;

namespace AdventOfCode2022Tests.Day10
{
    public class Part1
    {
        [Fact]
        public void RegisterClassHasAValue()
        {
            int value = 10;
            Register register = new(value);
            Assert.Equal(value, register.Value);
        }

        [Fact]
        public void CPUTakesStringInstructions()
        {
            CPU cpu = new();
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 24");
        }

        [Fact]
        public void CanComputeSignalStrength()
        {
            CPU cpu = new();
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 2");
            cpu.ExecuteInstruction("addx 3");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");

            Assert.Equal(1, cpu.GetSignalStrengthInCycle(1));
            Assert.Equal(2, cpu.GetSignalStrengthInCycle(2));
            Assert.Equal(3, cpu.GetSignalStrengthInCycle(3));
            Assert.Equal(12, cpu.GetSignalStrengthInCycle(4));
            Assert.Equal(15, cpu.GetSignalStrengthInCycle(5));
            Assert.Equal(36, cpu.GetSignalStrengthInCycle(6));
            Assert.Equal(42, cpu.GetSignalStrengthInCycle(7));
        }

        [Fact]
        public void LongTesting()
        {
            CPU cpu = new();
            cpu.ExecuteInstruction("addx 15");
            cpu.ExecuteInstruction("addx -11");
            cpu.ExecuteInstruction("addx 6");
            cpu.ExecuteInstruction("addx -3");
            cpu.ExecuteInstruction("addx 5");
            cpu.ExecuteInstruction("addx -1");
            cpu.ExecuteInstruction("addx -8");
            cpu.ExecuteInstruction("addx 13");
            cpu.ExecuteInstruction("addx 4");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx -1");
            cpu.ExecuteInstruction("addx 5");
            cpu.ExecuteInstruction("addx -1");
            cpu.ExecuteInstruction("addx 5");
            cpu.ExecuteInstruction("addx -1");
            cpu.ExecuteInstruction("addx 5");
            cpu.ExecuteInstruction("addx -1");
            cpu.ExecuteInstruction("addx 5");
            cpu.ExecuteInstruction("addx -1");
            cpu.ExecuteInstruction("addx -35");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("addx 24");
            cpu.ExecuteInstruction("addx -19");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("addx 16");
            cpu.ExecuteInstruction("addx -11");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 21");
            cpu.ExecuteInstruction("addx -15");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx -3");
            cpu.ExecuteInstruction("addx 9");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("addx -3");
            cpu.ExecuteInstruction("addx 8");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("addx 5");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx -36");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("addx 7");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 2");
            cpu.ExecuteInstruction("addx 6");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 7");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx -13");
            cpu.ExecuteInstruction("addx 13");
            cpu.ExecuteInstruction("addx 7");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("addx -33");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 2");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 8");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx -1");
            cpu.ExecuteInstruction("addx 2");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 17");
            cpu.ExecuteInstruction("addx -9");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("addx -3");
            cpu.ExecuteInstruction("addx 11");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx -13");
            cpu.ExecuteInstruction("addx -19");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("addx 3");
            cpu.ExecuteInstruction("addx 26");
            cpu.ExecuteInstruction("addx -30");
            cpu.ExecuteInstruction("addx 12");
            cpu.ExecuteInstruction("addx -1");
            cpu.ExecuteInstruction("addx 3");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx -9");
            cpu.ExecuteInstruction("addx 18");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("addx 2");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 9");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx -1");
            cpu.ExecuteInstruction("addx 2");
            cpu.ExecuteInstruction("addx -37");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("addx 3");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 15");
            cpu.ExecuteInstruction("addx -21");
            cpu.ExecuteInstruction("addx 22");
            cpu.ExecuteInstruction("addx -6");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 2");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx -10");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 20");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("addx 2");
            cpu.ExecuteInstruction("addx 2");
            cpu.ExecuteInstruction("addx -6");
            cpu.ExecuteInstruction("addx -11");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");

            Assert.Equal(420, cpu.GetSignalStrengthInCycle(20));
            Assert.Equal(1140, cpu.GetSignalStrengthInCycle(60));
            Assert.Equal(1800, cpu.GetSignalStrengthInCycle(100));
            Assert.Equal(2940, cpu.GetSignalStrengthInCycle(140));
            Assert.Equal(2880, cpu.GetSignalStrengthInCycle(180));
            Assert.Equal(3960, cpu.GetSignalStrengthInCycle(220));
        }

        [Fact]
        public void ExerciseSolution()
        {
            string filePath = @"TestFiles/Day10/ExerciseInput.txt";

            string[] instructions = File.ReadAllLines(filePath);

            CPU cpu = new();

            foreach (string instruction in instructions)
            {
                cpu.ExecuteInstruction(instruction);
            }

            int signalStrengthSum = 0;
            for (int cycleNum = 20; cycleNum <= 220; cycleNum += 40)
            {
                signalStrengthSum += cpu.GetSignalStrengthInCycle(cycleNum);
            }

            Assert.Equal(13440, signalStrengthSum);
        }
    }
}
