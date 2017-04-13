using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI_CtrlOperating.PageTest_WPF;

namespace UI_CtrlOperating
{
    public partial class UI_CtrlOperating_Page : Form
    {
        private List<Button> BtnList;

        public UI_CtrlOperating_Page()
        {
            InitializeComponent();

            ///把這邊函數化
            ///void Init_DragUI();
            UI_CtrlOperating_Funcs.Get_BASE_PAGE(this);
            UI_CtrlOperating_Funcs.TimerCreate();
            MouseDown += UI_CtrlOperating_Funcs.TheForm_MouseDown;
            MouseMove += UI_CtrlOperating_Funcs.TheForm_MouseMove;
            MouseUp += UI_CtrlOperating_Funcs.TheForm_MouseUp;
            Paint += UI_CtrlOperating_Funcs.TheForm_Paint;
            UI_CtrlOperating_Funcs.CtrlMode = UI_CtrlOperating_Funcs.TheMode.UI_Edit_Mode;


            BtnList = new List<Button>();
            for(int i = 0; i < 99; i++)
            {
                BtnList.Add(new Button());
                BtnList[i].FlatStyle = FlatStyle.Flat;
                //BtnList[i].Visible = false;
                AddMovingCtrl(BtnList[i], i);
            }

            BtnList[0].Location = new Point(50, 60);
            BtnList[1].Location = new Point(200, 60);
            //button3_Click(null, null);

            //UI_CtrlOperating_Funcs.CtrlMode = UI_CtrlOperating_Funcs.TheMode.Func_Edit_Mode;
            //radioButton_Func_Edit.Checked = true;
            //BtnList[2].Focus();
            ////UI_CtrlOperating_Funcs.Ctrl_Click(null, null);

            //ToolStripButton TSB = new ToolStripButton(Properties.Resources.Sunset);
            //Controls.Add(TSB);
            //Controls.AddRange( (new Control[] { ((Control)(TSB)) }));

            BtnList[0].Text = "整\n體\n座\n標\n偏\n移";
            BtnList[1].Text = "移\n動\n到\n位\n置";
            BtnList[2].Text = "吐\n膠";
            BtnList[3].Text = "停\n止\n吐\n膠";
            BtnList[4].Text = "點\n膠\n結\n束";
        }

        public void AddMovingCtrl(Control ctrl, int i = 0)
        {
            ctrl.Size = new Size(32, 123);
            ctrl.Location = new Point(0 + 500 + ctrl.Width * i, 60);// + ctrl.Size.Height * i);
            ctrl.BackColor = SystemColors.Control;
            Controls.Add(ctrl);

            AddTheCtrl(ctrl);
        }
        public void AddTheCtrl(Control ctrl)
        {
            ctrl.MouseDown += UI_CtrlOperating_Funcs.Ctrl_MouseDown;
            ctrl.MouseMove += UI_CtrlOperating_Funcs.Ctrl_MouseMove;
            ctrl.MouseUp += UI_CtrlOperating_Funcs.Ctrl_MouseUp;
            ctrl.MouseEnter += UI_CtrlOperating_Funcs.Ctrl_MouseEnter;
            ctrl.MouseLeave += UI_CtrlOperating_Funcs.Ctrl_MouseLeave;
            ctrl.Click += UI_CtrlOperating_Funcs.Ctrl_Click;
        }

        private void UI_CtrlOperating_Page_MouseDown(object sender, MouseEventArgs e)
        {
            //BtnList[2].Text = "YOO";
        }
        private void UI_CtrlOperating_Page_MouseMove(object sender, MouseEventArgs e)
        {
            int SideBdr = (Width - ClientSize.Width) / 2;
            int TopBdr = (Height - ClientSize.Height) - SideBdr;

            Point CursorPos = new Point(
                Cursor.Position.X - Location.X - SideBdr,
                Cursor.Position.Y - Location.Y - TopBdr);


            //BtnList[0].Text = "" + UI_LinkingCtrl.MouseInBorder(button1, CursorPos);
            //BtnList[1].Text = "" + CursorPos;
            //BtnList[2].Text = "" + Cursor.Position;
            //BtnList[3].Text = "" + button1.Location;

        }

