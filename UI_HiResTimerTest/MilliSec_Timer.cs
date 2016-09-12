using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MilliSec_Timer_Page
{
    public class MilliSec_Timer
    {
        [DllImport("winmm")]
        static public extern uint timeGetTime();

        [DllImport("winmm")]
        static public extern void timeBeginPeriod(int t);

        [DllImport("winmm")]
        static public extern uint timeEndPeriod(int t);

        static public int interval;
        static public bool enable;

        public MilliSec_Timer() 
        {

        }

        static public void MilliSec_TimerFunc()
        {
            uint timerstart = timeGetTime();
            while (enable)
            {
                uint i = 0;
                while (i < interval)     //N为时间间隔（ms）
                {
                    i = timeGetTime() - timerstart;
                }
                timerstart = timeGetTime();
                //timerfunction();               //需要循环运行的函数；           
            }
        }




    }
}
