using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp14
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            button1.Text = "Ok";
        }

        public int Data
        {
            get
            {
                return trackBar1.Value;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            main.Invalidate();
            Form2.ActiveForm.Close();
        }
    }
}
