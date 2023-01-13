using FluentAssertions;
using System.Collections;
using Xunit;

namespace AdventOfCode2022Tests.Day13
{
    public class HelperTests
    {
        [Theory]
        [InlineData("[10,[1,20,[1],[[]]],312]", 3)]
        [InlineData("[10,[1,2],3]", 3)]
        [InlineData("[10,2]", 2)]
        [InlineData("[1]", 1)]
        [InlineData("[[]]", 1)]
        [InlineData("[]", 0)]
        public void ReturnNumberOfItemsRecursiveLists(string input, int expectedNumberOfITems)
        {
            int actualNumberOfItems = ListComparerHelpers.CalculateNumberOfItemsInList(input);

            Assert.Equal(expectedNumberOfITems, actualNumberOfItems);
        }

        [Theory]
        [ClassData(typeof(CalculatorTestData))]
        public void GetItemsInList(string input, List<string> expectedItems)
        {
            List<string> actualItems = ListComparerHelpers.GetItemsInList(input);

            actualItems.Should().BeEquivalentTo(expectedItems);
        }

        public class CalculatorTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { "[[],120,[[]],1,[12,[]]]", new List<string>() { "[]", "120", "[[]]", "1", "[12,[]]" } };
                yield return new object[] { "[120,1]", new List<string>() { "120", "1" } };
                yield return new object[] { "[120]", new List<string>() { "120" } };
                yield return new object[] { "[1]", new List<string>() { "1" } };
                yield return new object[] { "[]", new List<string>() };
                yield return new object[] { "[[]]", new List<string>() { "[]" } };
                yield return new object[] { "[[[]]]", new List<string>() { "[[]]" } };
                yield return new object[] { "[[],[]]", new List<string>() { "[]", "[]" } };
                yield return new object[] { "[[[]],[]]", new List<string>() { "[[]]", "[]" } };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

    }
}
