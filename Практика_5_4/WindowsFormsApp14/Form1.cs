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
        bool Draw;
        int x, y;
        bool direction;

        public Form1()
        {
            InitializeComponent();
            Draw = false;
            x = 0;
            y = 0;
            direction = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Draw = true;
            pictureBox1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Draw = false;
            pictureBox1.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (direction)
            {
                x += 5;
                y += 5;
                if (x + 20 >= pictureBox1.ClientSize.Width || y + 20 >= pictureBox1.ClientSize.Height)
                {
                    direction = false;
                }
            }
            else
            {
                x -= 0;
                y -= 5;
                if (x == 0 || y == 0)
                {
                    direction = true;
                }
            }
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (Draw)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Black), x, y, 20, 20);
            }
        }
    }
}
