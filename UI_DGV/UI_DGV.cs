using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DGV_Helper;
//using FormShared;
namespace UI_DGV
{
    public partial class FormDgvCtrl : Form
    {
        DGV_helper dgv_handle;
        private int DGV_sel_idx;
        private int DGV_sel_cnt;

        public FormDgvCtrl()//Panel Loader)
        {
            InitializeComponent();
            //FitThisToDGV();
            dgv_handle = new DGV_helper();
            DGV_sel_idx = 0;
            DGV_TwoHeaders(ref dataGridView_Show);

            dgv_handle.DefaultItemsDGV( ref dataGridView_Show);
            dgv_handle.InitStdDGV(      ref dataGridView_Show);
            dgv_handle.set_DGV_ReadOnly(ref dataGridView_Show, 0, 2);
            dgv_handle.GetDGV(          ref dataGridView_Show);

            List<object> val = new List<object>();
            val.Add(6);
            val.Add(12);
            dgv_handle.add_DGV_Row(ref dataGridView_Show, val);
            //dgv_handle.sort_DGV_Rows(ref dataGridView_Show, 0, ListSortDirection.Descending);

            my_test = new List<TestData>();
            my_bindingSource = new BindingSource();
        }

        #region some events and functions
        /// <summary>強制讓this的版面大小等於DGV的大小。。</summary>
        public void FitThisToDGV()
        {
            this.ClientSize = dataGridView_Show.Size;
        }
        /// <summary>強制讓這個DGV至少擁有兩個欄位可以使用。</summary>
        public void DGV_TwoHeaders(ref DataGridView DGV)
        {
            if (DGV.ColumnCount > 1)
                return;

            DataGridViewTextBoxColumn a = new DataGridViewTextBoxColumn();
            a.HeaderText = "Idx";
            a.Name = "index";
            DataGridViewTextBoxColumn b = new DataGridViewTextBoxColumn();
            b.HeaderText = "val";
            b.Name = "value";

            DGV.Columns.AddRange(new DataGridViewColumn[] {a, b});
        }
        /// <summary>左鍵計算起始選取index、右鍵可show出選單。</summary>
        public void onCellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            switch(e.Button)
            {
                case MouseButtons.Left:
                    break;
                case MouseButtons.Right:
                    if (e.RowIndex >= 0)
                        contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);//dataGridView1.GetCellCount(DataGridViewElementStates.Selected)
                    break;
                default:
                    return;
            }
        }
        /// <summary>左鍵計算index，右鍵選擇CurrentCell、調整編輯的enable屬性。</summary>
        private void onCellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    break;
                case MouseButtons.Right:
                    get_DGV_selectedRowIdx();

                    if (e.RowIndex > -1 && !(DGV_sel_idx <= e.RowIndex && e.RowIndex < DGV_sel_cnt + DGV_sel_idx))
                    {
                        DGV_sel_idx = e.RowIndex;
                        DGV_sel_cnt = 1;
                        dataGridView_Show.CurrentCell = dataGridView_Show.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }

                    if (dataGridView_Show.SelectedCells.Count > 1)
                        editToolStripMenuItem.Enabled = false;
                    else
                        editToolStripMenuItem.Enabled = true;

                    break;
                default:
                    return;
            }
        }
        /// <summary>Returns the array(index) of selected rows.</summary>
        private int[] get_DGV_selectedRowIdx()
        {
            if (dataGridView_Show.CurrentCell == null)
            {
                DGV_sel_idx = -1;
                DGV_sel_cnt = 0;
                return null;
            }
            if(dataGridView_Show.SelectedCells.Count == 0)
            {
                DGV_sel_idx = -1;
                DGV_sel_cnt = 0;
                return null;
            }
            int[] rowIndexes = (from sc in dataGridView_Show.SelectedCells.Cast<DataGridViewCell>()
                          select sc.RowIndex).Distinct().ToArray();
            DGV_sel_idx = rowIndexes.Min();
            DGV_sel_cnt = rowIndexes.Max() - DGV_sel_idx + 1;
            return rowIndexes;
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            get_DGV_selectedRowIdx();

            dataGridView_Show.CurrentCell = dataGridView_Show.Rows[DGV_sel_idx].Cells[1];

            dataGridView_Show.CurrentCell.Selected = true;

            button_Add.PerformClick();
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            get_DGV_selectedRowIdx();
            dgv_handle.DGV_COPY(DGV_sel_idx, DGV_sel_cnt);
        }
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            get_DGV_selectedRowIdx();
            dgv_handle.DGV_CUT(DGV_sel_idx, DGV_sel_cnt);
        }
        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            get_DGV_selectedRowIdx();
            //dgv_handle.DGV_INSERT(DGV_sel_idx);
            test_INSERT(DGV_sel_idx);
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            get_DGV_selectedRowIdx();
            dgv_handle.DGV_DELETE(DGV_sel_idx, DGV_sel_cnt);
        }

        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            switch(e.Button)
            {
                case MouseButtons.Left:
                    return;
                case MouseButtons.Right:
                    Size sz = new Size(dataGridView_Show.Size.Width,
                        dataGridView_Show.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + dataGridView_Show.ColumnHeadersHeight);
                    Rectangle rect = new Rectangle(dataGridView_Show.Location, sz);
                    if(!Mouse_InRect(rect) && dataGridView_Show.SelectedCells.Count > 0)
                    {
                        DGV_sel_idx = dataGridView_Show.RowCount - 1;
                        DGV_sel_cnt = 1;
                        dataGridView_Show.ClearSelection();
                        dataGridView_Show.Rows[DGV_sel_idx].Selected = true;
                        editToolStripMenuItem.Enabled = true;

                        contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                    }
                    if(dataGridView_Show.SelectedCells.Count == 0)
                    {
                        DGV_sel_idx = -1;
                        DGV_sel_cnt = 0;
                        editToolStripMenuItem.Enabled = false;

                        contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                    }
                    return;
                default:
                    return;
            }
        }
        public bool Mouse_InRect(Rectangle rect)
        {
            if (rect == null)
                return false;

            int borderWidth = (this.Width - this.ClientSize.Width) / 2;
            int titleBarHeight = this.Height - this.ClientSize.Height - 2 * borderWidth;

            Point Mouse2Form = new Point(MousePosition.X - this.Location.X - borderWidth,
                MousePosition.Y - this.Location.Y - titleBarHeight - borderWidth);

            if (rect.X <= Mouse2Form.X && Mouse2Form.X <= rect.X + rect.Size.Width &&
                rect.Y <= Mouse2Form.Y && Mouse2Form.Y <= rect.Y + rect.Size.Height)
                return true;
            else
                return false;
        }
        #endregion


        #region DGV data binding_source with custom class
        private class TestData
        {
            private int idx;
            private string info;

            public TestData(int index, string information)
            {
                idx = index;
                info = information;
            }

            public int my_idx
            {
                get
                {
                    return idx;
                }

                //set
                //{
                //    idx = value;
                //}
            }
            public string my_info
            {
                get
                {
                    return info;
                }

                set
                {
                    info = value;
                }
            }
        }
        private List<TestData> my_test;
        private BindingSource my_bindingSource;
        private void button_Init_Click(object sender, EventArgs e)
        {
            dataGridView_Show.DataSource = my_bindingSource;

            index.DataPropertyName = "my_idx";
            value.DataPropertyName = "my_info";

            my_bindingSource.Clear();

            my_test.Clear();
            my_test.Add(new TestData(1, "a"));
            my_test.Add(new TestData(2, "b"));
            my_test.Add(new TestData(3, "c"));
            my_test.Add(new TestData(4, "d"));
            my_test.Add(new TestData(5, "e"));

            //for (int i = 0; i < my_test.Count; i++)
            //    my_bindingSource.Add(my_test[i]);

            my_bindingSource.DataSource = my_test;
        }
        private void button_Print_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            for (int i = 0; i < my_test.Count; i++)
                richTextBox1.Text += my_test[i].my_idx + "\t" + my_test[i].my_info + "\n";
            //richTextBox1.Text += "HI:"+my_test[0].ToString();
        }
        private void button_Add_Click(object sender, EventArgs e)
        {
            get_DGV_selectedRowIdx();
            
            //my_test.Insert(DGV_sel_idx + 1, new TestData(my_test.Count() + 1, "test"));

            //my_bindingSource.Insert(DGV_sel_idx + 1, my_test[DGV_sel_idx + 1]);
            my_bindingSource.Insert(DGV_sel_idx + 1, new TestData(my_test.Count() + 1, "test"));
            //my_bindingSource.DataSource = my_test;
            //dataGridView_Show.Refresh();

        }
        private void test_INSERT(int idx)
        {
            for (int i = 0; i < dgv_handle.ClipBoard.Count; i++)
                my_bindingSource.Insert(idx + 1 + i, Clip2TestData(i));
        }
        private TestData Clip2TestData(int i)
        {
            DataGridViewRow DGV_R = dgv_handle.DGV_Row_CloneValues(dgv_handle.ClipBoard[i]);
            
            int idx  = (int)(DGV_R.Cells[0].Value);
            string info = (string)(DGV_R.Cells[1].Value);
            return new TestData(idx, info);
        }

        #endregion

    }

}
