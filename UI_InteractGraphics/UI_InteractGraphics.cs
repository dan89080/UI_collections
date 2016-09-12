using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_InteractGraphics
{
    ///
    /// http://www.java2s.com/Code/CSharp/2D-Graphics/GraphicsPathExample.htm
    /// 
    public partial class UI_InteractGraphics_Page : Form
    {
        public GraphicsPath path;


        public UI_InteractGraphics_Page()
        {
            InitializeComponent();
        }

        private void UI_InteractGraphics_Page_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            path = new GraphicsPath();
            
            path.StartFigure();
            //參數：圖形外接長方形左上角座標/長寬，起始角度(質心垂直最下方為0°，方向逆時針)，角度差
            path.AddArc(10, 10, 100, 100, 20, 50);
            path.AddLine(20, 50, 70, 230);
            path.CloseFigure();

            path.AddEllipse(120, 50, 80, 80);

            e.Graphics.FillPath(Brushes.White, path);
            e.Graphics.DrawPath(Pens.Black, path);
        }

        private void UI_InteractGraphics_Page_MouseDown(object sender, MouseEventArgs e)
        {
            if (path.IsVisible(e.X, e.Y))
            {
                MessageBox.Show("You clicked inside the figure.");
            }

        }

        public bool PntIsInCtrl(Control ctrl, int X_inForm, int Y_inForm)
        {
            bool inX = (ctrl.Location.X <= X_inForm && X_inForm <= (ctrl.Location.X + ctrl.Size.Width)) ? true : false;
            bool inY = (ctrl.Location.Y <= Y_inForm && Y_inForm <= (ctrl.Location.Y + ctrl.Size.Height)) ? true : false;
            
            if(inX && inY)
                return true;
            else
                return false;
        }
    }
}
