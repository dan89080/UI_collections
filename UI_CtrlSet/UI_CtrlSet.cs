using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_CtrlSet
{
    public partial class UI_CtrlSet_Page : Form
    {

        /*
        #region one dimension UI members
        public List<TextBox>     TextBox_Set;
        public List<Label>       Label_Set;
        public List<Button>      Button_Set;
        public List<PictureBox>  PictureBox_Set;
        public List<CheckBox>    CheckBox_Set;
        public List<RadioButton> RadioBtn_Set;
        #endregion

        #region two dimension UI members
        public List<List<TextBox>>     TextBox_pack_Set;
        public List<List<Label>>       Label_pack_Set;
        public List<List<Button>>      Button_pack_Set;
        public List<List<PictureBox>>  PictureBox_pack_Set;
        public List<List<CheckBox>>    CheckBox_pack_Set;
        public List<List<RadioButton>> RadioBtn_pack_Set;
        #endregion
        
        #region private members
        //private List<Control> Ctrl_Set;
        #endregion
        */

        public UI_CtrlSet_Page()
        {
            InitializeComponent();

            this.BackColor = SystemColors.ActiveCaption;
        }
        public UI_CtrlSet_Page(Color backColor)
        {
            InitializeComponent();

            this.BackColor = backColor;
        }

        public enum CtrlType
        {
            TextBox,
            Label,
            Button,
            PictureBox,
            CheckBox,
            RadioButton
        }
        /// <summary>置入新的控制項。「會」清空原有的版面。※控制項高度與Font會互相影響。</summary>
        public void ClrAndAdd_Ctrl(object Ctrl_Set, CtrlType type, Point offset, Size size, int interval_Y, int num_Y, int interval_X = 0, int num_X = 1)
        {
            this.Controls.Clear();
            Add_Ctrl(Ctrl_Set, type, offset, size, interval_Y, num_Y, interval_X, num_X);
        }
        /// <summary>置入新的控制項。「不會」清空原有的版面。※控制項高度與Font會互相影響。</summary>
        public void Add_Ctrl(object Ctrl_Set, CtrlType type, Point offset, Size size, int interval_Y, int num_Y, int interval_X = 0, int num_X = 1)
        {
            if (num_X == 1)
            {
                Ctrl_Set = new List<Control>();
                for (int i = 0; i < num_Y; i++)
                {
                    Control temp = GetTempCtrl(type, size);
                    ((List<Control>)Ctrl_Set).Add(temp);
                    this.Controls.Add(((List<Control>)Ctrl_Set)[i]);
                    int tempX = offset.X + 0;
                    int tempY = offset.Y + (interval_Y + temp.Size.Height) * i;
                    ((List<Control>)Ctrl_Set)[i].Location = new Point(tempX, tempY);
                    ((List<Control>)Ctrl_Set)[i].Show();
                }
            }
            else
            {
                Ctrl_Set = new List<List<Control>>();
                for (int i = 0; i < num_Y; i++)
                {
                    List<Control> temp_pack = new List<Control>();
                    ((List<List<Control>>)Ctrl_Set).Add(temp_pack);
                    for (int j = 0; j < num_X; j++)
                    {
                        Control temp = GetTempCtrl(type, size);
                        ((List<List<Control>>)Ctrl_Set)[i].Add(temp);
                        this.Controls.Add(((List<List<Control>>)Ctrl_Set)[i][j]);
                        int tempX = offset.X + (interval_X + temp.Size.Width) * j;
                        int tempY = offset.Y + (interval_Y + temp.Size.Height) * i;
                        ((List<List<Control>>)Ctrl_Set)[i][j].Location = new Point(tempX, tempY);
                        ((List<List<Control>>)Ctrl_Set)[i][j].Show();
                    }
                }
            }
        }
        public Control GetTempCtrl(CtrlType type, Size size)
        {
            switch (type)
            {
                case CtrlType.Button:
                    Button btn = new Button();
                    btn.Text = "Button";
                    btn.Size = size;
                    return btn;
                case CtrlType.CheckBox:
                    CheckBox cb = new CheckBox();
                    cb.Text = "CheckBox";
                    cb.Size = size;
                    return cb;
                case CtrlType.Label:
                    Label lb = new Label();
                    lb.Text = "Label";
                    lb.Size = size;
                    return lb;
                case CtrlType.PictureBox:
                    PictureBox pb = new PictureBox();
                    pb.BorderStyle = BorderStyle.Fixed3D;
                    pb.Size = size;
                    return pb;
                case CtrlType.RadioButton:
                    RadioButton rb = new RadioButton();
                    rb.Text = "RadioButton";
                    rb.Size = size;
                    return rb;
                case CtrlType.TextBox:
                    TextBox tb = new TextBox();
                    tb.Size = size;
                    return tb;
                default:
                    return null;
            }
        }

    }
}
