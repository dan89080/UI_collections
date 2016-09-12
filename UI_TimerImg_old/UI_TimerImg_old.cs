using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

using TimerImg_old;
using System.Threading;

namespace UI_TimerImg_old
{
    public partial class UI_TimerImg_old_Page : Form
    {
        public int Pic_X, Pic_Y;
        public int cnt;
        bool Pause = false;
        double freq = 0.9;
        TimerImg_old_Handler my_Handler;
        DateTime StartTime;
        Thread thread_draw;
        bool drawing = false;

        public int temp;

        public UI_TimerImg_old_Page()
        {
            InitializeComponent();

            StartTime = DateTime.Now;

            Pic_X = pictureBox_Canvas.Size.Width;
            Pic_Y = pictureBox_Canvas.Size.Height;

            cnt = 0;
            pictureBox_Canvas.Image = new Bitmap(Pic_X, Pic_Y);
            //timer_Refresh.Enabled = true;
            //timer1.Enabled = false;
            my_Handler = new TimerImg_old_Handler((Bitmap)pictureBox_Canvas.Image);
            thread_draw = new Thread(draw_sin);
            thread_draw.IsBackground = true;

            //SetStyle(ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.ResizeRedraw, true);
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //SetStyle(ControlStyles.Selectable, true);
            temp = 0;
            timer_FPS.Start();
        }

        private unsafe void timer_Refresh_Tick(object sender, EventArgs e)
        {
            if (Pause)
                return;
            textBox_Xcnt.Text = cnt.ToString();
            pictureBox_Canvas.Refresh();
            
            //Invalidate()
        }
        #region some tools
        private void Draw_VertLine(PointDef p_Start,int Height,Color color)
        {
            PointDef p = p_Start.Clone();
            int T = Math.Abs(Height);
            p.setValue(color);
            
            if (Height < 0)
                p.Y--;
            else
                p.Y++;

            for (int i = 1; i <= T+1; i++)
            {
                p.setValue(color);
                if (Height < 0)
                    p.Y--;
                else
                    p.Y++;
            }
        }
        public void Draw_Line(ref PictureBox here, Point start, Point end, Color color)
        {
            try
            {
                using (Graphics g = Graphics.FromImage(here.BackgroundImage))
                {
                    Point a = new Point(start.X, start.Y);
                    Point b = new Point(end.X, end.Y);
                    Pen p = new Pen(color, 1);
                    g.DrawLine(p, a, b);
                    g.DrawLine(p, 200, 200, 200, 400);
                }
            }
            catch
            {

            }

        }
        private void Draw_Point(PointDef p,Color color)
        {
            p.setValue(color);
        }
        private double get_sin(double freq, double X,double X_Offset=0,double Y_Offset = 0)
        {
            return Y_Offset * Math.Sin(freq * (X / 180.0 * Math.PI) + X_Offset) + Y_Offset;
        }

        private void checkBox_Puase_Click(object sender, EventArgs e)
        {
            Pause = checkBox_Puase.Checked;
        }
        #endregion
        private void draw_sin()
        {
            while(true)
            {
                cnt++;

                pictureBox_Canvas.Invoke((MethodInvoker)delegate
                {

                    my_Handler.Draw_MiddleLine(Color.FromArgb(200, 191, 231));
                    my_Handler.Draw_ShiftLeft();
                    my_Handler.timeCount = cnt;
                    
                    my_Handler.Draw_Func_sin(Color.Tomato, my_Handler.draw_Y, freq, cnt + 1, Math.PI / 2, my_Handler.draw_Y);

                });
                
                Thread.Sleep(1);
                
            }

        }
        private void checkBox_Puase_CheckedChanged(object sender, EventArgs e)
        {
            TimeSpan duration;
            duration = DateTime.Now.Subtract(StartTime);
            textBox1.Text = string.Format("{0:D2}:{1:D2}", duration.Minutes, duration.Seconds);

        }

        private void UI_TimerImg_Page_Load(object sender, EventArgs e)
        {
            thread_draw.Start();
            timer_Refresh.Start();
        }

        
        private void timer_FPS_Tick(object sender, EventArgs e)
        {
            textBox2.Text = (cnt - temp) + "";

            temp = cnt;

        }

        private void pictureBox_Canvas_Paint(object sender, PaintEventArgs e)
        {
            c++;
        }
        int c = 0;
    }
    public unsafe class PointDef
    {
        public int X,Y;
        public byte* ptr;
        public int Stride;
        const int argb_size = 4;
        public PointDef(byte* ptr,int X,int Y,int Stride)
        {
            this.ptr = ptr;
            this.X = X;
            this.Y = Y;
            this.Stride = Stride;
        }
        public void setValue(Color color)
        {
            for (int argb = 0; argb < argb_size; ++argb)
                ptr[Y * Stride + X * argb_size + argb] = GetArgb(color, argb);
        }
        public PointDef Clone()
        {
            return (PointDef)this.MemberwiseClone();
        }
        private byte GetArgb(Color color,int ID)
        {
            switch(ID)
            {
                case 0:
                    return color.B;
                case 1:
                    return color.G;
                case 2:
                    return color.R;
                case 3:
                    return color.A;
                default:
                    return 0;
            }
        }
    }
}
