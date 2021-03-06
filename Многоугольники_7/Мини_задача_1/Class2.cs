using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Мини_задача_1
{
    abstract class Class2
    {
        protected int x0;
        protected int y0;
        protected int del_x;
        protected int del_y;
        protected bool dragged;
        protected bool In;
        public int r { get; set; }
        public Color c { get; set; }
        public Class2(int x, int y)
        {
            x0 = x;
            y0 = y;
            del_x = 0;
            del_y = 0;
            dragged = false;
            In = false;
            c = Color.Green;
            r = 40;
        }
        public bool InS { get { return In; } set { In = value; } }
        public int SetX { get { return x0; } set { x0 = value; } }
        public int SetY { get { return y0; } set { y0 = value; } }
        public int SetDX { get { return del_x; } set { del_x = value; } }
        public int SetDY { get { return del_y; } set { del_y = value; } }
        public bool SetDR { get { return dragged; } set { dragged = value; } }
        abstract public void Draw(Graphics g);
        abstract public bool Check(int x, int y);
    }
    class Circle : Class2
    {
        public Circle(int x, int y) : base(x, y) { }
        public override void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(c), x0 - r, y0 - r, 2 * r, 2 * r);
        }
        public override bool Check(int x, int y)
        {
            if (((x - x0) * (x - x0) + (y - y0) * (y - y0)) <= r * r) return true;
            else return false;
        }
    }
    class Sq : Class2
    {
        public Sq(int x, int y) : base(x, y) { }
        public override void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(c), x0 - r, y0 - r, 2 * r, 2 * r);
        }
        public override bool Check(int x, int y)
        {
            if (x0 - r < x && x0 + r > x && y0 - r < y && y0 + r > y) return true;
            else return false;
        }
    }
    class Triangle : Class2
    {
        public Point[] curvePoints = { new Point(), new Point(), new Point() };
        public Triangle(int x, int y) : base(x, y) { }
        public override void Draw(Graphics g)
        {
            curvePoints[0] = new Point(x0, y0 - 2 * r);
            curvePoints[1] = new Point(x0 - (int)(2 * r * Math.Sqrt(3) / 2), y0 + r / 2);
            curvePoints[2] = new Point(x0 + (int)(2 * r * Math.Sqrt(3) / 2), y0 + r / 2);
            g.FillPolygon(new SolidBrush(c), curvePoints);
        }
        public override bool Check(int x, int y)
        {
            if ((((curvePoints[0].X - x) * (curvePoints[2].Y - curvePoints[0].Y) - (curvePoints[2].X - curvePoints[0].X) * (curvePoints[0].Y - y)) >= 0) && (((curvePoints[2].X - x) * (curvePoints[1].Y - curvePoints[1].Y) - (curvePoints[1].X - curvePoints[2].X) * (curvePoints[2].Y - y)) >= 0) && (((curvePoints[1].X - x) * (curvePoints[0].Y - curvePoints[2].Y) - (curvePoints[0].X - curvePoints[1].X) * (curvePoints[1].Y - y)) >= 0)) return true;
            else return false;
        }
    }
}