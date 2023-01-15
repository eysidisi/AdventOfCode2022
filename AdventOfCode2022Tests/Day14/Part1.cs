using Xunit;

namespace AdventOfCode2022Tests.Day14
{
    public partial class Part1
    {
        [Fact]
        public void ParseOneLineInput()
        {
            string input = "498,4-> 498,6";

            Cave cave = new(input);

            Assert.True(cave.HasRock(498, 4));
            Assert.True(cave.HasRock(498, 5));
            Assert.True(cave.HasRock(498, 6));
            Assert.False(cave.HasRock(498, 7));
            Assert.False(cave.HasRock(498, 3));
            Assert.False(cave.HasRock(499, 5));
        }

        [Fact]
        public void ParseOneLineMoreThanTwoCoordinates()
        {
            string input = "498,4-> 498,3-> 495,3";
            Cave cave = new(input);

            Assert.True(cave.HasRock(498, 4));
            Assert.True(cave.HasRock(498, 3));
            Assert.True(cave.HasRock(497, 3));
            Assert.True(cave.HasRock(496, 3));
            Assert.True(cave.HasRock(495, 3));

            Assert.False(cave.HasRock(494, 3));
            Assert.False(cave.HasRock(495, 2));
        }

        [Fact]
        public void ParseTwoLinesInput()
        {
            string input = "498,4 -> 498,6 -> 496,6\r\n" +
                "503,4 -> 502,4 -> 502,9 -> 494,9";

            Cave cave = new(input);

            Assert.True(cave.HasRock(498, 4));
            Assert.True(cave.HasRock(498, 5));
            Assert.True(cave.HasRock(498, 6));
            Assert.True(cave.HasRock(497, 6));
            Assert.True(cave.HasRock(496, 6));

            Assert.True(cave.HasRock(503, 4));
            Assert.True(cave.HasRock(502, 4));
            Assert.True(cave.HasRock(502, 5));
            Assert.True(cave.HasRock(502, 6));
            Assert.True(cave.HasRock(502, 7));
            Assert.True(cave.HasRock(502, 8));
            Assert.True(cave.HasRock(502, 9));

            Assert.True(cave.HasRock(501, 9));
            Assert.True(cave.HasRock(500, 9));
            Assert.True(cave.HasRock(499, 9));
            Assert.True(cave.HasRock(498, 9));
            Assert.True(cave.HasRock(497, 9));
            Assert.True(cave.HasRock(496, 9));
            Assert.True(cave.HasRock(495, 9));
            Assert.True(cave.HasRock(494, 9));
        }

        [Fact]
        public void SandGoesDown()
        {
            string input = "498,4 -> 498,6 -> 496,6\r\n" +
                "503,4 -> 502,4 -> 502,9 -> 494,9";

            Cave cave = new(input);

            int numOfSands = 24;

            while (numOfSands > 0)
            {
                cave.DropOneSand();
                numOfSands--;
            }

            Assert.True(cave.HasSand(500, 2));

            Assert.True(cave.HasSand(500, 3));
            Assert.True(cave.HasSand(501, 3));
            Assert.True(cave.HasSand(499, 3));

            Assert.True(cave.HasSand(500, 4));
            Assert.True(cave.HasSand(501, 4));
            Assert.True(cave.HasSand(499, 4));

            Assert.True(cave.HasSand(497, 5));
            Assert.True(cave.HasSand(499, 5));
            Assert.True(cave.HasSand(500, 5));
            Assert.True(cave.HasSand(501, 5));

            Assert.True(cave.HasSand(499, 6));
            Assert.True(cave.HasSand(500, 6));
            Assert.True(cave.HasSand(501, 6));

            Assert.True(cave.HasSand(498, 7));
            Assert.True(cave.HasSand(499, 7));
            Assert.True(cave.HasSand(500, 7));
            Assert.True(cave.HasSand(501, 7));

            Assert.True(cave.HasSand(495, 8));
            Assert.True(cave.HasSand(497, 8));
            Assert.True(cave.HasSand(498, 8));
            Assert.True(cave.HasSand(499, 8));
            Assert.True(cave.HasSand(500, 8));
            Assert.True(cave.HasSand(501, 8));
        }

        [Fact]
        public void SandGoesIntoTheVoid()
        {
            string input = "498,4 -> 498,6 -> 496,6\r\n" +
                "503,4 -> 502,4 -> 502,9 -> 494,9";

            Cave cave = new(input);

            int expedtedNumberOfSands = 24;

            int actualNumberOfSandsThanCanRest = cave.FindNumberOfSandsThatCanRest();

            Assert.Equal(expedtedNumberOfSands, actualNumberOfSandsThanCanRest);
        }

        [Fact]
        public void ExerciseSolution()
        {
            string inputPath = @"TestFiles/Day14/ExerciseInput.txt";
            string input = File.ReadAllText(inputPath);

            Cave cave = new(input);

            int expedtedNumberOfSands = 674;

            int actualNumberOfSandsThanCanRest = cave.FindNumberOfSandsThatCanRest();

            Assert.Equal(expedtedNumberOfSands, actualNumberOfSandsThanCanRest);
        }
    }
}
