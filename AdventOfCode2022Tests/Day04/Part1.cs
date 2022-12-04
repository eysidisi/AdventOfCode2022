using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2022Tests.Day04
{
    public class Part1
    {
        private readonly ITestOutputHelper output;

        public Part1(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ElfHasRange()
        {
            string range = "2-4";
            Elf elf = new(range);
            Assert.Equal(2, elf.rangeMinPoint);
            Assert.Equal(4, elf.rangeMaxPoint);
        }

        [Theory]
        [InlineData("2-4", "5-6", false)]
        [InlineData("2-4", "4-5", false)]
        [InlineData("2-4", "3-5", false)]
        [InlineData("2-4", "2-4", true)]
        [InlineData("1-4", "2-4", true)]
        [InlineData("1-4", "2-3", true)]
        public void ElfPairChecksIfFullyContainedRangePresents(string elfRange1, string elfRange2, bool expectedResult)
        {
            Elf elf1 = new(elfRange1);
            Elf elf2 = new(elfRange2);
            ElfPair elfPair = new(elf1, elf2);

            Assert.Equal(expectedResult, elfPair.DoElvesContainEachOther());
        }

        [Fact]
        public void ReadSmallFile()
        {
            string filePath = @"TestFiles/Day04/SmallFile.txt";
            string[] lines = File.ReadAllLines(filePath);

            List<ElfPair> elfPairs = new();
            foreach (string line in lines)
            {
                string[] elfRanges = line.Split(',');
                Elf elf1 = new(elfRanges[0]);
                Elf elf2 = new(elfRanges[1]);

                elfPairs.Add(new ElfPair(elf1, elf2));
            }

            int numOfContainedPairs = 0;
            foreach (ElfPair elfPair in elfPairs)
            {
                if (elfPair.DoElvesContainEachOther())
                    numOfContainedPairs++;
            }

            output.WriteLine(numOfContainedPairs.ToString());
        }

        [Fact]
        public void ExerciseSolution()
        {
            string filePath = @"TestFiles/Day04/ExerciseInput.txt";
            string[] lines = File.ReadAllLines(filePath);

            List<ElfPair> elfPairs = new();
            foreach (string line in lines)
            {
                string[] elfRanges = line.Split(',');
                Elf elf1 = new(elfRanges[0]);
                Elf elf2 = new(elfRanges[1]);

                elfPairs.Add(new ElfPair(elf1, elf2));
            }

            int numOfContainedPairs = 0;
            foreach (ElfPair elfPair in elfPairs)
            {
                if (elfPair.DoElvesContainEachOther())
                    numOfContainedPairs++;
            }

            output.WriteLine(numOfContainedPairs.ToString());
        }

    }
}
