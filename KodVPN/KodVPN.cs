using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

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

                if (button1.Text == "Connect")
                {
                    connect();
                }
                else if (button1.Text == "Disconnect")
                {
                    disconnect();
                }
            }
            else
            {
                MessageBox.Show("Your username is not registered.");
                button1.Text = "Connect";
            }
        }

        private void connect()
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
            startInfo.Arguments = "--config " + textBox1.Text + ".ovpn";
            startInfo.Verb = "runas";
            process.StartInfo = startInfo;
            process.Start();

            MessageBox.Show("Connecting. Please wait 3 seconds");

            Thread.Sleep(3000);

            MessageBox.Show("Connected.");
            button1.Text = "Disconnect";

        }

        private void disconnect()
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Verb = "runas";
            startInfo.Arguments = "/C Taskkill /F /IM openvpn.exe";
            process.StartInfo = startInfo;
            process.Start();


            MessageBox.Show("Disconnected.");
            button1.Text = "Connect";
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            this.Show();
            notifyIcon.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void KV_Resize(object sender, EventArgs e)
        {
            this.Hide();
            notifyIcon.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            disconnect();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://openvpn.net/community-downloads/");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://kodbulgaria.com");
        }
    }
}
