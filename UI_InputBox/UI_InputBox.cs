using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI_InputBox_Page
{
    public partial class UI_InputBox : Form
    {
        private string _Result;
        public string result { get { return _Result; } }

        public UI_InputBox(string title)
        {
            InitializeComponent();
            this.Text = title;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _Result = userinput.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _Result = "";
        }


    }
}
