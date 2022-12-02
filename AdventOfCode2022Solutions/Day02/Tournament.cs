namespace AdventOfCode2022Tests.Day02
{
    public class Tournament
    {
        private ITournamentDataSource dataSource;

        public Tournament(ITournamentDataSource dataSource)
        {
            this.dataSource = dataSource;
        }

        public int GetTotalScore()
        {
            int totalScore = 0;

            foreach (Round round in dataSource.GetRounds())
            {
                totalScore += round.GetScore();
            }

            return totalScore;
        }
    }
}