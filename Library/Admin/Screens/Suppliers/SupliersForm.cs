using Library.Admin.Screens.Suppliers;
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

namespace Library.Librarian.Screens.Customer
{
    public partial class SuppliersForm : Form
    {
        LibraryEntities db = new LibraryEntities();
        int id;
        public SuppliersForm()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NewSupplier newSupplier = new NewSupplier();
            newSupplier.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("هل تريد الحذف ؟", "تأكيد الحذف", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                var result = db.Suppliers.Find(id);
                db.Suppliers.Remove(result);
                db.SaveChanges();
                dgv.DataSource = db.Suppliers.ToList();
                MessageBox.Show("تم الحذف");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                dgv.DataSource = db.Suppliers.Where(x => x.Phone.Contains(txtPhone.Text)).ToList();
            }
            else if(txtPhone.Text == "")
            {
                dgv.DataSource = db.Suppliers.Where(x=>x.Name.Contains(txtName.Text)).ToList();
            }
            else
            {
                dgv.DataSource = db.Suppliers.Where(x => x.Phone.Contains(txtPhone.Text) || x.Name.Contains(txtName.Text)).ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgv.DataSource = db.Suppliers.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = db.Suppliers.SingleOrDefault(x => x.Id == id);
            var r = MessageBox.Show("هل تريد تأكيد التعديل ؟", "تأكيد التعديل", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                result.Name = txtFrmName.Text;
                result.Phone = txtFrmPhone.Text;
                result.email = txtMail.Text;
                result.Address = txtAddress.Text;
                result.Compony = txtCompony.Text;
                result.IsActive = checkBox1.Checked;


                db.SaveChanges();
                dgv.DataSource = db.Suppliers.ToList();
                MessageBox.Show("تم التعديل بنجاح");
                
            }
        }

        private void Backbtn_Click(object sender, EventArgs e)
        {

            this.Close();
            Thread th = new Thread(OpenAdminHomeScreen);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }
        void OpenAdminHomeScreen()
        {
            Application.Run(new AdminHomeScreen());
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SupliersForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'libraryDataSet20.Supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter.Fill(this.libraryDataSet20.Supplier);

        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(dgv.CurrentRow.Cells[0].Value.ToString());
                var result = db.Suppliers.SingleOrDefault(x => x.Id == id);
                txtFrmName.Text = result.Name;
                txtFrmPhone.Text = result.Phone;
                txtAddress.Text = result.Address;
                txtCompony.Text = result.Compony;
                txtMail.Text = result.email;
                checkBox1.Checked = result.IsActive.Value;
            }
            catch { }
        }
    }
}
