using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace autoc
{
    public partial class _08Choix : Form
    {
        public _08Choix()
        {
            InitializeComponent();
        }

        private void _08Choix_Load(object sender, EventArgs e)
        {
            panel2.BackColor = ColorTranslator.FromHtml("#eff2f9");
            button1.BackColor = ColorTranslator.FromHtml("#4ebfed");
            button2.BackColor = ColorTranslator.FromHtml("#4ebfed");
            label1.ForeColor = ColorTranslator.FromHtml("#757575");
            label2.ForeColor = ColorTranslator.FromHtml("#757575");
            label6.ForeColor = ColorTranslator.FromHtml("#757575");

            radioButton1.ForeColor = ColorTranslator.FromHtml("#757575");
            radioButton2.ForeColor = ColorTranslator.FromHtml("#757575");
            textBox9.ForeColor = ColorTranslator.FromHtml("#757575");
            label4.ForeColor = ColorTranslator.FromHtml("#757575");
            label5.ForeColor = ColorTranslator.FromHtml("#757575");
            label3.ForeColor = ColorTranslator.FromHtml("#4ebfed");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                label5.Visible = true;
                textBox9.Visible = true;
            }
            else 
            {
                label5.Visible = false;
                textBox9.Visible = false;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void _08Choix_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void openFile()
        {
            if (Program.filepath != "")
            {
                //toc, acc, rif 
                string mystring = Program.filepath;
                mystring = mystring.Substring(Math.Max(0, mystring.Length - 3));
                if (mystring == "toc")
                {
                    _03Consultation f = new _03Consultation();
                    f.Show();
                    this.Hide();
                    f.loadFile(Program.filepath);
                }
                if (mystring == "acc")
                {
                    _02Accessoire f = new _02Accessoire();
                    f.Show();
                    this.Hide();
                    f.loadFile(Program.filepath);
                }
                if (mystring == "rif")
                {
                    _01Tarif f = new _01Tarif();
                    f.Show();
                    this.Hide();
                    f.loadFile(Program.filepath);
                }
            }
            else
            {
                Menu m = new Menu();
                m.Show();
                this.Hide();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                Services.ChangeEtat(2);
                openFile();
            }
            else 
            {
                if (textBox9.Text == "renaultdacia2017")
                {
                    Services.ChangeEtat(1);
                    openFile();
                }
                else
                {
                    MessageBox.Show("Vérifiez que le code d'activation est indiqué correctement.", "Code d'activation non valide.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox9.Text = "";
                }
            }
        }
    }
}
