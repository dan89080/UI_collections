using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ET_Handler;

namespace UI_EventTrace
{
    public partial class UI_EventTrace : Form
    {

        public UI_EventTrace()
        {
            InitializeComponent();

            ET_handler.InitETLog();//
            ET_handler.AddEventTrace(this);//

            //ET_handler.ET_traceMenuStrip(ref menuStrip1);
            //Control ctrl = contextMenuStrip1.SourceControl;
            //contextMenuStrip1.AccessibleName
            //textBox1.Text = ctrl.Name;
            ET_handler.ET_traceContextMenuStrip(ref contextMenuStrip1);
        }
    }
}
