using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Humanizer;
using System.Globalization;
using System.Data.SqlServerCe;
using System.IO;
using System.Reflection;

namespace autoc
{
    public partial class _05Facture : Form
    {
        public _05Facture()
        {
            InitializeComponent();
        }

        public string toUpperfirst(string input) {
            return input.First().ToString().ToUpper() + String.Join("", input.Skip(1));
        }
        public void set(facture f, string par, string value)
        {
            if (value != "")
                f.SetParameterValue(par, float.Parse(value).ToString("n", new CultureInfo("nb-NO")));
            else
                f.SetParameterValue(par, value);
        }
        private void _05Facture_Load(object sender, EventArgs e)
        {
          facture f = new facture();
           
        
         CultureInfo c= new CultureInfo("fr");
          SqlCeCommand cmd = new SqlCeCommand("select * from Facture", Services.con);

          DatabaseDataSet s = new DatabaseDataSet();
          Services.con.Open();

          SqlCeDataAdapter da = new SqlCeDataAdapter(cmd);

          da.Fill(s, "Facture");
          Services.con.Close();



          f.SetDataSource(s);
          f.SetParameterValue("date", DateTime.Now.Day + " " + c.DateTimeFormat.GetMonthName(DateTime.Now.Month) + " " + DateTime.Now.Year);
          f.SetParameterValue("client", FicheInfo.client.ToUpper());
          f.SetParameterValue("ville", FicheInfo.ville.ToUpper());
             //f.SetParameterValue("modele", FicheInfo.serie);
             set(f, "totalht", FactureInfo.totalht);
             set(f, "tva7", FactureInfo.tva7);
             set(f, "tva20", FactureInfo.tva20);
             set(f, "pttc", FactureInfo.prixttc);
             set(f, "fww", FactureInfo.ww);
             set(f, "net", FactureInfo.net);
             set(f, "remiseTotal", FactureInfo.remiseTotal);
             f.SetParameterValue("netword", " Dirhams");
             if (FactureInfo.net != "")
             {
                 float aa = float.Parse(FactureInfo.net);
                 string x = aa.ToString("#.");
                 aa = float.Parse(x);
                 int a = (int)aa;

                 string r = a.ToWords(new CultureInfo("fr"));

                 f.SetParameterValue("netword", toUpperfirst(r) + " Dirhams");
             }
             if (FactureInfo.net == "")
             {
                 int a = int.Parse("0");
                 f.SetParameterValue("netword", a.ToWords(new CultureInfo("fr")) + " Dirhams");
             }
             crystalReportViewer1.ReportSource = f;
            // crystalReportViewer1.RefreshReport();
        }
    }
}
