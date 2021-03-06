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
    public delegate void RChEventHander(object sender, RadiusEventArgs e);
    public partial class Form2 : Form
    {
        public event RChEventHander Rch;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int v = Convert.ToInt32(trackBar1.Value);
            if (this.Rch != null)
            {
                this.Rch(this, new RadiusEventArgs(v));
            }
        }
    }

    public class RadiusEventArgs : EventArgs
    {
        public int Rad { set; get; }
        public RadiusEventArgs(int r)
        {
            Rad = r;
        }
    }
}
