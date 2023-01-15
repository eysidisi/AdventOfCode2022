namespace AdventOfCode2022Tests.Day14
{
    public class Cave
    {
        private readonly Coord SandStartingCoord = new(500, 0);
        private readonly int MaxDepth;

        HashSet<Coord> rockCoords = new();
        HashSet<Coord> sandCoords = new();

        private readonly bool hasFloor;

        public Cave(string input, bool hasFloor = false)
        {
            this.hasFloor = hasFloor;
            CreateRocks(input);
            MaxDepth = hasFloor ? rockCoords.Max(r => r.Y) + 2 : rockCoords.Max(r => r.Y);
        }

        private void CreateRocks(string input)
        {
            input = input.Replace(" ", "");

            string[] lines = input.Split("\r\n");

            foreach (string line in lines)
            {
                ParseLineAndAddRocks(line);
            }
        }

        public bool HasRock(int xCoord, int yCoord)
        {
            if (hasFloor && yCoord >= MaxDepth)
            {
                return true;
            }

            return rockCoords.Contains(new Coord(xCoord, yCoord));
        }

        private bool HasRock(Coord coord)
        {
            return HasRock(coord.X, coord.Y);
        }

        public bool HasSand(int x, int y)
        {
            return sandCoords.Contains(new Coord(x, y));
        }

        public int FindNumberOfSandsThatCanRest()
        {
            while (true)
            {
                try
                {
                    DropOneSand();
                }
                catch (SandGoingToVoidException)
                {
                    break;
                }
            }
            return sandCoords.Count();
        }

        public int FindNumberOfSandsToBlockSource()
        {
            while (true)
            {
                try
                {
                    DropOneSand();
                }
                catch (SandSourceBlockedException)
                {
                    break;
                }
            }
            return sandCoords.Count();
        }

        public void DropOneSand()
        {
            Coord sandCurrentCoord = SandStartingCoord;
            while (true)
            {
                Coord downOne = new(sandCurrentCoord.X, sandCurrentCoord.Y + 1);
                Coord leftOneDownOne = new(sandCurrentCoord.X - 1, sandCurrentCoord.Y + 1);
                Coord rightOneDownOne = new(sandCurrentCoord.X + 1, sandCurrentCoord.Y + 1);

                if (hasFloor == false && sandCurrentCoord.Y >= MaxDepth)
                {
                    throw new SandGoingToVoidException("Sands started going into the void");
                }

                Coord sandNextCoord;
                if (HasRock(downOne) == false && sandCoords.Contains(downOne) == false)
                {
                    sandNextCoord = downOne;
                }

                else if (HasRock(leftOneDownOne) == false && sandCoords.Contains(leftOneDownOne) == false)
                {
                    sandNextCoord = leftOneDownOne;
                }

                else if (HasRock(rightOneDownOne) == false && sandCoords.Contains(rightOneDownOne) == false)
                {
                    sandNextCoord = rightOneDownOne;
                }

                else
                    break;

                sandCurrentCoord = sandNextCoord;
            }

            sandCoords.Add(sandCurrentCoord);

            if (sandCurrentCoord == SandStartingCoord)
            {
                throw new SandSourceBlockedException();
            }
        }

        private void ParseLineAndAddRocks(string input)
        {
            string[] coordinatePairs = input.Split("->");

            for (int i = 0; i < coordinatePairs.Length - 1; i++)
            {
                Coord startingCoord = CreateCoordinate(coordinatePairs[i]);
                Coord endingCoord = CreateCoordinate(coordinatePairs[i + 1]);

                FillBetweenTheseCoords(startingCoord, endingCoord);
            }
        }

        private void FillBetweenTheseCoords(Coord startingCoord, Coord endingCoord)
        {
            if (startingCoord.X == endingCoord.X)
            {
                for (int yCoord = Math.Min(startingCoord.Y, endingCoord.Y);
                    yCoord <= Math.Max(startingCoord.Y, endingCoord.Y);
                    yCoord++)
                {
                    rockCoords.Add(new Coord(startingCoord.X, yCoord));
                }
            }

            else
            {
                for (int xCoord = Math.Min(startingCoord.X, endingCoord.X);
                    xCoord <= Math.Max(startingCoord.X, endingCoord.X);
                    xCoord++)
                {
                    rockCoords.Add(new Coord(xCoord, startingCoord.Y));
                }
            }
        }
        private Coord CreateCoordinate(string coord)
        {
            int x = int.Parse(coord.Split(",")[0]);
            int y = int.Parse(coord.Split(",")[1]);

            return new Coord(x, y);
        }
    }
}
