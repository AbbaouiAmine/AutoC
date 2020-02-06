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
    public partial class Wait : Form
    {
        public Wait()
        {
            InitializeComponent();
        }

        private void Wait_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Services.b.CancelAsync();
        }

        private void Wait_Load(object sender, EventArgs e)
        {

        }
    }
}
