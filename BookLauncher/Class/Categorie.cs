using System;

using System.Data;
using System.Data.OleDb;

namespace BookLauncher.Class
{
    class Categorie
    {
        //nom table   FOURNISSEUR
        OleDbCommand cm;
        Module MD = new Module();

        private int num;
        private String Valeur;
        private int parentID;
        private String NomLink; 
      
        //70
        //   cm.Parameters.Add("ID_CLIENT", OleDbType.Numeric).Value = ID_CLIENT;
        public void Ajouter_Categorie()
        {
            cm = new OleDbCommand("insert into Categories(num,Valeur,parentID,NomLink) values (?,?,?,?)", MD.Con);
            cm.Parameters.Add("num", OleDbType.VarChar, 100).Value = num;
            cm.Parameters.Add("Valeur", OleDbType.LongVarChar).Value = Valeur;
            cm.Parameters.Add("parentID", OleDbType.Numeric).Value = parentID;
            cm.Parameters.Add("NomLink", OleDbType.VarChar, 50).Value = NomLink;
            MD.Execute(cm);

        }


        public void Modifier_Categorie(int numero)
        {
            cm = new OleDbCommand("update Categories set num=?,Valeur=?,parentID=?,NomLink=? where num=?", MD.Con);
            cm.Parameters.Add("num", OleDbType.VarChar, 100).Value = num;
            cm.Parameters.Add("Valeur", OleDbType.LongVarChar).Value = Valeur;
            cm.Parameters.Add("parentID", OleDbType.Numeric).Value = parentID;
            cm.Parameters.Add("NomLink", OleDbType.VarChar, 50).Value = NomLink;
            cm.Parameters.Add("num", OleDbType.VarChar, 100).Value = numero;
            MD.Execute(cm);
        }
        public void Supprimer_Categorie()
        {
            cm = new OleDbCommand("delete from Categories  where num=?", MD.Con);
            cm.Parameters.Add("num", OleDbType.VarChar, 100).Value = num;
            MD.Execute(cm);
        }
        public bool Existe_Categorie_Nom(string nomcateg)
        {
            DataTable t = new DataTable();
            cm = new OleDbCommand("select * from TableCategorie where categ=?", MD.Con);
            cm.Parameters.Add("categ", OleDbType.VarChar, 255).Value = nomcateg;
            t=MD.remplir(cm);
            if(t.Rows.Count >0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public string Valeur_Categorie_Nom(string nomcateg)
        {
            DataTable t = new DataTable();
            cm = new OleDbCommand("select * from TableCategorie where categ=?", MD.Con);
            cm.Parameters.Add("categ", OleDbType.VarChar, 255).Value = nomcateg;
            t = MD.remplir(cm);
            return t.Rows[0]["valeur"].ToString();

        }
        public DataTable Liste_Categories()
        {
            cm = new OleDbCommand("select * from Categories  order by num ASC", MD.Con);

            return MD.remplir(cm);

        }
 

        public int Get_num
        {
            get { return num; }
            set { num = value; }
        }
        public string Get_Valeur
        {
            get { return Valeur; }
            set { Valeur = value; }
        }

        public int Get_parentID
        {
            get { return parentID; }
            set { parentID = value; }
        }
        public String Get_NomLink
        {
            get { return NomLink; }
            set { NomLink = value; }
        }
        
    }
}
