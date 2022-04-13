using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.Librarian.Screens.Customer
{
    public partial class NewCustomer : Form
    {
        LibraryEntities db = new LibraryEntities();

        public NewCustomer()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("هل أنت متاكد من إضافة هذا العميل كعميل جديد ؟", "إضافة عميل جديد", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                if (txtFrmName.Text == "" || txtFrmPhone.Text == "")
                {
                    MessageBox.Show("برجاء إكمال البيانات المطلوبة أولا");
                }
                else
                {
                    Library.Customer c = new Library.Customer();
                    c.Name = txtFrmName.Text;
                    c.Phone = txtFrmPhone.Text;
                    c.email = txtMail.Text;
                    c.Address = txtAddress.Text;
                    c.IsActive = checkBox1.Checked;



                    db.Customers.Add(c);
                    db.SaveChanges();

                    
                    MessageBox.Show("تم إضافة المورد");
                    txtFrmName.Text = "";
                    txtFrmPhone.Text = "";
                    txtMail.Text = "";
                    txtAddress.Text = "";
                    checkBox1.Checked = false;

                }
            }
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
