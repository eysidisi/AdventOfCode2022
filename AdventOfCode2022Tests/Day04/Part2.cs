using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2022Tests.Day04
{
    public class Part2
    {
        private readonly ITestOutputHelper output;

        public Part2(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData("2-4", "2-4", true)]
        [InlineData("2-4", "4-5", true)]
        [InlineData("2-4", "3-5", true)]
        [InlineData("2-4", "5-7", false)]
        [InlineData("4-5", "2-4", true)]
        [InlineData("3-5", "2-4", true)]
        [InlineData("5-7", "2-4", false)]
        public void ElfPairChecksIfRangesOverlap(string elfRange1, string elfRange2, bool expectedResult)
        {
            Elf elf1 = new(elfRange1);
            Elf elf2 = new(elfRange2);
            ElfPair elfPair = new(elf1, elf2);

            Assert.Equal(expectedResult, elfPair.DoRangesOverlap());
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
            int expectedNumOfOverlappingPairs = 4;
            int actualNumOfOverlappingPairs = 0;
            foreach (ElfPair elfPair in elfPairs)
            {
                if (elfPair.DoRangesOverlap())
                    actualNumOfOverlappingPairs++;
            }

            Assert.Equal(expectedNumOfOverlappingPairs, actualNumOfOverlappingPairs);
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

            int actualNumOfOverlappingPairs = 0;
            foreach (ElfPair elfPair in elfPairs)
            {
                if (elfPair.DoRangesOverlap())
                    actualNumOfOverlappingPairs++;
            }

            output.WriteLine(actualNumOfOverlappingPairs.ToString());
        }

    }
}
