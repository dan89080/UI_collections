using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcCtrlOffset_Helper
{
    public partial class CalcCtrlOffset_helper
    {
        /// <summary>returns new Size(BorderWidth, TitlebarHeight)</summary>
        static public Size Diff_Size2ClientSize(Control ctrl)
        {
            int BorderWidth = (ctrl.Width - ctrl.ClientSize.Width) / 2;
            int TitlebarHeight = ctrl.Height - ctrl.ClientSize.Height - 2 * BorderWidth;

            return new Size(BorderWidth, TitlebarHeight);
        }
        /// <summary>取得Button到最底層(通常為Form)視窗方框內的左上角距離。</summary>
        static public Point Offset_Btn2FormClient(Control cCtrl)
        {
            Point offset = Offset_CtrlBorder2FormClient(cCtrl);
            /// BorderSize of cCtrl
            offset.X -= ((Button)cCtrl).FlatAppearance.BorderSize;
            offset.Y -= ((Button)cCtrl).FlatAppearance.BorderSize;
            return offset;
        }
        /// <summary>取得Container到最底層(通常為Form)視窗方框內的左上角距離。</summary>
        static public Point Offset_Cntnr2FormClient(Control cCtrl)
        {
            Point offset = Offset_CtrlBorder2FormClient(cCtrl);
            /// BorderSize of cCtrl
            Size cCtrl_Border = Diff_Size2ClientSize(cCtrl);
            offset.X -= cCtrl_Border.Width;
            offset.Y -= cCtrl_Border.Width + cCtrl_Border.Height;
            return offset;
        }
        /// <summary>取得[pCtrl邊框內層]左上角到[最底層(通常為Form)視窗方框內層]左上角的距離。</summary>
        static public Point Offset_CtrlBorder2FormClient(Control cCtrl)
        {
            /// 
            /// 沒層(-1-1, -1-1)，單層(0, 0)
            /// 
            /// cCtrl to pCtrl
            Point offset = new Point(0, 0);
            offset.X = cCtrl.Left;
            offset.Y = cCtrl.Top;
            /// BorderSize of cCtrl
            Size cCtrl_Border = Diff_Size2ClientSize(cCtrl);
            offset.X += cCtrl_Border.Width;
            offset.Y += cCtrl_Border.Width + cCtrl_Border.Height;

            if (cCtrl.Parent != null)
                if (cCtrl.FindForm().Name != cCtrl.Parent.Name)
                {
                    /// pCtrl to ppCtrl
                    Point pCtrl2ppCtrl = Offset_CtrlBorder2FormClient(cCtrl.Parent);
                    offset.X += pCtrl2ppCtrl.X;
                    offset.Y += pCtrl2ppCtrl.Y;
                    /// BorderSize of pCtrl
                    Size pCtrl_Border = Diff_Size2ClientSize(cCtrl.Parent);
                    offset.X += pCtrl_Border.Width;
                    offset.Y += pCtrl_Border.Width + pCtrl_Border.Height;
                }
            return offset;
        }
        /// <summary>取得pCtrl到最底層(通常為Form)的整個視窗左上角距離。</summary>
        static public Point Offset_Ctrl2FormWhole(Control pCtrl)
        {
            Point offset = Offset_Btn2FormClient(pCtrl);
            Size sz = Diff_Size2ClientSize(pCtrl.FindForm());
            offset.X += sz.Width;
            offset.Y += sz.Width + sz.Height;
            return offset;
        }
        /// <summary>取得pCtrl到螢幕左上角距離。</summary>
        static public Point Offset_Ctrl2Screen(Control pCtrl)
        {
            Point offset = Offset_Ctrl2FormWhole(pCtrl);
            Point sz = pCtrl.FindForm().Location;
            offset.X += sz.X;
            offset.Y += sz.Y;
            return offset;
        }
    }
}
