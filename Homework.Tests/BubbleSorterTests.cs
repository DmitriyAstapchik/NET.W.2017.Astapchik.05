using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static Homework.BubbleSorter;

namespace Homework.Tests
{
    [TestFixture]
    public class BubbleSorterTests
    {
        private static int[][] testArray =
                {
                  new int[] { 1, 2, 0, 10, 22, -92 },
                  new int[] { 22, 999, 10, -2, -92, 0, 0, 29 },
                  new int[] { 19, 04, -2, 021, -12 },
                  new int[] { 1, 50, 41 },
                  new int[] { },
                  new int[] { -11, -22, 10, 200, 2 },
                  new int[] { 123, 123, 490, -24, -29, 0, 12 },
                  null,
                  new int[] { 0, 0, 25, 10 }
                };

        private Comparison<int[]> compareBySumAscending = (arr1, arr2) => ComparerHelper.CompareEmptyOrNull(arr1, arr2) ?? arr1.Sum().CompareTo(arr2.Sum());
        private Comparison<int[]> compareBySumDescending = (arr2, arr1) => ComparerHelper.CompareEmptyOrNull(arr1, arr2) ?? arr1.Sum().CompareTo(arr2.Sum());
        private Comparison<int[]> compareByMaxAscending = (arr1, arr2) => ComparerHelper.CompareEmptyOrNull(arr1, arr2) ?? arr1.Max().CompareTo(arr2.Max());
        private Comparison<int[]> compareByMaxDescending = (arr2, arr1) => ComparerHelper.CompareEmptyOrNull(arr1, arr2) ?? arr1.Max().CompareTo(arr2.Max());
        private Comparison<int[]> compareByMinAscending = (arr1, arr2) => ComparerHelper.CompareEmptyOrNull(arr1, arr2) ?? arr1.Min().CompareTo(arr2.Min());
        private Comparison<int[]> compareByMinDescending = (arr2, arr1) => ComparerHelper.CompareEmptyOrNull(arr1, arr2) ?? arr1.Min().CompareTo(arr2.Min());

        [Test]
        public void SortBySumAscendingTest()
        {
            Sort(testArray, new ComparerBySumAscending());
            Assert.True(testArray.Where(row => row == null).Concat(testArray.Where(row => row != null && row.Length == 0)).Concat(testArray.Where(row => row != null && row.Length > 0).OrderBy(row => row.Sum())).SequenceEqual(testArray));

            Sort(testArray, compareBySumAscending);
            Assert.True(testArray.Where(row => row == null).Concat(testArray.Where(row => row != null && row.Length == 0)).Concat(testArray.Where(row => row != null && row.Length > 0).OrderBy(row => row.Sum())).SequenceEqual(testArray));

            BubbleSorter2.Sort(testArray, new ComparerBySumAscending());
            Assert.True(testArray.Where(row => row == null).Concat(testArray.Where(row => row != null && row.Length == 0)).Concat(testArray.Where(row => row != null && row.Length > 0).OrderBy(row => row.Sum())).SequenceEqual(testArray));

            BubbleSorter2.Sort(testArray, compareBySumAscending);
            Assert.True(testArray.Where(row => row == null).Concat(testArray.Where(row => row != null && row.Length == 0)).Concat(testArray.Where(row => row != null && row.Length > 0).OrderBy(row => row.Sum())).SequenceEqual(testArray));
        }

        [Test]
        public void SortByMaxAscendingTest()
        {
            Sort(testArray, new ComparerByMaxAscending());
            Assert.True(testArray.Where(row => row == null).Concat(testArray.Where(row => row != null && row.Length == 0)).Concat(testArray.Where(row => row != null && row.Length > 0).OrderBy(row => row.Max())).SequenceEqual(testArray));

            Sort(testArray, compareByMaxAscending);
            Assert.True(testArray.Where(row => row == null).Concat(testArray.Where(row => row != null && row.Length == 0)).Concat(testArray.Where(row => row != null && row.Length > 0).OrderBy(row => row.Max())).SequenceEqual(testArray));

            BubbleSorter2.Sort(testArray, new ComparerByMaxAscending());
            Assert.True(testArray.Where(row => row == null).Concat(testArray.Where(row => row != null && row.Length == 0)).Concat(testArray.Where(row => row != null && row.Length > 0).OrderBy(row => row.Max())).SequenceEqual(testArray));

            BubbleSorter2.Sort(testArray, compareByMaxAscending);
            Assert.True(testArray.Where(row => row == null).Concat(testArray.Where(row => row != null && row.Length == 0)).Concat(testArray.Where(row => row != null && row.Length > 0).OrderBy(row => row.Max())).SequenceEqual(testArray));
        }

