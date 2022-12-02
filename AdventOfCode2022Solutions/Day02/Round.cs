namespace AdventOfCode2022Tests.Day02
{
    public class Round
    {
        private const int WinningScore = 6;
        private const int LosingScore = 0;
        private const int DrawScore = 3;

        private Shape myShape;
        private Shape elfsShape;

        public Round(Shape myShape, Shape elfsShape)
        {
            this.myShape = myShape;
            this.elfsShape = elfsShape;
        }

        public int GetScore()
        {
            int totalScore;

            if (myShape.Beats(elfsShape))
            {
                totalScore = WinningScore;
            }
            else if (elfsShape.Beats(myShape))
            {
                totalScore = LosingScore;
            }
            else
            {
                totalScore = DrawScore;
            }

            totalScore += myShape.Score();

            return totalScore;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Round otherRound = (Round)obj;

            return myShape.Equals(otherRound.myShape) && elfsShape.Equals(otherRound.elfsShape);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
