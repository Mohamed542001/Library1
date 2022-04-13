using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.Librarian
{
    public partial class SalesBillListData : Form
    {
        LibraryEntities db = new LibraryEntities();
        public SalesBillListData()
        {
            InitializeComponent();

            dgv2.DataSource = db.Sales_Bills.Select(x=>new { x.Id, x.Total, x.User.UserName, x.Customer.Name, x.Date}).ToList();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void SalesBillListData_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'libraryDataSet17.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter1.Fill(this.libraryDataSet17.Customer);

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv2_SelectionChanged(object sender, EventArgs e)
        {
            int id = int.Parse(dgv2.CurrentRow.Cells[0].Value.ToString());
            var bill = db.Sales_Bills.FirstOrDefault(x => x.Id == id);
            textNumber.Text = bill.Id.ToString();
            txtNote.Text = bill.Note;
            lblTotalAfterDiscount.Text = bill.TotalAfterDiscount.ToString();
            lblTotal.Text = bill.Total.ToString();
            dateTimePicker1.Value = (DateTime)bill.Date;
            txtDisc.Text = bill.Discount.ToString();
            comboBox1.SelectedValue = bill.Customer.Id;

            dataGridView1.Rows.Clear();
            foreach (var item in bill.SalesBillDetails)
            {
                dataGridView1.Rows.Add(
                    item.BookId,
                    item.Book.Name,
                    item.Price,
                    item.Quantity,
                    item.TotalPrice,
                    item.Book.Image == null ? new Bitmap(40,40 ) : Image.FromFile(item.Book.Image));
            }

        }
    }
}
