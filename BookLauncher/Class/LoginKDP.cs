using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLauncher.Class;
using System.Data.OleDb;
using System.Data;
//using DevExpress.XtraEditors.DXErrorProvider;
namespace BookLauncher.Class
{
    class LoginKDP 
    {
        Module MD = new Module();
        OleDbCommand cm;
        public string Email { get; set; }
        public string Password { get; set; }
        
        public void Modifier_Login()
        {
            cm = new OleDbCommand("UPDATE LoginKDP set Email=?,LPassword=? where Email=?", MD.Con);
            cm.Parameters.Add("Email", OleDbType.VarChar, 255).Value = Email;
            cm.Parameters.Add("LPassword", OleDbType.VarChar,255).Value = Password;
            cm.Parameters.Add("Email", OleDbType.VarChar, 255).Value = Module.Nom_Utilisateur;
            MD.Execute(cm);
        }
        public void return_Login()
        {
            DataTable t = new DataTable();
            cm = new OleDbCommand("select * from LoginKDP ", MD.Con);
            //cm.Parameters.Add("Email", OleDbType.VarChar, 200).Value = Email;
            t=MD.remplir(cm);
            if (t.Rows.Count >0)
            {
                Email = t.Rows[0][0].ToString();
                Password = t.Rows[0][1].ToString();
            }
        }
       
    }
}
