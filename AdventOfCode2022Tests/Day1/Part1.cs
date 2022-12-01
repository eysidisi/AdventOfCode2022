using FluentAssertions;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2022Tests.Day1
{
    public class Part1
    {
        private readonly ITestOutputHelper output;

        public Part1(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void OneElfInGroupWithOneMeal()
        {
            // Arrange
            ElfGroup elfGroup = new();
            elfGroup.AddElfCalorie(new List<int>() { 100 });

            int expectedResult = 100;

            //Act
            int actualResult = elfGroup.FindMaxCalories();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TwoElvesInGroupWithDifferentNumberOfMeals()
        {
            // Arrange
            ElfGroup elfGroup = new();
            elfGroup.AddElfCalorie(new List<int>() { 50, 30, 40 });
            elfGroup.AddElfCalorie(new List<int>() { 50, 1000 });

            int expectedResult = 1050;

            //Act
            int actualResult = elfGroup.FindMaxCalories();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void AddOneElfToAGroupUsingExternalDependency()
        {
            // Arrange
            Mock<IElfGroupCalorieDataSource> elfGroupCalorieDataSource =
                new();
            elfGroupCalorieDataSource.Setup(e => e.GetTotalCaloriesForElves()).
                Returns(new List<int>() { 100 });

            ElfGroup elfGroup = new();
            elfGroup.AddElfCaloriesUsingDataSource(elfGroupCalorieDataSource.Object);

            // Act
            int expectedMaxCalories = 100;
            int actualMaxCalories = elfGroup.FindMaxCalories();

            // Assert
            Assert.Equal(expectedMaxCalories, actualMaxCalories);
        }

        [Fact]
        public void ReadTextFileWithOneMeal()
        {
            // Arrange
            string filePath = @"TestFiles/OneElfOneMeal.txt";
            TextFileCalorieReader textCalorieReader = new(filePath);

            // Act
            List<int> actualCalories = textCalorieReader.GetTotalCaloriesForElves();
            List<int> expectedCalories = new() { 100 };

            //
            expectedCalories.Should().BeEquivalentTo(actualCalories);
        }

        [Fact]
        public void ReadTextfileWithTwoMeals()
        {
            // Arrange
            string filePath = @"TestFiles/OneElfTwoMeals.txt";
            TextFileCalorieReader textCalorieReader = new(filePath);

            // Act
            List<int> actualCalories = textCalorieReader.GetTotalCaloriesForElves();
            List<int> expectedCalories = new() { 300 };

            // Assert
            expectedCalories.Should().BeEquivalentTo(actualCalories);
        }

        [Fact]
        public void ReadTextFileWithTwoElvesWithTwoMeals()
        {
            // Arrange
            string filePath = @"TestFiles/TwoElvesTwoMeals.txt";
            TextFileCalorieReader textCalorieReader = new(filePath);

            // Act
            List<int> actualCalories = textCalorieReader.GetTotalCaloriesForElves();
            List<int> expectedCalories = new() { 300, 700 };

            // Assert
            expectedCalories.Should().BeEquivalentTo(actualCalories);
        }

        [Theory]
        [InlineData(@"TestFiles/ThreeElvesWithDifferentNumberOfMeals.txt", 1900)]
        [InlineData(@"TestFiles/TwoElvesTwoMeals.txt", 700)]
        public void ReadTextFileAndGetTheIndexWithMaxCalories(string filePath, int expectedMaxCalories)
        {
            // Arrange
            TextFileCalorieReader textCalorieReader = new(filePath);
            ElfGroup elfGroup = new();
            elfGroup.AddElfCaloriesUsingDataSource(textCalorieReader);

            // Act
            int actualMaxCalories = elfGroup.FindMaxCalories();

            // Assert
            Assert.Equal(expectedMaxCalories, actualMaxCalories);
        }

        [Fact]
        public void ExerciseAnswer()
        {
            // Arrange
            string filePath = @"TestFiles/ExerciseInput.txt";
            TextFileCalorieReader textCalorieReader = new(filePath);
            ElfGroup elfGroup = new();
            elfGroup.AddElfCaloriesUsingDataSource(textCalorieReader);

            // Act
            int actualMaxCalories = elfGroup.FindMaxCalories();

            // Assert
            output.WriteLine($"Max calories {actualMaxCalories}");
        }
    }
}