using Xunit;

namespace AdventOfCode2022Tests.Day06
{
    public class Part1
    {
        [Theory]
        [InlineData("aacade", 6)]
        [InlineData("abcd", 4)]
        [InlineData("abcad", 5)]
        public void CanFindTheStartOfThePacketMarker(string input, int expectedIndex)
        {
            Device device = new(input);
            int actualIndex = device.FindStartOfPacketMarker();

            Assert.Equal(expectedIndex, actualIndex);
        }

        [Fact]
        public void ExerciseSolution()
        {
            string filePath = @"TestFiles/Day06/ExerciseInput.txt";

            string[] lines = File.ReadAllLines(filePath);

            Device device = new(lines[0]);

            Assert.Equal(1623, device.FindStartOfPacketMarker());
        }
    }
}
