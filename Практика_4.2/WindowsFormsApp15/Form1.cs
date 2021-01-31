using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp15
{
    public partial class Form1 : Form
    {
        public string s;
        public Form1()
        {
            InitializeComponent();
            s = "";
        }

        public string InputText//назовите как нравится
        {
            get 
            { 
                return textBox1.Text; 
            }
            set 
            { 
                s = value; 
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Owner = this;
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = s;
        }
    }
}
