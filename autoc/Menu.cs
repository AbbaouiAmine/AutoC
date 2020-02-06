using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Humanizer;
using System.Windows.Forms;
using System.Globalization;
using System.Net.Mail;
using Microsoft.Win32;


namespace autoc
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
   
        }
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
        //        return cp;
        //    }
        //}

        int originalExStyle = -1;
        bool enableFormLevelDoubleBuffering = true;

        protected override CreateParams CreateParams
        {
            get
            {
                if (originalExStyle == -1)
                    originalExStyle = base.CreateParams.ExStyle;

                CreateParams cp = base.CreateParams;
                if (enableFormLevelDoubleBuffering)
                    cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
                else
                    cp.ExStyle = originalExStyle;

                return cp;
            }
        } 

       
        private void Menu_Load(object sender, EventArgs e)
        {
            b1.BackColor = ColorTranslator.FromHtml("#3cbff9");
            b2.BackColor = ColorTranslator.FromHtml("#3cbff9");
            b3.BackColor = ColorTranslator.FromHtml("#3cbff9");
            b4.BackColor = ColorTranslator.FromHtml("#3cbff9");

            panel1.BackColor = ColorTranslator.FromHtml("#3cbff9");
            panel2.BackColor = ColorTranslator.FromHtml("#3cbff9");
            panel3.BackColor = ColorTranslator.FromHtml("#3cbff9");
            panel4.BackColor = ColorTranslator.FromHtml("#3cbff9");
            panel10.BackColor = ColorTranslator.FromHtml("#3cbff9");
            
            b5.BackColor = ColorTranslator.FromHtml("#3cbff9");

            b6.BackColor = ColorTranslator.FromHtml("#3cbff9");
           /*label4.ForeColor = ColorTranslator.FromHtml("#323c45");
            label5.ForeColor = ColorTranslator.FromHtml("#323c45");
            label6.ForeColor = ColorTranslator.FromHtml("#323c45");
            label7.ForeColor = ColorTranslator.FromHtml("#323c45");
            label9.ForeColor = ColorTranslator.FromHtml("#323c45");*/

            bk1.BackColor = ColorTranslator.FromHtml("#323c45");
            bk2.BackColor = ColorTranslator.FromHtml("#323c45");
            bk3.BackColor = ColorTranslator.FromHtml("#323c45");
            bk4.BackColor = ColorTranslator.FromHtml("#323c45");
            bk5.BackColor = ColorTranslator.FromHtml("#323c45");

           //label1.BackColor = ColorTranslator.FromHtml("#3cbff9");
           //label2.BackColor = ColorTranslator.FromHtml("#3cbff9");
           //label3.BackColor = ColorTranslator.FromHtml("#3cbff9");
           label4.BackColor = ColorTranslator.FromHtml("#3cbff9");
           label5.BackColor = ColorTranslator.FromHtml("#3cbff9");
           label6.BackColor = ColorTranslator.FromHtml("#3cbff9");
           label7.BackColor = ColorTranslator.FromHtml("#3cbff9");
           label8.BackColor = ColorTranslator.FromHtml("#3cbff9");
           label9.BackColor = ColorTranslator.FromHtml("#3cbff9");
           label10.BackColor = ColorTranslator.FromHtml("#3cbff9");

            ligne.BackColor = ColorTranslator.FromHtml("#323c45");
            //labeltime.ForeColor = ColorTranslator.FromHtml("#323c45");
            Services.m = this;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labeltime.Text = DateTime.Now.ToString("dd/MM/yyyy      HH:mm:ss");
        }

        private void b5_MouseEnter(object sender, EventArgs e)
        {
            bk5.BackColor = ColorTranslator.FromHtml("#ffffff");
            label9.ForeColor = ColorTranslator.FromHtml("#323c45");
            panel10.BackgroundImage = global::autoc.Properties.Resources.priceB;
            
        }

        private void b5_MouseLeave(object sender, EventArgs e)
        {
            bk5.BackColor = ColorTranslator.FromHtml("#323c45");
            label9.ForeColor = ColorTranslator.FromHtml("#ffffff");
            panel10.BackgroundImage = global::autoc.Properties.Resources.price;
            
        }

        private void b5_Click(object sender, EventArgs e)
        {
            
            _01Tarif f = new _01Tarif();
            f.Show();
        }

        private void b1_Click(object sender, EventArgs e)
        {
            _03Consultation f = new _03Consultation();
            f.Show();
            f.selectAuto();
        }

        private void b1_MouseEnter(object sender, EventArgs e)
        {
            bk1.BackColor = ColorTranslator.FromHtml("#ffffff");
            label4.ForeColor = ColorTranslator.FromHtml("#323c45");
            panel1.BackgroundImage = global::autoc.Properties.Resources.consultantB;
        }

        private void b1_MouseLeave(object sender, EventArgs e)
        {
            bk1.BackColor = ColorTranslator.FromHtml("#323c45");
            label4.ForeColor = ColorTranslator.FromHtml("#ffffff");
            panel1.BackgroundImage = global::autoc.Properties.Resources.consultant;
            
        }

        private void b2_Click(object sender, EventArgs e)
        {
            
            _02Accessoire f = new _02Accessoire();
            f.Show();
        }

        private void b2_MouseEnter(object sender, EventArgs e)
        {
            bk2.BackColor = ColorTranslator.FromHtml("#ffffff");
            label5.ForeColor = ColorTranslator.FromHtml("#323c45");
            panel2.BackgroundImage = global::autoc.Properties.Resources.repairB;
        }

        private void b2_MouseLeave(object sender, EventArgs e)
        {
            bk2.BackColor = ColorTranslator.FromHtml("#323c45");
            label5.ForeColor = ColorTranslator.FromHtml("#ffffff");
            panel2.BackgroundImage = global::autoc.Properties.Resources.repair;
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void b4_MouseEnter(object sender, EventArgs e)
        {
            bk4.BackColor = ColorTranslator.FromHtml("#ffffff");
            label7.ForeColor = ColorTranslator.FromHtml("#323c45");
            this.panel4.BackgroundImage = global::autoc.Properties.Resources.aideB;
        }

        private void b4_MouseLeave(object sender, EventArgs e)
        {
            bk4.BackColor = ColorTranslator.FromHtml("#323c45");
            label7.ForeColor = ColorTranslator.FromHtml("#ffffff");
            this.panel4.BackgroundImage = global::autoc.Properties.Resources.aide;
           
        }

        private void b3_MouseEnter(object sender, EventArgs e)
        {
            bk3.BackColor = ColorTranslator.FromHtml("#ffffff");
            label6.ForeColor = ColorTranslator.FromHtml("#323c45");
            this.panel3.BackgroundImage = global::autoc.Properties.Resources.tagB;
        }

        private void b3_MouseLeave(object sender, EventArgs e)
        {
            bk3.BackColor = ColorTranslator.FromHtml("#323c45");
            label6.ForeColor = ColorTranslator.FromHtml("#ffffff");
            this.panel3.BackgroundImage = global::autoc.Properties.Resources.tag;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Services.chaine);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

           // MessageBox.Show(96560.ToWords(new CultureInfo("fr")));
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            MailAddress fromAddress = new MailAddress("abbaouiami@gmail.com", "From Name");
            MailAddress toAddress = new MailAddress("abbaouiamine.r@gmail.com", "To Name");
            const string fromPassword = "aminoss12ronomicro";
            const string subject = "Subject";
            const string body = "Body";
            // SMTP Configuration
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(fromAddress.Address, fromPassword);
            // MAIL MESSAGE CONFIGURATION
            MailMessage message = new MailMessage(fromAddress, toAddress);
            message.Subject = subject;
            message.Body = body;
            // SEND EMAIL
            smtp.Send(message);
        }

        private void b4_Click(object sender, EventArgs e)
        {
            _06Aide a = new _06Aide();
            a.Show();
        }

        private void b3_Click(object sender, EventArgs e)
        {
            try
            {
                var adobePath = Registry.GetValue(@"HKEY_CLASSES_ROOT\Software\Adobe\Acrobat\Exe", string.Empty, string.Empty);
                if (adobePath == null)
                {
                    if (MessageBox.Show(
        " acceptez vous l’installation de Adobe Acrobat Reader ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question
    ) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("https://get.adobe.com/fr/reader");
                    }
                    
                  
                }
                else
                {
                    Services.page = 1;
                    _07Remise r = new _07Remise();
                    r.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_3(object sender, EventArgs e)
        {
           
        }

     

   

     
    }
}
