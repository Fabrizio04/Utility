using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibVLCPlayer
{
    public partial class Form2 : Form
    {
        public Form2(string icon)
        {
            InitializeComponent();
            if(icon != null && icon != @"")
                this.Icon = new Icon(icon);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (System.Windows.Forms.Application.OpenForms["Form1"] as Form1).PlayURLFile(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
