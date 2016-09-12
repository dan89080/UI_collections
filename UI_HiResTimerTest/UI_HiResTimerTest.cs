using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using MS_HiResTimer;


namespace UI_HiResTimerTest
{
    public partial class UI_HiResTimerTest_Page : Form
    {
        public int cnt;
        Thread test;

        public UI_HiResTimerTest_Page()
        {
            InitializeComponent();

            cnt = 1;


        }

        public void Func_HiResTimer()
        {
            HiResTimer timer = new HiResTimer();

            // This example shows how to use the high-resolution counter to 
            // time an operation. 

            // Get counter value before the operation starts.
            Int64 counterAtStart = timer.Value;

            // Perform an operation that takes a measureable amount of time.
            for (int count = 0; count < 10000; count++)
            {
                count++;
                count--;
            }

            // Get counter value when the operation ends.
            Int64 counterAtEnd = timer.Value;

            // Get time elapsed in tenths of a millisecond.
            Int64 timeElapsedInTicks = counterAtEnd - counterAtStart;
            Int64 timeElapseInTenthsOfMilliseconds =
                (timeElapsedInTicks * 10000) / timer.Frequency;

            MessageBox.Show("Time Spent in operation (tenths of ms) "
                           + timeElapseInTenthsOfMilliseconds +
                           "\nCounter Value At Start: " + counterAtStart +
                           "\nCounter Value At End : " + counterAtEnd +
                           "\nCounter Frequency : " + timer.Frequency);

        }

        public int interval;
        public bool enable;
        public void Func_MilliSecTimer()
        {
            enable = true;
            interval = 10;
            Thread timerthread = new Thread(MilliSec_TimerFunc);

            timeBeginPeriod(1);

            timerthread.Start();
        }
        #region test

        [DllImport("winmm")]
        static extern uint timeGetTime();

        [DllImport("winmm")]
        static extern void timeBeginPeriod(int t);

        [DllImport("winmm")]
        static extern uint timeEndPeriod(int t);


        public void MilliSec_TimerFunc()
        {
            uint timerstart = timeGetTime();
            while (true)
            {
                uint i = 0;
                while (i < 500)     //N为时间间隔（ms）
                {
                    i = timeGetTime() - timerstart;
                }
                timerstart = timeGetTime();
                //timerfunction();               //需要循环运行的函数；
                textBox1.Text = cnt.ToString();
                cnt++;
            }
        }


        #endregion

        public void timerTest()
        {
            //textBox1.Text = cnt.ToString();
            while (true)
            {
                cnt++;

                Thread.Sleep(1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MilliSec_TimerFunc();
            test = new Thread(timerTest);

            test.Start();
            textBox1.Text = cnt.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            test.Abort();
            //timeBeginPeriod(1);

            textBox1.Text = cnt.ToString();
        }

    }
}
