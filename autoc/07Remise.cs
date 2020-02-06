using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using Microsoft.Win32;

namespace autoc
{
    public partial class _07Remise : Form
    {
        public _07Remise()
        {
            InitializeComponent();
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Stream f;
                openFileDialog1.Filter = "PDF file (*.pdf)|*.pdf";
                openFileDialog1.RestoreDirectory = true;
                openFileDialog1.FileName = "";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    
                    if ((f = openFileDialog1.OpenFile()) != null)
                    {

                        string a = openFileDialog1.FileName;
                        string StartupPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Remove(0, 6);
                        string p = Path.Combine(StartupPath + @"\Resources\", "remise.pdf");
                        if (File.Exists(p))
                        {
                            axAcroPDF1.src = "";
                            
                            File.Delete(p);
                        }
                        File.Copy(a, p);
                        axAcroPDF1.src = p;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          
        }

        

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void _07Remise_Load(object sender, EventArgs e)
        {
            try
            {
               

                button1.BackColor = ColorTranslator.FromHtml("#4ebfed");
                label10aa.ForeColor = ColorTranslator.FromHtml("#323c45");
                label11a.ForeColor = ColorTranslator.FromHtml("#4ebfed");
                string StartupPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Remove(0, 6);
                string p = Path.Combine(StartupPath + @"\Resources\", "remise.pdf");
                if (File.Exists(p))
                {
                    axAcroPDF1.src = p;
                }
                axAcroPDF1.src = axAcroPDF1.src;
                if (Services.page == 1)
                {
                    tabControl1.SelectedTab = tabPage1;
                }
                if (Services.page == 2)
                {
                    tabControl1.SelectedTab = tabPage2;
                    axAcroPDF1.Refresh();
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            
        }

        private void panel1a_MouseEnter(object sender, EventArgs e)
        {
            label11a.ForeColor = ColorTranslator.FromHtml("#323c45");
            label10aa.ForeColor = ColorTranslator.FromHtml("#4ebfed");
            this.pictureBox1a.Image = global::autoc.Properties.Resources.helpbtn71;
        }

        private void panel1a_MouseLeave(object sender, EventArgs e)
        {
            label10aa.ForeColor = ColorTranslator.FromHtml("#323c45");
            label11a.ForeColor = ColorTranslator.FromHtml("#4ebfed");
            this.pictureBox1a.Image = global::autoc.Properties.Resources.helpbtn6;
        }

        private void panel1a_Click(object sender, EventArgs e)
        {
            _06Aide a = new _06Aide();
            a.Show();
        }


        private void tabPage2_Enter(object sender, EventArgs e)
        {
            axAcroPDF1.src = axAcroPDF1.src;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void _07Remise_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void _07Remise_FormClosed(object sender, FormClosedEventArgs e)
        {
           

        }
        //[System.Runtime.InteropServices.DllImport("ole32.dll")]
        //static extern void CoFreeUnusedLibraries();
        //private void _07Remise_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (axAcroPDF1 != null)
        //    {
        //        axAcroPDF1.Dispose();
        //        System.Windows.Forms.Application.DoEvents();
        //        CoFreeUnusedLibraries();
        //    }
        //}


       
    }
}
