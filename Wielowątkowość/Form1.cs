using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Wielowątkowość
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void generating(int numbers)
        {
            for (int i = 0; i < numbers; i++)
            {
                //wykonywane w tym wątku
                int length = numbers.ToString().Length - 1;
                string test = "";
                for (int j = 0; j < length - i.ToString().Length; j++)
                {
                    test += "0";
                }
                test += i;

                // przesłanie do 1 wątku
                Action<string> action = new Action<string>(number => { this.listBox1.Items.Add(number); this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1; this.listBox1.SelectedIndex = -1; this.label3.Text = (i+1) + " / " + numbers; this.progressBar1.Value = (int)((i+1)/(float)numbers*100); });
                if (this.InvokeRequired)
                {
                    this.Invoke(action, test);
                }
                else
                {
                    action(test);
                }

                // zatrzymanie czasu
                Thread.Sleep(100);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            int permutationLength = (int)this.numericUpDown1.Value;
            int permutationQuantity = (int)Math.Pow(10, permutationLength);
            this.label3.Text = "0 / " + permutationQuantity;
            Thread thread = new Thread(new ThreadStart(() => this.generating(permutationQuantity)));
            thread.Start();
        }
    }
}
