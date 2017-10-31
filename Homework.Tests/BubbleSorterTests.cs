using NUnit.Framework;
using System.Linq;
using static Homework.BubbleSorter;
using System.Collections.Generic;

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
            //Sort(testArray, SortBy.Sum, SortOrder.Ascending);
            //Assert.True(testArray.OrderBy(row => row.Sum()).SequenceEqual(testArray));

            Sort(testArray, new ComparerBySumAscending());
            Assert.True(testArray.OrderBy(row => row.Sum()).SequenceEqual(testArray));
        }

        [Test]
        public void SortByMaxAscendingTest()
        {
            //Sort(testArray, SortBy.Max, SortOrder.Ascending);
            //Assert.True(testArray.OrderBy(row => row.Max()).SequenceEqual(testArray));

            Sort(testArray, new ComparerByMaxAscending());
            Assert.True(testArray.OrderBy(row => row.Max()).SequenceEqual(testArray));
        }

        [Test]
        public void SortByMinAscendingTest()
        {
            //Sort(testArray, SortBy.Min, SortOrder.Ascending);
            //Assert.True(testArray.OrderBy(row => row.Min()).SequenceEqual(testArray));

            Sort(testArray, new ComparerByMinAscending());
            Assert.True(testArray.OrderBy(row => row.Min()).SequenceEqual(testArray));
        }

        [Test]
        public void SortBySumDescendingTest()
        {
            //Sort(testArray, SortBy.Sum, SortOrder.Descending);
            //Assert.True(testArray.OrderByDescending(row => row.Sum()).SequenceEqual(testArray));

            Sort(testArray, new ComparerBySumDescending());
            Assert.True(testArray.OrderByDescending(row => row.Sum()).SequenceEqual(testArray));
        }

        [Test]
        public void SortByMaxDescendingTest()
        {
            //Sort(testArray, SortBy.Max, SortOrder.Descending);
            //Assert.True(testArray.OrderByDescending(row => row.Max()).SequenceEqual(testArray));

            Sort(testArray, new ComparerByMaxDescending());
            Assert.True(testArray.OrderByDescending(row => row.Max()).SequenceEqual(testArray));
        }

        [Test]
        public void SortByMinDescendingTest()
        {
            //Sort(testArray, SortBy.Min, SortOrder.Descending);
            //Assert.True(testArray.OrderByDescending(row => row.Min()).SequenceEqual(testArray));

            Sort(testArray, new ComparerByMinDescending());
            Assert.True(testArray.OrderByDescending(row => row.Min()).SequenceEqual(testArray));
        }

        class ComparerBySumAscending : IComparer<int[]>
        {
            public int Compare(int[] left, int[] right)
            {
                return left.Sum().CompareTo(right.Sum());
            }
        }

        class ComparerByMaxAscending : IComparer<int[]>
        {
            public int Compare(int[] left, int[] right)
            {
                return left.Max().CompareTo(right.Max());
            }
        }

        class ComparerByMinAscending : IComparer<int[]>
        {
            public int Compare(int[] left, int[] right)
            {
                return left.Min().CompareTo(right.Min());
            }
        }

        class ComparerBySumDescending : IComparer<int[]>
        {
            public int Compare(int[] left, int[] right)
            {
                return right.Sum().CompareTo(left.Sum());
            }
        }

        class ComparerByMaxDescending : IComparer<int[]>
        {
            public int Compare(int[] left, int[] right)
            {
                return right.Max().CompareTo(left.Max());
            }
        }

        class ComparerByMinDescending : IComparer<int[]>
        {
            public int Compare(int[] left, int[] right)
            {
                return right.Min().CompareTo(left.Min());
            }
        }
    }
}
