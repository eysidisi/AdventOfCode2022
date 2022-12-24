namespace AdventOfCode2022Tests.Day09
{
    public class Position
    {

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Position other = (Position)obj;

            return other.X == X && other.Y == Y;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return $"{X}-{Y}".GetHashCode();
        }
    }
}
