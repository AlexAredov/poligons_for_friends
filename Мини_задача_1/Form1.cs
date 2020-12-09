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
        List<Class2> pol = new List<Class2>();
        public Form1()
        {
            InitializeComponent();
            Draw = false;
            WhatS = 0;
            DoubleBuffered = true;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int u = 0;
            int d = 0;
            double y;
            bool Up = false;
            bool Down = false;
            if (Draw)
            {
                Graphics g = e.Graphics;
                foreach (Class2 aPart in pol)
                {
                    aPart.InS = false;
                    aPart.Draw(g);
                }
                Pen br = new Pen(Color.Black);
                if (pol.Count() > 2)
                {
                    for (int i = 0; i < pol.Count() - 1; i++)
                    {
                        for (int j = i + 1; j < pol.Count(); j++)
                        {
                            //if (pol[j].SetX != pol[i].SetX)
                            //{
                                for (int k = 0; k < pol.Count(); k++)
                                {
                                    if (k != j && k != i)
                                    {

                                        y = (pol[k].SetY - pol[j].SetY) * (pol[i].SetX - pol[j].SetX) - ((pol[i].SetY - pol[j].SetY) * (pol[k].SetX - pol[j].SetX));
                                        //y = (pol[j].SetY - pol[i].SetY) * (pol[k].SetX - pol[i].SetX) / (pol[j].SetX - pol[i].SetX) + pol[i].SetY;
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
                            //}
                            //else
                            //{
                            //    for (int k = 0; k < pol.Count; k++)
                            //    {
                            //        if (k != i && k != j)
                            //        {
                            //            if (pol[k].SetX <= pol[i].SetX)
                            //            {
                            //                Up = true;
                            //            }
                            //            else 
                            //            { 
                            //                Down = true; 
                            //            }
                            //        }
                            //    }
                            //    if (!(Up && Down))
                            //    {
                            //        pol[i].InS = true;
                            //        pol[j].InS = true;
                            //        e.Graphics.DrawLine(br, pol[i].SetX, pol[i].SetY, pol[j].SetX, pol[j].SetY);
                            //    }
                            //}
                            Up = false;
                            Down = false;
                            u = 0;
                            d = 0;
                        }
                    }
                }
            }
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
                else
                {
                    i = false;
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
                    if (!aPart.InS)
                    {
                        pol.Remove(aPart);
                        Refresh();
                        break;
                    }
                    Refresh();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
