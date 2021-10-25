namespace SpeedOfSort.Sorters
{
    internal sealed class BubbleSorter : ISorter
    {
        private int counter;
        private int arrayLenght = 1;

        public int GetProgressInPercents()
        {
            return (int)(counter * 100 / arrayLenght);
        }

        public void Sort(int[] array)
        {
            counter = 0;
            arrayLenght = array.Length;

            int temp;

            for (var i = 0; i < array.Length - 1; i++)
            {
                counter++;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
    }
}