using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using UI_CtrlSet;

namespace UI_collections
{
    public partial class theMain_page : Form
    {
        UI_CtrlSet_Page my_CtrlSet;

        public const string str_SYStabCtrl = "System.Windows.Forms.TabControl";
        public const string str_SYStextBox = "System.Windows.Forms.TextBox";
        public const string str_SYSgroupBx = "System.Windows.Forms.GroupBox";
        public const string str_SYStabPage = "System.Windows.Forms.TabPage";
        public const string str_SYSpanel = "System.Windows.Forms.Panel";
        public const string str_SYStimer = "System.Windows.Forms.Timer";
        public const string str_SYSbutton = "System.Windows.Forms.Button";
        public const string str_SYSchkbox = "System.Windows.Forms.CheckBox";
        public const string str_SYSrdobtn = "System.Windows.Forms.RadioButton";
        public const string str_SYSrhtxtBx = "System.Windows.Forms.RichTextBox";
        public const string str_SYSctxmnsp = "System.Windows.Forms.ContextMenuStrip";
        public const string str_SYStlsmnim = "System.Windows.Forms.ToolStripMenuItem";
        public const string str_SYSlabel = "System.Windows.Forms.Label";

        static public Button[] MyButton;
        static public TextBox[] MyTextBox;
        static public RichTextBox[] MyRhtxtBx;
        static public CheckBox[] MyChkBox;
        static public RadioButton[] MyRdoBtn;
        static public Label[] MyLabel;

        static public int NumButton;
        static public int NumTextBox;
        static public int NumRhtxtBox;
        static public int NumChkBox;
        static public int NumRdoBtn;
        static public int NumLabel;


        public theMain_page()
        {
            InitializeComponent();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(my_CtrlSet == null)
                my_CtrlSet = new UI_CtrlSet_Page();
            else if(my_CtrlSet.Visible == false)
                my_CtrlSet = new UI_CtrlSet_Page();
            /*ShowPage_InPanel(my_CtrlSet, ref panel1);*/

            if(!this.Controls.Contains(my_CtrlSet))
            {
                my_CtrlSet.TopLevel = false;
                this.Controls.Add(my_CtrlSet);
                my_CtrlSet.Show();
            }

            Point a;
            Size b;

            a = new Point(30,01);
            b = new Size(80,29);
            List<List<TextBox>> TextBox_pack_Set = new List<List<TextBox>>();
            my_CtrlSet.ClrAndAdd_Ctrl(TextBox_pack_Set, UI_CtrlSet_Page.CtrlType.TextBox, a, b, 2, 4, 40, 2);

            List<List<PictureBox>> PictureBox_pack_Set = new List<List<PictureBox>>();
            a = new Point(01, 01);
            b = new Size(29, 29);
            my_CtrlSet.Add_Ctrl(PictureBox_pack_Set, UI_CtrlSet_Page.CtrlType.PictureBox, a, b, 2, 4, 91, 2);
        }

        public void ShowPage_InPanel(object page, ref Panel panel)
        {
            panel.Controls.Clear();
            ((Form)page).TopLevel = false;
            panel.Controls.Add(((Form)page));
            ((Form)page).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.Controls.Contains(my_CtrlSet))
                return;

            CopySomething(ref panel1);

        }

        public void CopySomething(ref Panel pl)
        {
            pl.BackColor = my_CtrlSet.BackColor;


            
            
            
        }
        static private void MakeEventTrace_Testing(Control pCtrl)
        {
            //Count the amount of these controls
            //Num is now used to count the total amount.
            NumButton = 0;
            //NumTextBox = 0;
            //NumRhtxtBox = 0;
            NumChkBox = 0;
            NumRdoBtn = 0;
            NumLabel = 0;
            ControlCounting(pCtrl);

            //Make the amount of these controls
            MyButton = new Button[NumButton];
            //MyTextBox = new TextBox[NumTextBox];
            //MyRhtxtBx = new RichTextBox[NumRhtxtBox];
            MyChkBox = new CheckBox[NumChkBox];
            MyRdoBtn = new RadioButton[NumRdoBtn];
            MyLabel = new Label[NumLabel];

            //Assign them to our array, making it more convenient.
            //Num is now used for iteration
            NumButton = 0;
            //NumTextBox = 0;
            //NumRhtxtBox = 0;
            NumChkBox = 0;
            NumRdoBtn = 0;
            NumLabel = 0;
            ControlAssigning(pCtrl);


        }

