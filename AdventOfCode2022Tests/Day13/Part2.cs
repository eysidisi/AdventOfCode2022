using FluentAssertions;
using Xunit;

namespace AdventOfCode2022Tests.Day13
{
    public class Part2
    {
        [Fact]
        public void SortTwoEmptyLists()
        {
            string item1 = "[]";
            string item2 = "[]";

            List<string> expectedSortedList = new() { item1, item2 };

            List<string> actualSortedList = SortLists(new List<string>() { item1, item2 });

            expectedSortedList.Should().BeEquivalentTo(actualSortedList);
        }

        [Fact]
        public void SortOneEmptyOneIntegerList()
        {
            string item1 = "[]";
            string item2 = "[10]";

            List<string> expectedSortedList = new() { item1, item2 };

            List<string> actualSortedList = SortLists(new List<string>() { item2, item1 });

            actualSortedList.Should().Equal(expectedSortedList);
        }

        [Fact]
        public void AComplexExample()
        {
            List<string> input = new()
            {
                "[[1],[2,3,4]]",
                "[[[]]]",
                "[[1],4]",
                "[3]",
                "[[4,4],4,4]",
                "[[4,4],4,4,4]",
                "[1,[2,[3,[4,[5,6,7]]]],8,9]",
                "[[6]]",
                "[7,7,7]",
                "[[2]]",
                "[7,7,7,7]",
                "[[8,7,6]]",
                "[9]",
                "[1,1,5,1,1]",
                "[[]]",
                "[1,1,3,1,1]",
                "[1,[2,[3,[4,[5,6,0]]]],8,9]",
                "[]",
            };

            List<string> expectedSortedList = new()
            {
                "[]",
                "[[]]",
                "[[[]]]",
                "[1,1,3,1,1]",
                "[1,1,5,1,1]",
                "[[1],[2,3,4]]",
                "[1,[2,[3,[4,[5,6,0]]]],8,9]",
                "[1,[2,[3,[4,[5,6,7]]]],8,9]",
                "[[1],4]",
                "[[2]]",
                "[3]",
                "[[4,4],4,4]",
                "[[4,4],4,4,4]",
                "[[6]]",
                "[7,7,7]",
                "[7,7,7,7]",
                "[[8,7,6]]",
                "[9]",
            };

            List<string> actualSortedList = SortLists(input);

            actualSortedList.Should().Equal(expectedSortedList);
        }

        [Fact]
        public void SortThreeEmptyListsWithDifferentDepth()
        {
            string item1 = "[]";
            string item2 = "[[]]";
            string item3 = "[[[]]]";

            List<string> expectedSortedList = new() { item1, item2, item3 };

            List<string> actualSortedList = SortLists(new List<string>() { item3, item1, item2 });

            actualSortedList.Should().Equal(expectedSortedList);

        }

        [Fact]
        public void LargeExample()
        {
            string filePath = @"TestFiles/Day13/LargeExample.txt";

            List<string> lines = File.ReadAllLines(filePath).ToList();

            lines.RemoveAll(s => string.IsNullOrEmpty(s));

            lines.Add("[[2]]");
            lines.Add("[[6]]");

            List<string> actualSortedList = SortLists(lines);

            int indexOfTwo = actualSortedList.FindIndex(0, actualSortedList.Count(), (s) => s.Equals("[[2]]"));
            int indexOfSix = actualSortedList.FindIndex(0, actualSortedList.Count(), (s) => s.Equals("[[6]]"));

            Assert.Equal(140, (indexOfTwo + 1) * (indexOfSix + 1));
        }

        [Fact]
        public void ExerciseSolution()
        {
            string filePath = @"TestFiles/Day13/ExerciseInput.txt";

            List<string> lines = File.ReadAllLines(filePath).ToList();

            lines.RemoveAll(s => string.IsNullOrEmpty(s));

            lines.Add("[[2]]");
            lines.Add("[[6]]");

            List<string> actualSortedList = SortLists(lines);

            int indexOfTwo = actualSortedList.FindIndex(0, actualSortedList.Count(), (s) => s.Equals("[[2]]"));
            int indexOfSix = actualSortedList.FindIndex(0, actualSortedList.Count(), (s) => s.Equals("[[6]]"));

            Assert.Equal(20952, (indexOfTwo + 1) * (indexOfSix + 1));

        }

        private List<string> SortLists(List<string> list)
        {
            ListComparer listComparer = new();

            List<string> sortedList = new();

            foreach (string currentItemToInsert in list)
            {
                int indexToInsert = 0;

                for (; indexToInsert < sortedList.Count(); indexToInsert++)
                {
                    string elementToCompare = sortedList.ElementAt(indexToInsert);
                    bool? comparisonResult = listComparer.CompareLists(currentItemToInsert, elementToCompare);
                    if (comparisonResult.HasValue == false || comparisonResult.Value == true)
                    {
                        break;
                    }
                }

                sortedList.Insert(indexToInsert, currentItemToInsert);
            }

            return sortedList;
        }
    }
}
