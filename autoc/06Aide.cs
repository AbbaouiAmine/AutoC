using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace autoc
{
    public partial class _06Aide : Form
    {
        public _06Aide()
        {
            InitializeComponent();
        }
        public void intro(bool val)
        {

            if (val)
                axWindowsMediaPlayer1.URL = "";
            richTextBox1.Visible = val;
            pictureBox2.Visible = val;
            pictureBox1.Visible = val;
            axWindowsMediaPlayer1.Visible = !(val);

        }
        public void media(string file)
        {
           string StartupPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Remove(0,6);
        
      string p = Path.Combine(StartupPath+@"\Resources\", file);
      axWindowsMediaPlayer1.URL = p;
        }

        private void _06Aide_Load(object sender, EventArgs e)
        {
            //this.BackColor = ColorTranslator.FromHtml("#fff");
            panel1.BackColor = ColorTranslator.FromHtml("#323c45");
            panel2.BackColor = ColorTranslator.FromHtml("#323c45");

            label1.BackColor = ColorTranslator.FromHtml("#323c45");
            label2.BackColor = ColorTranslator.FromHtml("#323c45");
            panel3.BackColor = ColorTranslator.FromHtml("#3cbff9");
            panel11.BackColor = ColorTranslator.FromHtml("#fff");
            button2.BackColor = ColorTranslator.FromHtml("#323c45");
            button3.BackColor = ColorTranslator.FromHtml("#323c45");
            button4.BackColor = ColorTranslator.FromHtml("#323c45");
            button5.BackColor = ColorTranslator.FromHtml("#323c45");
            button6.BackColor = ColorTranslator.FromHtml("#323c45");
            button7.BackColor = ColorTranslator.FromHtml("#323c45");
            button8.BackColor = ColorTranslator.FromHtml("#323c45");
            button9.BackColor = ColorTranslator.FromHtml("#323c45");
            button1.BackColor = ColorTranslator.FromHtml("#323c45");

            button10.BackColor = ColorTranslator.FromHtml("#323c45");
            button11.BackColor = ColorTranslator.FromHtml("#323c45");
            button12.BackColor = ColorTranslator.FromHtml("#323c45");
            richTextBox1.Text = "Bienvenue dans la visionneuse d'aide Auto Consultation une source d'informations essentielle pour toutes les personnes qui utilisent  cette application de gestion,  La visionneuse d'aide vous donne accès à des informations, des exemples de travail  et bien d'autres choses encore. Pour trouver ce dont vous avez besoin, parcourez la table des matières, utilisez le menu à gauche pour naviguez dans le contenu .\n \n " + button1.Text + ".\n " + button2.Text + ". \n  " + button3.Text + ". \n  " + button4.Text + ". \n  " + button5.Text + ". \n";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            labelTitre.Text = button1.Text;
            intro(true);
            richTextBox1.Text = "Bienvenue dans la visionneuse d'aide Auto Consultation une source d'informations essentielle pour toutes les personnes qui utilisent  cette application de gestion,  La visionneuse d'aide vous donne accès à des informations, des exemples de travail  et bien d'autres choses encore. Pour trouver ce dont vous avez besoin, parcourez la table des matières, utilisez le menu à gauche pour naviguez dans le contenu .\n \n " + button1.Text + ".\n " + button2.Text + ". \n  " + button3.Text + ". \n  " + button4.Text + ". \n  " + button5.Text + ". \n";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            labelTitre.Text = button2.Text;
            intro(true);
            //axWindowsMediaPlayer1.URL=@"C:\Users\root\Desktop\20094545_186146588590559_7383905992871772160_n.mp4";
            richTextBox1.Text =  button2.Text + ". \n  " + button3.Text + ". \n  " + button4.Text + ". \n  " + button5.Text + ". \n";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            labelTitre.Text = button3.Text;
            intro(false);
            media("importTarif.mp4");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            labelTitre.Text = button4.Text;
            intro(false);
            media("exportTarif.mp4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            labelTitre.Text = button5.Text;
            intro(false);
            media("gestionTarif.mp4");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            labelTitre.Text = button6.Text;
            intro(false);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            labelTitre.Text = button12.Text;
            intro(false);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            labelTitre.Text = button11.Text;
            intro(false);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            labelTitre.Text = button10.Text;
            intro(false);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            labelTitre.Text = button7.Text;
            intro(false);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            labelTitre.Text = button8.Text;
            intro(false);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            labelTitre.Text = button9.Text;
            intro(false);
        }
    }
}
