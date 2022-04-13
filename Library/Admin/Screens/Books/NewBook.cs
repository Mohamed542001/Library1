using Library.Admin.Screens.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.Admin.AdminScreens.adminHorror
{
    public partial class NewBook : Form
    {
        LibraryEntities db = new LibraryEntities();
        string imagepath = "";
        public NewBook()
        {
            InitializeComponent();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtPrice.Text == "" || comboBox2.SelectedValue == null)
            {
                MessageBox.Show("برجاء إكمال البيانات المطلوبة أولا");
            }
            else
            {
                Book b = new Book();
                b.Name = txtName.Text;
                b.Note = txtNotes.Text;
                b.Department_Id = int.Parse(comboBox2.SelectedValue.ToString());
                //
                int qty, price;
                int.TryParse(txtQuantity.Text, out qty);
                int.TryParse(txtPrice.Text, out price);
                b.Price = price;
                b.Qty = qty;
                    

                db.Books.Add(b);
                db.SaveChanges();
                if (imagepath != "")
                {


                    string newpath = Environment.CurrentDirectory + "\\images\\Products\\" + b.Id + ".jpg";
                    File.Copy(imagepath, newpath);

                    b.Image = newpath;
                    db.SaveChanges();
                }
                MessageBox.Show("تم حفظ المنتج");
                txtName.Text = "";
                txtNotes.Text = "";
                txtPrice.Text = "";
                txtQuantity.Text = "";
                pictureBox1.ImageLocation = "";

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imagepath = dialog.FileName;
                pictureBox1.ImageLocation = dialog.FileName;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtEditCode_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            BookDepartment bookDepartment = new BookDepartment();
            bookDepartment.Show();
        }

        private void NewBook_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'libraryDataSet18.Department' table. You can move, or remove it, as needed.
            this.departmentTableAdapter1.Fill(this.libraryDataSet18.Department);

        }
    }
}
