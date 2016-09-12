using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimerImg;

namespace UI_TimerImg_test
{
    public partial class UI_TimerImg_test_Page : Form
    {
        public int Pic_X, Pic_Y;
        public int cnt;
        public bool Pause = false;
        public double freq = 0.9;
        public TimerImg_Handler my_Handler;
        public DateTime StartTime;
        public List<float> values;
        public Graph_time2value G_t2v;
        public GraphicsPath oldPath;

        public System.Windows.Forms.Timer timer_Refresh;
        public System.Threading.Timer timer_calc;
        public System.Timers.Timer timer_assign;

        public UI_TimerImg_test_Page()
        {
            InitializeComponent();

            StartTime = DateTime.Now;
            Pause = false;
            cnt = 0;
            Pic_X = pictureBox_Canvas.Size.Width;
            Pic_Y = pictureBox_Canvas.Size.Height;
            pictureBox_Canvas.Image = new Bitmap(Pic_X, Pic_Y);
            my_Handler = new TimerImg_Handler((Bitmap)pictureBox_Canvas.Image);
            InitFuncVal();
            //for (int i = 0; i < values.Count; i++)
            //{
            //    richTextBox1.Text += values[i] + "\n";
            //}
            //G_t2v.path.ToString();
            //using (Graphics g = Graphics.FromImage(my_Handler.my_Bitmap))
            //{
            //    g.DrawPath(Pens.Tomato, G_t2v.path);
            //}

            timer_calc = new System.Threading.Timer(
                timer_calc_Tick,
                null,
                TimeSpan.FromSeconds(0),
                TimeSpan.FromMilliseconds(1));
            timer_Refresh = new System.Windows.Forms.Timer();
            timer_Refresh.Tick += timer_Refresh_Tick;
            timer_Refresh.Interval = 1;
            timer_assign = new System.Timers.Timer();
            timer_assign.Elapsed += timer_assign_Elapsed;
            timer_assign.Interval = 1;
            
            timer_Refresh.Start();
            timer_assign.Start();
        }
        #region timers and checkBox
        private void checkBox_Pause_Click(object sender, EventArgs e)
        {
            Pause = checkBox_Pause.Checked;
        }
        private void timer_calc_Tick(object sender)
        {
            if (Pause)
                return;

            //object lk = new object();
            //lock(lk)
            //{
            //    cnt++;
            //}
            cnt++;
            ///
            /// calc function(sin) value
            ///
        }
        private void timer_Refresh_Tick(object sender, EventArgs e)
        {

            pictureBox_Canvas.Refresh();
            textBox_Xcnt.Text = cnt.ToString();

            TimeSpan duration;
            duration = DateTime.Now.Subtract(StartTime);
            if (duration.TotalMilliseconds > 2000000)
                timer_calc.Dispose();
        }
        private void timer_assign_Elapsed(object sender, EventArgs e)
        {
            using (Graphics g = Graphics.FromImage(my_Handler.my_Bitmap))
            {
                g.Clear(Color.Transparent);
                //Pen p_old = new Pen(Color.Black, 1);
                Pen p_new = new Pen(Color.Tomato, 1);
                //g.DrawPath(p_old, oldPath);
                //oldPath = G_t2v.path;
                float new_val = Convert.ToSingle(TimerImg_Handler.get_sin(my_Handler.draw_Y, freq/2, cnt, Math.PI / 2, my_Handler.draw_Y));
                G_t2v.updateValues(new_val, true);
                
                g.DrawPath(p_new, G_t2v.path);
            }
        }
        #endregion
        #region calculating function
        public void InitFuncVal()
        {
            //double init_Val = TimerImg_Handler.get_sin(my_Handler.draw_Y, freq, 0, Math.PI / 2, my_Handler.draw_Y);

            values = new List<float>(my_Handler.Pic_X);
            for(int i = 0; i < values.Capacity; i++)
            {                
                values.Add(Convert.ToSingle(TimerImg_Handler.get_sin(my_Handler.draw_Y, freq, i, Math.PI / 2, my_Handler.draw_Y)));
                cnt = i;
            }
            
            G_t2v = new Graph_time2value(values, 0, my_Handler.Pic_X);

            //G_t2v.

        }
        public void GenFuncVal(int count)
        {
            float last_val = Convert.ToSingle(TimerImg_Handler.get_sin(my_Handler.draw_Y, freq, count, Math.PI / 2, my_Handler.draw_Y));

            G_t2v.updateValues(last_val, true);
        }


        #endregion


    }
}
