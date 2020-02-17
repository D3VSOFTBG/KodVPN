using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace KodVPN
{
    public partial class KV : Form
    {
        public KV()
        {
            InitializeComponent();
        }

        private void KV_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox1.Text + ".ovpn"))
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
                startInfo.Arguments = "--config " + textBox1.Text + ".ovpn";
                startInfo.Verb = "runas";
                process.StartInfo = startInfo;
                process.Start();

                MessageBox.Show("Connecting.");

                Thread.Sleep(5000);

                MessageBox.Show("Connected.");

            }
            else
            {
                MessageBox.Show("Your username is not registered.");
            }

        }
                
           

        private void button2_Click(object sender, EventArgs e)
        {
            disconnect();
            MessageBox.Show("Disconnected.");
        }

        private void disconnect()
        {
            var proc1 = new ProcessStartInfo();
            proc1.UseShellExecute = true;

            proc1.WorkingDirectory = @"C:\Windows\System32";

            proc1.FileName = @"C:\Windows\System32\cmd.exe";
            proc1.Verb = "runas";
            proc1.Arguments = "/c Taskkill /F /IM openvpn.exe";
            proc1.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(proc1);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://openvpn.net/community-downloads/");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
