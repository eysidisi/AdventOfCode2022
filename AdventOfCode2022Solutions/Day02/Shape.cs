namespace AdventOfCode2022Tests.Day02
{
    public class Shape
    {
        ShapeType shapeType;
        ShapeType winningShape;
        int score;

        private Shape(ShapeType shapeType, int score, ShapeType winningShape)
        {
            this.shapeType = shapeType;
            this.score = score;
            this.winningShape = winningShape;
        }

        public static Shape CreateShapeUsingString(string value)
        {
            if (value == "X" || value == "A")
            {
                return Rock();
            }
            if (value == "Y" || value == "B")
            {
                return Paper();
            }
            return Scissors();
        }

        public static Shape Paper()
        {
            return new Shape(ShapeType.Paper, 2, ShapeType.Scissors);
        }

        public static Shape Rock()
        {
            return new Shape(ShapeType.Rock, 1, ShapeType.Paper);
        }

        public static Shape Scissors()
        {
            return new Shape(ShapeType.Scissors, 3, ShapeType.Rock);
        }

        public bool Beats(Shape opponentShape)
        {
            return (this.shapeType == opponentShape.winningShape);
        }

        public int Score()
        {
            return score;
        }
        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Shape otherShape = (Shape)obj;

            return shapeType == otherShape.shapeType;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Shape GetWinningShape()
        {
            switch (winningShape)
            {
                case ShapeType.Rock:
                    return Rock();
                case ShapeType.Scissors:
                    return Scissors();
                case ShapeType.Paper:
                    return Paper();
                default:
                    throw new InvalidDataException();
            }
        }

        public Shape GetLosingShape()
        {
            return GetWinningShape().GetWinningShape();
        }
    }
}
