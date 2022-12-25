namespace AdventOfCode2022Tests.Day09
{
    public class Rope
    {
        public Position HeadPos
        {
            get
            {
                return knotPositions.First();
            }
            private set
            {
                knotPositions[0] = value;
            }
        }

        public Position TailPos
        {
            get
            {
                return knotPositions.Last();
            }
        }

        public Position[] knotPositions;

        private HashSet<Position> visitedPositions = new()
        {
            new Position(0,0)
        };

        public Rope() : this(2) { }

        public Rope(int numberOfKnots)
        {
            knotPositions = new Position[numberOfKnots];
            for (int i = 0; i < numberOfKnots; i++)
            {
                knotPositions[i] = new Position(0, 0);
            }
        }

        public void MoveHead(string movementString)
        {
            string[] directionAndDistance = movementString.Split(" ");
            string direction = directionAndDistance[0];
            int distance = int.Parse(directionAndDistance[1]);

            while (distance != 0)
            {
                MoveHead(direction, 1);
                UpdateAllKnotsPositions();

                distance--;
            }
        }

        private void UpdateAllKnotsPositions()
        {
            for (int i = 0; i < knotPositions.Length - 1; i++)
            {
                Position leadingNode = knotPositions[i];
                ref Position followingNode = ref knotPositions[i + 1];

                if (DoesFollowingTouchLeading(leadingNode, followingNode) == false)
                    MoveFollowingToLeading(ref followingNode, leadingNode);
                else
                    break;

                if (i == knotPositions.Length - 2)
                    UpdateTailsVisitedPositions();
            }
        }

        private void UpdateTailsVisitedPositions()
        {
            if (visitedPositions.Contains(TailPos) == false)
            {
                visitedPositions.Add(TailPos);
            }
        }

        private void MoveFollowingToLeading(ref Position followingPos, Position leadingPos)
        {
            int distanceToMoveInY = (leadingPos.Y - followingPos.Y) > 0 ? 1 : -1;
            int distanceToMoveInX = (leadingPos.X - followingPos.X) > 0 ? 1 : -1;

            if (ArePositionsInTheSameRow(followingPos, leadingPos))
            {
                followingPos = new Position(followingPos.X, followingPos.Y + distanceToMoveInY);
            }

            else if (ArePositionsInTheSameCol(followingPos, leadingPos))
            {
                followingPos = new Position(followingPos.X + distanceToMoveInX, followingPos.Y);
            }

            else
            {
                followingPos = new Position(followingPos.X + distanceToMoveInX, followingPos.Y + distanceToMoveInY);
            }
        }

        private bool ArePositionsInTheSameCol(Position followingPos, Position leadingPos)
        {
            return followingPos.Y - leadingPos.Y == 0;
        }

        private bool ArePositionsInTheSameRow(Position followingPos, Position leadingPos)
        {
            return followingPos.X - leadingPos.X == 0;
        }

        public int NumberOfPositionsTailVisited()
        {
            return visitedPositions.Count;
        }

        private bool DoesFollowingTouchLeading(Position Pos1, Position Pos2)
        {
            return Math.Abs(Pos1.X - Pos2.X) < 2 &&
                Math.Abs(Pos1.Y - Pos2.Y) < 2;
        }

        private void MoveHead(string direction, int distance)
        {
            if (direction == "U")
            {
                HeadPos = new Position(HeadPos.X, HeadPos.Y + distance);
            }

            else if (direction == "D")
            {
                HeadPos = new Position(HeadPos.X, HeadPos.Y - distance);
            }

            else if (direction == "R")
            {
                HeadPos = new Position(HeadPos.X + distance, HeadPos.Y);
            }

            else if (direction == "L")
            {
                HeadPos = new Position(HeadPos.X - distance, HeadPos.Y);
            }

            else
                throw new ArgumentException("Undefined direction!");
        }
    }
}
