using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
namespace BookLauncher.Class
{
    class FileCover
    {
        Module MD = new Module();
        OleDbCommand cm;
        public int Nfile { get; set; }
        public int NBook { get; set; }
        public string NomFile { get; set; }
        public string CheminFile { get; set; }
        public string Status { get; set; }
        public DateTime DatePublier { get; set; }
        public void Ajouter_FileCover()
        {
            cm = new OleDbCommand("insert into FileCover(NBook,NomFile,CheminFile,Status) values (?,?,?,?)", MD.Con);
            cm.Parameters.Add("NBook", OleDbType.Numeric).Value = NBook;
            cm.Parameters.Add("NomFile", OleDbType.VarChar,255).Value = NomFile;
            cm.Parameters.Add("CheminFile", OleDbType.VarChar,255).Value = CheminFile;
            cm.Parameters.Add("Status", OleDbType.VarChar, 50).Value = Status;
 //cm.Parameters.Add("DatePublier", OleDbType.Date).Value = DatePublier;
            MD.Execute(cm);
        }
        public void Ajouter_AncienFileCover()
        {
            cm = new OleDbCommand("insert into FileCover(NBook,NomFile,CheminFile,Status,DatePublier) values (?,?,?,?,?)", MD.Con);
            cm.Parameters.Add("NBook", OleDbType.Numeric).Value = NBook;
            cm.Parameters.Add("NomFile", OleDbType.VarChar, 255).Value = NomFile;
            cm.Parameters.Add("CheminFile", OleDbType.VarChar, 255).Value = CheminFile;
            cm.Parameters.Add("Status", OleDbType.VarChar, 50).Value = Status;
            cm.Parameters.Add("DatePublier", OleDbType.Date).Value = DatePublier;
            MD.Execute(cm);
        }
        public void Modifier_DatePub_FileCover()
        {
            cm = new OleDbCommand("update FileCover set Status=?,DatePublier=? where Nfile=?", MD.Con);
            cm.Parameters.Add("Status", OleDbType.VarChar, 50).Value = Status;
 cm.Parameters.Add("DatePublier", OleDbType.Date).Value = DatePublier;
            cm.Parameters.Add("Nfile", OleDbType.Numeric).Value = Nfile;
            MD.Execute(cm);
        }
public void Supprimer_tout_FileCover()
        {
            cm = new OleDbCommand("Delete from FileCover where NBook=?", MD.Con);
            cm.Parameters.Add("NBook", OleDbType.Numeric).Value = NBook;
            
            MD.Execute(cm);

        }
        public void Supprimer_FileCover()
        {
            cm = new OleDbCommand("Delete from FileCover where Nfile=?", MD.Con);
            cm.Parameters.Add("Nfile", OleDbType.Numeric).Value = Nfile;
            
            MD.Execute(cm);

        }
        public DataTable  Liste_Cover_FileCover_nonPublier()
        {
            cm = new OleDbCommand("select * from FileCover where Status=?", MD.Con);
            cm.Parameters.Add("Status", OleDbType.VarChar, 50).Value = "Nouveau";
            DataTable t = new DataTable();
            t=MD.remplir(cm);
            return t;
        }
        public DataTable Liste_Cover_FileCover_Book()
        {
            cm = new OleDbCommand("select * from FileCover where NBook=?", MD.Con);
            cm.Parameters.Add("NBook", OleDbType.Numeric).Value = NBook;
            DataTable t = new DataTable();
            t = MD.remplir(cm);
            return t;
        }
        public bool Exists_Cover_FileCover()
        {
            cm = new OleDbCommand("select * from FileCover where CheminFile=?", MD.Con);
            cm.Parameters.Add("CheminFile", OleDbType.VarChar, 255).Value = CheminFile;
            DataTable t = new DataTable();
            t = MD.remplir(cm);
            if(t.Rows.Count>0)
            {
                Nfile=int.Parse(t.Rows[0][0].ToString());
                return true;
            }
            else
            {
                return false;
            }
            
        }

    }
}