        static private void ControlCounting(Control pCtrl)
        {
            foreach (Control cCtrl in pCtrl.Controls)
            {
                switch (cCtrl.GetType().ToString())
                {
                    case str_SYSbutton:
                        NumButton++;
                        break;
                    /*case str_SYStextBox:
                        NumTextBox++;
                        break;
                    case str_SYSrhtxtBx:
                        NumRhtxtBox++;
                        break;*/
                    case str_SYSchkbox:
                        NumChkBox++;
                        break;
                    case str_SYSrdobtn:
                        NumRdoBtn++;
                        break;
                    case str_SYSlabel:
                        NumLabel++;
                        break;
                    case str_SYSpanel:
                        ControlCounting(cCtrl);
                        break;
                    case str_SYSgroupBx:
                        ControlCounting(cCtrl);
                        break;
                    case str_SYStabCtrl:
                        for (int i = 0; i < ((TabControl)cCtrl).TabCount; i++)
                        {
                            ControlCounting(cCtrl, i);
                        }
                        break;
                    default:
                        //
                        break;
                }
            }
        }
        static private void ControlCounting(Control pCtrl, int i)
        {
            foreach (Control cCtrl in ((TabControl)pCtrl).TabPages[i].Controls)
            {
                switch (cCtrl.GetType().ToString())
                {
                    case str_SYSbutton:
                        NumButton++;
                        break;
                    /*case str_SYStextBox:
                        NumTextBox++;
                        break;
                    case str_SYSrhtxtBx:
                        NumRhtxtBox++;
                        break;*/
                    case str_SYSchkbox:
                        NumChkBox++;
                        break;
                    case str_SYSrdobtn:
                        NumRdoBtn++;
                        break;
                    case str_SYSlabel:
                        NumLabel++;
                        break;
                    case str_SYSpanel:
                        ControlCounting(cCtrl);
                        break;
                    case str_SYSgroupBx:
                        ControlCounting(cCtrl);
                        break;
                    case str_SYStabCtrl:
                        for (int j = 0; j < ((TabControl)cCtrl).TabCount; j++)
                        {
                            ControlCounting(cCtrl, j);
                        }
                        break;
                    default:
                        //
                        break;
                }
            }
        }
        static private void ControlAssigning(Control pCtrl)
        {
            foreach (Control cCtrl in pCtrl.Controls)
            {
                switch (cCtrl.GetType().ToString())
                {
                    case str_SYSbutton:
                        Button btnCtrl = (Button)cCtrl;
                        MyButton[NumButton] = new Button();
                        MyButton[NumButton] = btnCtrl;
                        NumButton++;
                        break;
                    /*case str_SYStextBox:

                        NumTextBox++;
                        break;
                    case str_SYSrhtxtBx:

                        NumRhtxtBox++;
                        break;*/
                    case str_SYSchkbox:
                        CheckBox chkboxCtrl = (CheckBox)cCtrl;
                        MyChkBox[NumChkBox] = new CheckBox();
                        MyChkBox[NumChkBox] = chkboxCtrl;
                        NumChkBox++;
                        break;
                    case str_SYSrdobtn:
                        RadioButton rdobtnCtrl = (RadioButton)cCtrl;
                        MyRdoBtn[NumRdoBtn] = new RadioButton();
                        MyRdoBtn[NumRdoBtn] = rdobtnCtrl;
                        NumRdoBtn++;
                        break;
                    case str_SYSlabel:
                        Label lblCtrl = (Label)cCtrl;
                        MyLabel[NumLabel] = new Label();
                        MyLabel[NumLabel] = lblCtrl;
                        NumLabel++;
                        break;
                    case str_SYSpanel:
                        ControlAssigning(cCtrl);
                        break;
                    case str_SYSgroupBx:
                        ControlAssigning(cCtrl);
                        break;
                    case str_SYStabCtrl:
                        for (int i = 0; i < ((TabControl)cCtrl).TabCount; i++)
                        {
                            ControlAssigning(cCtrl, i);
                        }
                        break;
                    default:
                        //
                        break;
                }
            }
        }
        static private void ControlAssigning(Control pCtrl, int i)
        {
            foreach (Control cCtrl in ((TabControl)pCtrl).TabPages[i].Controls)
            {
                switch (cCtrl.GetType().ToString())
                {
                    case str_SYSbutton:
                        Button btnCtrl = (Button)cCtrl;
                        MyButton[NumButton] = new Button();
                        MyButton[NumButton] = btnCtrl;
                        NumButton++;
                        break;
                    /*case str_SYStextBox:

                        NumTextBox++;
                        break;
                    case str_SYSrhtxtBx:

                        NumRhtxtBox++;
                        break;*/
                    case str_SYSchkbox:
                        CheckBox chkboxCtrl = (CheckBox)cCtrl;
                        MyChkBox[NumChkBox] = new CheckBox();
                        MyChkBox[NumChkBox] = chkboxCtrl;
                        NumChkBox++;
                        break;
                    case str_SYSrdobtn:
                        RadioButton rdobtnCtrl = (RadioButton)cCtrl;
                        MyRdoBtn[NumRdoBtn] = new RadioButton();
                        MyRdoBtn[NumRdoBtn] = rdobtnCtrl;
                        NumRdoBtn++;
                        break;
                    case str_SYSlabel:
                        Label lblCtrl = (Label)cCtrl;
                        MyLabel[NumLabel] = new Label();
                        MyLabel[NumLabel] = lblCtrl;
                        NumLabel++;
                        break;
                    case str_SYSpanel:
                        ControlAssigning(cCtrl);
                        break;
                    case str_SYSgroupBx:
                        ControlAssigning(cCtrl);
                        break;
                    case str_SYStabCtrl:
                        for (int j = 0; j < ((TabControl)cCtrl).TabCount; j++)
                        {
                            ControlAssigning(cCtrl, j);
                        }
                        break;
                    default:
                        //
                        break;
                }
            }
        }


    }
}
