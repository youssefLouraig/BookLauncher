using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Management;
using System.Threading;
using System.Management.Instrumentation;
using Microsoft.Win32;
using System.IO;
using System.Runtime;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
namespace BookLauncher.Class
{
    class Activer_Programme
    {
        //[DllImport("wininet.dll")]
        //public extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        //Creating a function that uses the API function...  
        public static bool IsConnectedToInternet()
        {
            int Desc;
            return InternetGetConnectedState(out Desc, 0);
        }
        //SqlConnection conn = new SqlConnection(@"Data Source = SQL5033.site4now.net; Initial Catalog = DB_A574AE_ActiveProgramme; User Id = DB_A574AE_ActiveProgramme_admin; Password=youssef067245001;");
        MySqlConnection conn = new MySqlConnection(@"server=softcomputer.site;user id=erfectea_youssef;database=erfectea_BookLicense;password=youssef067245001");

        //************************ fonction pour recuperer Date Aujourdhuit sur  internet
        public DateTime GetInternetTime(string host, bool ToLocalTime = false)
        {
            string timeStr;
            System.Net.Sockets.TcpClient Tcp = new System.Net.Sockets.TcpClient(host, 13);
            StreamReader reader = new StreamReader(Tcp.GetStream());
            DateTime LastSysTime;
            LastSysTime = DateTime.UtcNow;
            timeStr = reader.ReadToEnd();
            reader.Close();
            int year = int.Parse(timeStr.Substring(7, 2)) + 2000;
            int month = int.Parse(timeStr.Substring(10, 2));
            int day = int.Parse(timeStr.Substring(13, 2));
            int hour = int.Parse(timeStr.Substring(16, 2));
            int minute = int.Parse(timeStr.Substring(19, 2));
            int second = int.Parse(timeStr.Substring(22, 2));

            if (ToLocalTime)
            {
                //return new DateTime(year, month, day, hour, minute, second).ToLocalTime();
                return new DateTime(year, month, day).ToLocalTime();
            }
            else
            {
                return new DateTime(year, month, day, hour, minute, second);
            }
        }
        //****************************************************************
        private MySqlCommand cm;
        private MySqlDataAdapter adap = new MySqlDataAdapter();

