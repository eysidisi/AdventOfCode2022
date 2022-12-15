using Xunit;

namespace AdventOfCode2022Tests.Day06
{
    public class Part2
    {
        [Theory]
        [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
        [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
        [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)]
        [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
        [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
        public void CanFindStartOfMessageMarker(string input, int expectedIndex)
        {
            Device device = new(input);
            int actualIndex = device.FindStartOfMessageMarker();

            Assert.Equal(expectedIndex, actualIndex);

        }

        [Fact]
        public void ExerciseSolution()
        {
            string filePath = @"TestFiles/Day06/ExerciseInput.txt";

            string[] lines = File.ReadAllLines(filePath);

            Device device = new(lines[0]);

            Assert.Equal(1623, device.FindStartOfMessageMarker());

        }
    }
}
