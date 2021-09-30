using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
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

            Form1_Load(null, null); //перегружаємо форму
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear(); //очищаємо listBox перед додаванням процесів
            foreach (var item in Process.GetProcesses().OrderBy(x => x.ProcessName))
            {
                listBox1.Items.Add(item);
                listBox1.DisplayMember = "ProcessName"; //виводимо імя процесів
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                process = listBox1.SelectedItem as Process; //обраний елемент приводимо до Process
                process.Kill(); //зупиняємо процес

                Form1_Load(null, null);
            }
            catch (Exception)
            {
                MessageBox.Show("Не можливо закрити!", "Помилка закриття");
            }
        }
    }
    
}
