using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
namespace BookLauncher.Class
{
    class Users
    {
        OleDbCommand cm;
        Module MD = new Module();
        public string NameUser;
        public string Motpasse;
        public void Modifier_User(string nom)
        {
            cm = new OleDbCommand("update Users set NameUser=?,Motpasse=? where NameUser=?", MD.Con);//
            cm.Parameters.Add("NameUser", OleDbType.VarChar, 255).Value = NameUser;
            cm.Parameters.Add("Motpasse", OleDbType.VarChar,255).Value = Motpasse;
            cm.Parameters.Add("NameUser", OleDbType.VarChar, 255).Value = nom;
            MD.Execute(cm);

        }
        public void Return_User()
        {
            cm = new OleDbCommand("select * from Users ", MD.Con);
            DataTable t = new DataTable();
            t = MD.remplir(cm);
            if (t.Rows.Count>0 )
            {
                NameUser = t.Rows[0][0].ToString();
                Motpasse = t.Rows[0][1].ToString();
            }

        }

    }
}
