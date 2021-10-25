using System;
using System.Drawing;
using System.Windows.Forms;

namespace SpeedOfSort.Controls
{
    internal sealed class SorterPresentation
    {
        private readonly ProgressBar _progressBar;
        private readonly Label _name;
        private readonly Label _time;

        public SorterPresentation(string title, FlowLayoutPanel targetPanel)
        {
            _progressBar = new ProgressBar
            {
                Minimum = 0,
                Maximum = 100,
                Size = new Size(200, 60),
                Visible = true
            };
            _name = new Label
            {
                Text = title,
                AutoSize = true
            };
            _time = new Label
            {
                Text = "Tap execute",
                AutoSize = true
            };

            var panel = new FlowLayoutPanel
            {
                AutoSize = true,
                FlowDirection = FlowDirection.TopDown
            };

            panel.Controls.Add(_name);
            panel.Controls.Add(_progressBar);
            panel.Controls.Add(_time);

            targetPanel.Controls.Add(panel);
        }

        public void FillTimeInfo(TimeSpan ellapsed)
        {
            if (_time.InvokeRequired)
            {
                var d = new SafeFillTimeInfoDelegate(FillTimeInfo);
                _time.Invoke(d, ellapsed);
            }
            else
            {
                _time.Text = $"Seconds: {ellapsed.Seconds} \n" +
                    $"Miliseconds: {ellapsed.Milliseconds} \n" +
                    $"Ticks: {ellapsed.Ticks} \n";

                SetProgress(100);
            }
        }

        public void SetProgress(int value)
        {
            _progressBar.Value = value;
        }

        private delegate void SafeFillTimeInfoDelegate(TimeSpan ellapsed);
    }
}