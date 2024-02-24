using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;

namespace BookLauncher.Class
{
    public class Dictionary<TKey1, TKey2, TValue> : Dictionary<Tuple<TKey1, TKey2>, TValue>, IDictionary<Tuple<TKey1, TKey2>, TValue>
    {

        public TValue this[TKey1 key1, TKey2 key2]
        {
            get { return base[Tuple.Create(key1, key2)]; }
            set { base[Tuple.Create(key1, key2)] = value; }
        }

        public void Add(TKey1 key1, TKey2 key2, TValue value)
        {
            base.Add(Tuple.Create(key1, key2), value);
        }
        
        public bool ContainsKey(TKey1 key1, TKey2 key2)
        {
            return base.ContainsKey(Tuple.Create(key1, key2));
        }
    }
    class Module
    {
        //Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\myFolder\BookLauncher.accdb;Persist Security Info=False;    chaine connexion pour Access 2007
        // pour mot passe ajouter ";Jet OLEDB:Database Password=Mot passe"
        // public OleDbConnection Con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath.ToString() + "\\GestionVente.accdb;Persist Security Info=False");
        //public OleDbConnection Con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath.ToString() + "\\AzaStock.mdb;Persist Security Info=False");
        public OleDbConnection Con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath.ToString() + "\\BookLauncher.mdb;Persist Security Info=False;Jet OLEDB:Database Password=MyDbPassword");
 // public OleDbConnection Con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath.ToString() + @"\BookLauncher.accdb;Persist Security Info=False");
        OleDbDataAdapter Dt = new OleDbDataAdapter();
       public static string Skinnameprog;
        //public static bool Autor_AJT_Historique;
        public static string Nom_Utilisateur;
        public static string Mot_passe;
public static bool Verification_Activation_enligne;
        public static bool IsDouble(string ValueToTest)
        {
            double Test;
            bool OutPut;
            OutPut = double.TryParse(ValueToTest, out Test);
            return OutPut;
        }
        //Autor_AJT_Produit=?,Autor_AJT_Categorie=?,Autor_AJT_Comptoire=?,Autor_AJT_Operation=?,Autor_AJT_Achat=?,Autor_AJT_Societe=?,Autor_AJT_Fournisseur=?,Autor_AJT_Client=?,Autor_AJT_Devis=?,Autor_AJT_Utilisateurs=?
        public void Execute(OleDbCommand cm)
        {
            try
            {
                Con.Open();
                cm.ExecuteNonQuery();
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " | " + cm.CommandText.ToString());
                Con.Close();
                throw;
            }
        }
        public DataTable remplir(OleDbCommand cm)
        {
            try
            {

                DataSet ts = new DataSet();
                DataTable t = new DataTable();
                Dt.SelectCommand = cm;
                Dt.Fill(t);
                //t=ts.Tables;
                return t;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " | " + cm.CommandText.ToString());
                Con.Close();
                throw;
            }
        }
        public static async Task<DateTime> GetNISTDate(bool convertToLocalTime)
        {
            Random ran = new Random(DateTime.Now.Millisecond);
            DateTime date = DateTime.Today;
            string serverResponse = string.Empty;

            // Represents the list of NIST servers
            string[] servers = new string[] {
                         "64.90.182.55",
                         "206.246.118.250",
                         "207.200.81.113",
                         "128.138.188.172",
                         "64.113.32.5",
                         "64.147.116.229",
                         "64.125.78.85",
                         "128.138.188.172"
                          };

            // Try each server in random order to avoid blocked requests due to too frequent request
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    // Open a StreamReader to a random time server
                    StreamReader reader = new StreamReader(new System.Net.Sockets.TcpClient(servers[ran.Next(0, servers.Length)], 13).GetStream());
                    serverResponse = reader.ReadToEnd();
                    reader.Close();

                    // Check to see that the signiture is there
                    if (serverResponse.Length > 47 && serverResponse.Substring(38, 9).Equals("UTC(NIST)"))
                    {
                        // Parse the date
                        int jd = int.Parse(serverResponse.Substring(1, 5));
                        int yr = int.Parse(serverResponse.Substring(7, 2));
                        int mo = int.Parse(serverResponse.Substring(10, 2));
                        int dy = int.Parse(serverResponse.Substring(13, 2));
                        int hr = int.Parse(serverResponse.Substring(16, 2));
                        int mm = int.Parse(serverResponse.Substring(19, 2));
                        int sc = int.Parse(serverResponse.Substring(22, 2));

                        if (jd > 51544)
                            yr += 2000;
                        else
                            yr += 1999;

                        date = new DateTime(yr, mo, dy, hr, mm, sc);

                        // Convert it to the current timezone if desired
                        if (convertToLocalTime)
                            date = date.ToLocalTime();

                        // Exit the loop
                        break;
                    }

                }
                catch //(Exception ex)
                {
                    /* Do Nothing...try the next server */
                }
            }

            return date;
        }
    }
}
