using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ET_Handler
{
    public class ET_handler
    {
        static public FileString_Date HiToday = new FileString_Date();
        static public FileString_Date NowToday = new FileString_Date();
        #region some const strings of SysFormCtrl

        public const string str_SYStabCtrl = "System.Windows.Forms.TabControl";
        public const string str_SYStextBox = "System.Windows.Forms.TextBox";
        public const string str_SYSgroupBx = "System.Windows.Forms.GroupBox";
        public const string str_SYStabPage = "System.Windows.Forms.TabPage";
        public const string str_SYSpanel   = "System.Windows.Forms.Panel";
        public const string str_SYStimer   = "System.Windows.Forms.Timer";
        public const string str_SYSbutton  = "System.Windows.Forms.Button";
        public const string str_SYSchkbox  = "System.Windows.Forms.CheckBox";
        public const string str_SYSrdobtn  = "System.Windows.Forms.RadioButton";
        public const string str_SYSrhtxtBx = "System.Windows.Forms.RichTextBox";
        public const string str_SYSctxmnsp = "System.Windows.Forms.ContextMenuStrip";
        public const string str_SYStlsmnim = "System.Windows.Forms.ToolStripMenuItem";
        public const string str_SYSlabel   = "System.Windows.Forms.Label";
        public const string str_SYScxMnuSp = "System.Windows.Forms.ContextMenuStrip";
        
        #endregion
        public const string str_PathName = @"C:\Pfad";
        static public string str_FileName = thePfadString();

        #region ET file related
        /// <summary>初始化ET的文字紀錄檔。</summary>
        static public void InitETLog()
        {
            str_FileName = thePfadString();
            try
            {
                using (StreamReader sr = new StreamReader(str_FileName, true))
                {

                }
            }
            catch
            {
                System.IO.Directory.CreateDirectory(str_PathName);
                using (FileStream fs = File.Create(str_FileName))
                {

                }
            }
        }
        /// <summary>清空ET的文字紀錄檔。</summary>
        static public void ClearLog()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(str_FileName))
                {
                    sw.Write("");
                }
            }
            catch
            {
                System.IO.Directory.CreateDirectory(str_PathName);
                using (FileStream fs = File.Create(str_FileName))
                {

                }
            }
        }
        /// <summary>取得ET的文字紀錄檔的檔案位置。</summary>
        static public string thePfadString()
        {
            string thePfadPath = @"C:\Pfad\" + HiToday.FileNameDate() + " EventTraceLog.txt";
            return thePfadPath;
        }
        #endregion

        #region ET recording func. implementation
        /// <summary>紀錄(參數)pCtrl。其外觀上內層的cCtrl們也會被記錄(如果存在多層ctrl)。</summary>
        static public void AddEventTrace(Control pCtrl)
        {
            if (pCtrl != null)
            {
                foreach (Control cCtrl in pCtrl.Controls)
                {
                    //cCtrl.Click += new System.EventHandler(EventTrace_onClickEvent);
                    //cCtrl.Tag = new EventTraceTagObject(cCtrl);
                    switch (cCtrl.GetType().ToString())
                    {
                        case str_SYSbutton:
                            cCtrl.Click += new System.EventHandler(EventTrace_button_onClickEvent);
                            cCtrl.MouseDown += new System.Windows.Forms.MouseEventHandler(EventTrace_button_onMouseDown);
                            cCtrl.MouseUp += new System.Windows.Forms.MouseEventHandler(EventTrace_button_onMouseUp);
                            break;

                        /**/
                        case str_SYStextBox:
                            cCtrl.Validated += new System.EventHandler(EventTrace_onValidated);
                            break;
                        case str_SYSrhtxtBx:
                            cCtrl.Validated += new System.EventHandler(EventTrace_onValidated);
                            break;
                        case str_SYSchkbox:
                            ((CheckBox)cCtrl).CheckedChanged += new System.EventHandler(EventTrace_checkBox_onCheckedChanged);
                            break;
                        case str_SYSrdobtn:
                            ((RadioButton)cCtrl).CheckedChanged += new System.EventHandler(EventTrace_radioButton_onCheckedChanged);
                            break;
                        /*case str_SYSlabel:
                            ((Label)cCtrl).Click += new System.EventHandler(EventTrace_label_onClick);
                            ((Label)cCtrl).MouseDown += new System.Windows.Forms.MouseEventHandler(EventTrace_label_onMouseDown);
                            ((Label)cCtrl).MouseUp += new System.Windows.Forms.MouseEventHandler(EventTrace_label_onMouseUp);
                            break;
                        case str_SYSctxmnsp:
                            //((ToolStripMenuItem)cCtrl).Click += new System.EventHandler(EventTrace_onClickEvent);
                            MessageBox.Show(str_SYSctxmnsp, "HI");
                            foreach (ToolStripMenuItem itemCtrl in ((ContextMenuStrip)cCtrl).Items)
                            {
                                itemCtrl.Click += new System.EventHandler(EventTrace_menuItem_onClickEvent);
                            }
                            break;*/
                        case str_SYSpanel:
                            AddEventTrace(cCtrl);
                            break;
                        case str_SYSgroupBx:
                            AddEventTrace(cCtrl);
                            break;
                        case str_SYStabCtrl:
                            for (int i = 0; i < ((TabControl)cCtrl).TabCount; i++)
                            {
                                AddEventTrace(cCtrl, i);
                            }
                            break;
                        default:
                            //cCtrl.Click += new System.EventHandler(EventTrace_onDefaultEvent);
                            break;
                    }
                }
            }
        }
        /// <summary>紀錄pCtrl(型別為tabPage)內層的cCtrl們。</summary>
        static private void AddEventTrace(Control pCtrl, int i)
        {
            foreach (Control cCtrl in ((TabControl)pCtrl).TabPages[i].Controls)
            {
                //cCtrl.Tag = new EventTraceTagObject(cCtrl);
                switch (cCtrl.GetType().ToString())
                {
                    case str_SYSbutton:
                        cCtrl.Click += new System.EventHandler(EventTrace_button_onClickEvent);
                        cCtrl.MouseDown += new System.Windows.Forms.MouseEventHandler(EventTrace_button_onMouseDown);
                        cCtrl.MouseUp += new System.Windows.Forms.MouseEventHandler(EventTrace_button_onMouseUp);
                        break;
                    /**/
                    case str_SYStextBox:
                        cCtrl.Validated += new System.EventHandler(EventTrace_onValidated);
                        break;
                    case str_SYSrhtxtBx:
                        cCtrl.Validated += new System.EventHandler(EventTrace_onValidated);
                        break;
                    case str_SYSchkbox:
                        ((CheckBox)cCtrl).CheckedChanged += new System.EventHandler(EventTrace_checkBox_onCheckedChanged);
                        break;
                    case str_SYSrdobtn:
                        ((RadioButton)cCtrl).CheckedChanged += new System.EventHandler(EventTrace_radioButton_onCheckedChanged);
                        break;
                    /*case str_SYSlabel:
                        ((Label)cCtrl).Click += new System.EventHandler(EventTrace_label_onClick);
                        ((Label)cCtrl).MouseDown += new System.Windows.Forms.MouseEventHandler(EventTrace_label_onMouseDown);
                        ((Label)cCtrl).MouseUp += new System.Windows.Forms.MouseEventHandler(EventTrace_label_onMouseUp);
                        break;*/
                    case str_SYSpanel:
                        AddEventTrace(cCtrl);
                        break;
                    case str_SYSgroupBx:
                        AddEventTrace(cCtrl);
                        break;
                    case str_SYStabCtrl:
                        for (int j = 0; j < ((TabControl)cCtrl).TabCount; j++)
                        {
                            AddEventTrace(cCtrl, j);
                        }
                        break;
                    default:
                        //cCtrl.Click += new System.EventHandler(EventTrace_onDefaultEvent);
                        break;
                }
            }
        }

        /// <summary>For simple ctrls(most are in aother ctrl and doesn't contain other ctrls.)</summary>
        static public void WriteLog(object sender, string EventDetail)
        {
            NowToday = new FileString_Date();
            if (HiToday.DateEquals(NowToday) == false)
            {
                HiToday.DateAssign(NowToday);
                str_FileName = thePfadString();
                if (File.Exists(str_FileName) == false)
                {
                    System.IO.Directory.CreateDirectory(str_PathName);
                    using (FileStream fs = File.Create(str_FileName)) { }
                }
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(str_FileName, true))
                {
                    string theTime = System.DateTime.Now.ToString();
                    string senderName = ((Control)sender).Name;
                    string FromWhichForm = ((Control)sender).FindForm().Name;

                    sw.WriteLine(theTime + "  \t" + (senderName).PadRight(35) + (FromWhichForm).PadRight(25) + EventDetail.PadRight(20));
                }
            }
            catch
            {
                System.IO.Directory.CreateDirectory(str_PathName);
                using (FileStream fs = File.Create(str_FileName)) { }
            }
        }
        /// <summary>For external ctrls(may contain other ctrls, like DGV, MenuStrip, ContextMenuStrip.)</summary>
        static public void WriteExtCtrlLog(string sender_Who, string EventDetail, object sender_FromWhere)
        {
            NowToday = new FileString_Date();
            if (HiToday.DateEquals(NowToday) == false)
            {
                HiToday.DateAssign(NowToday);
                str_FileName = thePfadString();
                if (File.Exists(str_FileName) == false)
                {
                    System.IO.Directory.CreateDirectory(str_PathName);
                    using (FileStream fs = File.Create(str_FileName)) { }
                }
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(str_FileName, true))
                {
                    string theTime = System.DateTime.Now.ToString();
                    Control ctrl_FromWhere = ((Control)sender_FromWhere);
                    string FromWhichForm = ctrl_FromWhere.FindForm().Name;

                    sw.WriteLine(theTime + "  \t" + (sender_Who).PadRight(35) + (FromWhichForm).PadRight(25) + EventDetail.PadRight(20));
                }
            }
            catch
            {
                System.IO.Directory.CreateDirectory(str_PathName);
                using (FileStream fs = File.Create(str_FileName)) { }
            }
        }
        #endregion

        #region event trace: write log for [the events]
        private void EventTrace_onDefaultEvent(object sender, EventArgs e)
        {
            WriteLog(sender, "onDefaultEvent, sender:\t" + sender.ToString());
        }
        static public void EventTrace_button_onClickEvent(object sender, EventArgs e)
        {
            WriteLog(sender, "onClickEvent");
        }
        static public void EventTrace_onValidated(object sender, EventArgs e)
        {
            WriteLog(sender, "onValidated, Text: " + ((Control)sender).Text);
        }
        static public void EventTrace_checkBox_onCheckedChanged(object sender, EventArgs e)
        {
            WriteLog(sender, "onCheckedChanged, CheckState: " + ((CheckBox)sender).Checked);
        }
        static public void EventTrace_radioButton_onCheckedChanged(object sender, EventArgs e)
        {
            WriteLog(sender, "onCheckedChanged, CheckState: " + ((RadioButton)sender).Checked);
        }
        /*static public void EventTrace_menuItem_onClickEvent(object sender, EventArgs e)
        {
            //WriteLog((ToolStripMenuItem)sender, "onClickEvent");
            //MessageBox.Show(((ToolStripMenuItem)sender).Name);
        }*/
        static public void EventTrace_button_onMouseDown(object sender, EventArgs e)
        {
            WriteLog(sender, "onMouseDown");
        }
        static public void EventTrace_button_onMouseUp(object sender, EventArgs e)
        {
            WriteLog(sender, "onMouseUp");
        }
        static public void EventTrace_label_onMouseDown(object sender, EventArgs e)
        {
            WriteLog(sender, "onMouseDown");
        }
        static public void EventTrace_label_onClick(object sender, EventArgs e)
        {
            WriteLog(sender, "onClickEvent");
        }
        static public void EventTrace_label_onMouseUp(object sender, EventArgs e)
        {
            WriteLog(sender, "onMouseUp");
        }
        #endregion

        #region DataGridView event trace
        static public void ET_DGV_onCellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

            string MySender = ((DataGridView)sender).Name;
            string EventDetails;// = "onCellMouseDown,\t(column, row) = (" + e.ColumnIndex + ","
            //+ e.RowIndex.ToString().PadLeft(4) + ")";
            //Index_Down = ((DataGridView)sender).CurrentRow.Index;
            if (e.Button == MouseButtons.Right)
            {
                EventDetails = "onCellMouseDown(RightClick),(column, row) = (" + e.ColumnIndex + ","
                    + e.RowIndex.ToString().PadLeft(4) + ")";
            }
            else
            {
                EventDetails = "onCellMouseDown(LeftClick),\t(column, row) = (" + e.ColumnIndex + ","
                    + e.RowIndex.ToString().PadLeft(4) + ")";
            }
            WriteExtCtrlLog(MySender, EventDetails, ((Control)sender).FindForm());
            //MessageBox.Show(((DataGridView)sender).SelectedRows.Count.ToString(), "onCellMouseDown");
            //MessageBox.Show((((DataGridView)sender).CurrentCell).ToString(), "DGV_hi");
        }
        static public void ET_DGV_onCellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string MySender = ((DataGridView)sender).Name;
            string EventDetails = "onCellMouseClick,\t\t(column, row) = (" + e.ColumnIndex + ","
                + e.RowIndex.ToString().PadLeft(4) + ")";
            WriteExtCtrlLog(MySender, EventDetails, ((Control)sender).FindForm());
            //MessageBox.Show((((DataGridView)sender).CurrentCell).ToString(), "DGV_hi");            
        }
        static public void ET_DGV_onCellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            string MySender = ((DataGridView)sender).Name;
            string EventDetails = "onCellMouseUp,\t\t(column, row) = (" + e.ColumnIndex + ","
                + e.RowIndex.ToString().PadLeft(4) + ")";
            //Index_Up = ((DataGridView)sender).CurrentRow.Index;
            if (true)//((DataGridView)sender).SelectedRows.Count > 1)
            {
                EventDetails = EventDetails + ", selected length = " + (((DataGridView)sender).SelectedRows).Count;
            }
            WriteExtCtrlLog(MySender, EventDetails, ((Control)sender).FindForm());
            //MessageBox.Show(((DataGridView)sender).SelectedRows.Count.ToString(), "onCellMouseUp");
            //MessageBox.Show((((DataGridView)sender).CurrentCell).ToString(), "DGV_hi");            
        }
        static public void ET_DGV_onMouseDown(object sender, MouseEventArgs e)
        {
            WriteLog(sender, "onMouseDown");
        }
        static public void ET_DGV_onClick(object sender, EventArgs e)
        {
            WriteLog(sender, "onClickEvent");
        }
        static public void ET_DGV_onMouseUp(object sender, EventArgs e)
        {
            WriteLog(sender, "onMouseUp");
        }
        #endregion

        #region MenuStrip / ContextMenuStrip event trace
        static public void ET_traceMenuStrip(ref MenuStrip MS)
        {
            foreach(ToolStripMenuItem items in MS.Items)
            {
                items.Click += ET_MS_Items_onClick;
                foreach (ToolStripMenuItem drop in items.DropDownItems)
                {
                    drop.Click += ET_MS_DropDownItems_onClick;
                }
            }
        }
        /// <summary>ET [MenuStrip]ToolStripMenuItem click event. [item]</summary>
        static private void ET_MS_Items_onClick(object sender, EventArgs e)
        {
            string MySender = ((ToolStripMenuItem)sender).Name;
            string EventDetails = "onClick";
            WriteExtCtrlLog(MySender, EventDetails, ((ToolStripMenuItem)sender).Owner);
        }
        /// <summary>ET [MenuStrip]ToolStripMenuItem click event. [DropDownItem]</summary>
        static private void ET_MS_DropDownItems_onClick(object sender, EventArgs e)
        {
            string MySender = ((ToolStripMenuItem)sender).Name;
            string EventDetails = "onClick";
            WriteExtCtrlLog(MySender, EventDetails, ((ToolStripMenuItem)sender).OwnerItem.Owner);
        }

        static public void ET_traceContextMenuStrip(ref ContextMenuStrip CMS)
        {
            foreach (ToolStripMenuItem items in CMS.Items)
            {
                items.Click += ET_CMS_Items_onClick;
            }
        }
        /// <summary>ET [ContextMenuStrip]ToolStripMenuItem click event. [item]</summary>
        static private void ET_CMS_Items_onClick(object sender, EventArgs e)
        {
            string MySender = ((ToolStripMenuItem)sender).Name;

            string EventDetails = "onClick";
            WriteExtCtrlLog(MySender, EventDetails, ((ContextMenuStrip)(((ToolStripMenuItem)sender).Owner)).SourceControl);
        }
        #endregion

    }
    /// <summary>ET文字紀錄檔的檔案名稱的格式定義。</summary>
    public class FileString_Date
    {
        public int theDay;
        public int theMonth;
        public int theYear;
        /// <summary>取得當日的年月日。</summary>
        public FileString_Date()
        {
            theDay = System.DateTime.Now.Day;
            theMonth = System.DateTime.Now.Month;
            theYear = System.DateTime.Now.Year; ;
        }
        /// <summary>產生ET的文字紀錄檔的檔案名稱。</summary>
        public string FileNameDate()
        {
            if (theMonth < 10)
            {
                if (theDay < 10)
                {
                    return theYear.ToString() + " 0" + theMonth.ToString() + " 0" + theDay.ToString();
                }
                else
                {
                    return theYear.ToString() + " 0" + theMonth.ToString() + " " + theDay.ToString();
                }
            }
            else
            {
                if (theDay < 10)
                {
                    return theYear.ToString() + " " + theMonth.ToString() + " 0" + theDay.ToString();
                }
                else
                {
                    return theYear.ToString() + " " + theMonth.ToString() + " " + theDay.ToString();
                }
            }
        }
        public bool DateEquals(FileString_Date temp)
        {
            if (temp.theDay != this.theDay)
            {
                return false;
            }
            if (temp.theMonth != this.theMonth)
            {
                return false;
            }
            if (temp.theYear != this.theYear)
            {
                return false;
            }
            return true;
        }
        public void DateAssign(FileString_Date temp)
        {
            this.theDay = temp.theDay;
            this.theMonth = temp.theMonth;
            this.theYear = temp.theYear;
        }
    }
}
