namespace AdventOfCode2022Tests.Day01
{
    public class TextFileCalorieReader : IElfGroupCalorieDataSource
    {
        private string filePath;

        public TextFileCalorieReader(string filePath)
        {
            this.filePath = filePath;
        }

        public List<int> GetTotalCaloriesForElves()
        {
            string[] meals = File.ReadAllLines(filePath);

            List<int> totalCaloriesForElves = CalculateTotalCaloriesForElves(meals);

            return totalCaloriesForElves;
        }

        private List<int> CalculateTotalCaloriesForElves(string[] meals)
        {
            List<int> totalCaloriesForElves = new();
            int totalCaloriesForThisElf = 0;

            foreach (string meal in meals)
            {
                if (meal.Trim() != string.Empty)
                    totalCaloriesForThisElf += int.Parse(meal.Trim());

                else
                {
                    totalCaloriesForElves.Add(totalCaloriesForThisElf);
                    totalCaloriesForThisElf = 0;
                }
            }

            if (totalCaloriesForThisElf != 0)
                totalCaloriesForElves.Add(totalCaloriesForThisElf);

            return totalCaloriesForElves;
        }
    }
}