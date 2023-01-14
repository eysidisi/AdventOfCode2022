using Xunit;

namespace AdventOfCode2022Tests.Day13
{
    public class Part1
    {
        [Fact]
        public void CompareEmptyLists()
        {
            string list1 = "[]";
            string list2 = "[]";

            bool? actualResult = CompareLists(list1, list2);

            Assert.Null(actualResult);
        }

        [Fact]
        public void FirstEmptySecondNot()
        {
            string list1 = "[]";
            string list2 = "[3]";

            bool? actualResult = CompareLists(list1, list2);

            Assert.True(actualResult);
        }

        [Fact]
        public void FirstNotEmptySecondEmpty()
        {
            string list1 = "[3]";
            string list2 = "[]";

            bool? actualResult = CompareLists(list1, list2);

            Assert.False(actualResult);
        }

        [Fact]
        public void TwoIntegersInOrder()
        {
            string list1 = "[3]";
            string list2 = "[4]";

            bool? actualResult = CompareLists(list1, list2);

            Assert.True(actualResult);
        }

        [Fact]
        public void SameTwoIntegers()
        {
            string list1 = "[4]";
            string list2 = "[4]";

            bool? actualResult = CompareLists(list1, list2);

            Assert.Null(actualResult);
        }

        [Fact]
        public void TwoIntegersOutOfOrder()
        {
            string list1 = "[5]";
            string list2 = "[4]";

            bool? actualResult = CompareLists(list1, list2);

            Assert.False(actualResult);
        }

        [Fact]
        public void FirstListTwoElementsecondOne()
        {
            string list1 = "[40,5]";
            string list2 = "[40]";

            bool? actualResult = CompareLists(list1, list2);

            Assert.False(actualResult);
        }

        [Fact]
        public void FirstListTwoElementsecondOne2()
        {
            string list1 = "[6,5]";
            string list2 = "[4]";

            bool? actualResult = CompareLists(list1, list2);

            Assert.False(actualResult);
        }

        [Fact]
        public void FirstListTwoElementsecondOne3()
        {
            string list1 = "[3,5]";
            string list2 = "[4]";

            bool? actualResult = CompareLists(list1, list2);

            Assert.True(actualResult);
        }

        [Fact]
        public void FirstListOneElementSecondTwo()
        {
            string list1 = "[4]";
            string list2 = "[4,5]";

            bool? actualResult = CompareLists(list1, list2);

            Assert.True(actualResult);
        }

        [Fact]
        public void FirstListOneElementSecondTwo2()
        {
            string list1 = "[4]";
            string list2 = "[3,5]";

            bool? actualResult = CompareLists(list1, list2);

            Assert.False(actualResult);
        }

