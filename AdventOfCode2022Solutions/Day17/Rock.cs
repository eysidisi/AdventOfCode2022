namespace AdventOfCode2022Tests.Day17
{
    public class Rock
    {
        public string Type { get; }
        public Coordinate[] Coordinates { get; internal set; }

        public Rock(string type, Coordinate[] coordinates)
        {
            Type = type;
            Coordinates = coordinates;
        }


        internal void MoveDown()
        {
            foreach (Coordinate coordinate in Coordinates)
            {
                coordinate.Y--;
            }
        }

        internal void MoveRight()
        {
            foreach (Coordinate coordinate in Coordinates)
            {
                coordinate.X++;
            }
        }

        internal void MoveLeft()
        {
            foreach (Coordinate coordinate in Coordinates)
            {
                coordinate.X--;
            }
        }

        internal void MoveUp()
        {
            foreach (Coordinate coordinate in Coordinates)
            {
                coordinate.Y++;
            }
        }
    }
}
