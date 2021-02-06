using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp16
{
    public partial class Form1 : Form
    {
        bool Draw, direction;
        double x, y, a, x1, y1, x2, y2, x3, y3;
        int r;
        public Form1()
        {
            InitializeComponent();
            Draw = false;
            x = 380;
            y = 150;
            x1 = 380;
            y1 = 150;
            x2 = 380;
            y2 = 150;
            x3 = 380;
            y3 = 150;
            r = 40;
            a = 0;
            direction = true;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (Draw)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Black), (int)x, (int)y + 2*r, 20, 20);
                e.Graphics.FillEllipse(new SolidBrush(Color.Black), (int)x1, (int)y1 + 2*r, 20, 20);
                e.Graphics.FillEllipse(new SolidBrush(Color.Black), (int)x2, (int)y2 - 2*r, 20, 20);
                e.Graphics.FillEllipse(new SolidBrush(Color.Black), (int)x3, (int)y3 - 2*r, 20, 20);
            }
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            a++;
            if (direction)
            {
                x += (r * Math.Sin(a / 2));
                y += (r * Math.Cos(a / 2));
                x1 -= (r * Math.Sin(a / 2));
                y1 += (r * Math.Cos(a / 2));
                x2 += (r * Math.Sin(a / 2));
                y2 -= (r * Math.Cos(a / 2));
                x3 -= (r * Math.Sin(a / 2));
                y3 -= (r * Math.Cos(a / 2));
                if (x + 20 >= pictureBox1.ClientSize.Width || y + 20 >= pictureBox1.ClientSize.Height)
                {
                    direction = false;
                }
            }
            else
            {
                x -= 5;
                y -= 5;
                if (x == 0 || y == 0)
                {
                    direction = true;
                }
            }


            pictureBox1.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
