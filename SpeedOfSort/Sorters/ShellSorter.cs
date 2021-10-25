using System;

namespace SpeedOfSort.Sorters
{
    internal sealed class ShellSorter : ISorter
    {
        private ulong counter;
        private ulong maxSteps = 1;

        public int GetProgressInPercents()
        {
            return (int)(counter * 100 / maxSteps);
        }

        public void Sort(int[] array)
        {
            counter = 0;
            maxSteps = GetMaxSteps(array.Length);

            int d = array.Length / 2;

            if (counter > maxSteps / 2)
            {
                var b = 0;
            }

            while (d >= 1)
            {
                counter += (ulong)(array.Length - d);

                for (int i = d; i < array.Length; i++)
                {
                    int j = i;

                    while (j >= d && array[j - d] > array[j])
                    {
                        Swap(ref array[j], ref array[j - d]);
                        j = j - d;
                    }
                }

                d = d / 2;
            }
        }

        private static ulong GetMaxSteps(int arrayLenght)
        {
            ulong result = 0;

            int d = arrayLenght / 2;

            while (d >= 1)
            {
                result += (ulong)(arrayLenght - d);
                d = d / 2;
            }

            return result;
        }

        private static void Swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }
    }
}