        public bool Activer_programme_Deconnecter(string nom_client, string serial, string nom_programme)
        {
            conn.Open();
            MySqlTransaction trans = conn.BeginTransaction();
            try
            {

                cm = new MySqlCommand("select * from ComptesPc", conn);
                cm.Transaction = trans;
                MySqlDataAdapter Adp = new MySqlDataAdapter(cm);
                DataTable t = new DataTable();
                Adp.Fill(t);
                DataRow dr = t.NewRow();
                dr["Nomutilisat"] = nom_client;
                dr["PcSerie"] = passcode();
                dr["Serial"] = serial;

                short nombreJRS = 7;
                switch (typeActivation)
                {
                    case "Teste": nombreJRS = 7; break;
                    case "Month": nombreJRS = 30; break;
                    case "Year": nombreJRS = 365; break;
                    default: nombreJRS = 7; break;
                }
                DateTime dt = DateTime.Now.Date;
                try
                {
                    //dt = GetInternetTime("time.nist.gov", true);
dt = GetInternetTime("time.windows.com", true);
                }
                catch
                {

                }
                dt = dt.AddDays(nombreJRS);
                //dt = DateTime.Parse();
                dr["DateActive"] = dt.ToString("dd/MM/yyyy");
                dr["Activationstatus"] = true;
                dr["Processeur"] = nom_programme;
                dr["TypeActivation"] = typeActivation;
                t.Rows.Add(dr);
                MySqlCommandBuilder cmdb = new MySqlCommandBuilder(Adp);
                Adp.Update(t);
                //--------------------------------------------------------------

                // cm = new MySqlCommand("update Serials set status='True' where activationkeys='" + serial + "'", conn);
                cm = new MySqlCommand("select * from Serials where activationkeys='" + serial + "'", conn);
                cm.Transaction = trans;
                Adp = new MySqlDataAdapter(cm);
                t = new DataTable();
                Adp.Fill(t);
                //System.Windows.Forms.MessageBox.Show(t.Rows.Count.ToString());
                if (t.Rows.Count > 0)
                {
                    DataRow drw = t.Rows[0];
                    drw["status"] = true;
                    MySqlCommandBuilder cmb = new MySqlCommandBuilder(Adp);
                    Adp.Update(t);
                }
                //cm.ExecuteNonQuery();
                trans.Commit();
                conn.Close();
                return true;
            }
            catch
            {
                trans.Rollback();
                //MessageBox.Show(ex.Message.ToString());
                conn.Close();
                return false;
            }


        }
        public void desativer_compte(string serial)
        {
            conn.Open();
            MySqlTransaction trans = conn.BeginTransaction();
            try
            {

                cm = new MySqlCommand("update ComptesPc set Activationstatus='false' where Serial='" + serial + "'", conn);
                cm.Transaction = trans;
                DataTable t;
                MySqlDataAdapter Adp = new MySqlDataAdapter(cm);
                t = new DataTable();
                Adp.Fill(t);
                if (t.Rows.Count > 0)
                {
                    DataRow drw = t.Rows[0];
                    drw["Activationstatus"] = false;
                    MySqlCommandBuilder cmb = new MySqlCommandBuilder(Adp);
                    Adp.Update(t);
                }
                trans.Commit();
                conn.Close();

            }
            catch //(Exception ex)
            {
                trans.Rollback();
                //MessageBox.Show(ex.Message.ToString());
                conn.Close();
                //return false;
            }
        }
        public string type_Activation(string serial)
        {
            try
            {
                DataTable t = new DataTable();
                cm = new MySqlCommand("select * from ComptesPc where   Serial=@activ and Activationstatus=@stat", conn); //status='false' and    '" + tSerial.Text.ToString() + "'
                cm.Parameters.Add("@activ", MySqlDbType.VarChar, 300).Value = serial;
                cm.Parameters.Add("@stat", MySqlDbType.Bit).Value = true;
                //adap= new MySqlDataAdapter(cm);
                adap.SelectCommand = cm;
                adap.Fill(t);
                //MessageBox.Show(t.Rows.Count.ToString());
                if (t.Rows.Count > 0)
                {
                    return t.Rows[0]["TypeActivation"].ToString();

                }
                else
                {
                    return "No";
                }
            }
            catch //(Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return "No";
            }
        }
        public string DateActivation;
        public bool Serial_valide(string serial)
        {
            try
            {
                DataTable t = new DataTable();
                cm = new MySqlCommand("select * from ComptesPc where   Serial=@activ and Activationstatus=@stat", conn); //status='false' and    '" + tSerial.Text.ToString() + "'
                cm.Parameters.Add("@activ", MySqlDbType.VarChar, 300).Value = serial;
                cm.Parameters.Add("@stat", MySqlDbType.Bit).Value = true;
                //adap= new MySqlDataAdapter(cm);
                adap.SelectCommand = cm;
                adap.Fill(t);
                //MessageBox.Show(t.Rows.Count.ToString());
                if (t.Rows.Count > 0)
                {
                    typeActivation = t.Rows[0]["TypeActivation"].ToString();
                    DateActivation = t.Rows[0]["DateActive"].ToString();
                    //System.Windows.Forms.MessageBox.Show(DateActivation.ToString());
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch //(Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
        }
        public string typeActivation;
        public bool Serial_existe(string serial)
        {
            try
            {
                DataTable t = new DataTable();
                cm = new MySqlCommand("select * from Serials where   activationkeys=@activ and status=@stat", conn); //status='false' and    '" + tSerial.Text.ToString() + "'
                cm.Parameters.Add("@activ", MySqlDbType.VarChar, 300).Value = serial;
                cm.Parameters.Add("@stat", MySqlDbType.Bit).Value = false;
                //adap= new MySqlDataAdapter(cm);
                adap.SelectCommand = cm;
                adap.Fill(t);
                //MessageBox.Show(t.Rows.Count.ToString());
                if (t.Rows.Count > 0)
                {
                    typeActivation = t.Rows[0]["typeSerial"].ToString();
                    return true;
                }
                else
                {
                    typeActivation = "";
                    /// for activation
                    return false;
                }
            }
            catch
            {
                typeActivation = "";
                return false;
            }
        }
        private string code_disque()
        {
            SelectQuery query = new SelectQuery("Win32_bios");
            ManagementObjectSearcher search = new ManagementObjectSearcher(query);
            //ManagementObject info = new ManagementObject();
            string sStr = "";
            foreach (ManagementObject info in search.Get())
            {
                sStr = info.GetMethodParameters("serialnumber").ToString();
                //sStr = info("serialnumber").ToString();
            }

            return sStr;
        }
        public string passcode()
        {
            string s = "";
            ManagementObjectSearcher Searcher;
            Searcher = new ManagementObjectSearcher("Select ProcessorId From Win32_Processor");
            foreach (ManagementObject Device in Searcher.Get())
            {
                foreach (PropertyData Prop in Device.Properties)

                    s = (Prop.Value.ToString());
            }
            return s;
        }
        //public void Verification_Activation_APP()
        //{
        //    string serialProg = "BBB";
        //    string TypeActivation = "Trial";
        //    DateTime dateExpiration = DateTime.Today.Date.AddDays(10);
        //    bool isActive = true;

        //}
    }
}
