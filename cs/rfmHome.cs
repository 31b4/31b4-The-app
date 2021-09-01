using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _31b4
{
    public partial class rfmHome : Form
    {
        public rfmHome(){
            InitializeComponent();
        }

        private void rfmHome_Load(object sender, EventArgs e){
            timerTime.Start();
            labelTime.Text = DateTime.Now.ToLongTimeString();
            labelDate.Text = DateTime.Now.ToLongDateString();

        }

        private void timerTime_Tick(object sender, EventArgs e){
            labelTime.Text = DateTime.Now.ToLongTimeString();
            labelDate.Text = DateTime.Now.ToLongDateString();
        }

        private void githubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/Bence314");
        }

        private void discordLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("https://discord.gg/g9K9D86VNv");
        }
    }
}
