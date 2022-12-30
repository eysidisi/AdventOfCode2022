using AdventOfCode2022Solutions.Day11.Operations;
using Xunit;

namespace AdventOfCode2022Tests.Day11
{
    public class Part1
    {
        [Fact]
        public void MonkeysHaveItems()
        {
            Monkey monkey = new();
            monkey.AddItem(25);
        }

        [Fact]
        public void MonkeysHaveIds()
        {
            Monkey monkey = new(id: 1);
            Assert.Equal(1, monkey.Id);
        }

        [Fact]
        public void MonkeysHaveOperations()
        {
            Operation operation = new Sum(5);
            operation = new Multiplication(5);
            Monkey monkey = new(operation);
        }

        [Fact]
        public void MonkeysHaveConditions()
        {
            Operation operation = new Sum(5);
            int divisibleBy = 7;
            int trueConditionMonkeyId = 0;
            int falseConditionMonkeyId = 2;
            Condition condition = new(divisibleBy, trueConditionMonkeyId, falseConditionMonkeyId);

            Monkey monkey = new(operation, condition);
        }

        [Fact]
        public void ItemsHaveValuesAndMonkeyToThrow()
        {
            int value = 10;
            int monkeyToThrow = 3;
            Item item = new(value, monkeyToThrow);
        }

        [Fact]
        public void MonkeysThrowToDifferentMonkeysDependingOnSumResult()
        {
            int trueConditionMonkeyId = 1;
            int falseConditionMonkeyId = 2;
            Operation operation = new Sum(5);
            int divisbleBy = 7;
            Monkey monkey = new(operation, new Condition(divisbleBy, trueConditionMonkeyId, falseConditionMonkeyId));
            monkey.AddItem(2);
            monkey.AddItem(3);
            Item thrownItem = monkey.Throw();
            Assert.Equal(7, thrownItem.Value);
            Assert.Equal(1, thrownItem.MonkeyToThrow);

            thrownItem = monkey.Throw();
            Assert.Equal(8, thrownItem.Value);
            Assert.Equal(2, thrownItem.MonkeyToThrow);
        }


        [Fact]
        public void MonkeysThrowToDifferentMonkeysDependingOnMultiplicationResult()
        {
            int trueConditionMonkeyId = 0;
            int falseConditionMonkeyId = 3;
            Operation operation = new Multiplication(4);

            int divisbleBy = 3;
            Monkey monkey = new(operation, new Condition(divisbleBy, trueConditionMonkeyId, falseConditionMonkeyId));
            monkey.AddItem(2);
            monkey.AddItem(3);
            Item thrownItem = monkey.Throw();
            Assert.Equal(8, thrownItem.Value);
            Assert.Equal(3, thrownItem.MonkeyToThrow);

            thrownItem = monkey.Throw();
            Assert.Equal(12, thrownItem.Value);
            Assert.Equal(0, thrownItem.MonkeyToThrow);
        }

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
        public void CanParseStringToCreateMonkey()
        {
            string monkeyInfo = "Monkey 0:\r\n  " +
                "Starting items: 52, 78, 79, 63, 51, 94\r\n  " +
                "Operation: new = old * 13\r\n  " +
                "Test: divisible by 5\r\n    " +
                "If true: throw to monkey 1\r\n    " +
                "If false: throw to monkey 6\r\n";

            Monkey monkey = Monkey.Create(monkeyInfo);
            Assert.Equal(0, monkey.Id);
            List<long> items = new()
            {
                52,78,79,63,51,94
            };
            Assert.Equal(items, monkey.ItemValues);
        }

        [Fact]
        public void TestOneMonkey()
        {
            string monkeyInfo = "Monkey 0:\r\n  " +
                "Starting items: 3, 2, 1, 5\r\n  " +
                "Operation: new = old * 13\r\n  " +
                "Test: divisible by 5\r\n    " +
                "If true: throw to monkey 1\r\n    " +
                "If false: throw to monkey 6\r\n";

            Monkey monkey = Monkey.Create(monkeyInfo);

            Item[] expectedItems = new[]
            {
                new Item(39,6),
                new Item(26,6),
                new Item(13,6),
                new Item(65,1),
            };

            int startingNumberOfItems = monkey.ItemValues.Count();
            for (int i = 0; i < startingNumberOfItems; i++)
            {
                Item item = monkey.Throw();
                Assert.Equal(expectedItems[i].Value, item.Value);
                Assert.Equal(expectedItems[i].MonkeyToThrow, item.MonkeyToThrow);
            }
        }

        [Fact]
        public void ReadFile()
        {
            string path = @"TestFiles/Day11/ExerciseInput.txt";

            string[] lines = File.ReadAllText(path).Split("\r\n\r\n");

            List<Monkey> monkeys = new();

            foreach (string line in lines)
            {
                monkeys.Add(Monkey.Create(line));
            }

            Assert.Equal(7, monkeys.Count);
        }

