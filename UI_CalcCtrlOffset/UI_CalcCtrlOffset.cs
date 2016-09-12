using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalcCtrlOffset_Helper;

namespace UI_CalcCtrlOffset
{
    public partial class UI_CalcCtrlOffset_Page : Form
    {
        private Size BorderSize;

        public UI_CalcCtrlOffset_Page()
        {
            InitializeComponent();
            BorderSize = CalcCtrlOffset_helper.Diff_Size2ClientSize(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Point temp;
            //temp = CalcCtrlOffset_helper.Offset_CtrlBorder2FormClient(button1);
            //temp = CalcCtrlOffset_helper.Offset_Ctrl2FormWhole(button1);
            temp = CalcCtrlOffset_helper.Offset_Ctrl2Screen(button1);
            //temp.X += sz.Width;
            //temp.Y += sz.Height + sz.Width;
            //temp.X -= this.Location.X;
            //temp.Y -= this.Location.Y;
            MessageBox.Show("button1.Location = " + temp);
            //MessageBox.Show("button1.FindForm = " + button1.FindForm().Name);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Point temp;
            //temp = CalcCtrlOffset_helper.Offset_Ctrl2FormClient(button2);
            //temp = CalcCtrlOffset_helper.Offset_Ctrl2FormWhole(button2);
            temp = CalcCtrlOffset_helper.Offset_Ctrl2Screen(button2);
            //temp.X += sz.Width;
            //temp.Y += sz.Height + sz.Width;
            //temp.X -= this.Location.X;
            //temp.Y -= this.Location.Y;
            MessageBox.Show("button2.Location = " + temp);
            //MessageBox.Show("button1.FindForm = " + button1.FindForm().Name);
        }
    }
}
