using Xunit;

namespace AdventOfCode2022Tests.Day15
{
    public class Part2
    {
        [Fact]
        public void LargeExample()
        {
            string filePath = @"TestFiles/Day15/LargeExample.txt";
            string input = File.ReadAllText(filePath);

            Zone zone = new(input, true, (0, 20));
            long expectedTuningFrequency = 56000011;

            long actualTuningFrequency = zone.CalculateUniqueuTuningFrequency();

            Assert.Equal(expectedTuningFrequency, actualTuningFrequency);
        }

        [Fact]
        public void ExerciseSolution()
        {
            string filePath = @"TestFiles/Day15/ExerciseInput.txt";
            string input = File.ReadAllText(filePath);

            Zone zone = new(input, true, (0, 4000000));
            long expectedTuningFrequency = 13673971349056;

            long actualTuningFrequency = zone.CalculateUniqueuTuningFrequency();

            Assert.Equal(expectedTuningFrequency, actualTuningFrequency);
        }

    }
}
