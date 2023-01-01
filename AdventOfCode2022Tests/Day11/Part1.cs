using AdventOfCode2022Solutions.Day11.Operations;
using Xunit;

namespace AdventOfCode2022Tests.Day11
{
    public class Part1
    {
        [Fact]
        public void ConditionParsesString()
        {
            string[] conditionString = new[]{
                "Test: divisible by 5",
                "If true: throw to monkey 1",
                "If false: throw to monkey 6" };

            Condition condition = Condition.Create(conditionString);

            Assert.Equal(5, condition.DivisibleBy);
            Assert.Equal(1, condition.TrueConditionMonkeyId);
            Assert.Equal(6, condition.FalseConditionMonkeyId);
        }

        [Fact]
        public void OperationParsesString()
        {
            string line = "Operation: new = old * 13";
            Operation operation = Operation.Create(line);
            Assert.Equal(13, operation.Number);
            Assert.IsType<Multiplication>(operation);

            line = "Operation: new = old + 13";
            operation = Operation.Create(line);
            Assert.Equal(13, operation.Number);
            Assert.IsType<Sum>(operation);
        }

        [Fact]
        public void LargeExample()
        {
            string path = @"TestFiles/Day11/LargeExample.txt";

            string[] lines = File.ReadAllText(path).Split("\r\n\r\n");

            MonkeyGroup monkeyGroup = new(lines);

            int numberOfTurns = 20;

            while (numberOfTurns > 0)
            {
                numberOfTurns--;
                monkeyGroup.PlayOneRound(true);
            }

            Assert.Equal(10605, monkeyGroup.GetMonkeyBussiness());
        }

        [Fact]
        public void ExerciseSolution()
        {
            string path = @"TestFiles/Day11/ExerciseInput.txt";

            string[] lines = File.ReadAllText(path).Split("\r\n\r\n");

            MonkeyGroup monkeyGroup = new(lines);

            int numberOfTurns = 20;

            while (numberOfTurns > 0)
            {
                numberOfTurns--;
                monkeyGroup.PlayOneRound();
            }

            Assert.Equal(58786, monkeyGroup.GetMonkeyBussiness());
        }
    }
}
