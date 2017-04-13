using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI_CtrlOperating.PageTest_WPF;


namespace UI_CtrlOperating
{
    public class UI_CtrlOperating_Funcs
    {
        /*滑鼠用變數*/
        static private int CreateUI_X;
        static private int CreateUI_Y;
        static public Control Ctrl_Creating;
        static private int GrayInt = 85;
        static private Pen CtrlPen_Gray = new Pen(Color.FromArgb(GrayInt, GrayInt, GrayInt), 2.0F);
        static private Pen CtrlPen_Blue = new Pen(Color.FromArgb(50, 120, 210), 2.0F);
        static private Pen CtrlPen_Orange = new Pen(Color.FromArgb(255, 127, 39), 2.0F);
        static private bool isCreatingUI = false;
        static public TheMode CtrlMode;
        public enum TheMode
        {
            Exec_Mode,
            UI_Edit_Mode,
            Aro_Edit_Mode,
            Func_Edit_Mode,
            UI_Create_Mode
        };

        public UI_CtrlOperating_Funcs(){  }

        #region Dragging Control Events
        const int DRAG_HANDLE_SIZE = 7;
        static private int mouseX, mouseY;
        static private Control SelectedControl;
        static private Direction direction;
        static private Point newLocation;
        static private Size newSize;
        static public void Ctrl_MouseDown(object sender, MouseEventArgs e)
        {
            ///清空 Ctrl Border
            Graphics g = TheForm.CreateGraphics();
            g.Clear(TheForm.BackColor);
            TheForm.Refresh();
            g.Dispose();
            switch (CtrlMode)
            {
                //case TheMode.Func_Edit_Mode:
                //case TheMode.Exec_Mode:
                case TheMode.UI_Edit_Mode:
                case TheMode.Aro_Edit_Mode:
                    if (e.Button == MouseButtons.Left)
                    {
                        //Invalidate 才會取消其他選取
                        //不Invalidate 才會MouseDown立刻選取
                        /////TheForm.Invalidate();  //unselect other control
                        SelectedControl = (Control)sender;
                        Control control = (Control)sender;
                        
                        mouseX = -e.X;
                        mouseY = -e.Y;

                        Cursor.Clip = System.Drawing.Rectangle.Empty;

                        control.Invalidate();
                        DrawControlBorder(control);
                    }
                    break;
                case TheMode.Func_Edit_Mode:
                
                    break;
                case TheMode.Exec_Mode:
                
                    break;
                default:

                    break;
            }

        }
        static public void Ctrl_MouseUp(object sender, MouseEventArgs e)
        {
            switch (CtrlMode)
            {
                case TheMode.UI_Edit_Mode:
                    if (e.Button == MouseButtons.Left)
                    {
                        Control control = (Control)sender;
                        Cursor.Clip = System.Drawing.Rectangle.Empty;
                        control.Invalidate();
                        DrawControlBorder(control);
                    }
                    break;
                case TheMode.Func_Edit_Mode:

                    break;
                case TheMode.Exec_Mode:

                    break;
                default:

                    break;
            }

        }
        static public void Ctrl_MouseMove(object sender, MouseEventArgs e)
        {
            switch (CtrlMode)
            {
                case TheMode.UI_Edit_Mode:
                    if (e.Button == MouseButtons.Left)
                    {
                        Control control = (Control)sender;
                        Point nextPosition = new Point();
                        nextPosition = TheForm.PointToClient(Form.MousePosition);
                        nextPosition.Offset(mouseX, mouseY);
                        control.Location = nextPosition;
                        TheForm.Invalidate();
                    }

                    break;
                case TheMode.Func_Edit_Mode:

                    break;
                case TheMode.Exec_Mode:

                    break;
                default:

                    break;
            }

        }
        static public void Ctrl_MouseEnter(object sender, EventArgs e)
        {
            switch(CtrlMode)
            {
                case TheMode.UI_Edit_Mode:
                    timer1.Stop();
                    TheForm.Cursor = Cursors.SizeAll;
                    break;
                case TheMode.Func_Edit_Mode:

                    break;
                case TheMode.Exec_Mode:

                    break;
                default:
                    //timer1.Start();
                    timer1.Stop();
                    TheForm.Cursor = Cursors.SizeAll;

                    break;
            }
        }
        static public void Ctrl_MouseLeave(object sender, EventArgs e)
        {
            switch (CtrlMode)
            {
                case TheMode.UI_Edit_Mode:
                case TheMode.Aro_Edit_Mode:
                    TheForm.Cursor = Cursors.Default;
                    timer1.Start();
                    break;
                case TheMode.Func_Edit_Mode:

                    break;
                case TheMode.Exec_Mode:

                    break;
                default:

                    break;
            }
        }
        static public void Ctrl_Click(object sender, EventArgs e)
        {
            if (CtrlMode == TheMode.Func_Edit_Mode)
            {
                //MessageBox.Show("執行模式");
                WPFpage_test1 temp = new WPFpage_test1();
                temp.ShowDialog();

            }
            else if (CtrlMode == TheMode.Exec_Mode)
                MessageBox.Show("執行模式");
        }

