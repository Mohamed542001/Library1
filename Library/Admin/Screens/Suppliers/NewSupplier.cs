using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.Admin.Screens.Suppliers
{
    public partial class NewSupplier : Form
    {
        LibraryEntities db = new LibraryEntities();
        public NewSupplier()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("هل أنت متاكد من إضافة هذا المورد كمورد جديد ؟", "إضافة مورد جديد", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                if (txtFrmName.Text == "" || txtFrmPhone.Text == "")
                {
                    MessageBox.Show("برجاء إكمال البيانات المطلوبة أولا");
                }
                else
                {
                    Supplier s = new Supplier();
                    s.Name = txtFrmName.Text;
                    s.Phone = txtFrmPhone.Text;
                    s.email = txtMail.Text;
                    s.Address = txtAddress.Text;
                    s.Compony = txtCompony.Text;
                    s.IsActive = checkBox1.Checked;



                    db.Suppliers.Add(s);
                    db.SaveChanges();

                    MessageBox.Show("تم إضافة المورد");
                    txtCompony.Text = "";
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
