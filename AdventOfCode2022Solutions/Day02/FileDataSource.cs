namespace AdventOfCode2022Tests.Day02
{
    public class FileDataSource : ITournamentDataSource
    {
        private string filePath;

        public FileDataSource(string filePath)
        {
            this.filePath = filePath;
        }

        public List<Round> GetRounds()
        {
            string[] roundLines = File.ReadAllLines(filePath);
            List<Round> rounds = new();
            foreach (string roundLine in roundLines)
            {
                string[] shapeStrings = roundLine.Split(' ');
                Shape myShapeString = Shape.CreateShapeUsingString(shapeStrings[1]);
                Shape elfsShapeString = Shape.CreateShapeUsingString(shapeStrings[0]);

                rounds.Add(new Round(myShapeString, elfsShapeString));
            }

            return rounds;
        }
    }
}
