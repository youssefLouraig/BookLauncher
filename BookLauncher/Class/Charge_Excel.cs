using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using excel = Microsoft.Office.Interop.Excel;

namespace BookLauncher.Class
{
    class Charge_Excel
    {
        public string cheminfile;
        public List<Book> Books { set; get; }
        public void Import_Data()
        {
            excel.Application App = new excel.Application();
            excel.Workbook xwork = App.Workbooks.Open(cheminfile);
            excel._Worksheet xsheet = xwork.Sheets[1];
            excel.Range rng = xsheet.UsedRange;
int indx = 2;
            string s=rng.Cells[indx][1].value2;
            if (rng.Cells[1][1].value2!= "Interior File Path")
            {
System.Windows.Forms.MessageBox.Show("Wrong file");
                return;
            }
           
            

            while (s!="")
            {
                Book bk = new Book();
                bk.Interior_File = s;
                bk.Cover_File= rng.Cells[indx][2].value2;
                bk.Book_title=rng.Cells[indx][3].value2;
                bk.sub_title=rng.Cells[indx][4].value2;
                bk.Prefix = rng.Cells[indx][5].value2;
                bk.First_Name = rng.Cells[indx][6].value2;
                bk.Mid_Name = rng.Cells[indx][7].value2;
                bk.Last_Name = rng.Cells[indx][8].value2;
                bk.Suffix = rng.Cells[indx][9].value2;
                bk.Description = rng.Cells[indx][10].value2;
                bk.Kayword1 = rng.Cells[indx][11].value2;
                bk.Kayword2 = rng.Cells[indx][12].value2;
                bk.Kayword3 = rng.Cells[indx][13].value2;
                bk.Kayword4 = rng.Cells[indx][14].value2;
                bk.Kayword5 = rng.Cells[indx][15].value2;
                bk.Kayword6 = rng.Cells[indx][16].value2;
                bk.Kayword7 = rng.Cells[indx][17].value2;
                bk.Price = rng.Cells[indx][18].value2;
                TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                bk.Category1 = ti.ToTitleCase(rng.Cells[indx][19].value2);
                bk.Category2 = ti.ToTitleCase(rng.Cells[indx][20].value2);
                bk.ISBN = rng.Cells[indx][21].value2;
                //bk. = rng.Cells[indx][22].value2;
                //bk. = rng.Cells[indx][23].value2;
                //bk. = rng.Cells[indx][].value2;
                Books.Add(bk);
                indx++;
                s = rng.Cells[indx][1].value2;
            }
            
        }
    }
}
