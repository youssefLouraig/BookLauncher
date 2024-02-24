using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BookLauncher.Class;
using System.Data.OleDb;
//using System.Data;
namespace BookLauncher.Forms
{
    public partial class Frm_ListeBooks : DevExpress.XtraEditors.XtraUserControl
    {
        public Frm_ListeBooks()
        {
            InitializeComponent();
        }
        DataTable tbook = new DataTable();
        Book Cbook = new Book();
        private static Frm_ListeBooks _ListBook;
        public static Frm_ListeBooks ListBook
        {
            get
            {
                if (_ListBook == null) _ListBook = new Frm_ListeBooks();
                return _ListBook;
            }
        }
        private void Frm_ListeBooks_Load(object sender, EventArgs e)
        {
            tbook = Cbook.Liste_Books();
            gridControl1.DataSource = tbook;
            gridView1.Columns[0].Caption = "N° Book";
            gridView1.Columns[1].Caption = "Book Title";
            gridView1.Columns[2].Caption = "Sub Title";
            gridView1.Columns[4].Caption = "First Name";
            gridView1.Columns[5].Caption = "Middle Name";
            gridView1.Columns[6].Caption = "Last Name";
        }
        public int Nbook;
        private void Benvoyer_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > -1)
            {
                int[] j=gridView1.GetSelectedRows();
                DataRow rw = gridView1.GetDataRow(j[0]);
                Nbook = int.Parse(rw[0].ToString());
                //this.DialogResult=DialogResult.OK;
            }
                
                
        }

        private void Bclose_Click(object sender, EventArgs e)
        {
            Parent.Controls.Remove(this);
        }
    }
}