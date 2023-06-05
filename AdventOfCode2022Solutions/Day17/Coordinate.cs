namespace AdventOfCode2022Tests.Day17
{
    public class Coordinate
    {
        public Coordinate(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; internal set; }
        public double Y { get; internal set; }

        public override bool Equals(object? obj)
        {
            return obj is Coordinate coordinate &&
                   X == coordinate.X &&
                   Y == coordinate.Y;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            // Suitable nullity checks etc, of course :)
            hash = hash * 23 + X.GetHashCode();
            hash = hash * 23 + Y.GetHashCode();
            return hash;

        }
    }
}