        [Test]
        public void SortByMinAscendingTest()
        {
            Sort(testArray, new ComparerByMinAscending());
            Assert.True(testArray.Where(row => row == null).Concat(testArray.Where(row => row != null && row.Length == 0)).Concat(testArray.Where(row => row != null && row.Length > 0).OrderBy(row => row.Min())).SequenceEqual(testArray));

            Sort(testArray, compareByMinAscending);
            Assert.True(testArray.Where(row => row == null).Concat(testArray.Where(row => row != null && row.Length == 0)).Concat(testArray.Where(row => row != null && row.Length > 0).OrderBy(row => row.Min())).SequenceEqual(testArray));

            BubbleSorter2.Sort(testArray, new ComparerByMinAscending());
            Assert.True(testArray.Where(row => row == null).Concat(testArray.Where(row => row != null && row.Length == 0)).Concat(testArray.Where(row => row != null && row.Length > 0).OrderBy(row => row.Min())).SequenceEqual(testArray));

            BubbleSorter2.Sort(testArray, compareByMinAscending);
            Assert.True(testArray.Where(row => row == null).Concat(testArray.Where(row => row != null && row.Length == 0)).Concat(testArray.Where(row => row != null && row.Length > 0).OrderBy(row => row.Min())).SequenceEqual(testArray));
        }

        [Test]
        public void SortBySumDescendingTest()
        {
            Sort(testArray, new ComparerBySumDescending());
            Assert.True(testArray.Where(row => row != null && row.Length > 0).OrderByDescending(row => row.Sum()).Concat(testArray.Where(row => row != null && row.Length == 0)).Concat(testArray.Where(row => row == null)).SequenceEqual(testArray));

            Sort(testArray, compareBySumDescending);
            Assert.True(testArray.Where(row => row != null && row.Length > 0).OrderByDescending(row => row.Sum()).Concat(testArray.Where(row => row != null && row.Length == 0)).Concat(testArray.Where(row => row == null)).SequenceEqual(testArray));

            BubbleSorter2.Sort(testArray, new ComparerBySumDescending());
            Assert.True(testArray.Where(row => row != null && row.Length > 0).OrderByDescending(row => row.Sum()).Concat(testArray.Where(row => row != null && row.Length == 0)).Concat(testArray.Where(row => row == null)).SequenceEqual(testArray));

            BubbleSorter2.Sort(testArray, compareBySumDescending);
            Assert.True(testArray.Where(row => row != null && row.Length > 0).OrderByDescending(row => row.Sum()).Concat(testArray.Where(row => row != null && row.Length == 0)).Concat(testArray.Where(row => row == null)).SequenceEqual(testArray));
        }

        [Test]
        public void SortByMaxDescendingTest()
        {
            Sort(testArray, new ComparerByMaxDescending());
            Assert.True(testArray.Where(row => row != null && row.Length > 0).OrderByDescending(row => row.Max()).Concat(testArray.Where(row => row != null && row.Length == 0)).Concat(testArray.Where(row => row == null)).SequenceEqual(testArray));

            Sort(testArray, compareByMaxDescending);
            Assert.True(testArray.Where(row => row != null && row.Length > 0).OrderByDescending(row => row.Max()).Concat(testArray.Where(row => row != null && row.Length == 0)).Concat(testArray.Where(row => row == null)).SequenceEqual(testArray));

            BubbleSorter2.Sort(testArray, new ComparerByMaxDescending());
            Assert.True(testArray.Where(row => row != null && row.Length > 0).OrderByDescending(row => row.Max()).Concat(testArray.Where(row => row != null && row.Length == 0)).Concat(testArray.Where(row => row == null)).SequenceEqual(testArray));

            BubbleSorter2.Sort(testArray, compareByMaxDescending);
            Assert.True(testArray.Where(row => row != null && row.Length > 0).OrderByDescending(row => row.Max()).Concat(testArray.Where(row => row != null && row.Length == 0)).Concat(testArray.Where(row => row == null)).SequenceEqual(testArray));
        }

