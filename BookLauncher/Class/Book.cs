using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Data.OleDb;
namespace BookLauncher.Class
{
    class Book
    {
        Module MD = new Module();
        OleDbCommand cm;
        public int NBook { get; set; }
        public string Book_title { get; set; }
        public string sub_title { get; set; }
        public string Prefix { get; set; }
        public string First_Name { get; set; }
        public string Mid_Name { get; set; }
        public string Last_Name { get; set; }
        public string Suffix { get; set; }
        public string Description { get; set; }
        public string Kayword1 { get; set; }
        public string Kayword2 { get; set; }
        public string Kayword3 { get; set; }
        public string Kayword4 { get; set; }
        public string Kayword5 { get; set; }
        public string Kayword6 { get; set; }
        public string Kayword7 { get; set; }
 public string Adult { get; set; }
        public string Price { get; set; }
        public string priceuk { get; set; }
        public string pricede { get; set; }
        public string pricefr { get; set; }
        public string pricees { get; set; }
        public string priceit { get; set; }
        public string pricenl { get; set; }
        public string pricepl { get; set; }
        public string pricese { get; set; }
        public string pricecojp { get; set; }
        public string priceca { get; set; }
        public string priceau { get; set; }
        
        public string Category1 { get; set; }
        public string Category2 { get; set; }
        public string size_paper { get; set; }
        public string type_paper { get; set; }
        public string Bleed { get; set; }
        public string Finish { get; set; }
        public string Interior_File { get; set; }
        public string Cover_File { get; set; }
        public string ISBN { get; set; }
        public bool HardBook { get; set; }

