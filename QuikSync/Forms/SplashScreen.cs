using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormAnimation;

namespace QuikSync.Forms
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();

            MaxValue = 100;
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
        }

        private void SplashScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(38, 38, 42), 2), this.DisplayRectangle);
        }

        public void IncrementValue(int inc = 1)
        {
            CurrentValue += inc;
            ReDrawProgressBar();
            this.Update();
        }

        public void SetText(string text) 
        {
            textLabel.Text = text;
            this.Update();
        }

        public void ReDrawProgressBar() 
        {
            progressPanel.Width = (int)((CurrentValue / (double)MaxValue * 100) * (this.Width / (double)100));
        }

        private int maxVal;
        public int MaxValue { get { return maxVal; } set { maxVal = value;  ReDrawProgressBar(); } }
        public int CurrentValue {get; set;}
    }
}
