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
    public partial class Form1 : Form
    {
        int s1;
        Color col;
        public Form1()
        {
            InitializeComponent();
            s1 = 100;
            col = Color.Black;
        }
        public int S1 { get; set; }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 Dialog = new Form2();
            Dialog.Owner = this;
            Dialog.ShowDialog();
            s1 = Dialog.Data * 2;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush pen = new SolidBrush(col);
            e.Graphics.FillEllipse(pen, 200 , 200, s1, s1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;
            MyDialog.Color = col;
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                col = MyDialog.Color;
                Invalidate();
            }

        }
    }
}
