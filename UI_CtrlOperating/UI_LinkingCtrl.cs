using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_CtrlOperating
{
    public class UI_LinkingCtrl
    {
        public Control ctrl_src;
        public Control ctrl_des;

        public UI_LinkingCtrl(Control Ctrl_src, Control Ctrl_des)
        {
            ctrl_src = Ctrl_src;
            ctrl_des = Ctrl_des;
        }
    
    
    }
    //public int SideBdr;
    //public int TopBdr;
    //SideBdr = (fm.Width - fm.ClientSize.Width) / 2;
    //TopBdr = (fm.Height - fm.ClientSize.Height) - SideBdr;
}
