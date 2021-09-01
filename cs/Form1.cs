using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace _31b4
{
    public partial class Form1 : Form
    {
        public static bool ExitN = false;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
            int nLeftRect,
            int nTopRect,
            int NRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );
        
        

        public Point mouselocation;
        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0,0,Width,Height,25,25));

            labelTitle.Text = "Home";
            rfmHome frmDashboard_vrb = new rfmHome() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmDashboard_vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(frmDashboard_vrb);
            frmDashboard_vrb.Show();
        }

        private void Form1_Load(object sender, EventArgs e){
            panelLeft.Height = buttonHome.Height;
            panelLeft.Top = buttonHome.Top;
            buttonHome.BackColor = Color.FromArgb(48, 59, 71);
            ExitN = true;
            

            
        }//endLoad
        #region buttoms
        //-----------------------buttoms--------------------------------
        private void buttonHome_Click(object sender, EventArgs e){
            panelLeft.Height = buttonHome.Height;
            panelLeft.Top = buttonHome.Top;
            buttonHome.BackColor = Color.FromArgb(48, 59, 71);

            labelTitle.Text = "Home";
            this.PnlFormLoader.Controls.Clear();
            rfmHome frmHome_Vrb = new rfmHome() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmHome_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(frmHome_Vrb);
            frmHome_Vrb.Show();
            ExitN = true;

        }

        private void buttonClicker_Click(object sender, EventArgs e){
            panelLeft.Height = buttonClicker.Height;
            panelLeft.Top = buttonClicker.Top;
            buttonClicker.BackColor = Color.FromArgb(48, 59, 71);

            labelTitle.Text = "Auto Clicker";
            this.PnlFormLoader.Controls.Clear();
            frmAutoclicker frmHome_Vrb = new frmAutoclicker() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmHome_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(frmHome_Vrb);
            frmHome_Vrb.Show();
            ExitN = false;

        }

        private void buttonTyper_Click(object sender, EventArgs e){
            
            panelLeft.Height = buttonTyper.Height;
            panelLeft.Top = buttonTyper.Top;
            buttonTyper.BackColor = Color.FromArgb(48, 59, 71);
            labelTitle.Text = "Auto Typer";
            this.PnlFormLoader.Controls.Clear();
            frmAutotyper frmHome_Vrb = new frmAutotyper() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmHome_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(frmHome_Vrb);
            frmHome_Vrb.Show();
            ExitN = true;
            //MessageBox.Show("Not working yet.");

        }

        private void buttonIDK_Click(object sender, EventArgs e){
            panelLeft.Height = buttonIDK.Height;
            panelLeft.Top = buttonIDK.Top;
            buttonIDK.BackColor = Color.FromArgb(48, 59, 71);

            labelTitle.Text = "Settings";
            this.PnlFormLoader.Controls.Clear();
            frmidk frmHome_Vrb = new frmidk() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmHome_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(frmHome_Vrb);
            frmHome_Vrb.Show();
            ExitN = true;

        }
        //--------------------------app moving------------------------
        private void panel4_MouseDown(object sender, MouseEventArgs e){
            mouselocation = new Point(-e.X, -e.Y);
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e){
            if (e.Button == MouseButtons.Left){
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouselocation.X, mouselocation.Y);
                Location = mousePose;
            }
        }
        //--------------------------close, mini--------------------------
        private void buttonClose_Click(object sender, EventArgs e){
            ExitN = true;
            Environment.Exit(0);
            Application.Exit();
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e){
            ExitN = true;
            WindowState = FormWindowState.Minimized;

        }
        //-------------------------buttoms leave-----------------------
        private void buttonHome_Leave(object sender, EventArgs e){
            buttonHome.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void buttonClicker_Leave(object sender, EventArgs e){
            buttonClicker.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void buttonTyper_Leave(object sender, EventArgs e){
            buttonTyper.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void buttonIDK_Leave(object sender, EventArgs e){
            buttonIDK.BackColor = Color.FromArgb(24, 30, 54);
        }
        #endregion//endragion
        

    }
}
