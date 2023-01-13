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

            bool orderResults = CompareLists(list1, list2);

            Assert.True(orderResults);
        }

        [Fact]
        public void FirstEmptySecondNot()
        {
            string list1 = "[]";
            string list2 = "[3]";

            bool orderResults = CompareLists(list1, list2);

            Assert.True(orderResults);
        }

        [Fact]
        public void FirstNotEmptySecondEmpty()
        {
            string list1 = "[3]";
            string list2 = "[]";

            bool orderResults = CompareLists(list1, list2);

            Assert.False(orderResults);
        }

        [Fact]
        public void TwoIntegersInOrder()
        {
            string list1 = "[3]";
            string list2 = "[4]";

            bool orderResults = CompareLists(list1, list2);

            Assert.True(orderResults);
        }

        [Fact]
        public void SameTwoIntegers()
        {
            string list1 = "[4]";
            string list2 = "[4]";

            bool orderResults = CompareLists(list1, list2);

            Assert.True(orderResults);
        }

        [Fact]
        public void TwoIntegersOutOfOrder()
        {
            string list1 = "[5]";
            string list2 = "[4]";

            bool orderResults = CompareLists(list1, list2);

            Assert.False(orderResults);
        }

        [Fact]
        public void FirstListTwoElementsecondOne()
        {
            string list1 = "[40,5]";
            string list2 = "[40]";

            bool orderResults = CompareLists(list1, list2);

            Assert.False(orderResults);
        }

        [Fact]
        public void FirstListTwoElementsecondOne2()
        {
            string list1 = "[6,5]";
            string list2 = "[4]";

            bool orderResults = CompareLists(list1, list2);

            Assert.False(orderResults);
        }

        [Fact]
        public void FirstListTwoElementsecondOne3()
        {
            string list1 = "[3,5]";
            string list2 = "[4]";

            bool orderResults = CompareLists(list1, list2);

            Assert.True(orderResults);
        }

        [Fact]
        public void FirstListOneElementSecondTwo()
        {
            string list1 = "[4]";
            string list2 = "[4,5]";

            bool orderResults = CompareLists(list1, list2);

            Assert.True(orderResults);
        }

        [Fact]
        public void FirstListOneElementSecondTwo2()
        {
            string list1 = "[4]";
            string list2 = "[3,5]";

            bool orderResults = CompareLists(list1, list2);

            Assert.False(orderResults);
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
        [InlineData("[[]]", "[[]]", true)]
        [InlineData("[[]]", "[]", false)]
        [InlineData("[]", "[[]]", true)]
        [InlineData("[[[3]]]", "[[3]]", true)]
        [InlineData("[[[[1,6]]],[[[5,3,7],[],[10,9,7,3,3],0,[]],3,10,5],[],[10,[2]]]", "[[[[1,5],5],[[6],[3,2],9,[2,0,8]],[9,[6,9,4],8,0,6]],[[[8],8,10],0,[],6,[[2,7,8],0,9]],[7,1],[[[0],[9,5,9]],[[2,10]],[]]]", false)]
        [InlineData("[[],[[[0,3,2,6],7],8,5,5],[1],[[6,6,10,10],9,[[9,1],[6,0,2,10],[0,7,1,1,2]],[0,[],[8,6,5,6],[9,8,6],8]],[0,[],[[],[7,10,10]]]]", "[[2,[[9,2,7],2,[4,8,5],4],0,[[7,4,0,9],3]]]", true)]
        public void DifferentLists(string list1, string list2, bool result)
        {
            bool orderResults = CompareLists(list1, list2);

            Assert.Equal(result, orderResults);
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
            for (int i = 0; i < lines.Length; i += 3)
            {
                string firstList = lines[i];
                string secondList = lines[i + 1];
                if (CompareLists(firstList, secondList) == true)
                    pairIndexSum += pairNum;
                pairNum++;
            }

            Assert.Equal(5678, pairIndexSum);

        }

        private bool CompareLists(string list1, string list2)
        {
            ListComparer listComparer = new();
            return listComparer.CompareLists(list1, list2);
        }
    }
}
