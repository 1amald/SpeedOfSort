namespace SpeedOfSort.Sorters
{
    public interface ISorter
    {
        public int GetProgressInPercents();
        public void Sort(int[] array);
    }
}