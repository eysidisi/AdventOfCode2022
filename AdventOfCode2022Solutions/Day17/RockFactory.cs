namespace AdventOfCode2022Tests.Day17
{
   public class RockFactory : IRockFactory
    {
        int nextRockTypeNumber = 0;

        public Rock CreateTheNextRockInOrder(double currentHeight = 0)
        {
            if (nextRockTypeNumber == 0)
            {
                nextRockTypeNumber++;
                return CreateRock("Horizontal", currentHeight);
            }
            else if (nextRockTypeNumber == 1)
            {
                nextRockTypeNumber++;
                return CreateRock("Star", currentHeight);
            }
            else if (nextRockTypeNumber == 2)
            {
                nextRockTypeNumber++;
                return CreateRock("L", currentHeight);
            }
            else if (nextRockTypeNumber == 3)
            {
                nextRockTypeNumber++;
                return CreateRock("Vertical", currentHeight);
            }
            else if (nextRockTypeNumber == 4)
            {
                nextRockTypeNumber = 0;
                return CreateRock("Square", currentHeight);
            }
            else
            {
                throw new Exception("Invalid rock type");
            }
        }

        public Rock CreateRock(string type, double bottomLength)
        {
            if (type == "Horizontal")
            {
                return CreateHorizontalRock(bottomLength);
            }
            else if (type == "Star")
            {
                return CreateStar(bottomLength);
            }
            else if (type == "L")
            {
                return CreateL(bottomLength);
            }
            else if (type == "Vertical")
            {
                return CreateVertical(bottomLength);
            }
            else if (type == "Square")
            {
                return CreateSquare(bottomLength);
            }
            else
            {
                throw new Exception("Invalid rock type");
            }
        }

        private Rock CreateSquare(double bottomLength)
        {
            return new Rock("Square",
                                   new Coordinate[]
                                   {
                        new Coordinate(2, bottomLength+4),
                        new Coordinate(2, bottomLength+5),
                        new Coordinate(3, bottomLength+4),
                        new Coordinate(3, bottomLength+5)});
        }

        private Rock CreateVertical(double bottomLength)
        {
            return new Rock("Vertical",
                                   new Coordinate[]
                                   {
                        new Coordinate(2, bottomLength+4),
                        new Coordinate(2, bottomLength+5),
                        new Coordinate(2, bottomLength+6),
                        new Coordinate(2, bottomLength+7)});
        }

        private Rock CreateL(double bottomLength)
        {
            return new Rock("L",
                                   new Coordinate[]
                                   {
                        new Coordinate(2, bottomLength+4),
                        new Coordinate(3, bottomLength+4),
                        new Coordinate(4, bottomLength+4),
                        new Coordinate(4, bottomLength+5),
                        new Coordinate(4, bottomLength+6) });
        }

        private static Rock CreateStar(double bottomLength)
        {
            return new Rock("Star",
                                   new Coordinate[]
                                   {
                        new Coordinate(3, bottomLength+4),
                        new Coordinate(3, bottomLength+5),
                        new Coordinate(3, bottomLength+6),
                        new Coordinate(2, bottomLength+5),
                        new Coordinate(4, bottomLength+5) });
        }

        private static Rock CreateHorizontalRock(double height)
        {
            return new Rock("Horizontal",
                new Coordinate[] {
                    new Coordinate(2, height+4),
                    new Coordinate(3, height+4),
                    new Coordinate(4, height+4),
                    new Coordinate(5, height+4) });

        }
    }
}

