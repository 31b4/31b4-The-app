using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace _31b4 {//project
    public partial class frmAutoclicker : Form {
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Keys vKey);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        private const int LEFTUP = 0x0004;
        private const int LEFTDOWN = 0x0002;
        public static int intervals = 50;
        public bool click = false;
        public int parsedValue;
        public frmAutoclicker() {
            InitializeComponent();
        }
        public static int testCounter = 0;
        public static Thread AC;
        private void frmAutoclicker_Load(object sender, EventArgs e) {//betoltes
            TestButtom.Text = Convert.ToString(testCounter);
            trackBar1.Maximum = 2000;
            trackBar1.Minimum = 1;
            trackBar1.TickFrequency = 200;
            trackBar1.Value = intervals;
            timer1.Interval = trackBar1.Value;
            msec.Text = Convert.ToString(intervals+"ms");
            //clicker
            CheckForIllegalCrossThreadCalls = false;
            backgroundWorker1.RunWorkerAsync();
            AC = new Thread(AutoClick);
            Form1.ExitN = false;
            AC.Start();
        }
        private void AutoClick() {//auto clicker
            while (true) {
                if (click == true) {
                    mouse_event(dwFlags: LEFTUP, dx: 0, dy: 0, cButtons: 0, dwExtraInfo: 0);
                    Thread.Sleep(1);
                    mouse_event(dwFlags: LEFTDOWN, dx: 0, dy: 0, cButtons: 0, dwExtraInfo: 0);
                    Thread.Sleep(1);
                    mouse_event(dwFlags: LEFTUP, dx: 0, dy: 0, cButtons: 0, dwExtraInfo: 0);
                    Thread.Sleep(intervals);
                }
                Thread.Sleep(2);
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
            while (true) {
                if (checkBox1.Checked) {
                    if (GetAsyncKeyState(Keys.F9) < 0) {
                        click = false;
                        onoff.Text = "Off";
                    } else if (GetAsyncKeyState(Keys.F10) < 0) {
                        click = true;
                        onoff.Text = "On";
                    } else if(!click){
                        onoff.Text = "Off";
                    } else if (click) {
                        onoff.Text = "On";
                    }
                    Thread.Sleep(1);
                } else if (!checkBox1.Checked) {
                    click = false;
                    onoff.Text = "Off";
                }
                Thread.Sleep(1);
                if (Form1.ExitN) {
                    checkBox1.Checked = false;
                    pressToRun.Checked = false;
                    AC.Abort();
                } else if (pressToRun.Checked) {
                    click = false;
                }
            }
        }//end background worker
        private void trackBar1_Scroll(object sender, EventArgs e) {
            msec.Text = Convert.ToString(trackBar1.Value) + "ms";
            timer1.Interval = trackBar1.Value;
            intervals = trackBar1.Value;
        }
        private void TestButtom_Click(object sender, EventArgs e) {
            testCounter++;
            TestButtom.Text = Convert.ToString(testCounter);
        }
        private void button1_Click(object sender, EventArgs e) {
            testCounter = 0;
            TestButtom.Text = Convert.ToString(testCounter);
        }
        private void onoff_Click(object sender, EventArgs e) {
            if (checkBox1.Checked && !(pressToRun.Checked)) {
                if (onoff.Text=="Off") {
                    onoff.Text = "On";
                    Thread.Sleep(1000);
                    click = true;
                } else {
                    onoff.Text = "Off";
                    click = false;
                    Thread.Sleep(500);
                }
            }
        }
    }//end class
}
