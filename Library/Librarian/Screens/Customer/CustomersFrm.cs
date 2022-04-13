using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.Librarian.Screens.Customer
{
    public partial class CustomersFrm : Form
    {
        LibraryEntities db = new LibraryEntities();
        int id;
        public CustomersFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                dgv.DataSource = db.Customers.Where(x => x.Phone.Contains(txtPhone.Text)).ToList();
            }
            else if (txtPhone.Text == "")
            {
                dgv.DataSource = db.Customers.Where(x => x.Name.Contains(txtName.Text)).ToList();
            }
            else
            {
                dgv.DataSource = db.Customers.Where(x => x.Phone.Contains(txtPhone.Text) || x.Name.Contains(txtName.Text)).ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgv.DataSource = db.Customers.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NewCustomer newCustomer = new NewCustomer();
            newCustomer.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = db.Customers.SingleOrDefault(x => x.Id == id);
            var r = MessageBox.Show("هل تريد تأكيد التعديل ؟", "تأكيد التعديل", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                result.Name = txtFrmName.Text;
                result.Phone = txtFrmPhone.Text;
                result.email = txtMail.Text;
                result.Address = txtAddress.Text;
                result.IsActive = checkBox1.Checked;


                db.SaveChanges();
                dgv.DataSource = db.Customers.ToList();
                MessageBox.Show("تم التعديل بنجاح");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("هل تريد الحذف ؟", "تأكيد الحذف", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                var result = db.Customers.Find(id);
                db.Customers.Remove(result);
                db.SaveChanges();
                dgv.DataSource = db.Customers.ToList();
                MessageBox.Show("تم الحذف");
            }
        }

        private void CustomersFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'libraryDataSet21.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.libraryDataSet21.Customer);

            txtFrmName.Focus();
            txtFrmName.Select();
            txtFrmName.SelectAll();

        }

        private void Backbtn_Click(object sender, EventArgs e)
        {

            this.Close();
            Thread th = new Thread(OpenLibrarianHomeScreen);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }
        void OpenLibrarianHomeScreen()
        {
            Application.Run(new LibrarianHomeScreen());
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(dgv.CurrentRow.Cells[0].Value.ToString());
                var result = db.Customers.SingleOrDefault(x => x.Id == id);
                txtFrmName.Text = result.Name;
                txtFrmPhone.Text = result.Phone;
                txtAddress.Text = result.Address;
                txtMail.Text = result.email;
                checkBox1.Checked = result.IsActive.Value;
            }
            catch { }
        }

        private void txtFrmName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                txtFrmPhone.Focus();
                txtFrmPhone.SelectAll();
            }
        }
    }
}
