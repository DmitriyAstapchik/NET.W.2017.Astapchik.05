using System.Collections.Generic;

namespace Homework
{
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
