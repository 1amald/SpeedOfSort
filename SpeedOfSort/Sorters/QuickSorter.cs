namespace SpeedOfSort.Sorters
{
    internal sealed class QuickSorter : ISorter
    {
        private ulong counter;
        private ulong max = 1;

        public int GetProgressInPercents()
        {
            var virtualProgress = (int)(counter * 100 / max);

            if (virtualProgress > 100)
            {
                return 100;
            }

            return virtualProgress;
        }

        public void Sort(int[] array)
        {
            counter = 0;
            max = (ulong)array.Length;

            Sort(array, 0, array.Length - 1);
        }

        private int Partition(int[] array, int start, int end)
        {
            int temp;
            int marker = start;

            for (int i = start; i < end; i++)
            {
                if (array[i] < array[end])
                {
                    temp = array[marker];
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }

            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;

            return marker;
        }

        private void Sort(int[] array, int start, int end)
        {
            counter++;
            if (start >= end)
            {
                return;
            }

            int pivot = Partition(array, start, end);
            Sort(array, start, pivot - 1);
            Sort(array, pivot + 1, end);
        }
    }
}