        [Test]
        public void SortByMinDescendingTest()
        {
            Sort(testArray, new ComparerByMinDescending());
            Assert.True(testArray.Where(row => row != null && row.Length > 0).OrderByDescending(row => row.Min()).Concat(testArray.Where(row => row != null && row.Length == 0)).Concat(testArray.Where(row => row == null)).SequenceEqual(testArray));

            Sort(testArray, compareByMinDescending);
            Assert.True(testArray.Where(row => row != null && row.Length > 0).OrderByDescending(row => row.Min()).Concat(testArray.Where(row => row != null && row.Length == 0)).Concat(testArray.Where(row => row == null)).SequenceEqual(testArray));

            BubbleSorter2.Sort(testArray, new ComparerByMinDescending());
            Assert.True(testArray.Where(row => row != null && row.Length > 0).OrderByDescending(row => row.Min()).Concat(testArray.Where(row => row != null && row.Length == 0)).Concat(testArray.Where(row => row == null)).SequenceEqual(testArray));

            BubbleSorter2.Sort(testArray, compareByMinDescending);
            Assert.True(testArray.Where(row => row != null && row.Length > 0).OrderByDescending(row => row.Min()).Concat(testArray.Where(row => row != null && row.Length == 0)).Concat(testArray.Where(row => row == null)).SequenceEqual(testArray));
        }

        /// <summary>
        /// Helps on comparing two arrays that can be null or empty
        /// </summary>
        private static class ComparerHelper
        {
            /// <summary>
            /// Compares two null, empty or filled arrays. Null arrays are lesser than empty arrays, filled arrays go for further comparison
            /// </summary>
            /// <param name="left">left array</param>
            /// <param name="right">right array</param>
            /// <returns>null if both arrays are not null or empty, -1 if left is lesser, 0 on equality, 1 if right is lesser</returns>
            public static int? CompareEmptyOrNull(int[] left, int[] right)
            {
                if ((left == null || left.Length == 0) && right != null)
                {
                    return -1;
                }

                if ((right == null || right.Length == 0) && left != null)
                {
                    return 1;
                }

                if ((left == null && right == null) || (left.Length == 0 && right.Length == 0))
                {
                    return 0;
                }

                return null;
            }
        }

        private class ComparerBySumAscending : IComparer<int[]>
        {
            public int Compare(int[] left, int[] right)
            {
                return ComparerHelper.CompareEmptyOrNull(left, right) ?? left.Sum().CompareTo(right.Sum());
            }
        }

        private class ComparerByMaxAscending : IComparer<int[]>
        {
            public int Compare(int[] left, int[] right)
            {
                return ComparerHelper.CompareEmptyOrNull(left, right) ?? left.Max().CompareTo(right.Max());
            }
        }

        private class ComparerByMinAscending : IComparer<int[]>
        {
            public int Compare(int[] left, int[] right)
            {
                return ComparerHelper.CompareEmptyOrNull(left, right) ?? left.Min().CompareTo(right.Min());
            }
        }

        private class ComparerBySumDescending : IComparer<int[]>
        {
            public int Compare(int[] left, int[] right)
            {
                return ComparerHelper.CompareEmptyOrNull(right, left) ?? right.Sum().CompareTo(left.Sum());
            }
        }

        private class ComparerByMaxDescending : IComparer<int[]>
        {
            public int Compare(int[] left, int[] right)
            {
                return ComparerHelper.CompareEmptyOrNull(right, left) ?? right.Max().CompareTo(left.Max());
            }
        }

        private class ComparerByMinDescending : IComparer<int[]>
        {
            public int Compare(int[] left, int[] right)
            {
                return ComparerHelper.CompareEmptyOrNull(right, left) ?? right.Min().CompareTo(left.Min());
            }
        }
    }
}
