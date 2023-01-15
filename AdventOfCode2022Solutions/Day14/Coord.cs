namespace AdventOfCode2022Tests.Day14
{
    public class Coord
    {
        public Coord(int xCoord, int yCoord)
        {
            X = xCoord;
            Y = yCoord;
        }

        public int X { get; set; }
        public int Y { get; set; }

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
