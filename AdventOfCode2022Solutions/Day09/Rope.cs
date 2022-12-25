namespace AdventOfCode2022Tests.Day09
{
    public class Rope
    {
        public Position HeadPos { get; private set; } = new Position(0, 0);
        public Position TailPos { get; private set; } = new Position(0, 0);
        private HashSet<Position> visitedPositions = new()
        {
            new Position(0,0)
        };

        public void MoveHead(string upMovement)
        {
            string[] directionAndDistance = upMovement.Split(" ");
            string direction = directionAndDistance[0];
            int distance = int.Parse(directionAndDistance[1]);

            while (distance != 0)
            {
                MoveHead(direction, 1);

                if (DoesTailTouchHead() == false)
                {
                    MoveTail();
                    UpdateVisitedPositions();
                }

                distance--;
            }
        }

        private void UpdateVisitedPositions()
        {
            if (visitedPositions.Contains(TailPos) == false)
            {
                visitedPositions.Add(TailPos);
            }
        }

        private void MoveTail()
        {
            int distanceToMoveInY = (HeadPos.Y - TailPos.Y) > 0 ? 1 : -1;
            int distanceToMoveInX = (HeadPos.X - TailPos.X) > 0 ? 1 : -1;

            if (AreTailHeadInTheSameRow())
            {
                TailPos = new Position(TailPos.X, TailPos.Y + distanceToMoveInY);
            }

            else if (AreTailHeadInTheSameCol())
            {
                TailPos = new Position(TailPos.X + distanceToMoveInX, TailPos.Y);
            }

            else
            {
                TailPos = new Position(TailPos.X, TailPos.Y + distanceToMoveInY);
                TailPos = new Position(TailPos.X + distanceToMoveInX, TailPos.Y);
            }
        }

        private bool AreTailHeadInTheSameCol()
        {
            return HeadPos.Y - TailPos.Y == 0;
        }

        private bool AreTailHeadInTheSameRow()
        {
            return HeadPos.X - TailPos.X == 0;
        }

        public int NumberOfPositionsTailVisited()
        {
            return visitedPositions.Count;
        }

        private bool DoesTailTouchHead()
        {
            return Math.Abs(TailPos.X - HeadPos.X) < 2 &&
                Math.Abs(TailPos.Y - HeadPos.Y) < 2;
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
