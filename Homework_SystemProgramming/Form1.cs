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

namespace Homework_SystemProgramming
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Process process = new Process();
        private void button1_Click(object sender, EventArgs e)
        {
            process.StartInfo = new ProcessStartInfo(textBox1.Text);
            process.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var item in Process.GetProcesses())
            {
                listBox1.Items.Add($"Process ID: {item.Id}");
                listBox1.Items.Add($"Process ProcessName: {item.ProcessName}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                process = listBox1.SelectedItem as Process;
                process.Kill();
            }
            catch (Exception)
            {
                MessageBox.Show("Не можливо закрити!", "Помилка закриття");
            }
        }
    }
    
}
