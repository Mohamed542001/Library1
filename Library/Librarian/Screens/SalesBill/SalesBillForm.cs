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
    public partial class SalesBillForm : Form
    {
        LibraryEntities db = new LibraryEntities();
        List<Book> books;
        public SalesBillForm()
        {
            InitializeComponent();
            books = db.Books.ToList();

            lblUser.Text = Users.Name;
        }

        private void SalesBillForm_Load(object sender, EventArgs e)
        {
            this.customerTableAdapter.FillBy1(this.libraryDataSet16.Customer);

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Image != null)
                {
                    imageList1.Images.Add(Image.FromFile(books[i].Image));
                }
                else
                {
                    Bitmap btm = new Bitmap(80, 80);
                    imageList1.Images.Add(btm);
                }

                ListViewItem item = new ListViewItem();
                item.Text = books[i].Name;
                item.ImageIndex = i;
                item.Tag = books[i];

                listView1.Items.Add(item);

            }


        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void CalculateTotal()
        {
            try
            {
                decimal total = 0;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    total += decimal.Parse(dataGridView1.Rows[i].Cells["totalPrice"].Value.ToString());
                }
                lblTotal.Text = total.ToString();
                decimal discount = decimal.Parse(txtDisc.Text);

                lblTotalAfterDiscount.Text = (total - discount).ToString();
            }
            catch { }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                var book =(Book)listView1.SelectedItems[0].Tag;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if(dataGridView1.Rows[i].Cells["id"].Value.ToString() == book.Id.ToString())
                    {
                        dataGridView1.Rows[i].Cells["quantity"].Value =
                            int.Parse(dataGridView1.Rows[i].Cells["quantity"].Value.ToString()) + 1;
                        dataGridView1.Rows[i].Cells["totalPrice"].Value =
                            int.Parse(dataGridView1.Rows[i].Cells["quantity"].Value.ToString()) * 
                            decimal.Parse(dataGridView1.Rows[i].Cells["price"].Value.ToString());
                        CalculateTotal();
                        return;

                    }
                }

                dataGridView1.Rows.Add(
                    book.Id,
                    book.Name,
                    book.Price,
                    1,
                    (book.Price * 1),
                    book.Image ==null? new Bitmap(40,40) : Image.FromFile(book.Image));
                CalculateTotal();
            }
        }

        private void txtDisc_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void txtDisc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Library.Sales_Bill result = new Sales_Bill()
            {
                Date = (DateTime)dateTimePicker1.Value.Date,
                Discount = decimal.Parse(txtDisc.Text),
                Total = decimal.Parse(lblTotal.Text),
                TotalAfterDiscount = decimal.Parse(lblTotalAfterDiscount.Text),
                Note = txtNote.Text,
                CustomerId = int.Parse(comboBox1.SelectedValue.ToString()),
                UserId = Users.Id

            };

            List<SalesBillDetail> list = new List<SalesBillDetail>();
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                list.Add(new SalesBillDetail
                {
                    BookId = int.Parse(dataGridView1.Rows[i].Cells["id"].Value.ToString()),
                    Quantity = int.Parse(dataGridView1.Rows[i].Cells["quantity"].Value.ToString()),
                    Price = decimal.Parse(dataGridView1.Rows[i].Cells["price"].Value.ToString()),
                    TotalPrice = int.Parse(dataGridView1.Rows[i].Cells["quantity"].Value.ToString()) * decimal.Parse(dataGridView1.Rows[i].Cells["price"].Value.ToString()),
                });
            }

            result.SalesBillDetails = list;
            db.Sales_Bills.Add(result);
            db.SaveChanges();

            MessageBox.Show("تم الحفظ . رقم الفاتورة =" + result.Id);
            
            
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculateTotal();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SalesBillListData bills = new SalesBillListData();
            bills.Show();
        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {

        }
    }
}
