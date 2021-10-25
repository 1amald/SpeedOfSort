using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

using SpeedOfSort.Controls;
using SpeedOfSort.Sorters;

namespace SpeedOfSort
{
    public partial class Form1 : Form
    {
        private readonly Dictionary<ISorter, SorterPresentation> _sorterWindowMap;
        private readonly CancellationTokenSource cts = new CancellationTokenSource();

        public Form1()
        {
            InitializeComponent();

            _sorterWindowMap = new Dictionary<ISorter, SorterPresentation>
            {
                { new ShellSorter(), new SorterPresentation("Shell", _flowLayoutPanel) },
                { new QuickSorter(), new SorterPresentation("QuickSorter", _flowLayoutPanel) },
                { new BubbleSorter(), new SorterPresentation("Bubble", _flowLayoutPanel) }
            };
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            _timer.Enabled = true;

            stateIndicator.Text = "Creating array";

            var arrayCount = Convert.ToInt32(arrayCountCb.Items[arrayCountCb.SelectedIndex]);
            int[] array = await Task.Run(() => GenerateArray(arrayCount));

            stateIndicator.Text = "Processing";

            if (_succesivilyRadio.Checked)
            {
                await ExecuteSuccessivily(_sorterWindowMap, array);
            }
            else
            {
                await ExecuteParallel(_sorterWindowMap, array);
            }

            _timer.Enabled = false;

            stateIndicator.Text = "Waiting for execute";
        }

        private async Task ExecuteSuccessivily(Dictionary<ISorter, SorterPresentation> map, int[] array)
        {
            foreach (KeyValuePair<ISorter, SorterPresentation> pair in map)
            {
                var newArray = new int[array.Length];
                Array.Copy(array, newArray, array.Length);

                var stopWatch = Stopwatch.StartNew();

                await Task.Run(() => pair.Key.Sort(newArray));

                pair.Value.FillTimeInfo(stopWatch.Elapsed);
            }
        }

        private async Task ExecuteParallel(Dictionary<ISorter, SorterPresentation> map, int[] array)
        {
            var tasks = new List<Task>();

            foreach (KeyValuePair<ISorter, SorterPresentation> keyValuePair in map)
            {
                var newArray = new int[array.Length];
                array.CopyTo(newArray, 0);

                Task newTask = Task.Run(
                        () =>
                        {
                            var stopWatch = Stopwatch.StartNew();

                            keyValuePair.Key.Sort(newArray);

                            return stopWatch.Elapsed;
                        })
                    .ContinueWith(task => { keyValuePair.Value.FillTimeInfo(task.Result); });

                tasks.Add(newTask);
            }

            await Task.WhenAll(tasks);
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            foreach (KeyValuePair<ISorter, SorterPresentation> keyValuePair in _sorterWindowMap)
            {
                keyValuePair.Value.SetProgress(keyValuePair.Key.GetProgressInPercents());
            }
        }

        private int[] GenerateArray(int arrayCount)
        {
            var random = new Random();
            var array = new int[arrayCount];

            for (var i = 0; i < arrayCount; i++)
            {
                array[i] = random.Next(int.MinValue, int.MaxValue);
            }

            return array;
        }
    }
}