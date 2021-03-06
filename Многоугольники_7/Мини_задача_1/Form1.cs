using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Мини_задача_1
{
    public partial class Form1 : Form
    {
        bool Draw;
        int WhatS;
        Color col;
        dynamic Radius = 40;
        List<Class2> pol = new List<Class2>();
        public Form1()
        {
            InitializeComponent();
            Draw = false;
            WhatS = 0;
            col = Color.Green;
            DoubleBuffered = true;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            double y;
            bool Up = false;
            bool Down = false;
            if (Draw)
            {
                Graphics g = e.Graphics;

                foreach (Class2 aPart in pol)
                {
                    aPart.InS = false;
                    aPart.c = col;
                    aPart.r = Radius;
                    aPart.Draw(g);
                }
                Pen br = new Pen(Color.Black);
                if (pol.Count() > 2)
                {
                    for (int i = 0; i < pol.Count() - 1; i++)
                    {
                        for (int j = i + 1; j < pol.Count(); j++)
                        {
                            for (int k = 0; k < pol.Count(); k++)
                            {
                                if (k != j && k != i)
                                {
                                    y = (pol[k].SetY - pol[j].SetY) * (pol[i].SetX - pol[j].SetX) - ((pol[i].SetY - pol[j].SetY) * (pol[k].SetX - pol[j].SetX));
                                    if (y >= 0)
                                    {
                                        Up = true;
                                    }
                                    else
                                    {
                                        Down = true;
                                    }
                                }
                            }
                            if (!(Up && Down))
                            {
                                pol[i].InS = true;
                                pol[j].InS = true;
                                e.Graphics.DrawLine(br, pol[i].SetX, pol[i].SetY, pol[j].SetX, pol[j].SetY);
                            }
                            Up = false;
                            Down = false;
                        }
                    }
                }
            }
        }
        private bool IsInsideFigure(double x, double y, List<Class2> figures)
        {

            if (pol.Count() > 2)
            {
                double y1;
                bool Up = false;
                bool Down = false;
                List<Class2> polygon = new List<Class2>();
                Class2 check = new Sq((int)x, (int)y);
                figures.Add(check);
                polygon.Clear();
                for (int i = 0; i < figures.Count() - 1; i++)
                {
                    for (int j = i + 1; j < figures.Count(); j++)
                    {
                        for (int k = 0; k < figures.Count(); k++)
                        {
                            if (k != j && k != i)
                            {
                                y1 = (figures[k].SetY - figures[j].SetY) * (figures[i].SetX - figures[j].SetX) - ((figures[i].SetY - figures[j].SetY) * (figures[k].SetX - figures[j].SetX));
                                if (y1 >= 0)
                                {
                                    Up = true;
                                }
                                else
                                {
                                    Down = true;
                                }
                            }
                        }
                        if (!(Up && Down))
                        {
                            polygon.Add(figures[j]);
                            polygon.Add(figures[i]);
                        }
                        Up = false;
                        Down = false;
                    }
                }
                if (!polygon.Contains(check))
                {
                    figures.Remove(check);
                    return true;
                }
                figures.Remove(check);
            }

            return false;
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (pol.Any())
            {
                bool i = false;
                foreach (Class2 aPart in pol)
                {
                    if (Draw && aPart.Check(e.X, e.Y))
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            aPart.SetDX = e.X - aPart.SetX;
                            aPart.SetDY = e.Y - aPart.SetY;
                            aPart.SetDR = true;
                            i = true;
                        }
                        else if (e.Button == MouseButtons.Right)
                        {
                            pol.Remove(aPart);
                            Refresh();
                            i = true;
                            break;
                        }
                    }
                }
                if (!i)
                {
                    if (IsInsideFigure(e.X, e.Y, pol))
                    {
                        Draw = true;
                        for (int k = 0; k < pol.Count; k++)
                        {
                            pol[k].SetDX = e.X - pol[k].SetX;
                            pol[k].SetDY = e.Y - pol[k].SetY;
                            pol[k].SetDR = true;
                        }
                    }
                    else
                    {
                        Draw = true;
                        switch (WhatS)
                        {
                            case 0:
                                pol.Add(new Sq(e.X, e.Y));
                                break;
                            case 1:
                                pol.Add(new Triangle(e.X, e.Y));
                                break;
                            default:
                                pol.Add(new Circle(e.X, e.Y));
                                break;
                        }
                        Refresh();
                    }
                }
            }
            else
            {
                Draw = true;
                switch (WhatS)
                {
                    case 0:
                        pol.Add(new Sq(e.X, e.Y));
                        break;
                    case 1:
                        pol.Add(new Triangle(e.X, e.Y));
                        break;
                    default:
                        pol.Add(new Circle(e.X, e.Y));
                        break;
                }
                Refresh();
            }

        }
        private void квадратToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WhatS = 0;
        }

        private void треугольникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WhatS = 1;
        }

        private void кругToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WhatS = 2;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (Class2 aPart in pol)
            {
                if (aPart.SetDR)
                {
                    aPart.SetX = e.X - aPart.SetDX;
                    aPart.SetY = e.Y - aPart.SetDY;
                    Invalidate();
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (Class2 aPart in pol)
            {
                if (aPart.SetDR)
                {
                    aPart.SetDR = false;
                    Refresh();
                }
            }
            if (pol.Count > 2)
            {
                for (int k = 0; k < pol.Count; k++)
                {
                    if (!pol[k].InS)
                    {
                        pol.Remove(pol[k]);
                    }
                }
            }

            Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void цветToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void стартToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Start();
            vbl = true;
        }

        private void стопToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
        bool vbl = false;
        bool vbp = false;
        static Random rand = new Random();
        int i;

        private void timer1_Tick(object sender, EventArgs e)
        {
            i = rand.Next(0, 5);
            if (vbl)
            {
                foreach (Class2 aPart in pol)
                {
                    aPart.SetX += i;
                    aPart.SetY += i;
                    vbl = false;
                    vbp = true;
                }
            }
            else if (vbp)
            {
                foreach (Class2 aPart in pol)
                {
                    aPart.SetX -= i;
                    aPart.SetY -= i;
                    vbp = false;
                    vbl = true;
                }
            }
            Refresh();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void изменитьРазмерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 RadiusF = new Form2();
            RadiusF.Show();
            RadiusF.Rch += RadiusDelegate;
        }

        private void RadiusDelegate(object sender, RadiusEventArgs e)
        {
            Radius = e.Rad;
            Refresh();
        }
    }
}