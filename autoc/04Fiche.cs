using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace autoc
{
    public partial class _04Fiche : Form
    {
        public _04Fiche()
        {
            InitializeComponent();
        }
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
        public void set(fiche f,string par, string value)
        {
            if (value != "")
                f.SetParameterValue(par, float.Parse(value).ToString("n", new CultureInfo("nb-NO")));
            else
                f.SetParameterValue(par, value);
        }
        public string set(string value)
        {
            if (value != "")
              return float.Parse(value).ToString("n", new CultureInfo("nb-NO"));
            else
               return value;
        }
        private void _04Fiche_Load(object sender, EventArgs e)
        {
            fiche f = new fiche();
            f.SetParameterValue("Date", DateTime.Now.ToString(" dd/MM/yyyy "));
            f.SetParameterValue("Client", FicheInfo.client);
            f.SetParameterValue("Commercial", FicheInfo.commercial);
            f.SetParameterValue("Ville", FicheInfo.ville);
            f.SetParameterValue("GSM", FicheInfo.gsm);
            f.SetParameterValue("Modele", FicheInfo.modele + " - " + FicheInfo.serie);
            //Categorie
            f.SetParameterValue("Particulier", FicheInfo.particulier);
            f.SetParameterValue("Commercant", FicheInfo.commercant);
            f.SetParameterValue("Agence", FicheInfo.agence);
            f.SetParameterValue("Taxieur", FicheInfo.taxieur);
            f.SetParameterValue("Conventionne", FicheInfo.conventionne);
            //Paiement
            f.SetParameterValue("Aucomptant", FicheInfo.aucomptant);
            f.SetParameterValue("Organisme", FicheInfo.organisme);
            f.SetParameterValue("Avance", FicheInfo.avance);
            f.SetParameterValue("Mensualite", FicheInfo.mensualite);
            f.SetParameterValue("typeV", FicheInfo.typeV);
            set(f,"Prixttc", FicheInfo.prixttc);

            set(f, "Imm", FicheInfo.imm);
            float sww = float.Parse(FicheInfo.ww) + float.Parse(FicheInfo.ww1);
            set(f, "Ww", sww.ToString());
            set(f, "Remisemontant", FicheInfo.remisemontant);
       

            f.SetParameterValue("Remisepourcentage", "("+FicheInfo.remisepourcentage+" %)");


            set(f,"Exoneration", FicheInfo.exoneration);


            set(f,"Subvention", FicheInfo.subvention);
            if(FicheInfo.accessoire.Count>0)
                f.SetParameterValue("Accessoire", "Accessoires");
            else
                f.SetParameterValue("Accessoire", "");
            set(f,"Accessoireprix", FicheInfo.accessoireprix);

            set(f, "RemiseCalcule", FicheInfo.remisecalcule);
            //Montant net

            set(f,"MontantTTc", FicheInfo.montantttc);


            set(f, "Montantexoneration", FicheInfo.montantexoneration);

            string m=FicheInfo.montantttc;
            if (FicheInfo.montantttc == "")
                m = FicheInfo.montantexoneration;
           
            if (FicheInfo.remisesup != "0")
            {
                f.SetParameterValue("observationprix","Remise supplémentaire : "+ set(FicheInfo.remisesup) +" Dh - Net à payer : "+set(m)+" Dh");
                f.SetParameterValue("Observation", FicheInfo.observation);
            }
            else {
                f.SetParameterValue("observationprix", FicheInfo.observation);
                f.SetParameterValue("Observation","");
            }
            crystalReportViewer1.ReportSource = f;
        }
    }
}
