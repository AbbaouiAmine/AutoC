using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace autoc
{
    public partial class _01Tarif : Form
    {
        string Table = "Tarif";
        public _01Tarif()
        {
            InitializeComponent();
        }

        //fliking form regle
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

        #region evenement systeme
        private void _01Tarif_Load(object sender, EventArgs e)
        {
            label10aa.ForeColor = ColorTranslator.FromHtml("#323c45");
            label11a.ForeColor = ColorTranslator.FromHtml("#4ebfed");
            radioButton1.ForeColor = ColorTranslator.FromHtml("#757575");
            radioButton2.ForeColor = ColorTranslator.FromHtml("#757575");
            groupBox3.BackColor = ColorTranslator.FromHtml("#f8f8f8");
            groupBox4.BackColor = ColorTranslator.FromHtml("#f8f8f8");
            groupBox1.BackColor = ColorTranslator.FromHtml("#f8f8f8");
            //groupBox4.Enabled = false;
            //groupBox1.Enabled = false;
            this.BackColor = ColorTranslator.FromHtml("#f8f8f8");
            dataGridView1.BackgroundColor = ColorTranslator.FromHtml("#f8f8f8");
            button1.BackColor = ColorTranslator.FromHtml("#4ebfed");
            button2.BackColor = ColorTranslator.FromHtml("#4ebfed");
            button3.BackColor = ColorTranslator.FromHtml("#4ebfed");
            button4.BackColor = ColorTranslator.FromHtml("#4ebfed");

            button6.BackColor = ColorTranslator.FromHtml("#4ebfed");
            button7.BackColor = ColorTranslator.FromHtml("#4ebfed");

            label1.ForeColor = ColorTranslator.FromHtml("#757575");
            label2.ForeColor = ColorTranslator.FromHtml("#757575");
            label3.ForeColor = ColorTranslator.FromHtml("#757575");
            label4.ForeColor = ColorTranslator.FromHtml("#757575");
            label5.ForeColor = ColorTranslator.FromHtml("#757575");
            label6.ForeColor = ColorTranslator.FromHtml("#757575");
            label7.ForeColor = ColorTranslator.FromHtml("#757575");
            label8.ForeColor = ColorTranslator.FromHtml("#757575");
            label9.ForeColor = ColorTranslator.FromHtml("#757575");
            actualiser();
        }
        public void loadFile(string path)
        {
            Stream f = new FileStream(path, FileMode.Open, FileAccess.Read); ;
            BinaryFormatter formatter = new BinaryFormatter();
            //Stream flux = new FileStream("chemin", FileMode.CreateNew, FileAccess.Write);
            dataGridView1.DataSource = (System.Data.DataTable)formatter.Deserialize(f);
            // flux.Close();
            f.Close();
            button2_Click(null, null);
        }

        private void _01Tarif_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Program.filepath != "")
            {
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                this.Dispose();
                Services.m.Show();
            }
        }
        //Clicks
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool exl = false;
                int etat = Services.Etat();
                if (etat == 1)
                    exl = (MessageBox.Show("Voulez vous faire l'importation en format Excel ?", "Format de l'importation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
                
                if (etat==1 && exl)
                {

                    openFileDialog1.Filter = "Excel Worbook (*.xlsx)|*.xlsx";
                    openFileDialog1.ReadOnlyChecked = true;
                    openFileDialog1.FileName = "";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {

                        String path = "";
                        path = openFileDialog1.FileName;

                        String chaine = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + "; Extended Properties='Excel 12.0 Xml;HDR=YES'";
                        OleDbConnection con = new OleDbConnection(chaine);

                        //get name of sheet1
                        con.Open();
                        System.Data.DataTable dbSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                        if (dbSchema == null || dbSchema.Rows.Count < 1)
                        {
                            throw new Exception("Error: Could not determine the name of the first worksheet.");
                        }
                        string firstSheetName = dbSchema.Rows[0]["TABLE_NAME"].ToString();
                        con.Close();
                        //===============================
                        OleDbCommand cmd = new OleDbCommand("select * from [" + firstSheetName + "] ", con);
                        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        string modele = "";
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (ds.Tables[0].Rows[i][0].ToString() != modele && ds.Tables[0].Rows[i][0].ToString() != "")
                            {
                                modele = ds.Tables[0].Rows[i][0].ToString();

                            }
                            else
                            {
                                ds.Tables[0].Rows[i][0] = modele;
                            }
                        }

                        dataGridView1.DataSource = ds.Tables[0];
                        config();
                        viderChamp();
                        trimGridView();
                    }
                }
                if(etat==2 || !exl)
                {
                    Stream f;
                    //ficheO ficheo = null;
                    openFileDialog1.Filter = "Tarif file (*.tarif)|*.tarif";
                    openFileDialog1.RestoreDirectory = true;
                    openFileDialog1.FileName = "";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        if ((f = openFileDialog1.OpenFile()) != null)
                        {

                            BinaryFormatter formatter = new BinaryFormatter();
                            //Stream flux = new FileStream("chemin", FileMode.CreateNew, FileAccess.Write);
                            dataGridView1.DataSource= (System.Data.DataTable)formatter.Deserialize(f);
                            // flux.Close();
                            f.Close();
                            button2_Click(null, null);
                        }
                    }

                    //if (ficheo != null)
                    //{
                    //    foreach (int i in checkedListBox1.CheckedIndices)
                    //    {
                    //        checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                    //    }
                    //    importAff(ficheo);



                    //    MessageBox.Show("Veuillez vérifier les accessoires", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void trimGridView()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows[i].Cells.Count; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = dataGridView1.Rows[i].Cells[j].Value.ToString().Trim();
                }
            }
        }
        public void choix()
        {
            if (radioButton2.Checked)
                Table = "Tarif";
            else
                Table = "TarifR";
        }
        private void button2_Click(object sender, EventArgs e)
        {


            try
            {

                if (dataGridView1.Rows.Count <= 0)
                {

                    MessageBox.Show("La liste des tarifs est vide", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    viderChamp();
                    //groupBox4.Enabled = false;
                    //groupBox1.Enabled = false;
                }
                else
                {
                    choix();
                    vidange();

                    Services.remplie = true;
                    Services.daTarif = new SqlCeDataAdapter("select * from " + Table, Services.con);
                    Services.daTarif.Fill(Services.ds, Table);

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DataRow row = Services.ds.Tables[Table].NewRow();
                        row[0] = i;
                        for (int j = 0; j < dataGridView1.Rows[i].Cells.Count; j++)
                        {
                            row[j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                        Services.ds.Tables[Table].Rows.Add(row);
                    }
                    SqlCeCommandBuilder cmd = new SqlCeCommandBuilder(Services.daTarif);
                    Services.daTarif.Update(Services.ds, Table);
                    if(sender!=null)
                    MessageBox.Show("L'enregistrement a été effectué avec succès", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else 
                        MessageBox.Show("L'importation a été effectué avec succès", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    actualiser();
                    viderChamp();
                    //MessageBox.Show(Services.connectionString);
                    //groupBox4.Enabled = false;
                    //groupBox1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            actualiser();
            viderChamp();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {




                if (dataGridView1.SelectedRows.Count > 0)
                {
                    float t0 = float.Parse(textBox2.Text);
                    t0 = float.Parse(textBox3.Text);
                    t0 = float.Parse(textBox4.Text);
                    t0 = float.Parse(textBox5.Text);
                    t0 = float.Parse(textBox6.Text);
                    t0 = float.Parse(textBox7.Text);
                    t0 = float.Parse(textBox8.Text);
                    dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value = textBox0.Text.Trim();
                    dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[1].Value = textBox1.Text.Trim();
                    dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[2].Value = textBox2.Text.Trim();
                    dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[3].Value = textBox3.Text.Trim();
                    dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[4].Value = textBox4.Text.Trim();
                    dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[5].Value = textBox5.Text.Trim();
                    dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[6].Value = textBox6.Text.Trim();
                    dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[7].Value = textBox7.Text.Trim();
                    dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[8].Value = textBox8.Text.Trim();
                    MessageBox.Show("la modification demandée a été effectuée", "", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    vidange();

                    Services.remplie = true;
                    Services.daTarif = new SqlCeDataAdapter("select * from " + Table, Services.con);
                    Services.daTarif.Fill(Services.ds, Table);

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DataRow row = Services.ds.Tables[Table].NewRow();
                        row[0] = i;
                        for (int j = 0; j < dataGridView1.Rows[i].Cells.Count; j++)
                        {
                            row[j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                        Services.ds.Tables[Table].Rows.Add(row);
                    }
                    SqlCeCommandBuilder cmd = new SqlCeCommandBuilder(Services.daTarif);
                    Services.daTarif.Update(Services.ds, Table);


                    actualiser();
                    viderChamp();

                }
                else
                {
                    MessageBox.Show("Aucune ligne n'est sélectionné", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            viderChamp();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int index = e.RowIndex;

                groupBox1.Enabled = true;
                groupBox4.Enabled = true;
                textBox0.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.Rows[index].Cells[5].Value.ToString();
                textBox6.Text = dataGridView1.Rows[index].Cells[6].Value.ToString();
                textBox7.Text = dataGridView1.Rows[index].Cells[7].Value.ToString();
                textBox8.Text = dataGridView1.Rows[index].Cells[8].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        #region Mes fonctions
        //Vidange de la table tarif
        public void vidange()
        {
            SqlCeCommand cmd = new SqlCeCommand("delete from " + Table, Services.con);
            Services.con.Open();
            cmd.ExecuteNonQuery();
            Services.con.Close();
        }
        public void actualiser()
        {

            choix();
            SqlCeCommand cmd = new SqlCeCommand("select modeleT, serieT, prixHtT, tauxT, montantTVA, pclientTTC, fraisImmT, fraisTrT, prixPublic from " + Table, Services.con);
            SqlCeDataAdapter da = new SqlCeDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        void viderChamp()
        {
            textBox0.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }
        void config()
        {
            for (int i = 0; i < 9; i++)
            {
                dataGridView1.Columns[i].Width = 120;
            }

        }
        #endregion

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                bool exl = false;
                int etat = Services.Etat();
                if (etat == 1)
                    exl = (MessageBox.Show("Voulez vous faire l'exportation en format Excel ?", "Format de l'exportation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
                
                if (etat == 1 && exl)
                {
                    if (dataGridView1.Rows.Count <= 0)
                    {
                        MessageBox.Show("La liste est vide !!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    else
                    {
                        Services.b = this.backgroundWorker1;
                        bool v = false;
                        Stream f;
                        saveFileDialog1.Filter = "Excel Worbook (*.xlsx)|*.xlsx";
                        saveFileDialog1.RestoreDirectory = true;
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            if ((f = saveFileDialog1.OpenFile()) != null)
                            {

                                String path = saveFileDialog1.FileName;
                                Services.chemin = path;
                                v = true;
                                f.Close();
                            }
                            else
                            {

                                Services.chemin = "";
                            }
                        }

                        if (v)
                        {
                            if (File.Exists(Services.chemin))
                            {
                                File.Delete(Services.chemin);
                            }
                            if (backgroundWorker1.IsBusy != true)
                            {
                                Wait a = new Wait();
                                Services.a = a;
                                a.Show();
                                backgroundWorker1.RunWorkerAsync();
                            }
                            else
                            {
                                MessageBox.Show("Veuillez Attendre le fin de l'exécution");
                            }
                        }
                    }
                }
                if(etat==2 || !exl)
                {
                    //Serialisation d'une tarif
                    if (dataGridView1.DataSource != null)
                    {
                        Stream f;
                        saveFileDialog1.Filter = "Tarif file (*.tarif)|*.tarif";
                        saveFileDialog1.RestoreDirectory = true;
                        saveFileDialog1.FileName = "";
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            if ((f = saveFileDialog1.OpenFile()) != null)
                            {
                                BinaryFormatter formatter = new BinaryFormatter();
                                //Stream flux = new FileStream("chemin", FileMode.CreateNew, FileAccess.Write);
                                formatter.Serialize(f, dataGridView1.DataSource);
                                // flux.Close();
                                f.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Veuillez verifier les informations");
                    }  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public int pourcentage(int total, int i)
        {

            return (100 * (int)(((float)i) / total));
        }

        #region ExporterDataGridVersExcel Surchargé Type #1
        ///<summary>
        ///Permet d'exporter un DataGrid vers excel
        ///</summary>
        /// <param name="dgView">Data Grid Source des données à Exporter vers Excel</param>
        ///<param name="unFichier">Fichier Excel de destination des données</param>
        ///<param name="strEnteteDeFichier">Libellé de l'en-tête du fichier à générer</param>
        public void ExporterDataGridVersExcel(DataGridView dgView, String unFichier)
        {
            int i = 0;
            int j = 0;
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                Workbook exbook = (Workbook)excel.Workbooks.Add(Missing.Value);
                Worksheet exsheet = (Worksheet)excel.ActiveSheet;
                //Double[] Totaux= new Double[4];

                //Mise en forme de l'en-tête de la feuille Excel
                //exsheet.Cells[1, 1] = strEnteteDeFichier;
                Range r;
                //r.Interior.ColorIndex = XlColorIndex.xlColorIndexAutomatic;
                //r.Font.Bold = true;
                //r.BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, Missing.Value);
                //r.EntireColumn.AutoFit();//Fin de la mise en forme de l'en-tête.

                foreach (DataGridViewColumn ch in dgView.Columns)
                {
                    r = exsheet.get_Range(Convert.ToChar(65 + i).ToString() + "1", Missing.Value);
                    exsheet.Cells[1, i + 1] = ch.Name.Trim();
                    r.Interior.ColorIndex = XlColorIndex.xlColorIndexAutomatic;
                    r.Font.Bold = true;
                    r.BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, Missing.Value);
                    r.EntireColumn.AutoFit();
                    i++;
                }
                // backgroundWorker1.ReportProgress(pourcentage(dgView.Rows.Count,1));
                j = 2;

                foreach (DataGridViewRow uneLigne in dgView.Rows)
                {
                    i = 1;
                    foreach (DataGridViewColumn uneColonne in dgView.Columns)
                    {
                        r = exsheet.get_Range(Convert.ToChar(65 + i - 1).ToString() + j.ToString(), Missing.Value);
                        exsheet.Cells[j, i] = "'" + uneLigne.Cells[uneColonne.Name].Value.ToString().Trim();
                        r.BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, Missing.Value);
                        r.EntireColumn.AutoFit();
                        i++;
                    }
                    exsheet.Columns.AutoFit();
                    j++;
                    //backgroundWorker1.ReportProgress(pourcentage(dgView.Rows.Count, j));
                }

                exsheet.SaveAs(unFichier, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                excel.Quit();
                backgroundWorker1.ReportProgress(111);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                backgroundWorker1.ReportProgress(111);
            }
        }

        //ExporterDataGridVersExcel
        #endregion //ExporterDataGridVersExcel

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ExporterDataGridVersExcel(dataGridView1, Services.chemin);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //progressBar1.Value = (int)(e.ProgressPercentage);

            Services.a.Hide();
            Services.a.Dispose();
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            label11a.ForeColor = ColorTranslator.FromHtml("#323c45");
            label10aa.ForeColor = ColorTranslator.FromHtml("#4ebfed");
            this.pictureBox1a.Image = global::autoc.Properties.Resources.helpbtn71;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            label10aa.ForeColor = ColorTranslator.FromHtml("#323c45");
            label11a.ForeColor = ColorTranslator.FromHtml("#4ebfed");
            this.pictureBox1a.Image = global::autoc.Properties.Resources.helpbtn6;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            _06Aide a = new _06Aide();
            a.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            viderChamp();
            System.Data.DataTable DT = (System.Data.DataTable)dataGridView1.DataSource;
            if (DT != null)
                DT.Clear();
            actualiser();
        }

        //private void pictureBox3_MouseEnter(object sender, EventArgs e)
        //{
        //    this.pictureBox3.Image = global::autoc.Properties.Resources.helpbtn71;
        //}

        //private void pictureBox3_MouseLeave(object sender, EventArgs e)
        //{
        //    this.pictureBox3.Image = global::autoc.Properties.Resources.helpbtn6;
        //}

        //private void pictureBox3_Click(object sender, EventArgs e)
        //{
        //    _06Aide a = new _06Aide();
        //    a.Show();
        //}

    }
}
