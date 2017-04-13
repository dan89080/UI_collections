using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_DGV_table
{
    public partial class UI_DGV_table_Page : Form
    {
        public List<RowData> DisplayTable;
        public UI_DGV_table_Page()
        {
            InitializeComponent();
        }

        public void DGV_Init()
        {
            DisplayTable.Add(new RowData(new object[] { 
                "怪奇塔、儲值", "強大的物理/術傷害", "陣亡爆發", "重擊、降敵方物防", "", "", "" }));
            DisplayTable.Add(new RowData(new object[] { 
                "", "", "", "", "", "", "" }));
            DisplayTable.Add(new RowData(new object[] { 
                "", "", "", "", "", "", "" }));

            #region show on DGV
            dataGridView_Show.Columns.Clear();
            DataGridViewTextBoxColumn DGV_Z = new DataGridViewTextBoxColumn();
            DGV_Z.HeaderText = "idx";
            DGV_Z.Name = "index";
            DataGridViewTextBoxColumn DGV_A = new DataGridViewTextBoxColumn();
            DGV_A.HeaderText = "來源";
            DGV_A.Name = "A";
            DataGridViewTextBoxColumn DGV_B = new DataGridViewTextBoxColumn();
            DGV_B.HeaderText = "奧義";
            DGV_B.Name = "B";
            DataGridViewTextBoxColumn DGV_C = new DataGridViewTextBoxColumn();
            DGV_C.HeaderText = "天賦1";
            DGV_C.Name = "C";
            DataGridViewTextBoxColumn DGV_D = new DataGridViewTextBoxColumn();
            DGV_D.HeaderText = "天賦2";
            DGV_D.Name = "D";
            DataGridViewTextBoxColumn DGV_E = new DataGridViewTextBoxColumn();
            DGV_E.HeaderText = "天賦3";
            DGV_E.Name = "E";
            DataGridViewTextBoxColumn DGV_F = new DataGridViewTextBoxColumn();
            DGV_F.HeaderText = "備註";
            DGV_F.Name = "F";

            dataGridView_Show.Columns.AddRange(new DataGridViewColumn[] { DGV_Z, DGV_A, DGV_B, DGV_C, DGV_D, DGV_E, DGV_F });
            InitStdDGV(ref dataGridView_Show);

            dataGridView_Show.Rows[0].Cells[0].Value = "血櫻";
            dataGridView_Show.Rows[1].Cells[0].Value = "小夢";
            dataGridView_Show.Rows[2].Cells[0].Value = "月姬";

            for (int i = 0; i < DisplayTable.Count; i++)
            {
                dataGridView_Show.Rows.Add();
                //dataGridView_Show.Rows[i].Cells[0].Value = i + 1;
                dataGridView_Show.Rows[i].Cells[0].ReadOnly = true;
                for (int j = 0; j < DisplayTable[i].getMemberCount; j++)
                {
                    dataGridView_Show.Rows[i].Cells[j + 1].Value = DisplayTable[i].ItemArray[j];
                    dataGridView_Show.Rows[i].Cells[j + 1].ReadOnly = true;
                }
            }
            for (int i = 0; i < dataGridView_Show.RowCount; i++)
            {
                for (int j = 0; j < dataGridView_Show.Rows[i].Cells.Count; j++)
                {
                    dataGridView_Show.Rows[i].Cells[j].Style.SelectionBackColor = dataGridView_Show.DefaultCellStyle.BackColor;
                    dataGridView_Show.Rows[i].Cells[j].Style.SelectionForeColor = dataGridView_Show.DefaultCellStyle.ForeColor;
                }
            }
            #endregion
        }
        /// <summary>初始化，調整DGV的一些外觀/屬性。</summary>
        public void InitStdDGV(ref DataGridView DGV)
        {
            ///
            /// Visibles
            ///
            DGV.RowHeadersVisible = false;
            DGV.ColumnHeadersVisible = true;
            ///
            /// RowHeaders asterisk or arrows visible
            /// 
            DGV.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            ///
            /// Colors
            ///
            for (int i = 0; i < DGV.RowCount; i++)
            {
                DGV.Rows[i].Cells[0].Style.SelectionBackColor = DGV.DefaultCellStyle.BackColor;
                DGV.Rows[i].Cells[0].Style.SelectionForeColor = DGV.DefaultCellStyle.ForeColor;
            }
            ///
            /// Edit Modes (add, edit, delete, sort, resize, ...)
            ///
            DGV.AllowUserToAddRows = false;
            DGV.AllowUserToDeleteRows = false;
            DGV.AllowUserToOrderColumns = false;
            for (int i = 0; i < DGV.ColumnCount; i++)
            {
                DGV.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToResizeRows = false;
            /*
            The rest part here requires at least two Column Headers in the dataGridView.
            */
            ///
            /// items text allignment
            /// 
            DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DGV.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            for (int i = 1; i < DGV.ColumnCount; i++)
                DGV.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ///
            /// AutoSizeMode (Headers)
            ///
            DGV.Columns[0].Width = 40;
            for (int i = 1; i < DGV.ColumnCount - 2; i++)
                DGV.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DGV.Columns[DGV.ColumnCount - 2].Width = 120;
            DGV.Columns[DGV.ColumnCount - 1].Width = 60;
            ///
            /// Format
            ///
            DGV.Columns[0].DefaultCellStyle.Format = "N0";
            for (int i = 1; i < DGV.ColumnCount - 1; i++)
                DGV.Columns[i].DefaultCellStyle.Format = "N2";
            DGV.Columns[DGV.ColumnCount - 1].DefaultCellStyle.Format = "N0";
        }

        public class RowData
        {
            public List<string> TheDatas;
            public object[] ItemArray;

            private int _MemCnt;


            public RowData()
            {
                TheDatas = new List<string>();
                ItemArray = TheDatas.ToArray();
                _MemCnt = TheDatas.Count;
            }
            public RowData(List<string> _data = null)
            {
                TheDatas = _data;
                ItemArray = TheDatas.ToArray();
                _MemCnt = TheDatas.Count;
            }
            public RowData(object[] _ItemArray = null)
            {
                ItemArray = _ItemArray;
                TheDatas = new List<string>();
                for (int i = 0; i < ItemArray.Count(); i++)
                    TheDatas.Add(ItemArray[i].ToString());
                _MemCnt = TheDatas.Count;
            }


            public int getMemberCount
            {
                get { return _MemCnt; }
            }

        }
    }
}
