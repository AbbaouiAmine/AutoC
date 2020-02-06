using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace autoc
{
    public partial class _03Consultation : Form
    {
        string Table1 = "Tarif";
        string Table2 = "Accessoire";
        string typeV = "DACIA";
        public static string remiselocal="";
        public _03Consultation()
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
        //int originalExStyle = -1;
        //bool enableFormLevelDoubleBuffering = true;

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        if (originalExStyle == -1)
        //            originalExStyle = base.CreateParams.ExStyle;

        //        CreateParams cp = base.CreateParams;
        //        if (enableFormLevelDoubleBuffering)
        //            cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
        //        else
        //            cp.ExStyle = originalExStyle;

        //        return cp;
        //    }
        //}

        public void Ini(EventArgs e)
        {
            FicheInfo.vider();
            textBox6.Text = FicheInfo.prixttc;
            comboBox3.Text = FicheInfo.accessoireprix;
            textBox7.Text = FicheInfo.remisecalcule;
            textBox10.Text = FicheInfo.exoneration;
            textBox8.Text = FicheInfo.subvention;
            textBox11.Text = FicheInfo.imm;
            textBox5.Text = FicheInfo.ww;
            textBox9.Text = FicheInfo.montantttc;
            textBox17.Text = FicheInfo.remisecalcule;
            labelAccPrix.Text = FicheInfo.accessoireprix;
            textBoxww18.Text = "300";
            textBox18.Text = FicheInfo.remisemontantLocal;
            numericUpDown1.Value = 1;
            checkBox2.Checked = false;
            
               
           
        }
        public void suppEvent()
        {
            this.textBox6.TextChanged -= new System.EventHandler(this.button1_Click);
            this.textBox7.TextChanged -= new System.EventHandler(this.button1_Click);
            this.textBox10.TextChanged -= new System.EventHandler(this.button1_Click);
            this.textBox8.TextChanged -= new System.EventHandler(this.button1_Click);
            this.textBox11.TextChanged -= new System.EventHandler(this.button1_Click);
            this.textBox5.TextChanged -= new System.EventHandler(this.button1_Click);

        }
        public void addEvent()
        {
            this.textBox6.TextChanged += new System.EventHandler(this.button1_Click);
            this.textBox7.TextChanged += new System.EventHandler(this.button1_Click);
            this.textBox10.TextChanged += new System.EventHandler(this.button1_Click);
            this.textBox8.TextChanged += new System.EventHandler(this.button1_Click);
            this.textBox11.TextChanged += new System.EventHandler(this.button1_Click);
            this.textBox5.TextChanged += new System.EventHandler(this.button1_Click);

        }
        public void selectAuto()
        {
            
            comboBox1.Text = "Veuillez sélectionner votre modèle";
            ((ListBox)checkedListBox1).DataSource = null;
            ((ListBox)checkedListBox1).Items.Clear();
            comboBox2.DataSource = null;
            comboBox2.Items.Clear();
            button2.Enabled = false;
            button4.Enabled = false;
            button7.Enabled = false;
            textBox9.Text = "0";
            labelmarge.Text = "0";
            
        }
        private void _03Consultation_Load(object sender, EventArgs e)
        {

            try
            {
                radioButton1.ForeColor = ColorTranslator.FromHtml("#757575");
                radioButton2.ForeColor = ColorTranslator.FromHtml("#757575");
                this.textBox7.MouseClick -= new System.Windows.Forms.MouseEventHandler(this.textBox7_MouseClick);
                this.textBox7.TextChanged -= new System.EventHandler(this.textBox7_TextChanged);
                this.textBox17.TextChanged -= new System.EventHandler(this.textBox17_TextChanged);
                this.textBox19.TextChanged -= new System.EventHandler(this.textBox19_TextChanged);
                this.textBox18.TextChanged -= new System.EventHandler(this.textBox18_TextChanged);
                if (radioButton1.Checked)
                    textBox19.Text = "6";
                else
                    textBox19.Text = "4";
                label10aa.ForeColor = ColorTranslator.FromHtml("#323c45");
                label11a.ForeColor = ColorTranslator.FromHtml("#4ebfed");
               // pictureBox2.BackColor = ColorTranslator.FromHtml("#fff");
                checkBox3.Checked = true;
                this.BackColor = ColorTranslator.FromHtml("#fff");
                labelnumligne.Text = "";
                suppEvent();
                FicheInfo.vider();
                Ini(e);
                //groupBox2.Enabled = false;
                //groupBox9.Enabled = false;
                //textBox17.Enabled = false;
                //comboBox2.Enabled = false;
                button1.BackColor = ColorTranslator.FromHtml("#4ebfed");
                button2.BackColor = ColorTranslator.FromHtml("#4ebfed");
                button3.BackColor = ColorTranslator.FromHtml("#4ebfed");
                button4.BackColor = ColorTranslator.FromHtml("#4ebfed");
                button5.BackColor = ColorTranslator.FromHtml("#4ebfed");
                button6.BackColor = ColorTranslator.FromHtml("#4ebfed");
                button8.BackColor = ColorTranslator.FromHtml("#4ebfed");
                button9.BackColor = ColorTranslator.FromHtml("#4ebfed");
                button7.BackColor = ColorTranslator.FromHtml("#4ebfed");
                button10.BackColor = ColorTranslator.FromHtml("#4ebfed");
                textBox8.Enabled = false;
                textBox10.Enabled = false;
                textBox16.Enabled = false;

                #region style code

                this.BackColor = ColorTranslator.FromHtml("#f8f8f8");


                groupBox1.BackColor = ColorTranslator.FromHtml("#f8f8f8");
                groupBox1.ForeColor = ColorTranslator.FromHtml("#5b6969");

                groupBox2.BackColor = ColorTranslator.FromHtml("#f8f8f8");
                groupBox2.ForeColor = ColorTranslator.FromHtml("#5b6969");

                groupBox3.BackColor = ColorTranslator.FromHtml("#f8f8f8");
                groupBox3.ForeColor = ColorTranslator.FromHtml("#5b6969");

                groupBox4.BackColor = ColorTranslator.FromHtml("#f8f8f8");
                groupBox4.ForeColor = ColorTranslator.FromHtml("#5b6969");

                groupBox5.BackColor = ColorTranslator.FromHtml("#f8f8f8");
                groupBox5.ForeColor = ColorTranslator.FromHtml("#5b6969");

                groupBox6.BackColor = ColorTranslator.FromHtml("#f8f8f8");
                groupBox6.ForeColor = ColorTranslator.FromHtml("#5b6969");

                groupBox7.BackColor = ColorTranslator.FromHtml("#f8f8f8");
                groupBox7.ForeColor = ColorTranslator.FromHtml("#5b6969");

                groupBox9.BackColor = ColorTranslator.FromHtml("#f8f8f8");
                groupBox9.ForeColor = ColorTranslator.FromHtml("#5b6969");

                groupBox1a.ForeColor = ColorTranslator.FromHtml("#5b6969");
                groupBox2a.ForeColor = ColorTranslator.FromHtml("#5b6969");

                tabPage1.BackColor = ColorTranslator.FromHtml("#f8f8f8");
                tabPage1.ForeColor = ColorTranslator.FromHtml("#5b6969");

                tabPage2.BackColor = ColorTranslator.FromHtml("#f8f8f8");
                tabPage2.ForeColor = ColorTranslator.FromHtml("#5b6969");
                label23.ForeColor = ColorTranslator.FromHtml("#757575");
                label12.ForeColor = ColorTranslator.FromHtml("#757575");
                label1a.ForeColor = ColorTranslator.FromHtml("#757575");
                label2a.ForeColor = ColorTranslator.FromHtml("#757575");
                label3a.ForeColor = ColorTranslator.FromHtml("#757575");
                label4a.ForeColor = ColorTranslator.FromHtml("#757575");
                label5a.ForeColor = ColorTranslator.FromHtml("#757575");
                label6a.ForeColor = ColorTranslator.FromHtml("#757575");
                label7a.ForeColor = ColorTranslator.FromHtml("#757575");
                label8a.ForeColor = ColorTranslator.FromHtml("#757575");
                label9a.ForeColor = ColorTranslator.FromHtml("#757575");
                label10a.ForeColor = ColorTranslator.FromHtml("#757575");
                label21.ForeColor = ColorTranslator.FromHtml("#757575");
                label2.ForeColor = ColorTranslator.FromHtml("#757575");
                label3.ForeColor = ColorTranslator.FromHtml("#757575");
                label4.ForeColor = ColorTranslator.FromHtml("#757575");
                label5.ForeColor = ColorTranslator.FromHtml("#757575");
                label6.ForeColor = ColorTranslator.FromHtml("#757575");
                label8.ForeColor = ColorTranslator.FromHtml("#757575");
                label9.ForeColor = ColorTranslator.FromHtml("#757575");
                label22.ForeColor = ColorTranslator.FromHtml("#757575");
                //label23.ForeColor = ColorTranslator.FromHtml("#757575");


                label1.ForeColor = ColorTranslator.FromHtml("#757575");
                label17.ForeColor = ColorTranslator.FromHtml("#757575");
                label18.ForeColor = ColorTranslator.FromHtml("#757575");
                label19.ForeColor = ColorTranslator.FromHtml("#757575");
                label20.ForeColor = ColorTranslator.FromHtml("#757575");

                label7.ForeColor = ColorTranslator.FromHtml("#757575");
                label10.ForeColor = ColorTranslator.FromHtml("#757575");

                label11.ForeColor = ColorTranslator.FromHtml("#757575");
                label13.ForeColor = ColorTranslator.FromHtml("#757575");
                label14.ForeColor = ColorTranslator.FromHtml("#757575");
                labelAccPrix.ForeColor = ColorTranslator.FromHtml("#757575");
                label15.ForeColor = ColorTranslator.FromHtml("#757575");
                label16.ForeColor = ColorTranslator.FromHtml("#757575");
                #endregion

                // groupBox8.Text = groupBox8.Text + " " + DateTime.Now.ToString("( dd/MM/yyyy )");

                #region //remplissage des categorie
                comboBox4.Items.Add("Particulier");
                comboBox4.Items.Add("Commerçant ou Société");
                comboBox4.Items.Add("Agence de location");
                comboBox4.Items.Add("Taxieur");
                comboBox4.Items.Add("Conventionné");
                #endregion

                #region//Remplissage des modele
                comboBox1.SelectedIndexChanged -= new EventHandler(comboBox1_SelectedIndexChanged);
                comboBox1.DataSource = Modele();
                comboBox1.DisplayMember = "modeleT";
                comboBox1.ValueMember = "modeleT";
                

                

                this.comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
                #endregion
                this.textBox19.TextChanged += new System.EventHandler(this.textBox19_TextChanged);
                this.textBox18.TextChanged += new System.EventHandler(this.textBox18_TextChanged);
                this.textBox17.TextChanged += new System.EventHandler(this.textBox17_TextChanged);
                this.textBox7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox7_MouseClick);
                this.textBox7.TextChanged += new System.EventHandler(this.textBox7_TextChanged);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        #region evenements des conrols
        private void _03Consultation_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Program.filepath != "")
            {
                Application.Exit();
            }
            else
            {
                this.Dispose();
                Services.m.Show();
                Services.quantiteTotal = 0;
                Services.remiseTotal = 0;
                Services.margeTotal = 0;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                groupBox7.Enabled = false;
                textBox13.Text = "";
                textBox14.Text = "";
                textBox15.Text = "";
            }
            else
            {
                groupBox7.Enabled = true;
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox8.Enabled = true;
            }
            else
            {
                textBox8.Enabled = false;
                textBox8.Text = "0";
            }
        }

        private void comboBox4_SelectionChangeCommitted(object sender, EventArgs e)
        {

            if (comboBox4.SelectedIndex == 0 || comboBox4.SelectedIndex == 4)
            {
                textBox16.Enabled = true;
            }
            else
            {

                textBox16.Enabled = false;
                textBox16.Text = "";
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (e != null)
            {
                Ini(e);
                checkBox4.Checked = false;
                suppEvent();
                comboBox3.SelectedIndexChanged -= new EventHandler(comboBox3_SelectedIndexChanged);
                textBox6.Text = "";
                textBox11.Text = "";
                textBox5.Text = "";

                comboBox2.SelectedIndexChanged -= new EventHandler(comboBox2_SelectedIndexChanged);
                comboBox2.DataSource = Serie(comboBox1.Text);
                comboBox2.DisplayMember = "serieT";
                comboBox2.SelectedIndexChanged += new EventHandler(comboBox2_SelectedIndexChanged);
                this.checkedListBox1.Size = new System.Drawing.Size(264, 50);
                this.button12.Image = global::autoc.Properties.Resources.arrow1;
                //checkedListBox1.HorizontalScrollbar = false;
                //==================================
                FicheInfo.accessoire = new List<string>();

                comboBox3.DataSource = Accessoire(comboBox1.Text);
                comboBox3.DisplayMember = "nomAc";
                comboBox3.ValueMember = "pclientTtcAc";
                //checkedListBox1 = new System.Windows.Forms.CheckedListBox();
                //this.checkedListBox1.CheckOnClick = true;
                //this.checkedListBox1.Cursor = System.Windows.Forms.Cursors.Default;
                //this.checkedListBox1.Font = new System.Drawing.Font("Open Sans", 11.25F);
                //this.checkedListBox1.FormattingEnabled = true;
                //this.checkedListBox1.HorizontalScrollbar = true;
                //this.checkedListBox1.Location = new System.Drawing.Point(24, 51);
                //this.checkedListBox1.Name = "checkedListBox1";
                //this.checkedListBox1.Size = new System.Drawing.Size(258, 50);
                //this.checkedListBox1.TabIndex = 31;
                //this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
                //this.checkedListBox1.Click += new System.EventHandler(this.checkedListBox1_Click);
                //this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
                //this.checkedListBox1.SelectedValueChanged += new System.EventHandler(this.checkedListBox1_SelectedValueChanged);
                // checkedListBox1.Refresh();
                ((ListBox)checkedListBox1).DataSource = Accessoire(comboBox1.Text);

                ((ListBox)checkedListBox1).DisplayMember = "nomAc";
                ((ListBox)checkedListBox1).ValueMember = "pclientTtcAc";
                //checkedListBox1.Refresh();


                foreach (int i in checkedListBox1.CheckedIndices)
                {
                    checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                }


                comboBox3.SelectedIndexChanged += new EventHandler(comboBox3_SelectedIndexChanged);
                comboBox2.Enabled = true;

                if (comboBox2.Items.Count > 0)
                {
                    comboBox2.SelectedIndex = 0;
                    comboBox2_SelectedIndexChanged(null, null);

                }
                if (((ListBox)checkedListBox1).Items.Count > 0)
                {
                    checkedListBox1.SetItemCheckState(0, CheckState.Checked);
                    checkedListBox1_SelectedValueChanged(null, null);
                }
                textBox18.Enabled = true;
                button2.Enabled = true;
                button4.Enabled = true;
                button7.Enabled = true;
            }
            else {
                IniPage();
            }
        }

        public void IniPage(){
            try
            {
                Ini(null);
                checkBox4.Checked = false;
                suppEvent();
                DataRow r = Info("", "");
                labeltva.Text = r["tauxT"].ToString();
                textBox6.Text = r["pclientTTC"].ToString();
                double s = double.Parse(r["fraisImmT"].ToString()) - 300;
                textBox11.Text = s.ToString(); ;
                double ww = double.Parse(r["fraisTrT"].ToString());
                textBox5.Text = ww.ToString();
                groupBox2.Enabled = true;
                groupBox9.Enabled = true;
                button1_Click(null, null);

                addEvent();
                checkedListBox1.Refresh();
                ((ListBox)checkedListBox1).DataSource = Accessoire("");

                ((ListBox)checkedListBox1).DisplayMember = "nomAc";
                ((ListBox)checkedListBox1).ValueMember = "pclientTtcAc";
                checkedListBox1.Refresh();
                foreach (int i in checkedListBox1.CheckedIndices)
                {
                    checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                }
                if (((ListBox)checkedListBox1).Items.Count > 0)
                {
                    checkedListBox1.SetItemCheckState(0, CheckState.Checked);
                    checkedListBox1_SelectedValueChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Ini(e);
                checkBox4.Checked = false;
                suppEvent();
                DataRow r = Info(comboBox1.Text, comboBox2.Text);
                if (r != null)
                {
                    labeltva.Text = r["tauxT"].ToString();
                    textBox6.Text = r["pclientTTC"].ToString();
                    double s = double.Parse(r["fraisImmT"].ToString()) - 300;
                    textBox11.Text = s.ToString(); ;
                    double ww = double.Parse(r["fraisTrT"].ToString());
                    textBox5.Text = ww.ToString();
                    groupBox2.Enabled = true;
                    groupBox9.Enabled = true;
                    button1_Click(null, null);

                    addEvent();
                    checkedListBox1.Refresh();
                    ((ListBox)checkedListBox1).DataSource = Accessoire(comboBox1.Text);

                    ((ListBox)checkedListBox1).DisplayMember = "nomAc";
                    ((ListBox)checkedListBox1).ValueMember = "pclientTtcAc";
                    checkedListBox1.Refresh();
                    foreach (int i in checkedListBox1.CheckedIndices)
                    {
                        checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                    }
                    if (((ListBox)checkedListBox1).Items.Count > 0)
                    {
                        checkedListBox1.SetItemCheckState(0, CheckState.Checked);
                        checkedListBox1_SelectedValueChanged(null, null);
                    }
                }
            }
                catch(IndexOutOfRangeException ex){
                
                
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion


        //Extraction des modeles
        public DataTable Modele()
        {

            string req = "select distinct modeleT from "+Table1;
            SqlCeCommand cmd = new SqlCeCommand(req, Services.con);
            DataSet ds = new DataSet();
            SqlCeDataAdapter da = new SqlCeDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }

        //Extraction des modeles pour une serie donne
        public DataTable Serie(String modele)
        {

            string req = "select  serieT from "+Table1+" where modeleT= @p1";
            SqlCeParameter p1 = new SqlCeParameter("@p1", modele);
            SqlCeCommand cmd = new SqlCeCommand(req, Services.con);
            cmd.Parameters.Add(p1);
            DataSet ds = new DataSet();
            SqlCeDataAdapter da = new SqlCeDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }
        //Extraction des accessoires pour un modele
        public DataTable Accessoire(String modele)
        {

            string req = "select nomAc,pclientTtcAc from  "+Table2+" where modeleAc=@p1";
            SqlCeParameter p1 = new SqlCeParameter("@p1", modele);
            SqlCeCommand cmd = new SqlCeCommand(req, Services.con);
            cmd.Parameters.Add(p1);
            DataSet ds = new DataSet();
            SqlCeDataAdapter da = new SqlCeDataAdapter(cmd);
            da.Fill(ds);
           // MessageBox.Show(ds.Tables[0].Rows.Count.ToString());
            return ds.Tables[0];
            
        }

        //Extraction des info pour un modele et une serie
        public DataRow Info(String modele, String serie)
        {

            string req = "select pclientTTC,fraisImmT,fraisTrT,tauxT from "+Table1+" where modeleT=@p1 and serieT=@p2 ";
            SqlCeParameter p1 = new SqlCeParameter("@p1", modele);
            SqlCeParameter p2 = new SqlCeParameter("@p2", serie);
            SqlCeCommand cmd = new SqlCeCommand(req, Services.con);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            DataSet ds = new DataSet();
            SqlCeDataAdapter da = new SqlCeDataAdapter(cmd);
            da.Fill(ds);
            
                return ds.Tables[0].Rows[0];
            
        }

        public string vide0(string chaine)
        {
            if (chaine == "")
                return "0";

            return chaine;
        }

        public string vide0null(object chaine)
        {
            if (chaine == null)
                return "0";

            return (string)chaine;
        }
        public string set(string value)
        {
            if (value != "")
                return double.Parse(value).ToString("n", new CultureInfo("nb-NO"));
            else
                return value;
        }
        public void Calculer(bool cal)
        {

            
                #region Informations personnels
                FicheInfo.client = textBox1.Text;
                #region Categorie
                FicheInfo.particulier = "";
                FicheInfo.commercant = "";
                FicheInfo.agence = "";
                FicheInfo.taxieur = "";
                FicheInfo.conventionne = "";

                FicheInfo.remisesup = textBox17.Text;

                String categorie = comboBox4.Text;
                switch (categorie)
                {
                    case "Particulier": FicheInfo.particulier = textBox16.Text; break;
                    case "Commerçant ou Société": FicheInfo.commercant = "X"; break;
                    case "Agence de location": FicheInfo.agence = "X"; break;
                    case "Taxieur": FicheInfo.taxieur = "X"; break;
                    case "Conventionné": FicheInfo.conventionne = textBox16.Text; break;

                }

                #endregion
                FicheInfo.ville = textBox2.Text;
                FicheInfo.gsm = textBox3.Text;
                FicheInfo.commercial = textBox4.Text;
                #endregion

                #region Information de la vihecule
                FicheInfo.modele = comboBox1.Text;
                FicheInfo.serie = comboBox2.Text;
                #endregion

                #region Accessoire

                //FicheInfo.accessoire = comboBox3.Text;
                //text
                // FicheInfo.accessoireprix =comboBox3.SelectedValue.ToString();
                FicheInfo.accessoireprix = labelAccPrix.Text;
                #endregion

                #region Prix
                FicheInfo.prixttc = textBox6.Text;
                FicheInfo.imm = textBox11.Text;
                FicheInfo.ww = textBox5.Text;
                FicheInfo.ww1 = textBoxww18.Text;
                //Remise
                if (checkBox1.Checked)
                {
                    double prixTTC = double.Parse(vide0(textBox6.Text));
                    double pourcentage = double.Parse(vide0(textBox7.Text)) + double.Parse(vide0(textBox18.Text));
                    double remiseCalcule = prixTTC * ((double)pourcentage / 100);
                    FicheInfo.remisecalcule = remiseCalcule.ToString("#.##");
                    FicheInfo.remisepourcentage = pourcentage.ToString();
                    FicheInfo.remisepourcentageLocal = double.Parse(vide0(textBox18.Text)).ToString();
                    FicheInfo.remisemontant = "0";
                    FicheInfo.remisemontantLocal = "0";
                    double remiseCalculeLocal = prixTTC * (double.Parse(vide0(textBox18.Text)) / 100);
                    FicheInfo.remisecalculeLocal = remiseCalculeLocal.ToString();
                    if (cal)
                    {
                        if (remiseCalculeLocal != 0)
                            textBox12.Text = "Remise Local : " + set(remiseCalculeLocal.ToString()) + " DH ";
                        else
                            textBox12.Text = ""; 
                    }

                    //calcul marge 
                    double pourcentagemarge = double.Parse(vide0(textBox19.Text));
                    double remiseL = double.Parse(vide0(FicheInfo.remisecalculeLocal));
                    double tva = double.Parse(vide0(labeltva.Text));
                    double accP = double.Parse(vide0(labelAccPrix.Text));
                    //double remS = double.Parse(vide0(textBox17.Text));
                    double marge = ((prixTTC+accP) * (pourcentagemarge / 100) - remiseL) / (1 + (tva / 100));
                    
                    labelmarge.Text = (marge * double.Parse(numericUpDown1.Value.ToString())).ToString("#.##");
                    FicheInfo.marge = labelmarge.Text;

                }
                else
                {
                    FicheInfo.remisepourcentage = "";
                    FicheInfo.remisepourcentageLocal = "";
                    double m = double.Parse(vide0(textBox7.Text)) + double.Parse(vide0(textBox18.Text));
                    FicheInfo.remisemontant = m.ToString();
                    FicheInfo.remisemontantLocal = vide0(textBox18.Text);
                    FicheInfo.remisecalcule = "0";
                    FicheInfo.remisecalculeLocal = "0";
                    if (cal)
                    {
                        if (FicheInfo.remisemontantLocal != "0")
                            textBox12.Text = "Remise Local: " + set(FicheInfo.remisemontantLocal) + " DH ";
                        else
                            textBox12.Text = ""; 
                    }

                    //calcul marge 
                    double prixTTC = double.Parse(vide0(textBox6.Text));
                    double pourcentagemarge = double.Parse(vide0(textBox19.Text));
                    double remiseL = double.Parse(vide0(FicheInfo.remisemontantLocal));
                    double tva = double.Parse(vide0(labeltva.Text));
                    double accP = double.Parse(vide0(labelAccPrix.Text));
                    //double remS = double.Parse(vide0(textBox17.Text));
                    double marge = ((prixTTC+accP) * (pourcentagemarge / 100) - remiseL) / (1 + (tva / 100));
                    double margeSansLocal = (((prixTTC + accP) * (pourcentagemarge / 100)) / (1 + (tva / 100)))/2;
                    toolTip1.SetToolTip(label22, margeSansLocal.ToString("#.##")+" Dh");
                    
                    labelmarge.Text = (marge * double.Parse(numericUpDown1.Value.ToString())).ToString("#.##");
                    FicheInfo.marge = labelmarge.Text;
                }

                //eXONERATION
                if (checkBox4.Checked)
                {
                    FicheInfo.exoneration = textBox10.Text;
                }
                else
                {
                    FicheInfo.exoneration = "0";
                }

                //Subvention
                if (checkBox2.Checked)
                {
                    FicheInfo.subvention = textBox8.Text;
                }
                else
                {
                    FicheInfo.subvention = "0";
                }
                #endregion

                #region Mode de paiement
                if (checkBox3.Checked)
                {
                    FicheInfo.aucomptant = "X";
                    FicheInfo.organisme = "";
                    FicheInfo.avance = "";
                    FicheInfo.mensualite = "";
                }
                else
                {
                    FicheInfo.aucomptant = "";
                    FicheInfo.organisme = textBox13.Text;
                    FicheInfo.avance = textBox14.Text;
                    FicheInfo.mensualite = textBox15.Text;
                }
                #endregion

                #region Cacul Montant
                //Calcul
                /*=========================Remise cas*/
                double remise = 0;
                if (checkBox1.Checked)
                    remise = double.Parse(vide0(FicheInfo.remisecalcule));
                else
                    remise = double.Parse(vide0(FicheInfo.remisemontant));

                /*=========================Subvention cas*/
                double sub = 0;
                if (checkBox2.Checked)
                    sub = double.Parse(vide0(FicheInfo.subvention));


                /*=========================Exoneration cas*/
                double exo = 0;
                if (checkBox4.Checked)
                    exo = double.Parse(vide0(textBox10.Text));

                double prixTTc = double.Parse(vide0(FicheInfo.prixttc));
                double acc = double.Parse(vide0(FicheInfo.accessoireprix));
                double imm = double.Parse(vide0(FicheInfo.imm));
                double ww = double.Parse(vide0(FicheInfo.ww)) + double.Parse(vide0(FicheInfo.ww1));
                double montant = prixTTc - remise + acc - sub - exo + imm + ww;

                if (exo != 0)
                {

                    textBox9.Text = montant.ToString("#.##");

                    FicheInfo.montantttc = "";
                    FicheInfo.montantexoneration = textBox9.Text;
                }
                else
                {

                    textBox9.Text = montant.ToString("#.##");
                    FicheInfo.montantttc = textBox9.Text;
                    FicheInfo.montantexoneration = "";
                    FicheInfo.quantite = numericUpDown1.Value.ToString();
                }

                FicheInfo.observation = textBox12.Text;
                #endregion

                #region Calcul Montan - remise
                string n = "";
                string n1 = "";
                if (textBox17.Text == "")
                    n1 = "0";
                else
                    n1 = textBox17.Text;

                if (FicheInfo.montantttc != "")
                {
                    n = FicheInfo.montantttc;
                }
                else
                {
                    n = FicheInfo.montantexoneration;
                }

                double mon = double.Parse(n);
                double mon1 = double.Parse(n1);
                textBox9.Text = (mon - mon1).ToString("#.##");
                if (FicheInfo.montantttc != "")
                {
                    FicheInfo.montantttc = textBox9.Text;
                }
                else
                {
                    FicheInfo.montantexoneration = textBox9.Text;
                }
                #endregion 
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                Calculer(true);
                //MessageBox.Show(FicheInfo.remisemontant);
                //string a = textBox17.Text;
                //textBox17.Text = "0";
                //textBox17.Text = a;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox4.Checked)
                {
                    textBox10.Enabled = true;
                    label7.Text = "Montant exonéré";
                    double ex = ((double.Parse(vide0(textBox6.Text)) + double.Parse(vide0(labelAccPrix.Text))) * (double.Parse(vide0(labeltva.Text)) / 100)) / (1 + (double.Parse(vide0(labeltva.Text)) / 100));
                    textBox10.Text = ex.ToString("#.##");
                }
                else
                {
                    textBox10.Text = "0";
                    textBox10.Enabled = false;
                    label7.Text = "Montant TTC";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string setValue(string value)
        {
            if (value != "")
                return double.Parse(value).ToString("n", new CultureInfo("nb-NO"));

            return value;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //if (textBox17.Text != "")
                //    FicheInfo.observation = "( Remise supplémentaire : " + setValue(textBox17.Text) + " DH - Net à payer : " + setValue(textBox9.Text) + " DH ) - " + textBox12.Text;
                //else
                //{
                //    FicheInfo.observation = "( Net à payer : " + setValue(textBox9.Text) + "DH ) - " + textBox12.Text;
                //}

                Calculer(false);
                choix();

                _04Fiche f = new _04Fiche();
                f.Show();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (!checkBox5.Checked)
                {
                    double s = double.Parse(labelAccPrix.Text) + double.Parse(comboBox3.SelectedValue.ToString());
                    if (s > 0)
                        labelAccPrix.Text = s.ToString();
                    else
                        labelAccPrix.Text = "0";
                }
                else
                {
                    double s = double.Parse(labelAccPrix.Text) - double.Parse(comboBox3.SelectedValue.ToString());
                    if (s > 0)
                        labelAccPrix.Text = s.ToString();
                    else
                        labelAccPrix.Text = "0";
                }
                labelAccPrix.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label20_Click(object sender, EventArgs e)
        {
            if (labelmarge.Visible == true)
            {
                labelmarge.Visible = false;
                textBox19.Visible = false;
            }
            else
            {
                labelmarge.Visible = true;
                textBox19.Visible = true;
            }
        }


        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Calculer(false);
                string n = "";
                string n1 = "";
                if (textBox17.Text == "")
                    n1 = "0";
                else
                    n1 = textBox17.Text;

                if (FicheInfo.montantttc != "")
                {
                    n = FicheInfo.montantttc;
                }
                else
                {
                    n = FicheInfo.montantexoneration;
                }

                double mon = double.Parse(n);
                double mon1 = double.Parse(n1);
                double mon1Ht = mon1 / (1 + (double.Parse(vide0(labeltva.Text)) / 100));
                //textBox9.Text = (mon - mon1).ToString();
                labelmarge.Text = ((double.Parse(vide0(labelmarge.Text))-mon1Ht)*double.Parse(numericUpDown1.Value.ToString())).ToString("#.##");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox9.Text != "")
                {
                    textBox17.Enabled = true;
                }
                else
                {
                    textBox17.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                #region Informations personnels
                FicheInfo.client = textBox1.Text;
                FicheInfo.ville = textBox2.Text;
                // FicheInfo.gsm = textBox3.Text;
                #endregion


                FicheInfo.net = double.Parse(textBox9.Text).ToString("0.00");

            }
            catch (Exception ex)
            {

            }
            _05Facture f = new _05Facture();
            f.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string chaine = "";


                MessageBox.Show(chaine);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public double SommeAcc()
        {
            return 0;
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (checkBox5.Text == "+")
                    checkBox5.Text = "-";
                else
                    checkBox5.Text = "+";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                Services.margeTotal += double.Parse(FicheInfo.marge);
                toolTip2.SetToolTip(label23, Services.margeTotal.ToString("#.##") + " Dh");
                //Remise
               double prixHt = 0;
                if (checkBox1.Checked)
                {
                    double prixTTC = double.Parse(vide0(textBox6.Text));
                    double pourcentage = double.Parse(vide0(FicheInfo.remisepourcentage));
                    double remiseCalcule = prixTTC * ((double)pourcentage / 100);
                    Services.remiseTotal += remiseCalcule;
                   // prixHt = double.Parse(textBox6.Text) - remiseCalcule;
                      prixHt = double.Parse(textBox6.Text);
                }
                else
                {
                    
                    Services.remiseTotal += double.Parse(FicheInfo.remisemontant);
                    //prixHt = double.Parse(textBox6.Text) - double.Parse(FicheInfo.remisemontant);
                    prixHt = double.Parse(textBox6.Text);
                }
                
                double tva = double.Parse(labeltva.Text);
                double tvaAcc = double.Parse("20");
                double prixACC = double.Parse(labelAccPrix.Text);//+ prixHt;
                prixACC = prixACC / (1 + (tvaAcc / 100));
                prixHt = prixHt / (1 + (tva / 100));
                if (dataGridView1.Rows.Count > 1)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
                }

                double montant = prixHt * double.Parse(numericUpDown1.Value.ToString());
                double montantAcc = prixACC * double.Parse(numericUpDown1.Value.ToString());
                string acc = "";
                for (int i = 0; i < FicheInfo.accessoire.Count; i++)
                {
                    if (i == 0)
                        acc += FicheInfo.accessoire[0].ToString();
                    else
                    {
                        if (i == FicheInfo.accessoire.Count - 1)
                        {
                            acc += " / " + FicheInfo.accessoire[i].ToString();
                        }
                        else
                        {
                            acc += " / " + FicheInfo.accessoire[i].ToString()+" / ";
                        }
                    }
                }



                if (acc != "")
                {
                    dataGridView1.Rows.Add(comboBox1.Text + " " + comboBox2.Text, numericUpDown1.Value.ToString(), prixHt.ToString("#.##"), labeltva.Text, montant.ToString("#.##"));
                    for (int i = 0; i < FicheInfo.accessoire.Count; i++)
                    {
                        double pUAcc = double.Parse(FicheInfo.accessoireP[i].ToString()) / (1 + (tvaAcc / 100));
                        double m = pUAcc * int.Parse(numericUpDown1.Value.ToString());
                        dataGridView1.Rows.Add(FicheInfo.accessoire[i].ToString(), numericUpDown1.Value.ToString(), pUAcc.ToString("#.##"), "20", m.ToString("#.##"));
                    }
                    
                }
                else
                {
                    dataGridView1.Rows.Add(comboBox1.Text + " " + comboBox2.Text, numericUpDown1.Value.ToString(), prixHt.ToString("#.##"), labeltva.Text, montant);
                }

                Services.remiseTotal += double.Parse(vide0(textBox17.Text));
                Services.quantiteTotal += int.Parse(numericUpDown1.Value.ToString());
                double ww = (double.Parse(textBox5.Text) / 1.2);
                dataGridView1.Rows.Add("FRAIS DE MISE EN ROUTE", Services.quantiteTotal.ToString(), ww.ToString(), "20", (double.Parse(Services.quantiteTotal.ToString())*ww).ToString("#.##"));
                textBox20.Text = vide0(Services.remiseTotal.ToString("#.##"));
                //selectAuto();
                //IniPage();
               
                tabControl1.SelectedTab = tabPage2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCeCommand cmd1 = new SqlCeCommand("delete from Facture", Services.con);
                Services.con.Open();
                cmd1.ExecuteNonQuery();
                Services.con.Close();

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    SqlCeCommand cmd = new SqlCeCommand("insert into Facture values(@a1,@a2,@a3,@a4,@a5)", Services.con);
                    SqlCeParameter p1 = new SqlCeParameter("@a1", dataGridView1.Rows[i].Cells[0].Value.ToString());
                    SqlCeParameter p2 = new SqlCeParameter("@a2", int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()));
                    SqlCeParameter p3 = new SqlCeParameter("@a3", double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()));
                    SqlCeParameter p4 = new SqlCeParameter("@a4", double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()));
                    SqlCeParameter p5 = new SqlCeParameter("@a5", double.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()));
                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                    cmd.Parameters.Add(p3);
                    cmd.Parameters.Add(p4);
                    cmd.Parameters.Add(p5);
                    Services.con.Open();
                    cmd.ExecuteNonQuery();
                    Services.con.Close();
                }

                //SqlCeCommand cmd1 = new SqlCeCommand("select * from Facture", Services.con);

                //Services.con.Open();
                //SqlCeDataReader dr = cmd1.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(dr);
                //dr.Close();
                //Services.con.Close();
                //dataGridView1.Rows.Clear();
                //dataGridView1.DataSource = dt;
                Cursor.Current = Cursors.WaitCursor;
                #region Informations personnels
                FicheInfo.client = textBox1.Text;
                FicheInfo.ville = textBox2.Text;
                // FicheInfo.gsm = textBox3.Text;
                #endregion

                FicheInfo.net = double.Parse(textBox9.Text).ToString("0.00");

                FactureInfo.totalht = textBoxr0.Text;
                FactureInfo.tva7 = textBoxr1.Text;
                FactureInfo.tva20 = textBoxr2.Text;
                FactureInfo.prixttc = textBoxr3.Text;
                FactureInfo.ww = textBoxr4.Text;
                FactureInfo.net = textBoxr5.Text;
                FactureInfo.remiseTotal = textBox20.Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




            _05Facture f = new _05Facture();
            f.Show();
        }



        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                tabPage2.Text = "Facture Proforma (" + dataGridView1.Rows.Count + ")";
                // this.Controls.tabamine.Refresh();
                tabControl1.Refresh();
                SommeCal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabPage2_MouseHover(object sender, EventArgs e)
        {

        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int index = e.RowIndex;

                //groupBox1.Enabled = true;
                //groupBox4.Enabled = true;
                textBox0c.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
                textBox1c.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
                textBox2c.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
                textBox3c.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
                labelnumligne.Text = index.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }
        public void vider()
        {
            labelnumligne.Text = "";
            textBox0c.Text = "";
            textBox1c.Text = "";
            textBox2c.Text = "";
            textBox3c.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (labelnumligne.Text != "")
                {
                    int a = int.Parse(labelnumligne.Text);
                    dataGridView1.Rows[a].Cells[0].Value = textBox0c.Text;
                    dataGridView1.Rows[a].Cells[1].Value = textBox1c.Text;
                    dataGridView1.Rows[a].Cells[2].Value = textBox2c.Text;
                    dataGridView1.Rows[a].Cells[3].Value = textBox3c.Text;
                    dataGridView1.Rows[a].Cells[4].Value = (double.Parse(textBox1c.Text) * double.Parse(textBox2c.Text)).ToString();
                    MessageBox.Show("L'élément sélectionné a été bien modifié.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vider();
                    SommeCal();
                }
                else
                {
                    MessageBox.Show("Aucun élément n'a été sélectionné", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SommeCal()
        {
            double totalht = 0;
            double tva7 = 0;
            double tva20 = 0;
            double prixttc = 0;
            double ww = 0;
            double net = 0;
            double remiseTotal = 0;



            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                totalht += ((double.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString())));
                if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "7")
                {
                    tva7 += double.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()) * (((double)7) / 100);

                }

                if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "20")
                {
                    tva20 += double.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()) * (((double)20) / 100);

                }
            }
            prixttc = totalht + tva20 + tva7;
            if (dataGridView1.Rows.Count > 0)
                ww =  double.Parse(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].Value.ToString());
            else
                ww = 0;
            remiseTotal=double.Parse(vide0(textBox20.Text));
            net = prixttc + ww - remiseTotal;
            textBoxr0.Text = totalht.ToString();
            textBoxr1.Text = tva7.ToString();
            textBoxr2.Text = tva20.ToString();
            textBoxr3.Text = prixttc.ToString();
            textBoxr4.Text = ww.ToString();
            textBoxr5.Text = net.ToString();

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        public void loadFile(string path) {
            Stream f = new FileStream(path,FileMode.Open,FileAccess.Read);
            ficheO ficheo = null;
            BinaryFormatter formatter = new BinaryFormatter();
            //Stream flux = new FileStream("chemin", FileMode.CreateNew, FileAccess.Write);
            ficheo = (ficheO)formatter.Deserialize(f);
            // flux.Close();
            f.Close();
            if (ficheo != null)
            {
                foreach (int i in checkedListBox1.CheckedIndices)
                {
                    checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                }
                importAff(ficheo);
                MessageBox.Show("Veuillez vérifier les accessoires", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {

                Calculer(true);
                choix();
                ficheO fiche = new ficheO();
                fiche.typeV = FicheInfo.typeV;

                #region Information personnel
                fiche.commercial = FicheInfo.commercial;
                fiche.client = FicheInfo.client;
                fiche.gsm = FicheInfo.gsm;
                fiche.ville = FicheInfo.ville;

                fiche.particulier = FicheInfo.particulier;
                fiche.commercant = FicheInfo.commercant;
                fiche.agence = FicheInfo.agence;
                fiche.taxieur = FicheInfo.taxieur;
                fiche.conventionne = FicheInfo.conventionne;

                #endregion

                #region Info Vihecule
                fiche.modele = FicheInfo.modele;
                fiche.serie = FicheInfo.serie;
                #endregion

                #region Mode paiement
                fiche.aucomptant = FicheInfo.aucomptant;
                fiche.organisme = FicheInfo.organisme;
                fiche.avance = FicheInfo.avance;
                fiche.mensualite = FicheInfo.mensualite;
                #endregion

                #region accessoires

                #endregion

                #region Prix
                
                fiche.accessoire = FicheInfo.accessoire;
               
                fiche.accessoireprix = FicheInfo.accessoireprix;

                fiche.prixttc = FicheInfo.prixttc;

                fiche.remisemontant = FicheInfo.remisemontant;
                fiche.remisepourcentage = FicheInfo.remisepourcentage;

                fiche.remisemontantLocal = FicheInfo.remisemontantLocal;
                fiche.remisepourcentageLocal = FicheInfo.remisepourcentageLocal;

                fiche.exoneration = FicheInfo.exoneration;

                fiche.subvention = FicheInfo.subvention;

                fiche.imm = FicheInfo.imm;
                fiche.ww = FicheInfo.ww;
                #endregion

                #region Net a payer
                fiche.montantttc = FicheInfo.montantttc;
                fiche.montantexoneration = FicheInfo.montantexoneration;

                fiche.remisesup = FicheInfo.remisesup;
                fiche.remisecalcule = FicheInfo.remisecalcule;
                fiche.remisecalculeLocal = FicheInfo.remisecalculeLocal;


                fiche.observation = FicheInfo.observation;

                fiche.net = FicheInfo.net;

                fiche.quantite = FicheInfo.quantite;

                #endregion


                fiche.quantiteTotal = Services.quantiteTotal.ToString();
                fiche.remiseTotal = Services.remiseTotal.ToString("#.##");
                //fACTURE 
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    factureO fact = new factureO();
                    fact.designation = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    fact.qte = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    fact.pu = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    fact.txtva = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    fact.montant = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    fiche.factures.Add(fact);

                }


                Stream f;
                saveFileDialog1.Filter = "AutoC file (*.autoc)|*.autoc";
                saveFileDialog1.RestoreDirectory = true;
                if(fiche.commercial!="")
                saveFileDialog1.FileName = fiche.client+" Le "+DateTime.Now.Day.ToString()+"-"+DateTime.Now.Month.ToString()+"-"+DateTime.Now.Year.ToString()+" Par  "+fiche.commercial;
                else
                    saveFileDialog1.FileName = fiche.client + " Le " + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
                
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((f = saveFileDialog1.OpenFile()) != null)
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        //Stream flux = new FileStream("chemin", FileMode.CreateNew, FileAccess.Write);
                        formatter.Serialize(f, fiche);
                        // flux.Close();
                        f.Close();
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                Stream f;
                ficheO ficheo = null;
                openFileDialog1.Filter = "AutoC file (*.autoc)|*.autoc";
                openFileDialog1.RestoreDirectory = true;
                openFileDialog1.FileName = "";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((f = openFileDialog1.OpenFile()) != null)
                    {

                        BinaryFormatter formatter = new BinaryFormatter();
                        //Stream flux = new FileStream("chemin", FileMode.CreateNew, FileAccess.Write);
                        ficheo = (ficheO)formatter.Deserialize(f);
                        // flux.Close();
                        f.Close();
                    }
                }

                if (ficheo != null)
                {
                    foreach (int i in checkedListBox1.CheckedIndices)
                    {
                        checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                    }
                    importAff(ficheo);



                    MessageBox.Show("Veuillez vérifier les accessoires", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void importAff(ficheO f)
        {

            if (f.typeV == "DACIA")
                radioButton2.Checked = true;
            else
                radioButton1.Checked = true;


            #region Informations personnels
            textBox1.Text = f.client;



            String categorie = "";
            string infoC = "";
            //particulier
            if (f.particulier != "")
            {
                categorie = "Particulier";
                infoC = f.particulier;

            }
            //commercant
            if (f.commercant != "")
            {
                categorie = "Commerçant ou Société";
                infoC = f.particulier;
            }
            if (f.agence != "")
            {
                categorie = "Agence de location";
            }
            if (f.taxieur != "")
            {
                categorie = "Taxieur";
            }
            if (f.conventionne != "")
            {
                categorie = "Conventionné";
                infoC = f.conventionne;
            }


            textBox16.Text = infoC;
            comboBox4.Text = categorie;



            textBox2.Text = f.ville;
            textBox3.Text = f.gsm;
            textBox4.Text = f.commercial;
            #endregion

            #region Information de la vihecule
            comboBox1.Text = f.modele;
            comboBox2.Text = f.serie;
            #endregion

            #region Accessoire
            checkedListBox1.Refresh();
            ((ListBox)checkedListBox1).DataSource = Accessoire(comboBox1.Text);

            ((ListBox)checkedListBox1).DisplayMember = "nomAc";
            ((ListBox)checkedListBox1).ValueMember = "pclientTtcAc";
            checkedListBox1.Refresh();
            //comboBox3.Text = f.accessoire;
            for (int i = 0; i <f.accessoire.Count; i++)
            {
                for (int j = 0; j < checkedListBox1.Items.Count; j++)
                {
                    DataRow r = ((DataRowView)this.checkedListBox1.Items[j]).Row;
                    string val = (r[this.checkedListBox1.ValueMember]).ToString();
                    string dis = (r[this.checkedListBox1.DisplayMember]).ToString();
                    
                    string a= f.accessoire[i].ToString() ;
                    if (a == dis)
                    {
                        checkedListBox1.SetItemCheckState(j, CheckState.Checked);
                        checkedListBox1_SelectedValueChanged(null,null);
                    }
                }
                
            }

            //text
            // f.accessoireprix =comboBox3.SelectedValue.ToString();
            labelAccPrix.Text = f.accessoireprix;
            #endregion

            #region Prix
            textBox6.Text = f.prixttc;
            textBox11.Text = f.imm;
            textBox5.Text = f.ww;
            //Remise
            //if (checkBox1.Checked)
            //{
            //    double prixTTC = double.Parse(vide0(textBox6.Text));
            //    int pourcentage = int.Parse(vide0(textBox7.Text));
            //    double remiseCalcule = prixTTC * ((double)pourcentage / 100);
            //    f.remisecalcule = remiseCalcule.ToString("#.##");
            //    f.remisepourcentage = "(" + pourcentage.ToString() + " %)";
            //    f.remisemontant = "";
            //}
            //else
            //{
            //    f.remisepourcentage = "( %)";
            //    f.remisemontant = textBox7.Text;
            //    f.remisecalcule = "";
            //}
            if (f.remisepourcentage == "")
            {
                checkBox1.Checked = false;
                double r = double.Parse(vide0(f.remisemontant)) - double.Parse(vide0(f.remisemontantLocal));
                textBox7.Text = r.ToString();
                this.textBox18.TextChanged -= new System.EventHandler(this.textBox18_TextChanged);
                textBox18.Text = f.remisemontantLocal;
                this.textBox18.TextChanged += new System.EventHandler(this.textBox18_TextChanged);
                
            }
            else
            {
                checkBox1.Checked = true;
                double r = double.Parse(vide0(f.remisepourcentage)) - double.Parse(vide0(f.remisepourcentageLocal));
                
                textBox7.Text =r.ToString();
                this.textBox18.TextChanged -= new System.EventHandler(this.textBox18_TextChanged);
                textBox18.Text = f.remisepourcentageLocal;
                this.textBox18.TextChanged += new System.EventHandler(this.textBox18_TextChanged);
            }

            //eXONERATION

            textBox10.Text = f.exoneration;
            if (f.exoneration != "0")
            {
                checkBox4.Checked = true;
            }
            else
            {
                checkBox4.Checked = false;
            }


            //Subvention

            textBox8.Text = f.subvention;
            if (f.subvention != "0")
            {
                checkBox2.Checked = true;
            }
            else
            {
                checkBox2.Checked = false;
            }

            #endregion

            #region Mode de paiement
            if (f.aucomptant == "X")
            {
                checkBox3.Checked = true;
                textBox13.Text = "";
                textBox14.Text = "";
                textBox15.Text = "";
            }
            else
            {
                checkBox3.Checked = false;

                textBox13.Text = f.organisme;
                textBox14.Text = f.avance;
                textBox15.Text = f.mensualite;
            }
            #endregion


            #region Cacul Montant
            ////Calcul
            ///*=========================Remise cas*/
            //double remise = 0;
            //if (checkBox1.Checked)
            //    remise = double.Parse(vide0(f.remisecalcule));
            //else
            //    remise = double.Parse(vide0(f.remisemontant));

            ///*=========================Subvention cas*/
            //double sub = 0;
            //if (checkBox2.Checked)
            //    sub = double.Parse(vide0(f.subvention));


            ///*=========================Exoneration cas*/
            //double exo = 0;
            //if (checkBox4.Checked)
            //    exo = double.Parse(vide0(textBox10.Text));

            //double prixTTc = double.Parse(vide0(f.prixttc));
            //double acc = double.Parse(vide0(f.accessoireprix));
            //double imm = double.Parse(vide0(f.imm));
            //double ww = double.Parse(vide0(f.ww));
            //double montant = prixTTc - remise + acc - sub - exo + imm + ww;

            //if (exo != 0)
            //{

            //    textBox9.Text = montant.ToString();

            //    f.montantttc = "";
            //    f.montantexoneration = textBox9.Text;
            //}
            //else
            //{

            //    textBox9.Text = montant.ToString();
            //    f.montantttc = textBox9.Text;
            //    f.montantexoneration = "";
            //}
            if (f.montantttc != "")
            {
                textBox9.Text = f.montantttc;

            }
            else
            {
                textBox9.Text = f.montantexoneration;
            }

            textBox17.Text = f.remisesup;
            if (f.quantite != "")
                numericUpDown1.Value = int.Parse(f.quantite);
            else
                numericUpDown1.Value = 1;

            textBox12.Text = f.observation;
            #endregion

            //factures


            Services.quantiteTotal = int.Parse(f.quantiteTotal);
            Services.remiseTotal = double.Parse(vide0(f.remiseTotal));
            textBox20.Text = Services.remiseTotal.ToString("#.##");
            dataGridView1.Rows.Clear();
            for (int i = 0; i < f.factures.Count; i++)
            {
                dataGridView1.Rows.Add(
                    f.factures[i].designation,
                    f.factures[i].qte,
                    f.factures[i].pu,
                    f.factures[i].txtva,
                    f.factures[i].montant
                    );
            }


        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox16.Text != "")
                {

                    textBox16.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            try
            {
                Services.page = 2;
                _07Remise r = new _07Remise();
                r.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Voulez-vous vraiment vider la liste ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Services.quantiteTotal = 0;
                    Services.remiseTotal = 0;
                    Services.margeTotal = 0;
                    textBox20.Text="0";
                    dataGridView1.Rows.Clear();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                tabPage2.Text = "Facture Proforma (" + dataGridView1.Rows.Count + ")";
                // this.Controls.tabamine.Refresh();
                tabControl1.Refresh();
                SommeCal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dataGridView1.Rows[0].Cells[0].Value.ToString());
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 1)
                {

                    //int sommeQ = 0;
                    //for (int i = 0; i <= dataGridView1.Rows.Count - 2; i++)
                    //{

                    //    sommeQ += int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    //}
                    //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].Value = sommeQ;
                    //double montant = double.Parse(sommeQ.ToString()) * double.Parse(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value.ToString());
                    //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].Value = montant;
                    SommeCal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkedListBox1_MouseEnter(object sender, EventArgs e)
        {
            //this.checkedListBox1.Size = new System.Drawing.Size(278, 90);

        }

        private void checkedListBox1_MouseLeave(object sender, EventArgs e)
        {
            //this.checkedListBox1.Size = new System.Drawing.Size(278, 31);

        }

        private void checkedListBox1_MouseHover(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_Click(object sender, EventArgs e)
        {
            

        }
        //public void changeetatscroll(bool v){
        //    CheckedListBox c = this.checkedListBox1;
        //    c.HorizontalScrollbar = v;
        //    this.checkedListBox1 = c;
        //}
        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkedListBox1.Size.Height == 50)
                {
                    int size = (checkedListBox1.Items.Count / 2 + 1) * 50;
                    if (checkedListBox1.Items.Count == 0 || checkedListBox1.Items.Count == 1)
                    {
                        size = 50;
                        this.button12.Image = global::autoc.Properties.Resources.arrow1;
                        //checkedListBox1.HorizontalScrollbar = false;
                    }
                    else
                        // checkedListBox1.HorizontalScrollbar = true;
                        this.button12.Image = global::autoc.Properties.Resources.arrowup;
                    if (checkedListBox1.Items.Count > 15)
                        size = 15 * 50 / 2;

                    this.checkedListBox1.Size = new System.Drawing.Size(264, size);

                }
                else
                {
                    this.checkedListBox1.Size = new System.Drawing.Size(264, 50);
                    //checkedListBox1.HorizontalScrollbar = false;
                    this.button12.Image = global::autoc.Properties.Resources.arrow1;
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void checkedListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                checkBox4.Checked = false;
                double somme = 0;
                List<String> l = new List<string>();
                List<double> lp = new List<double>();
                for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                {
                    DataRow r = ((DataRowView)this.checkedListBox1.CheckedItems[i]).Row;
                    string val = (r[this.checkedListBox1.ValueMember]).ToString();
                    string dis = (r[this.checkedListBox1.DisplayMember]).ToString();
                    //MessageBox.Show(val);
                    somme += double.Parse(val);
                    lp.Add(double.Parse(val));
                    l.Add(dis);
                }
                FicheInfo.accessoire = l;
                FicheInfo.accessoireP = lp;
                labelAccPrix.Text = somme.ToString();
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox1a.Image = global::autoc.Properties.Resources.helpbtn71;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox1a.Image = global::autoc.Properties.Resources.helpbtn6;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            _06Aide a = new _06Aide();
            a.Show();
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

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (double.Parse(vide0(textBox7.Text)) > 0)
                {
                    if (!checkBox1.Checked)
                    {
                        string n = "";
                        string n1 = "";
                        if (textBox18.Text == "")
                        {
                            n1 = "0";
                        }
                        else
                            n1 = textBox18.Text;

                        if (FicheInfo.remisemontant == "")
                            n = "0";
                        else
                            n = FicheInfo.remisemontant;

                        double mon = double.Parse(n);
                        double mon1 = double.Parse(n1);
                        textBox7.Text = (mon - mon1).ToString();
                    }
                    else
                    {
                        string n = "";
                        string n1 = "";
                        if (textBox18.Text == "")
                        {
                            n1 = "0";
                        }
                        else
                            n1 = textBox18.Text;

                        if (FicheInfo.remisepourcentage == "")
                            n = "0";
                        else
                            n = FicheInfo.remisepourcentage;



                        double mon = double.Parse(n);
                        double mon1 = double.Parse(n1);
                        //if((mon-mon1)<0)
                        //    MessageBox.Show("La remise locale autorisé est dépassé", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox7.Text = (mon - mon1).ToString();
                    }
                }
                else
                {
                    textBox18.Text = "0";
                    
                   
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            //try
            //{

                if (double.Parse(vide0(textBox7.Text)) <= 0)
                {
                    textBox18.Text = "0";
                    if (double.Parse(vide0(textBox7.Text)) < 0)
                    { 
                    textBox7.Text="0";
                    }
                }
               

                Calculer(true);
                //MessageBox.Show(FicheInfo.remisemontant);
                //string a = textBox17.Text;
                //textBox17.Text = "0";
                //textBox17.Text = a;

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (double.Parse(vide0(textBox19.Text)) <= 0)
                {
                    if (radioButton1.Checked)
                        textBox19.Text = "6";
                    else
                        textBox19.Text = "4";
                }

                textBox18_TextChanged(null, null);
                textBox7_TextChanged(null, null);
            }
            catch (Exception ex)
            {
                if (radioButton1.Checked)
                    textBox19.Text = "6";
                else
                    textBox19.Text = "4";
                MessageBox.Show(ex.Message);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double margeM = double.Parse(vide0(labelmarge.Text)) / Services.quantite;
            labelmarge.Text = (margeM * double.Parse(numericUpDown1.Value.ToString())).ToString();
            Services.quantite = int.Parse(numericUpDown1.Value.ToString());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox7.Text = "0";
            textBox18.Text = "0";
        }

        private void textBox7_MouseClick(object sender, MouseEventArgs e)
        {
            textBox18.Text = "0";
        }
        public void choix()
        {
            if (radioButton2.Checked)
            {
                Table1 = "Tarif";
                Table2 = "Accessoire";
                typeV = "DACIA";
                FicheInfo.typeV = typeV;
            }
            else
            {
                Table1 = "TarifR";
                Table2 = "AccessoireR";
                typeV = "RENAULT";
                FicheInfo.typeV = typeV;
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            choix();
            _03Consultation_Load(null,null);
            
            comboBox1_SelectedIndexChanged(null, null);
            FicheInfo.vider();
            if(radioButton1.Checked)
            textBox19.Text = "6";
            else
                textBox19.Text = "4";

            _03Consultation_Load(null, null);
            selectAuto();
            textBox9.Text = "0";
            labelmarge.Text = "0";
            comboBox1.Text = "Veuillez sélectionner votre modèle";
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            _03Consultation_Load(null, null);
            selectAuto();
        }

       

        
    }
}
