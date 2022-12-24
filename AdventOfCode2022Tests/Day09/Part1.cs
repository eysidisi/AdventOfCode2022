using Xunit;

namespace AdventOfCode2022Tests.Day09
{
    public class Part1
    {
        [Fact]
        public void RopeHasHeadPosition()
        {
            Rope rope = new();
            Position p = new(0, 0);

            Assert.Equal(p, rope.HeadPos);
        }

        [Fact]
        public void RopeHeadCanMove()
        {
            Rope rope = new();
            string upMovement = "U 2";
            rope.MoveHead(upMovement);
            Assert.Equal(rope.HeadPos, new Position(0, 2));

            string downMovement = "D 1";
            rope.MoveHead(downMovement);
            Assert.Equal(rope.HeadPos, new Position(0, 1));

            string rightMovement = "R 1";
            rope.MoveHead(rightMovement);
            Assert.Equal(rope.HeadPos, new Position(1, 1));

            string leftMovement = "L 2";
            rope.MoveHead(leftMovement);
            Assert.Equal(rope.HeadPos, new Position(-1, 1));
        }


        [Fact]
        public void TailFollowsHead()
        {
            Rope rope = new();
            rope.MoveHead("U 1");
            Assert.Equal(rope.TailPos, new Position(0, 0));

            rope.MoveHead("U 1");
            Assert.Equal(rope.TailPos, new Position(0, 1));

            rope.MoveHead("R 1");
            Assert.Equal(rope.TailPos, new Position(0, 1));

            rope.MoveHead("R 1");
            Assert.Equal(rope.TailPos, new Position(1, 2));
        }

        [Fact]
        public void TailsVisitedPositionsAreStored()
        {
            Rope rope = new();

            rope.MoveHead("R 4");
            rope.MoveHead("U 4");
            rope.MoveHead("L 3");
            rope.MoveHead("D 1");
            rope.MoveHead("R 4");
            rope.MoveHead("D 1");
            rope.MoveHead("L 5");
            rope.MoveHead("R 2");

            int expectedNumOfPositionsVisited = 13;

            Assert.Equal(expectedNumOfPositionsVisited, rope.NumberOfPositionsTailVisited());
        }

        [Fact]
        public void ExerciseSolution()
        {
            string[] input = File.ReadAllLines(@"TestFiles/Day09/ExerciseInput.txt");
            Rope rope = new();

            foreach (string item in input)
            {
                rope.MoveHead(item);
            }

            int expectedNumOfPositionsVisited = 5878;

            Assert.Equal(expectedNumOfPositionsVisited, rope.NumberOfPositionsTailVisited());
        }
    }
}