        [Theory]
        [InlineData("[[[[3,10,1,1],[0],[4]],10,[[1,4,1],7,10],[[2,3],[4,10,6,6]],9],[[6,[3,1,4,0,0]],5,8,0],[10,10,7,[[],[0,8],[7,6,4]],[[0,7,2,1,2],7,2,[6,0],[7,6,4,6]]]]", "[[],[],[9,[8,[],1]],[1,5],[[],[]]]", false)]
        [InlineData("[[4],[[],[[4],9],[]]]", "[[[]],[]]", false)]
        [InlineData("[1,[2,[3,[4,[5,6,7]]]],8,9]", "[1,[2,[3,[4,[5,6,0]]]],8,9]", false)]
        [InlineData("[7,7,7,7]", "[7,7,7]", false)]
        [InlineData("[9]", "[[8,7,6]]", false)]
        [InlineData("[[4,4],4,4]", "[[4,4],4,4,4]", true)]
        [InlineData("[[1],[2,3,4]]", "[[1],4]", true)]
        [InlineData("[1,10,30,1,1]", "[[1,1,1],10,50,1,30]", true)]
        [InlineData("[1,1,3,1,1]", "[1,1,5,1,1]", true)]
        [InlineData("[3]", "[[],4]", false)]
        [InlineData("[3]", "[[]]", false)]
        [InlineData("[[]]", "[3]", true)]
        [InlineData("[[]]", "[[]]", null)]
        [InlineData("[[]]", "[]", false)]
        [InlineData("[]", "[[]]", true)]
        [InlineData("[[[],3,[[2,2,7,4,7],1]],[6],[[1,[9]],[[3,6,10,2,0],[10,3,0,6,1],8,7],[[3,7,5,9],5,1]],[0]]", "[[[]],[],[],[1,1,6,[[8,0,5,9,10],6],8]]", false)]
        [InlineData("[1,2]", "[[1]]", false)]
        [InlineData("[[1]]", "[1,2]", true)]
        [InlineData("[[6,[6,[1,8],[8,10,0,8,5]],[[7],7]],[[],0,[[8,9,8],1,3,[]]]]", "[[[[6,2,6,4,5],3,[0],[9]],4],[],[5,1,[[]],[3,[10,1,10,5,10]]]]", true)]
        [InlineData("[[[3]]]", "[[3]]", null)]
        [InlineData("[[1],[2,3,4]]", "[1,[2,[3,[4,[5,6,0]]]],8,9]", true)]
        [InlineData("[1,[2,[3,[4,[5,6,0]]]],8,9]", "[[1],[2,3,4]]", false)]
        [InlineData("[1,[2,[3,[4,[5,6,0]]]],8,9]", "[[1],4]", true)]
        [InlineData("[[[[1,6]]],[[[5,3,7],[],[10,9,7,3,3],0,[]],3,10,5],[],[10,[2]]]", "[[[[1,5],5],[[6],[3,2],9,[2,0,8]],[9,[6,9,4],8,0,6]],[[[8],8,10],0,[],6,[[2,7,8],0,9]],[7,1],[[[0],[9,5,9]],[[2,10]],[]]]", false)]
        public void DifferentLists(string list1, string list2, bool? result)
        {
            bool? actualResult = CompareLists(list1, list2);

            Assert.Equal(result, actualResult);
        }

        [Fact]
        public void LargeExample()
        {
            string filePath = @"TestFiles/Day13/LargeExample.txt";

            string[] lines = File.ReadAllLines(filePath);

            int pairNum = 1;
            int pairIndexSum = 0;
            for (int i = 0; i < lines.Length; i += 3)
            {
                string firstList = lines[i];
                string secondList = lines[i + 1];
                if (CompareLists(firstList, secondList) == true)
                    pairIndexSum += pairNum;
                pairNum++;
            }

            Assert.Equal(13, pairIndexSum);
        }

        [Fact]
        public void ExerciseSolution()
        {
            string filePath = @"TestFiles/Day13/ExerciseInput.txt";

            string[] lines = File.ReadAllLines(filePath);

            int pairNum = 1;
            int pairIndexSum = 0;

            List<int> expectedPairNumbers = new()
            {
                3,7,8,9,10,11,13,14,17,20,21,22,24,25,26,27,28,31,32,33,35,37,38,41,43,44,45,46,47,52,54,55,56,59,60,61,62,63,64,65,68,71,73,74,76,77,78,82,83,84,86,87,88,90,91,92,94,95,96,100,103,109,111,112,113,115,122,123,124,127,128,131,132,136,140,144,145,147,148
            };
            List<int> actualPairNumberes = new();

            for (int i = 0; i < lines.Length; i += 3)
            {
                string firstList = lines[i];
                string secondList = lines[i + 1];
                if (CompareLists(firstList, secondList) == true)
                {
                    actualPairNumberes.Add(pairNum);
                    if (expectedPairNumbers.Contains(pairNum) == false)
                    {
                        Console.WriteLine("aa");
                    }
                    pairIndexSum += pairNum;
                }
                pairNum++;
            }



            Assert.Equal(5503, pairIndexSum);

        }

        private bool? CompareLists(string list1, string list2)
        {
            ListComparer listComparer = new();
            return listComparer.CompareLists(list1, list2);
        }
    }
}
