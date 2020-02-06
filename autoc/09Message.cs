using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace autoc
{
    public partial class _09Message : Form
    {
        public _09Message()
        {
            InitializeComponent();
        }
        public void setFormat(string format) 
        {
            radioButton1.Text = format;
        }
        private void _09Message_Load(object sender, EventArgs e)
        {
            Services.opened = true;
            button2.BackColor = ColorTranslator.FromHtml("#4ebfed");
            panel1.BackColor = ColorTranslator.FromHtml("#fff");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked)
            {
                Services.format = 1;
            }
            else 
            {
                Services.format = 0;
            }
            this.Hide();
            Services.opened = false;
        }

        private void _09Message_FormClosed(object sender, FormClosedEventArgs e)
        {
            Services.format = 0;
        }
    }
}
