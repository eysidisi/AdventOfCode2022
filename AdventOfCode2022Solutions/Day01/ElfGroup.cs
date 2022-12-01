namespace AdventOfCode2022Tests
{
    public class ElfGroup
    {
        List<int> elvesTotalCalories = new();

        public ElfGroup()
        {
        }

        public void AddElfCalorie(List<int> mealCalories)
        {
            elvesTotalCalories.Add(mealCalories.Sum());
        }

        public void AddElfCaloriesUsingDataSource(IElfGroupCalorieDataSource elfGroupCalorieDataSource)
        {
            elvesTotalCalories.AddRange(elfGroupCalorieDataSource.GetTotalCaloriesForElves());
        }

        public int FindMaxCalories()
        {
            return elvesTotalCalories.Max();
        }

        // Takes nlog(n) bu still good enough
        public int FindSumOfTopThreeCalories()
        {
            return elvesTotalCalories.OrderByDescending(x => x).Take(3).Sum();
        }
    }
}