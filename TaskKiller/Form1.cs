using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskKiller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Process[] prs = Process.GetProcesses();

            foreach (Process proc in prs)
            {
                listBox1.Items.Add(Convert.ToString(proc.ProcessName));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName(listBox1.SelectedItem.ToString());
            foreach (Process process in processes)
            {
                process.Kill();
            }

            listBox1.Items.Clear();
            Process[] prs = Process.GetProcesses();

            foreach (Process proc in prs)
            {
                listBox1.Items.Add(Convert.ToString(proc.ProcessName));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Process[] prs = Process.GetProcesses();

            foreach (Process proc in prs)
            {
                listBox1.Items.Add(Convert.ToString(proc.ProcessName));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Process[] prs = Process.GetProcesses();
            bool found = false;
            foreach (Process proc in prs)
            {
                string process = Convert.ToString(proc.ProcessName);
                if (String.Compare(process, richTextBox1.Text) == 0)
                {
                    listBox1.Items.Add(Convert.ToString(proc.ProcessName));
                    found = true;
                }
            }
            if (found == false)
            {
                System.Windows.Forms.MessageBox.Show("Process isn't running");
            }
            richTextBox1.Clear();
        }
    }
}
