namespace AdventOfCode2022Tests.Day02
{
    public class Part2DataSource : ITournamentDataSource
    {
        private string filePath;

        public Part2DataSource(string filePath)
        {
            this.filePath = filePath;
        }

        public List<Round> GetRounds()
        {
            string[] roundLines = File.ReadAllLines(filePath);
            List<Round> rounds = new();

            foreach (string roundLine in roundLines)
            {
                rounds.Add(new Round(roundLine));
            }

            return rounds;
        }
    }
}
