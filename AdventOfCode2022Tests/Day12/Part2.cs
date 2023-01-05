using Xunit;

namespace AdventOfCode2022Tests.Day12
{
    public class Part2
    {
        [Fact]
        public void CanFindShortestPathWithMoreThanOneStartingPoints()
        {
            string filePath = @"TestFiles/Day12/LargeExample.txt";

            string inputString = File.ReadAllText(filePath);

            HeightMap heightMap = new(inputString);
            heightMap.MarkManyStartingPoints();

            ShortestPathCalculator pathCalculator = new(heightMap);
            int shortestPath = pathCalculator.FindShortestPathWithMoreThanOneStartingPoint();
            Assert.Equal(29, shortestPath);
        }

        [Fact]
        public void ExerciseSolution()
        {
            string filePath = @"TestFiles/Day12/ExerciseInput.txt";

            string inputString = File.ReadAllText(filePath);

            HeightMap heightMap = new(inputString);
            heightMap.MarkManyStartingPoints();

            ShortestPathCalculator pathCalculator = new(heightMap);
            int shortestPath = pathCalculator.FindShortestPathWithMoreThanOneStartingPoint();
            Assert.Equal(354, shortestPath);
        }

    }
}
