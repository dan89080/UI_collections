using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_ControlGroups
{
    public partial class UI_ControlGroups : Form
    {
        public int MAX_inputItems = 8;
        public int MAX_statusItems = 8;
        public int MAXShown_inputItems = 8;
        public int MAXShown_statusItems = 8;
        
        public int[] Data_inputItems;
        public int[] Data_statusItems;

        private Label[] Label_titles;
        private TextBox[] Textbox_datas;
        private Label[] Label_units;

        private PictureBox[] PictureBox_status;
        private Button[] Button_switch;

        public InputItem_Set[] InputItemSet;
        public StatusItem_Set[] StatusItemSet;

        public UI_ControlGroups()
        {
            InitializeComponent();

            UI_getInstructionItemArray();
            UI_createInstructionsArray();

            comboBox_AxisCtrlFunc.SelectedIndex = 0;
        }
        public void SetMaxNum(int input, int status, int shown_input, int shown_status)
        {
            MAX_inputItems = input;
            MAX_statusItems = status;
            MAXShown_inputItems = shown_input;
            MAXShown_statusItems = shown_status;
        }

        public class InputItem_One
        {
            public Label Lb_title;
            public TextBox Tb_data;
            public Label Lb_unit;

            public InputItem_One(Label title, TextBox data, Label unit)
            {
                //Lb_title = new Label();
                //Tb_data = new TextBox();
                //Lb_unit = new Label();
                Lb_title = title;
                Tb_data = data;
                Lb_unit = unit;
            }
            public void SetAnItem(Label title, TextBox data, Label unit)
            {
                Lb_title = title;
                Tb_data = data;
                Lb_unit = unit;
            }
        }
        public class InputItem_Set
        {
            public InputItem_One[] myItem;
            public int num_Instruction;

            /// <summary>
            /// Create space for InputItem_Set.
            /// </summary>
            /// <param name="num"></param>
            public InputItem_Set(int num)
            {
                num_Instruction = num;
                if (num <= 0)
                {
                    return;
                }
                else
                {
                    myItem = new InputItem_One[num];
                }
            }
        }
        public class StatusItem_One
        {
            public PictureBox Pb_status;
            public Button Btn_switch;

            public StatusItem_One(PictureBox status, Button btn_switch)
            {
                Pb_status = status;
                Btn_switch = btn_switch;
            }
            public void SetAnItem(PictureBox status, Button toggle)
            {
                Pb_status = status;
                Btn_switch = toggle;
            }
        }
        public class StatusItem_Set
        {
            public StatusItem_One[] myItem;
            public int num_Instruction;

            /// <summary>
            /// Create space for StatusItem_Set.
            /// </summary>
            /// <param name="num"></param>
            public StatusItem_Set(int num)
            {
                num_Instruction = num;
                if (num <= 0)
                {
                    return;
                }
                else
                {
                    myItem = new StatusItem_One[num];
                }
            }
        }

        private void UI_getInstructionItemArray()
        {
            Label_titles = new Label[MAXShown_inputItems];
            Textbox_datas = new TextBox[MAXShown_inputItems];
            Label_units = new Label[MAXShown_inputItems];

            PictureBox_status = new PictureBox[MAX_statusItems];
            Button_switch = new Button[MAX_statusItems];
            ///
            ///
            ///
            Label_titles[0] = label_func_A00;
            Label_titles[1] = label_func_A01;
            Label_titles[2] = label_func_A02;
            Label_titles[3] = label_func_A03;
            Label_titles[4] = label_func_A04;

            Label_titles[5] = label_func_A05;
            Label_titles[6] = label_func_A06;
            Label_titles[7] = label_func_A07;
            ///
            ///
            ///
            Textbox_datas[0] = textBox_func_B00;
            Textbox_datas[1] = textBox_func_B01;
            Textbox_datas[2] = textBox_func_B02;
            Textbox_datas[3] = textBox_func_B03;
            Textbox_datas[4] = textBox_func_B04;

            Textbox_datas[5] = textBox_func_B05;
            Textbox_datas[6] = textBox_func_B06;
            Textbox_datas[7] = textBox_func_B07;
            ///
            ///
            ///
            Label_units[0] = label_func_C00;
            Label_units[1] = label_func_C01;
            Label_units[2] = label_func_C02;
            Label_units[3] = label_func_C03;
            Label_units[4] = label_func_C04;

            Label_units[5] = label_func_C05;
            Label_units[6] = label_func_C06;
            Label_units[7] = label_func_C07;
            ///
            ///
            ///
            PictureBox_status[0] = pictureBox_func_A00;
            PictureBox_status[1] = pictureBox_func_A01;
            PictureBox_status[2] = pictureBox_func_A02;
            PictureBox_status[3] = pictureBox_func_A03;
            ///
            ///
            ///
            Button_switch[0] = button_func_B00;
            Button_switch[1] = button_func_B01;
            Button_switch[2] = button_func_B02;
            Button_switch[3] = button_func_B03;
        }
        private void UI_createInstructionsArray()
        {
            InputItemSet = new InputItem_Set[MAX_inputItems];
            Data_inputItems = new int[] { 0, 1, 1, 1, 0, 1, 3, 2 };
            for (int i = 0; i < MAX_inputItems; i++)
            {
                InputItemSet[i] = new InputItem_Set(Data_inputItems[i]);
            }                        
        }
        public void UI_InputItem_Set_Show(int num)
        {
            for (int i = 0; i < MAXShown_inputItems; i++)
            {
                if (i < num)
                {
                    Label_titles[i].Visible = true;
                    Textbox_datas[i].Visible = true;
                    Label_units[i].Visible = true;
                }
                else
                {
                    Label_titles[i].Visible = false;
                    Textbox_datas[i].Visible = false;
                    Label_units[i].Visible = false;
                }
            }
        }
        public void uI_StatusItem_Set_Show(int num)
        {
            for (int i = 0; i < MAX_statusItems; i++)
            {
                if (i < num)
                {
                    PictureBox_status[i].Visible = true;
                    Button_switch[i].Visible = true;
                }
                else
                {
                    PictureBox_status[i].Visible = false;
                    Button_switch[i].Visible = false;
                }
            }
        }

        private void comboBox_AxisCtrlFunc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] titles = new string[] { "" };
            string[] units = new string[] { "" };
            switch (comboBox_AxisCtrlFunc.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    titles = new string[]{
                        "時間設定"};
                    units = new string[]{
                        "(ms)"};
                    break;
                case 2:
                    titles = new string[]{
                        "偏移值(x,y,z)"};
                    units = new string[]{
                        ""};
                    break;
                case 3:
                    titles = new string[]{
                        "選擇陣列"};
                    units = new string[]{
                        ""};
                    break;
                case 4:
                    break;
                case 5:
                    titles = new string[]{
                        "轉跳位置"};
                    units = new string[]{
                        ""};
                    break;
                case 6:
                    titles = new string[]{
                        "等待訊號",
                        "動作ON.OFF",
                        "轉跳位置"};
                    units = new string[]{
                        "",
                        "",
                        ""};
                    break;
                case 7:
                    titles = new string[]{
                        "動作訊號",
                        "動作ON.OFF"};
                    units = new string[]{
                        "",
                        ""};
                    break;
                default:

                    break;
            }
            int sel_index = comboBox_AxisCtrlFunc.SelectedIndex;
            for (int i = 0; i < InputItemSet[sel_index].num_Instruction; i++)
            {
                Label_titles[i].Text = titles[i];
                Label_units[i].Text = units[i];

                InputItemSet[sel_index].myItem[i] = new InputItem_One
                    (Label_titles[i], Textbox_datas[i], Label_units[i]);
                InputItemSet[sel_index].myItem[i].Tb_data = Textbox_datas[i];
            }

            UI_InputItem_Set_Show(InputItemSet[sel_index].num_Instruction);
        }

    }
}
