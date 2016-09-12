using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_WriteImage
{
    public partial class UI_WriteImage_page : Form
    {
        public UI_WriteImage_page()
        {
            InitializeComponent();

            this.BackgroundImage = new Bitmap(this.Size.Width, this.Size.Height);
            this.BackgroundImage = 
                Write2Image(this.BackgroundImage, "(1)backgroung image 測試\n文\t字 0 1 2 9", new Point(100, 100));

            Font f;
            f = new Font("Microsoft Jhenghei", 28, FontStyle.Underline);
            this.BackgroundImage =
                Write2Image(this.BackgroundImage, "(2)早安", f, new Point(100, 200));
            f = new Font("新細明體", 28, FontStyle.Underline);
            this.BackgroundImage =
                Write2Image(this.BackgroundImage, "(3)晚安", f, Brushes.White, new Point(250, 200));

        }

        /// <summary>
        /// 將指定的文字畫在指定的影像。
        /// </summary>
        /// <param name="theImage"></param>
        /// <param name="msg"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public Image Write2Image(Image theImage, string msg, Point where)
        {
            if(theImage == null)
            {
                return null;
            }
            Graphics g = Graphics.FromImage(theImage);
            Font f = new Font("Microsoft Jhenghei", 12, FontStyle.Underline);

            g.DrawString(msg, f, Brushes.Black, where);

            g.Dispose();
            return theImage;
        }
        /// <summary>
        /// 將指定的文字使用指定的字形畫在指定的影像。
        /// </summary>
        /// <param name="theImage"></param>
        /// <param name="msg"></param>
        /// <param name="f"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public Image Write2Image(Image theImage, string msg, Font f, Point where)
        {
            if (theImage == null)
            {
                return null;
            }
            Graphics g = Graphics.FromImage(theImage);

            g.DrawString(msg, f, Brushes.Black, where);

            g.Dispose();
            return theImage;
        }
        /// <summary>
        /// 將指定的文字使用指定的字形和顏色畫在指定的影像。
        /// </summary>
        /// <param name="theImage"></param>
        /// <param name="msg"></param>
        /// <param name="f"></param>
        /// <param name="brush"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public Image Write2Image(Image theImage, string msg, Font f, Brush brush, Point where)
        {
            //this.BackgroundImage = new Bitmap(this.Size.Width, this.Size.Height);
            if (theImage == null)
            {
                return null;
            }
            Graphics g = Graphics.FromImage(theImage);
            //Font f = new Font("Microsoft Jhenghei", Convert.ToSingle(24), FontStyle.Underline);
            //Font f = new Font("新細明體", 18, FontStyle.Underline);
            //Font f = new Font(fontName, 18, FontStyle.Underline);//"Microsoft Jhenghei"
            //Font f = new Font("Microsoft Jhenghei", 18, FontStyle.Underline);
            //this.Font.Name

            g.DrawString(msg, f, brush, where);

            g.Dispose();
            return theImage;
        }

    }
}
