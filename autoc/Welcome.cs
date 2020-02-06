using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrendanGrant.Helpers.FileAssociation;
using System.IO;
using System.Reflection;

namespace autoc
{
    public partial class Welcome : Form
    {
        string s0 = "", s1 = "", s2 = "";
        int etat = 0;
        string p = " . ";
        DateTime t = DateTime.Now;
        public Welcome()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }


        private void Welcome_Load(object sender, EventArgs e)
        {

            label1.BackColor = ColorTranslator.FromHtml("#4ebfed");
            label2.BackColor = ColorTranslator.FromHtml("#4ebfed");
            label3.BackColor = ColorTranslator.FromHtml("#4ebfed");
            label4.BackColor = ColorTranslator.FromHtml("#4ebfed");
            labelaz.BackColor = ColorTranslator.FromHtml("#4ebfed");

            panel3.BackColor = ColorTranslator.FromHtml("#4ebfed");
            panel2.BackColor = ColorTranslator.FromHtml("#4ebfed");

            this.BackColor = ColorTranslator.FromHtml("#4ebfed");
            label3.ForeColor = ColorTranslator.FromHtml("#323c45");

            

            timer1.Start();
            s0 = ""; s1 = ""; s2 = "";
            etat = 0;
            
        }


        void associationTypeAndIcon()
        {
            FileAssociationInfo fai = new FileAssociationInfo(".autoc");
            FileAssociationInfo fai1 = new FileAssociationInfo(".tarif");
            FileAssociationInfo fai2 = new FileAssociationInfo(".acc");
            //if (!fai.Exists && Services.etat==0)
            //{
                fai.Create("AutoConsultation");

                //Specify MIME type (optional)
                fai.ContentType = "application/AutoConsultation-app";

                //Programs automatically displayed in open with list
                fai.OpenWithList = new string[] { "autoc.exe" };
            //}
            //if (!fai1.Exists && Services.etat == 0)
            //{

                fai1.Create("Tarif-AutoConsultation");

                //Specify MIME type (optional)

                fai1.ContentType = "application/AutoConsultation-app";

                //Programs automatically displayed in open with list
                fai1.OpenWithList = new string[] { "autoc.exe" };
            //}
            //if (!fai2.Exists && Services.etat == 0)
            //{

                fai2.Create("Acc-AutoConsultation");

                //Specify MIME type (optional)

                fai2.ContentType = "application/AutoConsultation-app";

                //Programs automatically displayed in open with list
                fai2.OpenWithList = new string[] { "autoc.exe" };
            //}
            /////////////////////////////////////////////////////
            ProgramAssociationInfo pai = new ProgramAssociationInfo(fai.ProgID);
            ProgramAssociationInfo pai1 = new ProgramAssociationInfo(fai1.ProgID);
            ProgramAssociationInfo pai2 = new ProgramAssociationInfo(fai2.ProgID);
            //if (!pai.Exists && Services.etat == 0)
            //{

                string StartupPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Remove(0, 6);

                string c = Path.Combine(StartupPath, "autoc.exe");
                string c1 = Path.Combine(StartupPath, "fileico.ico");
                pai.Create
                (
                    //Description of program/file type
                "fichier d'Auto Consultation ",
                new ProgramVerb
                     (
                    //Verb name
                     "autoc",
                    //Path and arguments to use
                     c + " %0"
                     )
                   );

                //optional
                pai.DefaultIcon = new ProgramIcon(c1);
            //}
            //if (!pai1.Exists && Services.etat == 0)
            //{

                StartupPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Remove(0, 6);

                c = Path.Combine(StartupPath, "autoc.exe");
                c1 = Path.Combine(StartupPath, "tarif.ico");
                pai1.Create
                (
                    //Description of program/file type
                "ficher Tarif d'Auto Consultation ",
                new ProgramVerb
                     (
                    //Verb name
                     "tarif",
                    //Path and arguments to use
                     c + " %0"
                     )
                   );

                //optional
                pai1.DefaultIcon = new ProgramIcon(c1);
            //}
            //if (!pai2.Exists && Services.etat == 0)
            //{

                StartupPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Remove(0, 6);

                c = Path.Combine(StartupPath, "autoc.exe");
                c1 = Path.Combine(StartupPath, "acc.ico");
                pai2.Create
                (
                    //Description of program/file type
                "ficher accessoire d'Auto Consultation ",
                new ProgramVerb
                     (
                    //Verb name
                     "acc",
                    //Path and arguments to use
                     c + " %0"
                     )
                   );

                //optional
                pai2.DefaultIcon = new ProgramIcon(c1);
            //}
        }
        private void panel3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //label2.Text = label1.Text.Length.ToString()+ "   s0 = "+s0.Length+" , s1 = "+s1.Length+" , s2= "+s2.Length;
            label1.Text = s0 + "." + s1 + "." + s2 + ".";
            if (etat == 0)
            {
                s0 += "   ";
                s1 += "   ";
                s2 += "   ";
                if (label1.Text.Length == 12)
                    etat = 1;
                if (s0.Length >= 58)
                {
                    s0 = "";
                    s1 = "";
                    s2 = "";
                    p = " . ";
                    label4.Text = "Connexion";
                }
            }
            if (etat == 1 && s0.Length == 14 && s1.Length == 2 && s2.Length == 2)
            {
                etat = 0;
            }

            if (etat == 1 && s2.Length == 2)
            {
                s1 = s1.Remove(s1.Length - 1);
                s0 += " ";

            }

            if (etat == 1 && s2.Length != 2)
            {
                s2 = s2.Remove(s2.Length - 1);
                s0 += " ";

            }
            if (label1.Text.Length == 12 || (label1.Text.Length == 21 && p.Length == 6) || (label1.Text.Length == 21 && p.Length == 9))
            {
                label4.Text = "Connexion" + p;
                p += " . ";
            }
            if ((DateTime.Now - t).Seconds >= 3)
            {
                // Program.filepath = "accc.acc";
                //********************************************************************
                //********************************************************************
                string a = Program.filepath;
               // Program.filepath = @"C:\Users\root\Desktop\s  sa.acc";
                
                if (Services.etat != 0)
                {
                    if (Program.filepath != "")
                    {
                        //toc, acc, rif 
                        string mystring = Program.filepath;
                        //mystring.Replace(" ", String.Empty);
                        mystring = mystring.Substring(Math.Max(0, mystring.Length - 3));
                        if (mystring == "toc")
                        {
                            _03Consultation f = new _03Consultation();
                            f.Show();
                            timer1.Dispose();
                            this.Hide();
                            f.loadFile(Program.filepath);
                        }
                        if (mystring == "acc")
                        {
                            
                            _02Accessoire f = new _02Accessoire();
                            f.Show();
                            timer1.Dispose();
                            this.Hide();

                            f.loadFile(Program.filepath);
                        }
                        if (mystring == "rif")
                        {
                            
                            _01Tarif f = new _01Tarif();
                            f.Show();
                            timer1.Dispose();
                            this.Hide();
                            f.loadFile(Program.filepath);
                        }
                    }
                    else
                    {
                        Menu m = new Menu();
                        m.Show();
                        timer1.Dispose();
                        this.Hide();
                    }
                }
                else 
                {
                    
                    _08Choix c = new _08Choix();
                    c.Show();
                    timer1.Dispose();
                    associationTypeAndIcon();
                    this.Hide();
                }

            }

        }

        private void panel2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }




    }
}
