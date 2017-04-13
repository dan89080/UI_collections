using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace UI_CtrlOperating
{
    public class UI_PicBtn : ToolStripButton, IContainerControl
    {

        bool IContainerControl.ActivateControl(Control active)
        {
            throw new NotImplementedException();
        }

        Control IContainerControl.ActiveControl
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