        public void Ajouter_Book()
        {
            cm = new OleDbCommand("insert into Book(Book_title,sub_title,Prefix,First_Name,Mid_Name,Last_Name,Suffix,Description,Kayword1,Kayword2,Kayword3,Kayword4,Kayword5,Kayword6,Kayword7,Adult,Price,Category1,Category2,size_paper,type_paper,Bleed,Finish,Interior_File,ISBN) values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)", MD.Con);//25
            cm.Parameters.Add("Book_title", OleDbType.VarChar, 255).Value =Book_title ;
            cm.Parameters.Add("sub_title", OleDbType.VarChar, 255).Value =sub_title ;
            cm.Parameters.Add("Prefix", OleDbType.VarChar, 255).Value =Prefix ;
            cm.Parameters.Add("First_Name", OleDbType.VarChar, 255).Value =First_Name ;
            cm.Parameters.Add("Mid_Name", OleDbType.VarChar, 255).Value =Mid_Name ;
            cm.Parameters.Add("Last_Name", OleDbType.VarChar, 255).Value =Last_Name ;
            cm.Parameters.Add("Suffix", OleDbType.VarChar, 255).Value =Suffix ;
            cm.Parameters.Add("Description", OleDbType.LongVarChar).Value =Description ;
            cm.Parameters.Add("Kayword1", OleDbType.VarChar, 255).Value =Kayword1 ;
            cm.Parameters.Add("Kayword2", OleDbType.VarChar, 255).Value =Kayword2 ;
            cm.Parameters.Add("Kayword3", OleDbType.VarChar, 255).Value =Kayword3 ;
            cm.Parameters.Add("Kayword4", OleDbType.VarChar, 255).Value =Kayword4 ;
            cm.Parameters.Add("Kayword5", OleDbType.VarChar, 255).Value =Kayword5 ;
            cm.Parameters.Add("Kayword6", OleDbType.VarChar, 255).Value =Kayword6 ;
            cm.Parameters.Add("Kayword7", OleDbType.VarChar, 255).Value =Kayword7 ;
            cm.Parameters.Add("Adult", OleDbType.VarChar, 255).Value =Adult ;
            cm.Parameters.Add("Price", OleDbType.VarChar, 255).Value =Price ;
            cm.Parameters.Add("Category1", OleDbType.VarChar, 255).Value =Category1 ;
            cm.Parameters.Add("Category2", OleDbType.VarChar, 255).Value =Category2 ;
            cm.Parameters.Add("size_paper", OleDbType.VarChar, 255).Value =size_paper ;
            cm.Parameters.Add("type_paper", OleDbType.VarChar, 255).Value =type_paper ;
            cm.Parameters.Add("Bleed", OleDbType.VarChar, 255).Value =Bleed ;
            cm.Parameters.Add("Finish", OleDbType.VarChar, 255).Value =Finish ;
            cm.Parameters.Add("Interior_File", OleDbType.VarChar, 255).Value =Interior_File ;
            cm.Parameters.Add("ISBN", OleDbType.VarChar, 255).Value =ISBN ;
        MD.Execute(cm);

        }
        public void Modifier_Book()
        {
            cm = new OleDbCommand("Update Book set Book_title=?,sub_title=?,Prefix=?,First_Name=?,Mid_Name=?,Last_Name=?,Suffix=?,Description=?,Kayword1=?,Kayword2=?,Kayword3=?,Kayword4=?,Kayword5=?,Kayword6=?,Kayword7=?,Adult=?,Price=?,Category1=?,Category2=?,size_paper=?,type_paper=?,Bleed=?,Finish=?,Interior_File=?,ISBN=? where NBook=?", MD.Con);//25
            cm.Parameters.Add("Book_title", OleDbType.VarChar, 255).Value = Book_title;
            cm.Parameters.Add("sub_title", OleDbType.VarChar, 255).Value = sub_title;
            cm.Parameters.Add("Prefix", OleDbType.VarChar, 255).Value = Prefix;
            cm.Parameters.Add("First_Name", OleDbType.VarChar, 255).Value = First_Name;
            cm.Parameters.Add("Mid_Name", OleDbType.VarChar, 255).Value = Mid_Name;
            cm.Parameters.Add("Last_Name", OleDbType.VarChar, 255).Value = Last_Name;
            cm.Parameters.Add("Suffix", OleDbType.VarChar, 255).Value = Suffix;
            cm.Parameters.Add("Description", OleDbType.LongVarChar).Value = Description;
            cm.Parameters.Add("Kayword1", OleDbType.VarChar, 255).Value = Kayword1;
            cm.Parameters.Add("Kayword2", OleDbType.VarChar, 255).Value = Kayword2;
            cm.Parameters.Add("Kayword3", OleDbType.VarChar, 255).Value = Kayword3;
            cm.Parameters.Add("Kayword4", OleDbType.VarChar, 255).Value = Kayword4;
            cm.Parameters.Add("Kayword5", OleDbType.VarChar, 255).Value = Kayword5;
            cm.Parameters.Add("Kayword6", OleDbType.VarChar, 255).Value = Kayword6;
            cm.Parameters.Add("Kayword7", OleDbType.VarChar, 255).Value = Kayword7;
            cm.Parameters.Add("Adult", OleDbType.VarChar, 255).Value = Adult;
            cm.Parameters.Add("Price", OleDbType.VarChar, 255).Value = Price;
            cm.Parameters.Add("Category1", OleDbType.VarChar, 255).Value = Category1;
            cm.Parameters.Add("Category2", OleDbType.VarChar, 255).Value = Category2;
            cm.Parameters.Add("size_paper", OleDbType.VarChar, 255).Value = size_paper;
            cm.Parameters.Add("type_paper", OleDbType.VarChar, 255).Value = type_paper;
            cm.Parameters.Add("Bleed", OleDbType.VarChar, 255).Value = Bleed;
            cm.Parameters.Add("Finish", OleDbType.VarChar, 255).Value = Finish;
            cm.Parameters.Add("Interior_File", OleDbType.VarChar, 255).Value = Interior_File;
            cm.Parameters.Add("ISBN", OleDbType.VarChar, 255).Value = ISBN;
    cm.Parameters.Add("NBook", OleDbType.Numeric).Value = NBook;
            MD.Execute(cm);

        }
        public void Supprimer_Book()
        {
            cm = new OleDbCommand("delete from Book  where NBook=?", MD.Con);//25
            
            cm.Parameters.Add("NBook", OleDbType.Numeric).Value = NBook;
            MD.Execute(cm);

        }
        public DataTable  Liste_Books()
        {
            cm = new OleDbCommand("select * from Book  ", MD.Con);//25

            //cm.Parameters.Add("NBook", OleDbType.Numeric).Value = NBook;
           return MD.remplir(cm);

        }
        //private DataTable 
        public int Max_N_Book()
        {
            DataTable t = new DataTable();
            cm = new OleDbCommand("select Max(NBook) from Book  ", MD.Con);//25
            t=MD.remplir(cm);
            if (t.Rows.Count > 0)
            {
                return int.Parse(t.Rows[0][0].ToString());
            }
            else
            {
                return 0;
            }
        }
        public void Affater_Book()
        {
            DataTable t = new DataTable();
            cm = new OleDbCommand("select * from Book  where NBook=?", MD.Con);//25
            cm.Parameters.Add("NBook", OleDbType.Numeric).Value = NBook;
            //set Book_title=?,sub_title=?,Prefix=?,First_Name=?,Mid_Name=?,Last_Name=?,Suffix=?,Description=?,Kayword1=?,Kayword2=?,Kayword3=?,Kayword4=?,Kayword5=?,Kayword6=?,Kayword7=?,Adult=?,Price=?,Category1=?,Category2=?,size_paper=?,type_paper=?,Bleed=?,Finish=?,Interior_File=?,ISBN=?
            t=MD.remplir(cm);
            if(t.Rows.Count  > 0)
            {
                Book_title = t.Rows[0]["Book_title"].ToString();
 sub_title= t.Rows[0]["sub_title"].ToString();
                 Prefix= t.Rows[0]["Prefix"].ToString();
                 First_Name= t.Rows[0]["First_Name"].ToString();
                 Mid_Name= t.Rows[0]["Mid_Name"].ToString();
                 Last_Name= t.Rows[0]["Last_Name"].ToString();
                 Suffix= t.Rows[0]["Suffix"].ToString();
                 Description= t.Rows[0]["Description"].ToString();
                 Kayword1= t.Rows[0]["Kayword1"].ToString();
                 Kayword2= t.Rows[0]["Kayword2"].ToString();
                 Kayword3= t.Rows[0]["Kayword3"].ToString();
                 Kayword4= t.Rows[0]["Kayword4"].ToString();
                 Kayword5= t.Rows[0]["Kayword5"].ToString();
                 Kayword6= t.Rows[0]["Kayword6"].ToString();
                 Kayword7= t.Rows[0]["Kayword7"].ToString();
                 Adult= t.Rows[0]["Adult"].ToString();
                 Price= t.Rows[0]["Price"].ToString();
                 Category1= t.Rows[0]["Category1"].ToString();
                 Category2= t.Rows[0]["Category2"].ToString();
                 size_paper= t.Rows[0]["size_paper"].ToString();
                 type_paper= t.Rows[0]["type_paper"].ToString();
                 Bleed= t.Rows[0]["Bleed"].ToString();
                 Finish= t.Rows[0]["Finish"].ToString();
                 Interior_File= t.Rows[0]["Interior_File"].ToString();
                 ISBN= t.Rows[0]["ISBN"].ToString();
               
            }
            else
            {
                Book_title = "";
            }
        }
    }
}
