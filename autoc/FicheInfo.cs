using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace autoc
{
    class FicheInfo
    {
        public static string typeV= "";
        public static string remiseTotal = "";
        public static string quantiteTotal = "";
        public static string margeTotal = "";

        #region Information personnels
        public static string client = "";
        public static string gsm = "";
        public static string ville = "";
        public static string commercial = "";
        #region Categorie
        public static string particulier = "";
        public static string commercant = "";
        public static string agence = "";
        public static string taxieur = "";
        public static string conventionne = "";
        #endregion
        #endregion

        #region Informations de la véhicule
        public static string modele = "";
        public static string serie = "";
        #endregion

        #region Mode de paiement
        public static string aucomptant = "";
        public static string organisme = "";
        public static string avance = "";
        public static string mensualite = "";
        #endregion

        #region Prix
        public static string prixttc = "";
        public static string imm = "";
        public static string ww = "";
        public static string ww1 = "";
        public static string remisemontant = "";

        public static string remisepourcentage = "";

        public static string remisemontantLocal = "";
        public static string remisepourcentageLocal = "";
        public static string exoneration = "";
        public static string subvention = "";

        public static List<string> accessoire = new List<string>();
        public static List<double> accessoireP = new List<double>();
        public static string accessoireprix = "";

        public static string marge = "";
        #endregion

        #region Net à payer
        public static string montantttc = "";
        public static string montantexoneration = "";
        public static string remisesup = "";
        public static string remisecalcule = "";
        public static string remisecalculeLocal = "";
        public static string observation = "";
        public static string quantite = "";
        public static string net = "";
        #endregion

        public static void vider()
        {
            FicheInfo.commercial = "";
            FicheInfo.client = "";
            FicheInfo.gsm = "";
            FicheInfo.ville = "";
            FicheInfo.modele = "";
            FicheInfo.serie = "";
            FicheInfo.particulier = "";
            FicheInfo.commercant = "";
            FicheInfo.agence = "";
            FicheInfo.taxieur = "";
            FicheInfo.conventionne = "";
            FicheInfo.aucomptant = "";
            FicheInfo.organisme = "0";
            FicheInfo.avance = "0";
            FicheInfo.mensualite = "0";

            FicheInfo.marge = "0";

            FicheInfo.remisemontantLocal = "0";
            FicheInfo.remisepourcentageLocal = "0";
            FicheInfo.prixttc = "0";
            FicheInfo.imm = "0";
            FicheInfo.ww = "0";
            FicheInfo.ww1 = "0";

            FicheInfo.remisemontant = "0";
            FicheInfo.remisepourcentage = "0";
            FicheInfo.exoneration = "0";
            FicheInfo.subvention = "0";

            FicheInfo.accessoire = new List<string>();
            FicheInfo.accessoireP = new List<double>();
            FicheInfo.accessoireprix = "0";

            FicheInfo.montantttc = "0";
            FicheInfo.montantexoneration = "0";

            FicheInfo.remisecalcule = "0";
            FicheInfo.remisecalculeLocal = "0";
            FicheInfo.observation = "0";
            FicheInfo.net = "0";
            FicheInfo.remisesup="0";
            FicheInfo.quantite = "1";

              FicheInfo.remiseTotal = "0";
              FicheInfo.quantiteTotal = "0";
              FicheInfo.margeTotal = "0";

              FicheInfo.typeV = "DACIA";
        }

       
    }
}
