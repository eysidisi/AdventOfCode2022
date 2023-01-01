using AdventOfCode2022Solutions.Day11.Operations;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022Tests.Day11
{
    public class Part2
    {
        [Fact]
        public void GroupCreatesMonkeys()
        {
            string path = @"TestFiles/Day11/LargeExample.txt";

            string[] lines = File.ReadAllText(path).Split("\r\n\r\n");

            MonkeyGroup monkeyGroup = new(lines);

            Assert.Equal(4, monkeyGroup.NumberOfMonkeys);
        }

        [Fact]
        public void ItemsHaveDivisionRemainings()
        {
            int value = 50;
            Item item = new(value);
            item.AddDivisor(3);
            item.AddDivisor(2);
            item.AddDivisor(13);

            Assert.Equal(2, item.GetRemainder(3));
            Assert.Equal(0, item.GetRemainder(2));
            Assert.Equal(11, item.GetRemainder(13));
        }

        [Fact]
        public void ItemsExecuteSum()
        {
            int value = 50;
            Item item = new(value);
            item.AddDivisor(3);
            item.AddDivisor(2);
            item.AddDivisor(13);

            Operation operation = new Sum(1);
            item.Execute(operation);
            Assert.Equal(0, item.GetRemainder(3));
            Assert.Equal(1, item.GetRemainder(2));
            Assert.Equal(12, item.GetRemainder(13));
        }

        [Fact]
        public void ItemsExecuteMultiplication()
        {
            int value = 50;
            Item item = new(value);
            item.AddDivisor(3);
            item.AddDivisor(2);
            item.AddDivisor(13);

            Operation operation = new Multiplication(3);
            item.Execute(operation);
            Assert.Equal(0, item.GetRemainder(3));
            Assert.Equal(0, item.GetRemainder(2));
            Assert.Equal(7, item.GetRemainder(13));
        }

        [Fact]
        public void ItemsExecuteSquare()
        {
            int value = 4;
            Item item = new(value);
            item.AddDivisor(3);
            item.AddDivisor(2);
            item.AddDivisor(13);

            Operation operation = new Square();
            item.Execute(operation);
            Assert.Equal(16 % 3, item.GetRemainder(3));
            Assert.Equal(16 % 2, item.GetRemainder(2));
            Assert.Equal(16 % 13, item.GetRemainder(13));
        }

        [Fact]
        public void MonkeysHaveNewItems()
        {
            string monkeyInfo = "Monkey 0:\r\n  " +
                "Starting items: 52, 78\r\n  " +
                "Operation: new = old * 13\r\n  " +
                "Test: divisible by 5\r\n    " +
                "If true: throw to monkey 1\r\n    " +
                "If false: throw to monkey 6\r\n";

            Monkey monkey = Monkey.Create(monkeyInfo, new List<int>() { 5 });
            Assert.Equal(0, monkey.Id);
            List<Item> expectedNewItems = new()
            {
                new Item(52),
                new Item(78),
            };

            expectedNewItems.ForEach(i => i.AddDivisor(5));

            expectedNewItems.Should().BeEquivalentTo(monkey.Items);
        }

        [Fact]
        public void MonkeyGroupPlaysRounds()
        {
            string path = @"TestFiles/Day11/LargeExample.txt";

            string[] lines = File.ReadAllText(path).Split("\r\n\r\n");

            MonkeyGroup monkeyGroup = new(lines);


            monkeyGroup.PlayOneRound();

            Assert.Equal(2, monkeyGroup.monkeys[0].NumberOfInspectedItems);
            Assert.Equal(4, monkeyGroup.monkeys[1].NumberOfInspectedItems);
            Assert.Equal(3, monkeyGroup.monkeys[2].NumberOfInspectedItems);
            Assert.Equal(6, monkeyGroup.monkeys[3].NumberOfInspectedItems);

            int roundNum = 19;
            while (roundNum > 0)
            {
                roundNum--;
                monkeyGroup.PlayOneRound();
            }

            Assert.Equal(99, monkeyGroup.monkeys[0].NumberOfInspectedItems);
            Assert.Equal(97, monkeyGroup.monkeys[1].NumberOfInspectedItems);
            Assert.Equal(8, monkeyGroup.monkeys[2].NumberOfInspectedItems);
            Assert.Equal(103, monkeyGroup.monkeys[3].NumberOfInspectedItems);
        }

        [Fact]
        public void MonkeyGroupPlays10000Rounds()
        {
            string path = @"TestFiles/Day11/LargeExample.txt";

            string[] lines = File.ReadAllText(path).Split("\r\n\r\n");

            MonkeyGroup monkeyGroup = new(lines);

            int roundNum = 10000;
            while (roundNum > 0)
            {
                roundNum--;
                monkeyGroup.PlayOneRound();
            }

            Assert.Equal(52166, monkeyGroup.monkeys[0].NumberOfInspectedItems);
            Assert.Equal(47830, monkeyGroup.monkeys[1].NumberOfInspectedItems);
            Assert.Equal(1938, monkeyGroup.monkeys[2].NumberOfInspectedItems);
            Assert.Equal(52013, monkeyGroup.monkeys[3].NumberOfInspectedItems);

            Assert.Equal(2713310158, monkeyGroup.GetMonkeyBussiness());
        }

        [Fact]
        public void ExerciseSolution()
        {
            string path = @"TestFiles/Day11/ExerciseInput.txt";

            string[] lines = File.ReadAllText(path).Split("\r\n\r\n");

            MonkeyGroup monkeyGroup = new(lines);

            int roundNum = 10000;
            while (roundNum > 0)
            {
                roundNum--;
                monkeyGroup.PlayOneRound();
            }

            Assert.Equal(14952185856, monkeyGroup.GetMonkeyBussiness());
        }

    }
}
