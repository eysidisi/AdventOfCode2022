using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2022Tests.Day1
{
    public class Part2
    {
        private readonly ITestOutputHelper output;

        public Part2(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void CalculateTopThreeTotalCalories()
        {
            // Arrange
            ElfGroup elfGroup = new();
            elfGroup.AddElfCalorie(new List<int>() { 50, 30, 40 });
            elfGroup.AddElfCalorie(new List<int>() { 150, 1000 });
            elfGroup.AddElfCalorie(new List<int>() { 5, 10 });
            elfGroup.AddElfCalorie(new List<int>() { 5000 });

            int expectedResult = 5000 + 1000 + 150 + 50 + 30 + 40;

            //Act
            int actualResult = elfGroup.FindSumOfTopThreeCalories();

            // Assert
            Assert.Equal(expectedResult, actualResult);

        }

        [Fact]
        public void ExeciseSolution()
        {
            // Arrange
            string filePath = @"TestFiles/ExerciseInput.txt";
            TextFileCalorieReader textCalorieReader = new(filePath);
            ElfGroup elfGroup = new();
            elfGroup.AddElfCaloriesUsingDataSource(textCalorieReader);

            // Act
            int actualMaxCalories = elfGroup.FindSumOfTopThreeCalories();

            // Assert
            output.WriteLine($"Max calories {actualMaxCalories}");
        }
    }
}
