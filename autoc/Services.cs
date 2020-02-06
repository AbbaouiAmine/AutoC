using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlServerCe;
using System.IO;
using System.Reflection;
using System.ComponentModel;

namespace autoc
{
    class Services
    {
        public static BackgroundWorker b;
        public static string chemin="";
        public static bool demmarer=true;
        public static Menu m;
        public static string StartupPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Remove(0,6);
        
        public static string connectionString = Path.Combine(StartupPath, "Database.sdf");
       
        public static string chaine = string.Format("DataSource={0}", connectionString);
        //public static string chaine = "server=.;database=autoc;integrated security=true";
        //Data Source=C:\Users\root\Desktop\code source\autoc\autoc\Database.sdf
        //public static string chaine="Provider=Microsoft.Jet.OLEDB.4.0; "+"Data Source=" + Server.MapPath("Pets/Pets.mdb"));
        public static SqlCeConnection con = new SqlCeConnection(Services.chaine);
        public static SqlCeDataAdapter daTarif;
        public static DataSet ds = new DataSet();
        public static bool remplie=false;
        public static Wait a;
        public static int format=0;
        public static bool opened;
        public static int page = 1;
        public static int etat = 0;
        public static int quantite = 1;
        public static int quantiteTotal = 0;
        public static double remiseTotal=0;
        public static double margeTotal = 0;
        public static int Etat()
        {
            string req = "select *  from  Config";
            SqlCeCommand cmd = new SqlCeCommand(req, Services.con);
            DataSet ds = new DataSet();
            SqlCeDataAdapter da = new SqlCeDataAdapter(cmd);
            da.Fill(ds);
            return int.Parse(ds.Tables[0].Rows[0][0].ToString());

        }
        public static void ChangeEtat(int e)
        {
            string req = "update Config set etat=@p1 where numE=1";
            SqlCeCommand cmd = new SqlCeCommand(req, Services.con);
            SqlCeParameter p1 = new SqlCeParameter("@p1", e);
            cmd.Parameters.Add(p1);
            Services.con.Open();
            cmd.ExecuteNonQuery();
            Services.con.Close();
        }
    }
}
