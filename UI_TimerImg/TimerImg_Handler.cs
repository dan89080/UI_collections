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

namespace TimerImg
{
    public unsafe class TimerImg_Handler
    {
        public Bitmap my_Bitmap;
        public BitmapData my_bmpData;
        public byte* my_bmpPtr;

        public int timeCount;
        /// <summary>Size of pictureBox.</summary>
        public int Pic_X, Pic_Y;
        /// <summary>The drawing position.</summary>
        public int draw_X, draw_Y;
        /// <summary>Current displaying position.</summary>
        public int idx_X, idx_Y;
        /// <summary>[is pause state] ? true : false</summary>
        public bool isPause;

        private const int argb_size = 4;

        public TimerImg_Handler(Bitmap grid)
        {
            my_Bitmap = grid;

            timeCount = 0;
            Pic_X = my_Bitmap.Width;
            Pic_Y = my_Bitmap.Height;
            draw_X = Pic_X - 2;
            draw_Y = (int)((Pic_Y - 6) / 2.0);
            idx_X = draw_X;
            idx_Y = draw_Y;
            isPause = false;
        }
        /// <summary>比強制設置argb四個值還要「慢」。</summary>
        public void Draw_Pixel(int to_X, int to_Y, int from_X, int from_Y)//, Color color)
        {
            for (int argb = 0; argb < argb_size; ++argb)
                my_bmpPtr[GetPtrArrayIdx(to_X, to_Y, argb)] = my_bmpPtr[GetPtrArrayIdx(from_X, from_Y, argb)];
        }
        private int GetPtrArrayIdx(int x, int y, int offset = 0)
        {
            return y * my_bmpData.Stride + x * argb_size + offset;
        }
        /// <summary>回傳值型態為Color，成員不只ARGB(所以會比較慢)。</summary>
        public Color Get_Pixel(int X, int Y)
        {
            try
            {
                Color color = Color.FromArgb(
                    my_bmpPtr[Y * my_bmpData.Stride + X * argb_size + 3],
                    my_bmpPtr[Y * my_bmpData.Stride + X * argb_size + 2],
                    my_bmpPtr[Y * my_bmpData.Stride + X * argb_size + 1],
                    my_bmpPtr[Y * my_bmpData.Stride + X * argb_size + 0]);
                //color.B = my_bmpPtr[Y * my_bmpData.Stride + X * argb_size + 0];
                //color.G = my_bmpPtr[Y * my_bmpData.Stride + X * argb_size + 1];
                //color.R = my_bmpPtr[Y * my_bmpData.Stride + X * argb_size + 2];
                //color.A = my_bmpPtr[Y * my_bmpData.Stride + X * argb_size + 3];
                return color;
            }
            catch
            {
                return Color.Transparent;
            }
        }
        private byte GetArgb(Color color, int ID)
        {
            switch (ID)
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
        public void Draw_MiddleLine(Color color)
        {
            ///
            /// LockBits and Pointer
            ///
            my_bmpData = my_Bitmap.LockBits(
                new Rectangle(Point.Empty, my_Bitmap.Size),
                ImageLockMode.ReadWrite,
                PixelFormat.Format32bppArgb);
            my_bmpPtr = (byte*)my_bmpData.Scan0;
            ///
            /// Draw MiddleLine
            ///
            for (int j = 0; j < my_bmpData.Stride; j += 4)
            {
                //Color.FromArgb(200, 191, 231)
                my_bmpPtr[draw_Y * my_bmpData.Stride + j + 0] = Color.FromArgb(200, 191, 231).B;
                my_bmpPtr[draw_Y * my_bmpData.Stride + j + 1] = Color.FromArgb(200, 191, 231).G;
                my_bmpPtr[draw_Y * my_bmpData.Stride + j + 2] = Color.FromArgb(200, 191, 231).R;
                my_bmpPtr[draw_Y * my_bmpData.Stride + j + 3] = Color.FromArgb(200, 191, 231).A;
            }
            ///
            /// UnlockBits
            ///
            my_Bitmap.UnlockBits(my_bmpData);
        }
        public void Draw_ShiftLeft()
        {
            ///
            /// LockBits and Pointer
            ///
            my_bmpData = my_Bitmap.LockBits(
                new Rectangle(Point.Empty, my_Bitmap.Size),
                ImageLockMode.ReadWrite,
                PixelFormat.Format32bppArgb);
            my_bmpPtr = (byte*)my_bmpData.Scan0;
            ///
            /// Shift Left
            ///
            for (int i = 0; i < Pic_Y; i++)
            {
                for (int j = 4; j < my_bmpData.Stride; j += 4)
                {
                    int stride_offset = i * my_bmpData.Stride + j;
                    my_bmpPtr[stride_offset - 4] = my_bmpPtr[stride_offset + 0];
                    my_bmpPtr[stride_offset - 3] = my_bmpPtr[stride_offset + 1];
                    my_bmpPtr[stride_offset - 2] = my_bmpPtr[stride_offset + 2];
                    my_bmpPtr[stride_offset - 1] = my_bmpPtr[stride_offset + 3];
                }
            }
            ///
            /// UnlockBits
            ///
            my_Bitmap.UnlockBits(my_bmpData);
        }


        public void Draw_Func_sin(Color color, double amp, double freq, double X_now, double X_Offset = 0, double Y_Offset = 0)
        {
            int a_X = draw_X;
            int b_X = draw_X - 1;
            double a_Y = get_sin(amp, freq, X_now + 1, Math.PI / 2, draw_Y);
            double b_Y = get_sin(amp, freq, X_now + 0, Math.PI / 2, draw_Y);
            Point a = new Point(a_X, (int)a_Y);
            Point b = new Point(b_X, (int)b_Y);
            using (Graphics g = Graphics.FromImage(my_Bitmap))
            {
                Pen p = new Pen(color, 1);
                g.DrawLine(p, a, b);


            }

        }
        /// <summary>Example for getting [sin] value. Fits inside.</summary>
        public static double get_sin(double amp, double freq, double X_now, double X_Offset = 0, double Y_Offset = 0)
        {
            return amp * Math.Sin(freq * (X_now / 180.0 * Math.PI) + X_Offset) + Y_Offset;
        }

    }

    public class Graph_time2value
    {
        public List<float> values;
        public int time_start;
        public int time_end;
        public GraphicsPath path;

        public Graph_time2value(List<float> values, int time_start, int time_end)
        {
            if (time_end - time_start != values.Count)
                return;

            this.values = values;
            this.time_start = time_start;
            this.time_end = time_end;

            updatePaths();
        }
        private void updatePaths()
        {
            path = new GraphicsPath();

            for (int i = time_start, m = 0; i < time_end - 1; i++, m++)
            {
                path.AddLine(i, values[m], i + 1, values[m + 1]);
                
            }
        }
        public void updateValues(float val, bool discharge)
        {
            if (discharge)
                values.RemoveAt(0);

            values.Add(val);

            updatePaths();
        }


    }
    public class Poi2D
    {
        public int x, y;
        public Poi2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
