using System.Runtime.Serialization;

namespace AdventOfCode2022Tests.Day14
{
    public class Cave
    {
        HashSet<Coord> rocks = new();
        HashSet<Coord> sands = new();

        public bool HasRock(int xCoord, int yCoord)
        {
            return rocks.Contains(new Coord(xCoord, yCoord));
        }

        public void ParseInput(string input)
        {
            input = input.Replace(" ", "");

            string[] lines = input.Split("\r\n");

            foreach (string line in lines)
            {
                ParseLineAndAddRocks(line);
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
                    rocks.Add(new Coord(startingCoord.X, yCoord));
                }
            }

            else
            {
                for (int xCoord = Math.Min(startingCoord.X, endingCoord.X);
                    xCoord <= Math.Max(startingCoord.X, endingCoord.X);
                    xCoord++)
                {
                    rocks.Add(new Coord(xCoord, startingCoord.Y));
                }
            }
        }

        private Coord CreateCoordinate(string coord)
        {
            int x = int.Parse(coord.Split(",")[0]);
            int y = int.Parse(coord.Split(",")[1]);

            return new Coord(x, y);
        }

        public void DropOneSand()
        {
            Coord sandCurrentCoord = new(500, 0);
            int maxDepth = rocks.Max(r => r.Y);

            while (true)
            {
                Coord downOne = new(sandCurrentCoord.X, sandCurrentCoord.Y + 1);
                Coord leftOneDownOne = new(sandCurrentCoord.X - 1, sandCurrentCoord.Y + 1);
                Coord rightOneDownOne = new(sandCurrentCoord.X + 1, sandCurrentCoord.Y + 1);

                Coord sandNextCoord;

                if (sandCurrentCoord.Y >= maxDepth)
                {
                    throw new SandException("Sands started going into the void");
                }

                if (rocks.Contains(downOne) == false && sands.Contains(downOne) == false)
                {
                    sandNextCoord = downOne;
                }

                else if (rocks.Contains(leftOneDownOne) == false && sands.Contains(leftOneDownOne) == false)
                {
                    sandNextCoord = leftOneDownOne;
                }

                else if (rocks.Contains(rightOneDownOne) == false && sands.Contains(rightOneDownOne) == false)
                {
                    sandNextCoord = rightOneDownOne;
                }

                else
                    break;

                sandCurrentCoord = sandNextCoord;
            }

            sands.Add(sandCurrentCoord);
        }

        public bool HasSand(int x, int y)
        {
            return sands.Contains(new Coord(x, y));
        }

        public int FindNumberOfSandsThatCanRest()
        {
            int numberOfSands = 0;

            while (true)
            {
                try
                {
                    DropOneSand();
                    numberOfSands++;
                }
                catch (SandException)
                {
                    break;
                }
            }
            return numberOfSands;
        }
    }

    public class Coord
    {
        public Coord(int xCoord, int yCoord)
        {
            X = xCoord;
            Y = yCoord;
        }

        public int X { get; set; }
        public int Y { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Coord other = (Coord)(obj);

            return X == other.X && Y == other.Y;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
    }
}

[Serializable]
internal class SandException : Exception
{
    public SandException()
    {
    }

    public SandException(string? message) : base(message)
    {
    }

    public SandException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected SandException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
