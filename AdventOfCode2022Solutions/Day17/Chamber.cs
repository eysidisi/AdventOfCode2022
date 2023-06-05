namespace AdventOfCode2022Tests.Day17
{
    public class Chamber
    {
        public Rock CurrentRock { get; private set; }
        public IReadOnlyCollection<Coordinate> RockCoordinates => rockCoordinates;

        private readonly string? windDirection;
        private readonly IRockFactory rockFactory;
        private bool isCurrentRockStuck = false;
        private double currentHeight = 0;
        private int currentWindIndex = 0;
        private HashSet<Coordinate> rockCoordinates;

        public Chamber(IRockFactory rockFactory, string? windDirection = null)
        {
            this.rockFactory = rockFactory;
            this.windDirection = windDirection;
            rockCoordinates = new HashSet<Coordinate>();
        }

        public void CreateRock()
        {
            isCurrentRockStuck = false;
            CurrentRock = rockFactory.CreateTheNextRockInOrder(currentHeight);
        }

        public bool TryToMoveRock()
        {
            if (CurrentRock == null)
            {
                throw new Exception("No rock to move");
            }

            if (isCurrentRockStuck)
            {
                throw new Exception("Can't move the current rock!");
            }

            if (windDirection != null)
            {
                TryToMoveRockInTheWind();
            }
            CurrentRock.MoveDown();

            if (RockHitsTheGround() || RockHitsAnotherRock())
            {
                CurrentRock.MoveUp();
                isCurrentRockStuck = true;
                return false;
            }

            return true;
        }

        public void Roll()
        {
            while (TryToMoveRock())
            {
            }

            foreach (var coord in CurrentRock.Coordinates)
            {
                rockCoordinates.Add(coord);
            }

            if (CurrentRock.Coordinates.Any(c => c.Y > currentHeight))
            {
                currentHeight = CurrentRock.Coordinates.Select(c => c.Y).Max();
            }
        }
        private void TryToMoveRockInTheWind()
        {
            if (windDirection[currentWindIndex] == '>')
            {
                TryToMoveRockToTheRight();
            }
            else
            {
                TryToMoveRockToTheLeft();
            }
            UpdateWindIndex();
        }

        private void TryToMoveRockToTheLeft()
        {
            CurrentRock.MoveLeft();
            if (RockHitsAnotherRock() || RockGoesOutOfTheChamber())
            {
                CurrentRock.MoveRight();
            }

        }

        private bool RockGoesOutOfTheChamber()
        {
            double leftCorner = CurrentRock.Coordinates.Select(c => c.X).Min();
            double rightCorner = CurrentRock.Coordinates.Select(c => c.X).Max();

            if (leftCorner < 0 || rightCorner > 6)
                return true;
            return false;
        }

        private void TryToMoveRockToTheRight()
        {
            CurrentRock.MoveRight();
            if (RockHitsAnotherRock() || RockGoesOutOfTheChamber())
            {
                CurrentRock.MoveLeft();
            }
        }

        private void UpdateWindIndex()
        {
            currentWindIndex++;
            currentWindIndex %= windDirection.Length;
        }

        private bool RockHitsAnotherRock()
        {
            foreach (var coord in CurrentRock.Coordinates)
            {
                if (rockCoordinates.Contains(coord))
                {
                    return true;
                }
            }
            return false;
        }

        private bool RockHitsTheGround()
        {
            return CurrentRock.Coordinates.Any(c => c.Y == 0);
        }

        public double GetHeight()
        {
            return currentHeight;
        }
    }
}
