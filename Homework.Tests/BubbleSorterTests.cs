using NUnit.Framework;
using System.Linq;
using static Homework.BubbleSorter;

namespace Homework.Tests
{
    [TestFixture]
    public class BubbleSorterTests
    {
        int[][] testArray =
                {
                  new int[] { 1, 2, 0, 10, 22, -92 },
                  new int[] { 22, 999, 10, -2, -92, 0, 0, 29 },
                  new int[] { 19, 04, -2, 021, -12 },
                  new int[] { 1, 50, 41 },
                  new int[] { -11, -22, 10, 200, 2 },
                  new int[] { 123, 123, 490, -24, -29, 0, 12 },
                  new int[] { 0, 0, 25, 10 }
                };

        [Test]
        public void SortBySumAscendingTest()
        {
            Sort(testArray, SortBy.Sum, SortOrder.Ascending);
            Assert.True(testArray.OrderBy(row => row.Sum()).SequenceEqual(testArray));
        }

        [Test]
        public void SortByMaxAscendingTest()
        {
            Sort(testArray, SortBy.Max, SortOrder.Ascending);
            Assert.True(testArray.OrderBy(row => row.Max()).SequenceEqual(testArray));
        }

        [Test]
        public void SortByMinAscendingTest()
        {
            Sort(testArray, SortBy.Min, SortOrder.Ascending);
            Assert.True(testArray.OrderBy(row => row.Min()).SequenceEqual(testArray));
        }

        [Test]
        public void SortBySumDescendingTest()
        {
            Sort(testArray, SortBy.Sum, SortOrder.Descending);
            Assert.True(testArray.OrderByDescending(row => row.Sum()).SequenceEqual(testArray));
        }

        [Test]
        public void SortByMaxDescendingTest()
        {
            Sort(testArray, SortBy.Max, SortOrder.Descending);
            Assert.True(testArray.OrderByDescending(row => row.Max()).SequenceEqual(testArray));
        }

        [Test]
        public void SortByMinDescendingTest()
        {
            Sort(testArray, SortBy.Min, SortOrder.Descending);
            Assert.True(testArray.OrderByDescending(row => row.Min()).SequenceEqual(testArray));
        }
    }
}