        private void rdoBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Exec.Checked)
            {
                UI_CtrlOperating_Funcs.CtrlMode = UI_CtrlOperating_Funcs.TheMode.Exec_Mode;
                Invalidate();
            }
            else if (radioButton_Func_Edit.Checked)
            {
                UI_CtrlOperating_Funcs.CtrlMode = UI_CtrlOperating_Funcs.TheMode.Func_Edit_Mode;
                Invalidate();
            }
            else if (radioButton_UI_Edit.Checked)
            {
                UI_CtrlOperating_Funcs.CtrlMode = UI_CtrlOperating_Funcs.TheMode.UI_Edit_Mode;
                for (int i = 0; i < BtnList.Count; i++)
                {

                }
            }
            else if (radioButton_Aro_Edit.Checked)
            {
                UI_CtrlOperating_Funcs.CtrlMode = UI_CtrlOperating_Funcs.TheMode.Aro_Edit_Mode;


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            radioButton_UI_Edit.Checked = true;
            UI_CtrlOperating_Funcs.CtrlMode = UI_CtrlOperating_Funcs.TheMode.UI_Create_Mode;
            Cursor = Cursors.Cross;
            try
            {
                Cursor csr = new Cursor("鼠標檔案位置");
                
            }catch { }

            ///把這邊函數化
            ///Button NewBtn();
            Button temp = new Button();
            temp.Size = new Size(75, 23);
            temp.Text = "hey";
            temp.BackColor = SystemColors.Control;
            //temp.Click += btn_Click;
            AddTheCtrl(temp);
            UI_CtrlOperating_Funcs.Ctrl_Creating = temp;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            radioButton_UI_Edit.Checked = true;
            UI_CtrlOperating_Funcs.CtrlMode = UI_CtrlOperating_Funcs.TheMode.UI_Create_Mode;
            Cursor = Cursors.Cross;

            ///把這邊函數化
            ///Button NewBtn();
            PictureBox temp = new PictureBox();
            temp.Size = new Size(100, 50);
            temp.BackgroundImageLayout = ImageLayout.Stretch;
            temp.BackgroundImage = Properties.Resources.Sunset;
            //temp.BackColor = Color.Blue;
            temp.BorderStyle = BorderStyle.FixedSingle;
            //temp.Click += btn_Click;
            AddTheCtrl(temp);
            UI_CtrlOperating_Funcs.Ctrl_Creating = temp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UI_CtrlOperating_Funcs.UI_LkCtrl = new List<UI_LinkingCtrl>();

            UI_CtrlOperating_Funcs.UI_LkCtrl.Add(new UI_LinkingCtrl(BtnList[0], BtnList[1]));
            UI_CtrlOperating_Funcs.UI_LkCtrl.Add(new UI_LinkingCtrl(BtnList[1], BtnList[2]));
            UI_CtrlOperating_Funcs.UI_LkCtrl.Add(new UI_LinkingCtrl(BtnList[2], BtnList[3]));
            UI_CtrlOperating_Funcs.UI_LkCtrl.Add(new UI_LinkingCtrl(BtnList[3], BtnList[4]));

            for (int i = 4; i < 98; i++ )
            {
                UI_CtrlOperating_Funcs.UI_LkCtrl.Add(new UI_LinkingCtrl(BtnList[i], BtnList[i+1]));
            }

                this.Refresh();
            //UI_CtrlOperating_Funcs.DrawCtrlLinkLine(BtnList[2], BtnList[3]);
            //BtnList[2].Text = button1.Parent.ToString();
            //BtnList[3].Text = button2.Parent.ToString();
        }

        //UserControl1
        //private void btn_Click(object sender, EventArgs e)
        //{
        //    if (UI_CtrlOperating_Funcs.CtrlMode == UI_CtrlOperating_Funcs.TheMode.Exec_Mode)
        //    {
        //    }
        //}

    }
}
