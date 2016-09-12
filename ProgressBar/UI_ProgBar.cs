using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_ProgBar
{
    public partial class UI_ProgBar_page : Form
    {
        public Timer timer_progress;
        public int MyIncrement;

        public UI_ProgBar_page()
        {
            InitializeComponent();

            Init_timer(100, false);

            TimerTextSettings();
        }
        #region TimerEvents
        public void Init_timer(int Interval, bool Enabled)
        {
            MyIncrement = 10;
            timer_progress = new Timer();
            timer_progress.Interval = Interval;
            timer_progress.Enabled = Enabled;
            timer_progress.Tick += timer_progress_Tick;
        }
        private void timer_progress_Tick(object sender, EventArgs e)
        {
            if (MyProgressBar.Value <= MyProgressBar.Maximum)
            {
                try
                {
                    if (checkBox_toInputText.Checked == true)
                    {
                        MyIncrement = Convert.ToInt32(textBox_inc_Timer.Text);
                    }
                    else
                    {
                        MyIncrement = 10;
                    }
                    MyProgressBar.Increment(MyIncrement);
                    label_interval.Text = "Timer Interval:\n(" + timer_progress.Interval + ")ms";
                    label_Increment.Text = "Timer Increment:\n(" + MyIncrement + ")";
                }
                catch
                {

                }

            }
        }
        private void TimerTextSettings()
        {
            if (timer_progress.Enabled)
            {
                button_timerAble.Text = "disable\ntimer(10)";
            }
            else
            {
                button_timerAble.Text = "enable\ntimer(10)";
                label_interval.Text = "Timer Interval:\n(--)ms";
            }
            label_interval.Text = "Timer Interval:\n(" + timer_progress.Interval + ")ms";
            textBox_SetInterval.Text = timer_progress.Interval + "";
            
        }
        #endregion
        #region ButtonEvents
        private void button_reset_Click(object sender, EventArgs e)
        {
            MyProgressBar.Value = MyProgressBar.Minimum;
        }
        private void button_timerAble_Click(object sender, EventArgs e)
        {
            timer_progress.Enabled = !timer_progress.Enabled;

            TimerTextSettings();
        }
        private void button_InputOnce_Click(object sender, EventArgs e)
        {
            try
            {
                MyProgressBar.Value += Convert.ToInt32(textBox_inc_Once.Text);
            }
            catch
            {
                textBox_inc_Once.Text = "0";
            }
        }
        private void button_SetInterval_Click(object sender, EventArgs e)
        {
            try
            {
                timer_progress.Interval = Convert.ToInt32(textBox_SetInterval.Text);
                label_interval.Text = "Timer Interval:\n(" + timer_progress.Interval + ")ms";
            }
            catch
            {

            }
        }
        #endregion

    }
}
