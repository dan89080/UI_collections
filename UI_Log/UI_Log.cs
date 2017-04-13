using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_Log
{
    public partial class UI_Log_Page : Form
    {
        public Color color_green  = Color.FromArgb(24,  231, 71);
        public Color color_yellow = Color.FromArgb(255, 255, 36);
        public Color color_blue   = Color.FromArgb(60,  40,  255);
        public Color color_red    = Color.FromArgb(255, 0,   0);
        public Color color_white  = Color.FromArgb(255, 255, 255);
        public Color color_black  = Color.FromArgb(0,   0,   0);

        public Font default_font = new Font("微軟正黑體", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(136)));

        public UI_Log_Page()
        {
            InitializeComponent();

            richTextBox_Log.AppendText("YA\n");
            TextColoring(ref richTextBox_Log, "十二藍\n", color_blue);
            TextColoring(ref richTextBox_Log, "十四藍\n", color_red, 16F);
            TextColoring(ref richTextBox_Log, "二十白\n", color_white, 20F);
            TextColoring(ref richTextBox_Log, "十六綠\n", color_green, 16F, FontStyle.Bold);
            TextColoring(ref richTextBox_Log, "十八黃\n", color_yellow, 18F, FontStyle.Underline);

            richTextBox_Log.AppendText("YO\n");
        }
        /// <summary>客製化加入到RTB的字。使用此函數後，如欲增加文字，請使用RTB.AppendText以保持客製化效果。FontStyle參數範例：((FontStyle)((FontStyle.Bold | FontStyle.Underline)))</summary>
        public void TextColoring(ref RichTextBox rtb, string text, Color color, float TextSize = 12F, FontStyle fs = FontStyle.Regular)
        {
            rtb.SelectionColor = color;
            rtb.SelectionFont = new Font("微軟正黑體", TextSize, fs, GraphicsUnit.Point, ((byte)(136)));
            rtb.AppendText(text);
        }
    }
}