        [Fact]
        public void ARoundConsistsOfEachMonkeyDoingTheirShits()
        {
            string monkeyInfo1 = "Monkey 0:\r\n  " +
    "Starting items: 1, 2\r\n  " +
    "Operation: new = old * 2\r\n  " +
    "Test: divisible by 4\r\n    " +
    "If true: throw to monkey 1\r\n    " +
    "If false: throw to monkey 2\r\n";

            string monkeyInfo2 = "Monkey 1:\r\n  " +
    "Starting items: 1, 2\r\n  " +
    "Operation: new = old * 3\r\n  " +
    "Test: divisible by 3\r\n    " +
    "If true: throw to monkey 0\r\n    " +
    "If false: throw to monkey 2\r\n";

            string monkeyInfo3 = "Monkey 2:\r\n  " +
    "Starting items: 1, 2\r\n  " +
    "Operation: new = old * 4\r\n  " +
    "Test: divisible by 4\r\n    " +
    "If true: throw to monkey 0\r\n    " +
    "If false: throw to monkey 1\r\n";

            Monkey monkey1 = Monkey.Create(monkeyInfo1);
            Monkey monkey2 = Monkey.Create(monkeyInfo2);
            Monkey monkey3 = Monkey.Create(monkeyInfo3);

            Round round = new(new List<Monkey>() { monkey1, monkey2, monkey3 });
            round.Turn();

            Assert.Equal(6, monkey1.ItemValues.Count);
        }

        [Fact]
        public void MonkeysKeepNumberOfItemsTheyInspect()
        {
            string monkeyInfo1 = "Monkey 0:\r\n  " +
    "Starting items: 1, 2\r\n  " +
    "Operation: new = old * 2\r\n  " +
    "Test: divisible by 4\r\n    " +
    "If true: throw to monkey 1\r\n    " +
    "If false: throw to monkey 2\r\n";

            string monkeyInfo2 = "Monkey 1:\r\n  " +
    "Starting items: 1, 2\r\n  " +
    "Operation: new = old * 3\r\n  " +
    "Test: divisible by 3\r\n    " +
    "If true: throw to monkey 0\r\n    " +
    "If false: throw to monkey 2\r\n";

            string monkeyInfo3 = "Monkey 2:\r\n  " +
    "Starting items: 1, 2\r\n  " +
    "Operation: new = old * 4\r\n  " +
    "Test: divisible by 4\r\n    " +
    "If true: throw to monkey 0\r\n    " +
    "If false: throw to monkey 1\r\n";

            Monkey monkey1 = Monkey.Create(monkeyInfo1);
            Monkey monkey2 = Monkey.Create(monkeyInfo2);
            Monkey monkey3 = Monkey.Create(monkeyInfo3);

            Round round = new(new List<Monkey>() { monkey1, monkey2, monkey3 });
            round.Turn();

            Assert.Equal(2, monkey1.NumberOfInspectedItems);
            Assert.Equal(3, monkey2.NumberOfInspectedItems);
            Assert.Equal(3, monkey3.NumberOfInspectedItems);
        }

        [Fact]
        public void LargeExample()
        {
            string path = @"TestFiles/Day11/LargeExample.txt";

            string[] lines = File.ReadAllText(path).Split("\r\n\r\n");

            List<Monkey> monkeys = new();

            foreach (string line in lines)
            {
                monkeys.Add(Monkey.Create(line));
            }

            Round round = new(monkeys);

            int numberOfTurns = 20;

            while (numberOfTurns > 0)
            {
                numberOfTurns--;
                round.Turn();
            }

            monkeys = monkeys.OrderByDescending(m => m.NumberOfInspectedItems).ToList();

            Assert.Equal(10605, monkeys[0].NumberOfInspectedItems * monkeys[1].NumberOfInspectedItems);
        }

        [Fact]
        public void ExerciseSolution()
        {
            string path = @"TestFiles/Day11/ExerciseInput.txt";

            string[] lines = File.ReadAllText(path).Split("\r\n\r\n");

            List<Monkey> monkeys = new();

            foreach (string line in lines)
            {
                monkeys.Add(Monkey.Create(line));
            }

            Round round = new(monkeys);

            int numberOfTurns = 20;

            while (numberOfTurns > 0)
            {
                numberOfTurns--;
                round.Turn();
            }

            monkeys = monkeys.OrderByDescending(m => m.NumberOfInspectedItems).ToList();

            Assert.Equal(58786, monkeys[0].NumberOfInspectedItems * monkeys[1].NumberOfInspectedItems);
        }
    }
}
