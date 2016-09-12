using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DGV_Helper
{
    public class DGV_helper
    {
        #region UI settings
        /// <summary>初始化，調整DGV的一些外觀/屬性。</summary>
        public void InitStdDGV(ref DataGridView DGV)
        {
            ///
            /// SelectionMode
            ///
            //DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
            //DGV.DefaultCellStyle.SelectionBackColor = DGV.DefaultCellStyle.BackColor;
            //DGV.DefaultCellStyle.SelectionForeColor = DGV.DefaultCellStyle.ForeColor;
            for (int i = 0; i < DGV.RowCount; i++)
            {
                //DGV.Columns[i].Selected = false;
                //DGV.Rows[i].Cells[0]
                //DGV.Columns[i]
                //DGV.Columns[i].DefaultCellStyle.SelectionBackColor = DGV.DefaultCellStyle.BackColor;
                //DGV.Columns[i].DefaultCellStyle.SelectionForeColor = DGV.DefaultCellStyle.ForeColor;
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
            DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            DGV.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            for (int i = 1; i < DGV.ColumnCount; i++)
                DGV.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ///
            /// AutoSizeMode (Headers)
            ///
            DGV.Columns[0].Width = 33;
            for(int i = 1; i < DGV.ColumnCount; i++)
                DGV.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ///
            /// Null Value
            ///
            DGV.Columns[0].DefaultCellStyle.NullValue = "-1";
            for (int i = 1; i < DGV.ColumnCount; i++)
                DGV.Columns[i].DefaultCellStyle.NullValue = "null";
            ///
            /// Format
            ///
            DGV.Columns[0].DefaultCellStyle.Format = "N0";
            for (int i = 1; i < DGV.ColumnCount; i++)
                DGV.Columns[i].DefaultCellStyle.Format = "N2";
        }
        /// <summary>初始化－讓DGV有五個橫排。</summary>
        public void DefaultItemsDGV(ref DataGridView DGV)
        {
            DGV.Rows.Add(5);
            for (int i = 0; i < 5; i++)
            {
                DGV.Rows[i].Cells[0].Value = i + 1;
                //DGV.Rows[i].Cells[0].ReadOnly = true;
                DGV.Rows[i].Cells[1].Value = 2 * (i + 1);
                //DGV.Rows[i].Cells[1].ReadOnly = true;
            }
        }
        /// <summary>讓DGV的cells設置成ReadOnly。</summary>
        public void set_DGV_ReadOnly(ref DataGridView DGV, int index_cell, int count)
        {
            for (int i = 0; i < DGV.RowCount; i++)
            {
                for (int j = index_cell; j < index_cell + count; j++)
                {
                    DGV.Rows[i].Cells[j].ReadOnly = true;
                }
            }
        }
        /// <summary>取得整個DGV裡面cells的value，型別為object[][]。</summary>
        public object[][] get_dataGridView_array(ref DataGridView DGV)
        {
            int RowCount = DGV.RowCount;
            int ColumnCount = DGV.ColumnCount;
            object[][] data = new object[RowCount][];

            for (int i = 0; i < RowCount; i++)
            {
                object[] temp = new object[ColumnCount];
                for (int j = 0; j < ColumnCount; j++)
                {
                    try
                    {
                        //temp[j] = Convert.ToDouble(dgv.Rows[i].Cells[j].Value.ToString());
                        temp[j] = DGV.Rows[i].Cells[j].Value;
                    }
                    catch { }
                }
                data[i] = temp;
            }
            return data;
        }

        /// <summary>設定整個DGV裡面cells的value，型別為object[][]。</summary>
        public void set_dataGridView_array(ref DataGridView DGV, object[][] data)
        {
            int RowCount = DGV.RowCount;
            int ColumnCount = DGV.ColumnCount;
            if (data.Count() != RowCount)
                return;

            for (int i = 0; i < RowCount; i++)
            {
                if (data[i].Count() != ColumnCount)
                    return;
                for (int j = 0; j < ColumnCount; j++)
                {
                    try
                    {
                        DGV.Rows[i].Cells[j].Value = data[i][j];
                    }
                    catch { }
                }
            }
        }        
        /// <summary> Set DGV data(value) at [row, column].</summary>
        public void set_DGVdata(ref DataGridView DGV, int index_row, int index_cell, object value)
        {
            DGV.Rows[index_row].Cells[index_cell].Value = value;
        }
        /// <summary>回傳-1可能是因為選取的項目不在DGV的cells裡面，或者他是null。</summary>
        public int get_DGV_indexRow(ref DataGridView DGV)
        {
            return DGV.CurrentCell.RowIndex;
        }
        /// <summary>回傳-1可能是因為選取的項目不在DGV的cells裡面，或者他是null。</summary>
        public int get_DGV_indexColumn(ref DataGridView DGV)
        {
            return DGV.CurrentCell.ColumnIndex;
        }
        /// <summary>排序DGV第index個column。</summary>
        public void sort_DGV_Rows(ref DataGridView DGV, int index, ListSortDirection direction)
        {
            if (DGV.RowCount <= index)
                return;

            DGV.Sort(DGV.Columns[index], direction);
        }
        /// <summary>在DGV最後一行依照List＜object＞ values加入數值。</summary>
        public void add_DGV_Row(ref DataGridView DGV, List<object> values)
        {
            if (DGV.ColumnCount != values.Count || DGV.Rows[0] == null)
                return;

            DataGridViewRow Row = DGV_Row_CloneValues(DGV.Rows[0]);
            for (int index = 0; index < DGV.ColumnCount; index++)
                Row.Cells[index].Value = values[index];
            DGV.Rows.Insert(DGV.RowCount, Row);
        }
        #endregion

        #region event settings
        private DataGridView my_DGV;
        public List<DataGridViewRow> ClipBoard;
        public DataGridViewRow DGV_Row_CloneValues(DataGridViewRow row)
        {
            DataGridViewRow clonedRow = (DataGridViewRow)row.Clone();
            for (int index = 0; index < row.Cells.Count; index++)
                clonedRow.Cells[index].Value = row.Cells[index].Value;
            return clonedRow;
        }
        public void GetDGV(ref DataGridView DGV)
        {
            my_DGV = DGV;
            ClipBoard = new List<DataGridViewRow>();
        }
        public void DGV_COPY(int idx, int count)
        {
            ClipBoard.Clear();
            DataGridViewRow temp;
            for (int i = idx; i < idx + count; i++)
            {
                temp = DGV_Row_CloneValues(my_DGV.Rows[i]);
                ClipBoard.Add(temp);
            }
        }
        public void DGV_CUT(int idx, int count)
        {
            ClipBoard.Clear();
            for (int i = idx; i < idx + count; i++)
            {
                ClipBoard.Add(my_DGV.Rows[idx]);
                my_DGV.Rows.Remove(my_DGV.Rows[idx]);
            }
        }
        public void DGV_INSERT(int idx)
        {
            for (int i = 0; i < ClipBoard.Count; i++)
                my_DGV.Rows.Insert(idx + 1 + i, DGV_Row_CloneValues(ClipBoard[i]));            
        }
        public void DGV_DELETE(int idx, int count)
        {
            for (int i = 0; i < count; i++)
                my_DGV.Rows.Remove(my_DGV.Rows[idx]);
        }
        #endregion

    }
}
