using Xunit;

namespace AdventOfCode2022Tests.Day09
{
    public class Part2
    {
        [Fact]
        public void RopeHasMoreThanOneKnots()
        {
            int numberOfKnots = 2;
            Rope rope = new(numberOfKnots);
        }

        [Fact]
        public void RopeControlsTenKnots()
        {
            Rope rope = new(10);

            rope.MoveHead("R 5");

            Assert.Equal(new Position(5, 0), rope.knotPositions[0]);
            Assert.Equal(new Position(4, 0), rope.knotPositions[1]);
            Assert.Equal(new Position(3, 0), rope.knotPositions[2]);
            Assert.Equal(new Position(2, 0), rope.knotPositions[3]);
            Assert.Equal(new Position(1, 0), rope.knotPositions[4]);
            Assert.Equal(new Position(0, 0), rope.knotPositions[5]);
            Assert.Equal(new Position(0, 0), rope.knotPositions[6]);

            rope.MoveHead("U 8");
            Assert.Equal(new Position(5, 8), rope.knotPositions[0]);
            Assert.Equal(new Position(5, 7), rope.knotPositions[1]);
            Assert.Equal(new Position(5, 6), rope.knotPositions[2]);
            Assert.Equal(new Position(5, 5), rope.knotPositions[3]);
            Assert.Equal(new Position(5, 4), rope.knotPositions[4]);
            Assert.Equal(new Position(4, 4), rope.knotPositions[5]);
            Assert.Equal(new Position(3, 3), rope.knotPositions[6]);
            Assert.Equal(new Position(2, 2), rope.knotPositions[7]);
            Assert.Equal(new Position(1, 1), rope.knotPositions[8]);
            Assert.Equal(new Position(0, 0), rope.knotPositions[9]);

            rope.MoveHead("L 8");
            Assert.Equal(new Position(-3, 8), rope.knotPositions[0]);
            Assert.Equal(new Position(-2, 8), rope.knotPositions[1]);
            Assert.Equal(new Position(-1, 8), rope.knotPositions[2]);
            Assert.Equal(new Position(0, 8), rope.knotPositions[3]);
            Assert.Equal(new Position(1, 8), rope.knotPositions[4]);
            Assert.Equal(new Position(1, 7), rope.knotPositions[5]);
            Assert.Equal(new Position(1, 6), rope.knotPositions[6]);
            Assert.Equal(new Position(1, 5), rope.knotPositions[7]);
            Assert.Equal(new Position(1, 4), rope.knotPositions[8]);
            Assert.Equal(new Position(1, 3), rope.knotPositions[9]);

            rope.MoveHead("D 3");
            rope.MoveHead("R 17");
            rope.MoveHead("D 10");
            rope.MoveHead("L 25");
            rope.MoveHead("U 20");

            int expectedNumberOfVisitedPos = 36;

            Assert.Equal(expectedNumberOfVisitedPos, rope.NumberOfPositionsTailVisited());
        }

        [Fact]
        public void ExerciseSolution()
        {
            string[] input = File.ReadAllLines(@"TestFiles/Day09/ExerciseInput.txt");
            Rope rope = new(10);

            foreach (string item in input)
            {
                rope.MoveHead(item);
            }

            int expectedNumOfPositionsVisited = 5878;

            Assert.Equal(expectedNumOfPositionsVisited, rope.NumberOfPositionsTailVisited());
        }

    }
}
