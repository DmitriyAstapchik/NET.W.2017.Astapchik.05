using System;
using System.Linq;
using System.Collections.Generic;

namespace Homework
{
    /// <summary>
    /// The class allows to sort jagged array of integers in several possible ways using bubble sort
    /// </summary>
    public static class BubbleSorter
    {
        /// <summary>
        /// compares two int arrays
        /// </summary>
        /// <param name="array1">first array</param>
        /// <param name="array2">second array</param>
        /// <returns>value, indicating two arrays order</returns>
        public delegate int CompareArrays(int[] array1, int[] array2);

        /// <summary>
        /// Possible kinds of sort
        /// </summary>
        public enum SortBy { Sum, Max, Min };

        /// <summary>
        /// Ascending or descending sort order
        /// </summary>
        public enum SortOrder { Ascending, Descending };

        /// <summary>
        /// Sorts jagged int array using bubble sort and comparer of int arrays
        /// </summary>
        /// <param name="array">jagged array to sort</param>
        /// <param name="comparer">object that compares two arrays</param>
        public static void Sort(int[][] array, IComparer<int[]> comparer)
        {
            bool swapped = true;
            for (int i = 0; i < array.Length - 1 && swapped == true; i++)
            {
                swapped = false;
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (comparer.Compare(array[j], array[j + 1]) > 0)
                    {
                        SwapArrays(ref array[j], ref array[j + 1]);
                        swapped = true;
                    }
                }
            }
        }

        /// <summary>
        /// sorts a jagged array of int arrays using compare function
        /// </summary>
        /// <param name="array">jagged array to sort</param>
        /// <param name="compare">compare function</param>
        public static void Sort(int[][] array, CompareArrays compare)
        {
            Sort(array, new ArrayComparer(compare));
        }

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
        internal static void SwapArrays(ref int[] array1, ref int[] array2)
        {
            var temp = array1;
            array1 = array2;
            array2 = temp;
        }

        /// <summary>
        /// represents an array compare object
        /// </summary>
        private class ArrayComparer : IComparer<int[]>
        {
            /// <summary>
            /// compare function
            /// </summary>
            private CompareArrays compare;

            /// <summary>
            /// constructs an instance with specified compare function
            /// </summary>
            /// <param name="compare">compare function</param>
            public ArrayComparer(CompareArrays compare)
            {
                this.compare = compare;
            }

            /// <summary>
            /// compares two arrays of integers
            /// </summary>
            /// <param name="arr1">first array</param>
            /// <param name="arr2">second array</param>
            /// <returns>value, indicating two arrays order</returns>
            public int Compare(int[] arr1, int[] arr2)
            {
                return compare(arr1, arr2);
            }
        }
    }

    /// <summary>
    /// second version of array bubble sorter
    /// </summary>
    public static class BubbleSorter2
    {
        /// <summary>
        /// sorts a jagged array of arrays of integers using compare function
        /// </summary>
        /// <param name="array">jagged array to sort</param>
        /// <param name="compare">compare function</param>
        public static void Sort(int[][] array, BubbleSorter.CompareArrays compare)
        {
            bool swapped = true;
            for (int i = 0; i < array.Length - 1 && swapped == true; i++)
            {
                swapped = false;
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (compare(array[j], array[j + 1]) > 0)
                    {
                        BubbleSorter.SwapArrays(ref array[j], ref array[j + 1]);
                        swapped = true;
                    }
                }
            }
        }

        /// <summary>
        /// sorts a jagged array of arrays of integers using arrays comparer
        /// </summary>
        /// <param name="array">array to sort</param>
        /// <param name="comparer">arrays compare object</param>
        public static void Sort(int[][] array, IComparer<int[]> comparer)
        {
            Sort(array, comparer.Compare);
        }
    }
}
