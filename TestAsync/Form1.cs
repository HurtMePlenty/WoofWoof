using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestAsync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Sync_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox1.Text += "Start" + System.Environment.NewLine;

            string result = string.Empty;


            var t = Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(5000);
                    result ="Done";
                });
            t.Wait();
            textBox1.Text += result + System.Environment.NewLine;
            

            textBox1.Text += "End" + System.Environment.NewLine;
        }

        private async void Async_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox1.Text += "Start" + System.Environment.NewLine;

            var result = await Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                return "Done";
            });

            textBox1.Text += result + System.Environment.NewLine;


            textBox1.Text += "End" + System.Environment.NewLine;
        }
    }
}
