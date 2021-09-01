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


namespace _31b4
{
    public partial class frmAutotyper : Form
    {
        public frmAutotyper()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Keys vKey);
        public static Thread AC;
        public bool spam = false;
        public int intervals;
        public string addedTxt="";
        public int times,timesSv;
        private void frmAutotyper_Load(object sender, EventArgs e)
        {
            trackBar1.Maximum = 1000;
            trackBar1.Minimum = 1;
            trackBar1.TickFrequency = 80;
            trackBar1.Value = 500;
            intervals = 500;
            btnDelay.Minimum = 1000;
            btnDelay.Maximum = 30000;
            btnDelay.TickFrequency = 3500;
            btnDelay.Value = 3000;
            spamBar.Maximum = 101;
            spamBar.Minimum = 1;
            spamBar.Value = 1;
            spamBar.TickFrequency = 15;
            backgroundWorker1.RunWorkerAsync();
            AC = new Thread(AutoTyper);
            AC.Start();
        }
        private void AutoTyper() {

            while (true){

                if (spam){
                    SendKeys.SendWait(addedTxt);
                    Thread.Sleep(1);
                    SendKeys.SendWait("{ENTER}");
                    if (timesSv<101) {
                        timesSv--;
                    }
                    if (timesSv == 0) {
                        spam = false;
                        onoff.Text = "Off";
                    }
                    Thread.Sleep(intervals);

                }

            }
        
        }
       

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label4.Text = Convert.ToString(trackBar1.Value) + "ms";
            intervals = trackBar1.Value;
            
        }

       

        /*private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e){
            while (true)
            {
                while (enableHotkeys.Checked ){
                    if (GetAsyncKeyState(Keys.F11) < 0){
                       spam = false;
                    }
                    else if (GetAsyncKeyState(Keys.F12) < 0){
                        Thread.Sleep(1);
                        spam = true;
                        break;
                    }
                    Thread.Sleep(1);
                    
                }
            }
        }*/

        private void added_text_TextChanged(object sender, EventArgs e){
            addedTxt = added_text.Text;
        }

       

        private void btnDelay_Scroll(object sender, EventArgs e) {
            label13.Text = Convert.ToString(btnDelay.Value/1000) + "s";
        }

        private void onoff_Click(object sender, EventArgs e) {
            if (checkEnable.Checked && !(added_text.Text=="")) {
                if (onoff.Text == "Off") {
                    onoff.Text = "On";
                    timesSv = times;
                    Thread.Sleep(btnDelay.Value);
                    spam = true;

                } else {
                    onoff.Text = "Off";
                    spam = false;
                }
            }
        }

        private void label3_Click(object sender, EventArgs e) {

        }

        private void spamBar_Scroll(object sender, EventArgs e) {
            times = spamBar.Value;
            timesSv = times;
            if (spamBar.Value==101) {
                spmTimes.Text = "∞";
            } else {
                spmTimes.Text = Convert.ToString(spamBar.Value);
            }
        }
    }
}
