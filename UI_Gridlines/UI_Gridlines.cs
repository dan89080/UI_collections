using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_Gridlines
{
    public partial class UI_Gridlines_Page : Form
    {
        public int Xnum, Ynum, Rec_Wd, Rec_Ht, Pic_X, Pic_Y;
        public Point Orig;
        public int[] Rect_Xlist;
        public int[] Rect_Ylist;

        public UI_Gridlines_Page()
        {
            InitializeComponent();
        }

        private void button_draw_Click(object sender, EventArgs e)
        {
            Xnum = Convert.ToInt32(textBox_X.Text);
            Ynum = Convert.ToInt32(textBox_Y.Text);
            Pic_X = pictureBox1.Size.Width;
            Pic_Y = pictureBox1.Size.Height;
            pictureBox1.BackgroundImage = new Bitmap(Pic_X, Pic_Y);
            Image my_grid = new Bitmap(Pic_X, Pic_Y);
            Pic_X -= 11;
            Pic_Y -= 11;
            Rec_Wd = Convert.ToInt32(Math.Floor(((double)Pic_X / (double)Xnum)));
            Rec_Ht = Convert.ToInt32(Math.Floor(((double)Pic_Y / (double)Ynum)));
            Size RectSize = new Size(Rec_Wd, Rec_Ht);

            Graphics g = Graphics.FromImage(my_grid);
            //Graphics g = Graphics.FromImage(pictureBox1.BackgroundImage);
            g.Clear(Color.FromArgb(120, 200, 200));

            //Orig = new Point(pictureBox1.Size.Width - Rec_Wd * Xnum - 8, 3);
            Orig = new Point(3, 3);

            Pen p = new Pen(Color.FromArgb(200, 135, 150), 1);
            Rectangle[][] r;
            r = new Rectangle[Ynum][];

            for (int i = 0; i < Ynum; i++)
            {
                Rectangle[] temp = new Rectangle[Xnum];
                r[i] = temp;
            }

            CntRectSizeList();

            for (int j = 0; j < Ynum; j++)
            {
                for (int i = 0; i < Xnum; i++)
                {
                    Size temp = new Size(Rect_Xlist[i + 1] - Rect_Xlist[i], Rect_Ylist[j + 1] - Rect_Ylist[j]);
                    r[j][i] = PutRect(new Point(Rect_Xlist[i] + Orig.X, Rect_Ylist[j] + Orig.Y), temp);
                    r[j][i] = new Rectangle(CntRectOffset(Orig, new Point(i, j), RectSize), RectSize);
                }
            }


            for (int i = 0; i < Ynum; i++)
            {
                g.DrawRectangles(p, r[i]);
            }

            g.Dispose();
            pictureBox1.BackgroundImage = my_grid;
        }



        public void CntRectSizeList()
        {
            Rect_Xlist = new int[Xnum + 1];
            Rect_Ylist = new int[Ynum + 1];

            if (Pic_X % Xnum != 0)
            {
                for (int i = Pic_X, j = 0; j < Xnum; j++)
                {

                    if (i % Xnum != 0)
                    {
                        i--;
                    }
                    Rect_Xlist[j] = Pic_X - i - 1;
                    i = i - Rec_Wd + 1;
                }
            }
            else
            {
                for (int i = Pic_X, j = Xnum - 1; j >= 0; j--)
                {
                    i = i - Rec_Wd;
                    Rect_Xlist[j] = i;
                }
            }
            Rect_Xlist[Xnum] = Pic_X;
            if (Pic_Y % Ynum != 0)
            {
                for (int i = Pic_Y, j = Ynum - 1; j >= 0; j--)
                {
                    i = i - Rec_Ht - 1;

                    if (i % Ynum != 0)
                    {
                        i--;
                    }
                    Rect_Ylist[j] = i;
                }
            }
            else
            {
                for (int i = Pic_Y, j = Ynum - 1; j >= 0; j--)
                {
                    i = i - Rec_Ht;
                    Rect_Ylist[j] = i;
                }
            }
            Rect_Ylist[Ynum] = Pic_Y;


            //richTextBox1.Text = "X:";
            for (int i = 0; i <= Xnum; i++)
            {
                //richTextBox1.Text += Rect_Xlist[i] + ", ";
            }
            //richTextBox1.Text += "\nY:";
            for (int i = 0; i <= Ynum; i++)
            {
                //richTextBox1.Text += Rect_Ylist[i] + ", ";
            }

        }
        public Point CntRectOffset(Point Orig, Point there, Size RectSize)
        {
            return new Point(Orig.X + there.X * RectSize.Width, Orig.Y + there.Y * RectSize.Height);
        }
        public Rectangle PutRect(Point there, Size SmallRectSize)
        {
            return new Rectangle(there, SmallRectSize);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            Point Offset = new Point(
                Control.MousePosition.X - pictureBox1.Location.X - this.Location.X - 08,//BorderStyle
                Control.MousePosition.Y - pictureBox1.Location.Y - this.Location.Y - 31 //BorderStyle
                );
            Point AxisPos = new Point(Offset.X - Orig.X, Offset.Y - Orig.Y);


            if (Rec_Wd * Rec_Wd != 0)
            {
                AxisPos = new Point(Convert.ToInt32(Math.Ceiling((double)AxisPos.X / (double)Rec_Wd)) - 1, Convert.ToInt32(Math.Ceiling((double)AxisPos.Y / (double)Rec_Ht)) - 1);
                if (AxisPos.X < 0 || AxisPos.Y < 0 || AxisPos.X >= Xnum || AxisPos.Y >= Ynum)
                {
                    return;
                }
                int Frame_Wd = Convert.ToInt32(Math.Ceiling(0.1 * (double)Rec_Wd));
                int Frame_Ht = Rec_Ht - Convert.ToInt32(0.9 * (double)Rec_Ht);
                AxisPos = new Point(
                    Convert.ToInt32(Math.Ceiling((double)AxisPos.X * (double)Rec_Wd)) + Frame_Wd + Orig.X,
                    Convert.ToInt32(Math.Ceiling((double)AxisPos.Y * (double)Rec_Ht)) + Frame_Ht + Orig.Y
                    );

                Frame_Wd = Rec_Wd - Convert.ToInt32(0.2 * (double)Rec_Wd);
                Frame_Ht = Rec_Ht - Convert.ToInt32(0.2 * (double)Rec_Ht);
                pictureBox1.Image = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
                Graphics g = Graphics.FromImage(pictureBox1.Image);

                Pen p = new Pen(Color.FromArgb(255, 0, 0), 2);
                Rectangle CurrentRect = new Rectangle(AxisPos, new Size(Frame_Wd, Frame_Ht));

                g.DrawRectangle(p, CurrentRect);

                g.Dispose();
            }
        }

        public class ImageGrid
        {
            public Image theImage;
            public int Xnum, Ynum;

            private int Orig_wd, Orig_ht;
            private int Fixed_wd, Fixed_ht;
            //private int Rec_Wd, Rec_Ht;
            private Point Orig;
            private Size RectSize;
            private int[] Rect_Xlist;
            private int[] Rect_Ylist;

            public ImageGrid(Image img, int num_X, int num_Y)
            {
                if (img == null)
                {
                    return;
                }
                theImage = img;
                Xnum = num_X;
                Ynum = num_Y;
                Orig = new Point(3, 3);

                Orig_wd = theImage.Size.Width;
                Orig_ht = theImage.Size.Height;
                Fixed_wd = Orig_wd - 11;
                Fixed_ht = Orig_ht - 11;
                int Rec_Wd = Convert.ToInt32(Math.Floor(((double)Fixed_wd / (double)Xnum)));
                int Rec_Ht = Convert.ToInt32(Math.Floor(((double)Fixed_ht / (double)Ynum)));
                RectSize = new Size(Rec_Wd, Rec_Ht);

                Graphics g = Graphics.FromImage(theImage);
                g.Clear(Color.FromArgb(120, 200, 200));


            }


        }


    }
}
