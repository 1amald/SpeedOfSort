using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace SpeedOfSort
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startButton = new System.Windows.Forms.Button();
            this.arrayCountCb = new System.Windows.Forms.ComboBox();
            this._parallelRadio = new System.Windows.Forms.RadioButton();
            this._flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._succesivilyRadio = new System.Windows.Forms.RadioButton();
            this._timer = new System.Timers.Timer();
            this.stateIndicator = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._timer)).BeginInit();
            this.SuspendLayout();

            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(49, 331);
            this.startButton.Margin = new System.Windows.Forms.Padding(5);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(239, 58);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Execute";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);

            // 
            // arrayCountCb
            // 
            this.arrayCountCb.FormattingEnabled = true;
            this.arrayCountCb.Items.AddRange(new object[] { "10000", "50000", "100000", "500000", "1000000", "5000000", "10000000", "100000000" });
            this.arrayCountCb.Location = new System.Drawing.Point(59, 259);
            this.arrayCountCb.Margin = new System.Windows.Forms.Padding(5);
            this.arrayCountCb.Name = "arrayCountCb";
            this.arrayCountCb.Size = new System.Drawing.Size(215, 39);
            this.arrayCountCb.TabIndex = 2;

            // 
            // _parallelRadio
            // 
            this._parallelRadio.Location = new System.Drawing.Point(59, 150);
            this._parallelRadio.Name = "_parallelRadio";
            this._parallelRadio.Size = new System.Drawing.Size(215, 33);
            this._parallelRadio.TabIndex = 3;
            this._parallelRadio.Text = "Parallel";
            this._parallelRadio.UseVisualStyleBackColor = true;

            // 
            // _flowLayoutPanel
            // 
            this._flowLayoutPanel.AutoSize = true;
            this._flowLayoutPanel.BackColor = System.Drawing.Color.Azure;
            this._flowLayoutPanel.Location = new System.Drawing.Point(327, 150);
            this._flowLayoutPanel.Name = "_flowLayoutPanel";
            this._flowLayoutPanel.Padding = new System.Windows.Forms.Padding(100, 200, 100, 200);
            this._flowLayoutPanel.Size = new System.Drawing.Size(200, 400);
            this._flowLayoutPanel.TabIndex = 5;

            // 
            // _succesivilyRadio
            // 
            this._succesivilyRadio.Checked = true;
            this._succesivilyRadio.Location = new System.Drawing.Point(59, 197);
            this._succesivilyRadio.Name = "_succesivilyRadio";
            this._succesivilyRadio.Size = new System.Drawing.Size(215, 33);
            this._succesivilyRadio.TabIndex = 4;
            this._succesivilyRadio.TabStop = true;
            this._succesivilyRadio.Text = "Successivity";
            this._succesivilyRadio.UseVisualStyleBackColor = true;

            // 
            // _timer
            // 
            this._timer.Interval = 50D;
            this._timer.SynchronizingObject = this;
            this._timer.Elapsed += new System.Timers.ElapsedEventHandler(this._timer_Elapsed);

            // 
            // stateIndicator
            // 
            this.stateIndicator.Location = new System.Drawing.Point(59, 86);
            this.stateIndicator.Name = "stateIndicator";
            this.stateIndicator.Size = new System.Drawing.Size(215, 45);
            this.stateIndicator.TabIndex = 6;
            this.stateIndicator.Text = "Waiting for execution";

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(2421, 1460);
            this.Controls.Add(this.stateIndicator);
            this.Controls.Add(this._succesivilyRadio);
            this.Controls.Add(this._parallelRadio);
            this.Controls.Add(this.arrayCountCb);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this._flowLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this._timer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label stateIndicator;

        private System.Timers.Timer _timer;

        private System.Windows.Forms.RadioButton _parallelRadio;
        private System.Windows.Forms.RadioButton _succesivilyRadio;

        private System.Windows.Forms.ComboBox arrayCountCb;

        private System.Windows.Forms.Button startButton;

        private System.Windows.Forms.FlowLayoutPanel _flowLayoutPanel;

        #endregion
    }
}