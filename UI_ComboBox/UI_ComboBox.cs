using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_ComboBox
{
    public partial class UI_ComboBox_Page : Form
    {
        public UI_ComboBox_Page()
        {
            InitializeComponent();
            int[] A = new int[3];
            Array.ConvertAll(A , value => (int)value);

            for (int i = 0; i < 3; i++)
                richTextBox1.Text += A[i] + "\n";
            /*
            enum 跟 string[] 的「絕對一對一」(onto and one-to-one)雙向關係鏈接。
            需能 input enum get string[] 或 input string[] get enum。
            */
        }
        #region UI button events
        private void button1_Click(object sender, EventArgs e)
        {
            string[] temp = new string[] { "" };
            try
            {
                temp = richTextBox1.Lines;
                if(temp.Count() == 0)
                    temp = new string[] { "default" };
            }
            catch { }

            int cnt = temp.Count();
            comboBox1.Items.Clear();

            for (int i = 0; i < cnt; i++)
                comboBox1.Items.Add(temp[i]);

            comboBox1.SelectedIndex = 0;
            MessageBox.Show("SelectedItem = " + comboBox1.SelectedItem);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";

            int cnt = comboBox1.Items.Count;
            string[] temp = new string[cnt];
            comboBox1.Items.CopyTo(temp, 0);

            for (int i = 0; i < cnt; i++)
                richTextBox1.Text += temp[i] + "\n";

        }
        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = comboBox1.Items[comboBox1.SelectedIndex].ToString();

            richTextBox1.Text += "\n" + comboBox1.SelectedItem.ToString();

        }
        #endregion

        public enum alpha{
            A,B,C
        }

    }
}
