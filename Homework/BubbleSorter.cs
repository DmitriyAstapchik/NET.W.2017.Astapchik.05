using System;
using System.Collections.Generic;

namespace Homework
{
    /// <summary>
    /// The class allows to sort jagged array of integers using bubble sort and specified arrays compare function
    /// </summary>
    public static class BubbleSorter
    {
        /// <summary>
        /// Sorts jagged integer array using bubble sort and comparer of integer arrays
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
        /// sorts a jagged array of integer arrays using compare function
        /// </summary>
        /// <param name="array">jagged array to sort</param>
        /// <param name="comparison">compare function</param>
        public static void Sort(int[][] array, Comparison<int[]> comparison)
        {
            Sort(array, new ComparerAdapter(comparison));
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
        private class ComparerAdapter : IComparer<int[]>
        {
            /// <summary>
            /// compare function
            /// </summary>
            private Comparison<int[]> comparison;

            /// <summary>
            /// constructs an instance with specified compare function
            /// </summary>
            /// <param name="comparison">compare function</param>
            public ComparerAdapter(Comparison<int[]> comparison)
            {
                this.comparison = comparison;
            }

            /// <summary>
            /// compares two arrays of integers
            /// </summary>
            /// <param name="arr1">first array</param>
            /// <param name="arr2">second array</param>
            /// <returns>value, indicating two arrays order</returns>
            public int Compare(int[] arr1, int[] arr2)
            {
                return comparison(arr1, arr2);
            }
        }
    }
}
