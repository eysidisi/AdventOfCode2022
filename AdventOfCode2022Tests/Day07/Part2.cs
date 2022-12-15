using Xunit;

namespace AdventOfCode2022Tests.Day07
{
    public class Part2
    {
        [Fact]
        public void cliCanFindTheDirectoriesWithLessThanASize()
        {
            CLI cli = new();
            string[] commandLines = new string[]
            {
            "$ cd /",
            "$ ls",
            "dir a",
            "14848514 b.txt",
            "8504156 c.dat",
            "dir d",
            "$ cd a",
            "$ ls",
            "dir e",
            "29116 f",
            "2557 g",
            "62596 h.lst",
            "$ cd e",
            "$ ls",
            "584 i",
            "$ cd ..",
            "$ cd ..",
            "$ cd d",
            "$ ls",
            "4060174 j",
            "8033020 d.log",
            "5626152 d.ext",
            "7214296 k",
            };

            cli.ExecuteCommandLines(commandLines);

            int expectedSize = 24933642;

            int actualTotalSize = cli.FindSmallestSizeToDeleteForUpdate();

            Assert.Equal(expectedSize, actualTotalSize);
        }

        [Fact]
        public void ExerciseSolution()
        {
            string filePath = @"TestFiles/Day07/ExerciseInput.txt";

            string[] commandLines = File.ReadAllLines(filePath);

            CLI cli = new();

            cli.ExecuteCommandLines(commandLines);

            int expectedSize = 5025657;

            int actualTotalSize = cli.FindSmallestSizeToDeleteForUpdate();

            Assert.Equal(expectedSize, actualTotalSize);

        }
    }
}
