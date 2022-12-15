using FluentAssertions;
using Xunit;

namespace AdventOfCode2022Tests.Day07
{
    public class Part1
    {
        [Fact]
        public void DirectoriesHaveSubdirectories()
        {
            ElfDirectory directory1 = new("dir1");
            ElfDirectory directory2 = new("dir1");

            directory1.TryToAddSubDirectory(directory2);

            directory1.SubDirectories.Should().BeEquivalentTo(new[] { directory2 });
        }

        [Fact]
        public void DirectoriesHaveFiles()
        {
            ElfDirectory directory1 = new("dir1");

            directory1.TryToAddFile("file1", 100);

            directory1.FilesToSizes.Should().BeEquivalentTo(new Dictionary<string, int>()
            {
                { "file1", 100 }
            });
        }

        [Fact]
        public void DirectoriesHaveSizes()
        {
            ElfDirectory directory1 = new("dir1");
            directory1.TryToAddFile("file1", 100);
            directory1.TryToAddFile("file1", 100);
            directory1.TryToAddFile("file2", 200);

            Assert.Equal(300, directory1.TotalSize);
        }

        [Fact]
        public void DirectoriesHaveSubdirectoriesSizes()
        {
            ElfDirectory directory1 = new("dir1");
            directory1.TryToAddFile("file1", 100);
            directory1.TryToAddFile("file2", 200);

            ElfDirectory directory2 = new("dir2");
            directory2.TryToAddFile("file1", 100);

            ElfDirectory directory3 = new("dir3");
            directory3.TryToAddFile("file1", 100);

            directory1.TryToAddSubDirectory(directory2);
            directory1.TryToAddSubDirectory(directory3);

            Assert.Equal(500, directory1.TotalSize);
        }

        [Fact]
        public void cliCanUnderstandCDCommand()
        {
            CLI cli = new();

            cli.ExecuteCommandLines(new string[] { "$ cd /" });

            Assert.Equal("/", cli.CurrentDirectory.Name);
        }

        [Fact]
        public void cliCanUnderstandNewDirectoryCommand()
        {
            CLI cli = new();
            string[] commandLines = new string[]
            {
                "$ cd /",
                "$ ls",
                "dir ddpgzpc",
                "dir mqjrd",
                "dir mrqjg",
                "dir rglgbsq",
                "298050 tjmjp.cqm",
                "dir wlqhpwqv",
            };
            cli.ExecuteCommandLines(commandLines);

            Assert.Equal("/", cli.CurrentDirectory.Name);
            Assert.Equal(298050, cli.CurrentDirectory.TotalSize);

            cli.CurrentDirectory.SubDirectories.Select(d => d.Name).
                Should().BeEquivalentTo(new List<string>()
                {
                        "ddpgzpc",
                        "mqjrd",
                        "mrqjg",
                        "rglgbsq",
                        "wlqhpwqv",
                });
        }

        [Fact]
        public void cliCanUnderstandMoveOutCommand()
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
            };

            cli.ExecuteCommandLines(commandLines);

            Assert.Equal("/", cli.CurrentDirectory.Name);
            Assert.Equal(23447523, cli.CurrentDirectory.TotalSize);

            cli.CurrentDirectory.SubDirectories.Select(d => d.Name).
                Should().BeEquivalentTo(new List<string>()
                {
                        "a",
                        "d",
                });
        }

        [Fact]
        public void cliCanFindDirectoriesSmallerOrEqualToASize()
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

            int expectedSize = 95437;

            int actualTotalSize = cli.FindTotalSizeOfDirectoriesLessThan(100000);

            Assert.Equal(expectedSize, actualTotalSize);
        }

        [Fact]
        public void ExerciseSolution()
        {
            string filePath = @"TestFiles/Day07/ExerciseInput.txt";

            string[] commandLines = File.ReadAllLines(filePath);

            CLI cli = new();

            cli.ExecuteCommandLines(commandLines);

            int expectedSize = 1915606;

            int actualTotalSize = cli.FindTotalSizeOfDirectoriesLessThan(100000);

            Assert.Equal(expectedSize, actualTotalSize);
        }

    }
}
