using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace autoc
{
    [Serializable]
   public  class ficheO
    {
        public string typeV = "";
        public string remiseTotal = "";
        public string quantiteTotal = "";

        #region Information personnels
        public string client = "";
        public string gsm = "";
        public string ville = "";
        public string commercial = "";
       
        #endregion

        #region Categorie
        public string particulier = "";
        public string commercant = "";
        public string agence = "";
        public string taxieur = "";
        public string conventionne = "";
        #endregion

        #region Informations de la véhicule
        public string modele = "";
        public string serie = "";
        #endregion

        #region Mode de paiement
        public string aucomptant = "";
        public string organisme = "";
        public string avance = "";
        public string mensualite = "";
        #endregion

        #region Prix
        public string prixttc = "";
        public string imm = "";
        public string ww = "";

        public string remisemontant = "";
        public string remisepourcentage = "";
        public string remisemontantLocal = "";
        public string remisepourcentageLocal = "";

        public string exoneration = "";
        public string subvention = "";

        public List<string> accessoire = new List<string>();
        public string accessoireprix = "";
        #endregion

        #region Net à payer
        public string montantttc = "";
        public string montantexoneration = "";
        public string remisecalcule = "";
        public string remisecalculeLocal = "";
        public string remisesup = "";
        public string observation = "";
        public string net = "";
        public string quantite="";
        #endregion

       public List<factureO> factures =new List<factureO>();
    }
}
