using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private string text;

        public string value { get { return text; } }

        private void button1_Click(object sender, EventArgs e)
        {
            text = this.textBox1.Text;
            this.Close();
        }

        private void textbox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                text = this.textBox1.Text;
                this.Close();
            }
        }
    }
}
