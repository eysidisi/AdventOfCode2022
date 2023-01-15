using Xunit;

namespace AdventOfCode2022Tests.Day14
{
    public class Part2
    {
        [Fact]
        public void SandsBlockSource()
        {
            string input = "498,4 -> 498,6 -> 496,6\r\n" +
                "503,4 -> 502,4 -> 502,9 -> 494,9";

            Cave cave = new(input, true);

            int expedtedNumberOfSands = 93;

            int actualNumberOfSandsToBlock = cave.FindNumberOfSandsToBlockSource();

            Assert.Equal(expedtedNumberOfSands, actualNumberOfSandsToBlock);
        }

        [Fact]
        public void ExerciseSolution()
        {
            string inputPath = @"TestFiles/Day14/ExerciseInput.txt";
            string input = File.ReadAllText(inputPath);

            Cave cave = new(input, true);

            int expedtedNumberOfSands = 24958;

            int actualNumberOfSandsThanCanRest = cave.FindNumberOfSandsToBlockSource();

            Assert.Equal(expedtedNumberOfSands, actualNumberOfSandsThanCanRest);
        }

    }
}
