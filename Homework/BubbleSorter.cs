using System;
using System.Linq;

namespace Homework
{
    /// <summary>
    /// The class allows to sort jagged array of integers in several possible ways using bubble sort
    /// </summary>
    public static class BubbleSorter
    {
        /// <summary>
        /// Possible kinds of sort
        /// </summary>
        public enum SortBy { Sum, Max, Min };

        /// <summary>
        /// Ascending or descending sort order
        /// </summary>
        public enum SortOrder { Ascending, Descending };

        /// <summary>
        /// Sorts jagged array by ascending/descending its nested arrays elements sum, max value or minvalue
        /// </summary>
        /// <param name="array">array to sort</param>
        /// <param name="by">kind of sort</param>
        /// <param name="order">order of sort</param>
        public static void Sort(int[][] array, SortBy by, SortOrder order)
        {
            #region compare func initialization
            Func<int[], int[], bool> compare;
            if (order == SortOrder.Ascending)
            {
                if (by == SortBy.Sum)
                {
                    compare = (arr1, arr2) => arr1.Sum() > arr2.Sum();
                }
                else if (by == SortBy.Max)
                {
                    compare = (arr1, arr2) => arr1.Max() > arr2.Max();
                }
                else
                {
                    compare = (arr1, arr2) => arr1.Min() > arr2.Min();
                }
            }
            else
            {
                if (by == SortBy.Sum)
                {
                    compare = (arr1, arr2) => arr1.Sum() < arr2.Sum();
                }
                else if (by == SortBy.Max)
                {
                    compare = (arr1, arr2) => arr1.Max() < arr2.Max();
                }
                else
                {
                    compare = (arr1, arr2) => arr1.Min() < arr2.Min();
                }
            }
            #endregion

            bool swapped = true;
            for (int i = 0; i < array.Length - 1 && swapped == true; i++)
            {
                swapped = false;
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (compare(array[j], array[j + 1]))
                    {
                        SwapArrays(ref array[j], ref array[j + 1]);
                        swapped = true;
                    }
                }
            }
        }

        /// <summary>
        /// Swaps two arrays by ref
        /// </summary>
        /// <param name="array1">first array</param>
        /// <param name="array2">second array</param>
        private static void SwapArrays(ref int[] array1, ref int[] array2)
        {
            var temp = array1;
            array1 = array2;
            array2 = temp;
        }
    }
}