        enum Direction
        {
            NW,
            N,
            NE,
            W,
            E,
            SW,
            S,
            SE,
            None
        }
        static private void DrawControlBorder(object sender)
        {
            Control control = (Control)sender;
            //define the border to be drawn, it will be offset by DRAG_HANDLE_SIZE / 2
            //around the control, so when the drag handles are drawn they will be seem
            //connected in the middle.
            Rectangle Border = new Rectangle(
                new Point(control.Location.X - DRAG_HANDLE_SIZE / 2,
                    control.Location.Y - DRAG_HANDLE_SIZE / 2),
                new Size(control.Size.Width + DRAG_HANDLE_SIZE,
                    control.Size.Height + DRAG_HANDLE_SIZE));
            //define the 8 drag handles, that has the size of DRAG_HANDLE_SIZE
            Rectangle NW = new Rectangle(
                new Point(control.Location.X - DRAG_HANDLE_SIZE,
                    control.Location.Y - DRAG_HANDLE_SIZE),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle N = new Rectangle(
                new Point(control.Location.X + control.Width / 2 - DRAG_HANDLE_SIZE / 2,
                    control.Location.Y - DRAG_HANDLE_SIZE),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle NE = new Rectangle(
                new Point(control.Location.X + control.Width,
                    control.Location.Y - DRAG_HANDLE_SIZE),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle W = new Rectangle(
                new Point(control.Location.X - DRAG_HANDLE_SIZE,
                    control.Location.Y + control.Height / 2 - DRAG_HANDLE_SIZE / 2),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle E = new Rectangle(
                new Point(control.Location.X + control.Width,
                    control.Location.Y + control.Height / 2 - DRAG_HANDLE_SIZE / 2),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle SW = new Rectangle(
                new Point(control.Location.X - DRAG_HANDLE_SIZE,
                    control.Location.Y + control.Height),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle S = new Rectangle(
                new Point(control.Location.X + control.Width / 2 - DRAG_HANDLE_SIZE / 2,
                    control.Location.Y + control.Height),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle SE = new Rectangle(
                new Point(control.Location.X + control.Width,
                    control.Location.Y + control.Height),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));

            //get the form graphic
            Graphics g = TheForm.CreateGraphics();
            //draw the border and drag handles
            ControlPaint.DrawBorder(g, Border, Color.Gray, ButtonBorderStyle.Dotted);
            ControlPaint.DrawGrabHandle(g, NW, true, true);
            ControlPaint.DrawGrabHandle(g, N, true, true);
            ControlPaint.DrawGrabHandle(g, NE, true, true);
            ControlPaint.DrawGrabHandle(g, W, true, true);
            ControlPaint.DrawGrabHandle(g, E, true, true);
            ControlPaint.DrawGrabHandle(g, SW, true, true);
            ControlPaint.DrawGrabHandle(g, S, true, true);
            ControlPaint.DrawGrabHandle(g, SE, true, true);
            g.Dispose();
        }
        /// <summary>Link ctrl from [ctrl_src] to [ctrl_des].</summary>
        /// <param name="ctrl_src">source control</param>
        /// <param name="ctrl_des">destination control</param>
        static public void DrawCtrlLinkLine(Control ctrl_src, Control ctrl_des)
        {
            if (ctrl_src == null || ctrl_des == null ||
                ctrl_src.Parent != ctrl_des.Parent)
                return;
            Control BasePanel = ctrl_src.Parent;

            Point src = new Point(ctrl_src.Location.X + ctrl_src.Width,
                    ctrl_src.Location.Y + ctrl_src.Height / 2);
            Point des = new Point(ctrl_des.Location.X,
                    ctrl_des.Location.Y + ctrl_des.Height / 2);
            double ht = Math.Abs(src.X - des.X);
            double wd = Math.Abs(src.Y - des.Y);
            double ang = ht * wd == 0 ? 90 : Math.Atan(ht / wd) * 180 / Math.PI;
            //TheForm.Text = ang + "";
            float tmp1 = 3.2F;
            float tmp2 = tmp1 * 2;
            float tmp3 = tmp1 * 3;

            using (Graphics g = BasePanel.CreateGraphics())
            {
                g.DrawLine(CtrlPen_Orange, src, des);
                g.DrawEllipse(new Pen(Color.FromArgb(63, 72, 204), tmp2), des.X - tmp2, des.Y - tmp1, tmp2, tmp2);
                
            }

        }

        static public Form TheForm;
        static public void Get_BASE_PAGE(Form theForm)
        {
            TheForm = theForm;
        }

        static public void TheForm_MouseDown(object sender, MouseEventArgs e)
        {
            TheForm.Invalidate();
            if(TheForm.Cursor == Cursors.Default && CtrlMode != TheMode.Aro_Edit_Mode)
                SelectedControl = null;
            if (CtrlMode == TheMode.UI_Create_Mode)
            {
                isCreatingUI = true;
                CreateUI_X = e.X;
                CreateUI_Y = e.Y;
            }
        }
        static public void TheForm_MouseMove(object sender, MouseEventArgs e)
        {
            #region UI_Create_Mode
            if (CtrlMode == TheMode.UI_Create_Mode && isCreatingUI == true)
            {
                using (Graphics g = TheForm.CreateGraphics())
                {
                    g.Clear(TheForm.BackColor);
                    TheForm.Refresh();
                    //Re-link the linked controls
                    //RelinkCtrl();
                    Ctrl_Creating.Size = new Size(e.X - CreateUI_X, e.Y - CreateUI_Y);
                    //g.DrawRectangle(CtrlPen_Gray, CreateUI_X, CreateUI_Y, e.X - CreateUI_X, e.Y - CreateUI_Y);
                    g.DrawRectangle(CtrlPen_Blue, CreateUI_X, CreateUI_Y, e.X - CreateUI_X, e.Y - CreateUI_Y);
                }                
            }
            #endregion
            #region UI_Edit_Mode
            if (SelectedControl != null && e.Button == MouseButtons.Left && CtrlMode == TheMode.UI_Edit_Mode)
            {
                timer1.Stop();
                TheForm.Invalidate();

                if (SelectedControl.Height < 20)
                {
                    SelectedControl.Height = 20;
                    direction = Direction.None;
                    TheForm.Cursor = Cursors.Default;
                    return;
                }
                else if (SelectedControl.Width < 20)
                {
                    SelectedControl.Width = 20;
                    direction = Direction.None;
                    TheForm.Cursor = Cursors.Default;
                    return;
                }

                //get the current mouse position relative the the app
                Point pos = TheForm.PointToClient(Form.MousePosition);

                #region resize the control in 8 directions
                if (direction == Direction.NW)
                {
                    //north west, location and width, height change
                    newLocation = new Point(pos.X, pos.Y);
                    newSize = new Size(SelectedControl.Size.Width - (newLocation.X - SelectedControl.Location.X),
                        SelectedControl.Size.Height - (newLocation.Y - SelectedControl.Location.Y));
                    SelectedControl.Location = newLocation;
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.SE)
                {
                    //south east, width and height change
                    newLocation = new Point(pos.X, pos.Y);
                    newSize = new Size(SelectedControl.Size.Width + (newLocation.X - SelectedControl.Size.Width - SelectedControl.Location.X),
                        SelectedControl.Height + (newLocation.Y - SelectedControl.Height - SelectedControl.Location.Y));
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.N)
                {
                    //north, location and height change
                    newLocation = new Point(SelectedControl.Location.X, pos.Y);
                    newSize = new Size(SelectedControl.Width,
                        SelectedControl.Height - (pos.Y - SelectedControl.Location.Y));
                    SelectedControl.Location = newLocation;
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.S)
                {
                    //south, only the height changes
                    newLocation = new Point(pos.X, pos.Y);
                    newSize = new Size(SelectedControl.Width,
                        pos.Y - SelectedControl.Location.Y);
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.W)
                {
                    //west, location and width will change
                    newLocation = new Point(pos.X, SelectedControl.Location.Y);
                    newSize = new Size(SelectedControl.Width - (pos.X - SelectedControl.Location.X),
                        SelectedControl.Height);
                    SelectedControl.Location = newLocation;
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.E)
                {
                    //east, only width changes
                    newLocation = new Point(pos.X, pos.Y);
                    newSize = new Size(pos.X - SelectedControl.Location.X,
                        SelectedControl.Height);
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.SW)
                {
                    //south west, location, width and height change
                    newLocation = new Point(pos.X, SelectedControl.Location.Y);
                    newSize = new Size(SelectedControl.Width - (pos.X - SelectedControl.Location.X),
                        pos.Y - SelectedControl.Location.Y);
                    SelectedControl.Location = newLocation;
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.NE)
                {
                    //north east, location, width and height change
                    newLocation = new Point(SelectedControl.Location.X, pos.Y);
                    newSize = new Size(pos.X - SelectedControl.Location.X,
                        SelectedControl.Height - (pos.Y - SelectedControl.Location.Y));
                    SelectedControl.Location = newLocation;
                    SelectedControl.Size = newSize;
                }
                #endregion
            }
            #endregion
        }
        static public void TheForm_MouseUp(object sender, MouseEventArgs e)
        {
            //TheForm.Invalidate();
            if (CtrlMode == TheMode.UI_Create_Mode)
            {
                using (Graphics g = TheForm.CreateGraphics())
                {
                    g.Clear(TheForm.BackColor);
                    TheForm.Refresh();
                }
                TheForm.Controls.Add(Ctrl_Creating);
                Ctrl_Creating.Location = new Point(CreateUI_X, CreateUI_Y);
                SelectedControl = Ctrl_Creating;
                CtrlMode = TheMode.UI_Edit_Mode;
                isCreatingUI = false;
            }
            if (SelectedControl != null && CtrlMode == TheMode.UI_Edit_Mode)
            {//     || CtrlMode == TheMode.Aro_Edit_Mode

                DrawControlBorder(SelectedControl);
            }
            timer1.Start();
            TheForm.Cursor = Cursors.Default;
        }
        static public List<UI_LinkingCtrl> UI_LkCtrl;
        static public void TheForm_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                foreach(UI_LinkingCtrl LkCtrl in UI_LkCtrl)
                {
                    DrawCtrlLinkLine(LkCtrl.ctrl_src, LkCtrl.ctrl_des);
                }
            }
            catch { }

        }

        static private Timer timer1;
        static public void TimerCreate()
        {
            timer1 = new Timer();
            timer1.Interval = 5;
            timer1.Enabled = true;
            timer1.Tick += new System.EventHandler(timer1_Tick);

            timer1.Start();
        }
        static private void timer1_Tick(object sender, EventArgs e) 
        {
            #region Get the direction and display correct cursor
            if (SelectedControl != null)
            {
                Point pos = TheForm.PointToClient(Form.MousePosition);
                switch (CtrlMode)
                {
                    case TheMode.UI_Edit_Mode:
                        #region UI_Edit_Mode
                        //check if the mouse cursor is within the drag handle
                        if ((pos.X >= SelectedControl.Location.X - DRAG_HANDLE_SIZE &&
                            pos.X <= SelectedControl.Location.X) &&
                            (pos.Y >= SelectedControl.Location.Y - DRAG_HANDLE_SIZE &&
                            pos.Y <= SelectedControl.Location.Y))
                        {
                            direction = Direction.NW;
                            TheForm.Cursor = Cursors.SizeNWSE;
                        }
                        else if ((pos.X >= SelectedControl.Location.X + SelectedControl.Width &&
                            pos.X <= SelectedControl.Location.X + SelectedControl.Width + DRAG_HANDLE_SIZE &&
                            pos.Y >= SelectedControl.Location.Y + SelectedControl.Height &&
                            pos.Y <= SelectedControl.Location.Y + SelectedControl.Height + DRAG_HANDLE_SIZE))
                        {
                            direction = Direction.SE;
                            TheForm.Cursor = Cursors.SizeNWSE;
                        }
                        else if ((pos.X >= SelectedControl.Location.X + SelectedControl.Width / 2 - DRAG_HANDLE_SIZE / 2) &&
                            pos.X <= SelectedControl.Location.X + SelectedControl.Width / 2 + DRAG_HANDLE_SIZE / 2 &&
                            pos.Y >= SelectedControl.Location.Y - DRAG_HANDLE_SIZE &&
                            pos.Y <= SelectedControl.Location.Y)
                        {
                            direction = Direction.N;
                            TheForm.Cursor = Cursors.SizeNS;
                        }
                        else if ((pos.X >= SelectedControl.Location.X + SelectedControl.Width / 2 - DRAG_HANDLE_SIZE / 2) &&
                            pos.X <= SelectedControl.Location.X + SelectedControl.Width / 2 + DRAG_HANDLE_SIZE / 2 &&
                            pos.Y >= SelectedControl.Location.Y + SelectedControl.Height &&
                            pos.Y <= SelectedControl.Location.Y + SelectedControl.Height + DRAG_HANDLE_SIZE)
                        {
                            direction = Direction.S;
                            TheForm.Cursor = Cursors.SizeNS;
                        }
                        else if ((pos.X >= SelectedControl.Location.X - DRAG_HANDLE_SIZE &&
                            pos.X <= SelectedControl.Location.X &&
                            pos.Y >= SelectedControl.Location.Y + SelectedControl.Height / 2 - DRAG_HANDLE_SIZE / 2 &&
                            pos.Y <= SelectedControl.Location.Y + SelectedControl.Height / 2 + DRAG_HANDLE_SIZE / 2))
                        {
                            direction = Direction.W;
                            TheForm.Cursor = Cursors.SizeWE;
                        }
                        else if ((pos.X >= SelectedControl.Location.X + SelectedControl.Width &&
                            pos.X <= SelectedControl.Location.X + SelectedControl.Width + DRAG_HANDLE_SIZE &&
                            pos.Y >= SelectedControl.Location.Y + SelectedControl.Height / 2 - DRAG_HANDLE_SIZE / 2 &&
                            pos.Y <= SelectedControl.Location.Y + SelectedControl.Height / 2 + DRAG_HANDLE_SIZE / 2))
                        {
                            direction = Direction.E;
                            TheForm.Cursor = Cursors.SizeWE;
                        }
                        else if ((pos.X >= SelectedControl.Location.X + SelectedControl.Width &&
                            pos.X <= SelectedControl.Location.X + SelectedControl.Width + DRAG_HANDLE_SIZE) &&
                            (pos.Y >= SelectedControl.Location.Y - DRAG_HANDLE_SIZE &&
                            pos.Y <= SelectedControl.Location.Y))
                        {
                            direction = Direction.NE;
                            TheForm.Cursor = Cursors.SizeNESW;
                        }
                        else if ((pos.X >= SelectedControl.Location.X - DRAG_HANDLE_SIZE &&
                            pos.X <= SelectedControl.Location.X + DRAG_HANDLE_SIZE) &&
                            (pos.Y >= SelectedControl.Location.Y + SelectedControl.Height - DRAG_HANDLE_SIZE &&
                            pos.Y <= SelectedControl.Location.Y + SelectedControl.Height + DRAG_HANDLE_SIZE))
                        {
                            direction = Direction.SW;
                            TheForm.Cursor = Cursors.SizeNESW;
                        }
                        else
                        {
                            TheForm.Cursor = Cursors.Default;
                            direction = Direction.None;
                        }
                        #endregion
                        break;
                    case TheMode.Aro_Edit_Mode:
                        #region Aro_Edit_Mode
                        if ((pos.X >= SelectedControl.Location.X + SelectedControl.Width &&
                            pos.X <= SelectedControl.Location.X + SelectedControl.Width + DRAG_HANDLE_SIZE &&
                            pos.Y >= SelectedControl.Location.Y + SelectedControl.Height / 2 - DRAG_HANDLE_SIZE / 2 &&
                            pos.Y <= SelectedControl.Location.Y + SelectedControl.Height / 2 + DRAG_HANDLE_SIZE / 2))
                        {
                            direction = Direction.E;
                            //TheForm.Cursor = Cursors.SizeWE;
                            TheForm.Cursor = Cursors.PanEast;
                        }
                        #endregion
                        break;
                    default:
                        break;
                }
                
            }
            else if(CtrlMode == TheMode.UI_Create_Mode)
            {
                //TheForm.Cursor = Cursors.Default;
            }
            else
            {
                direction = Direction.None;
                TheForm.Cursor = Cursors.Default;
            }
            #endregion
        }


        #endregion



    }
}
