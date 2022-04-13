using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class NewLibrarian : Form
    {
        LibraryEntities db = new LibraryEntities();
        public NewLibrarian()
        {
            InitializeComponent();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            User u = new User();
            u.UserName = txtUserName.Text;
            u.Password = txtPassword.Text;
            u.Phone = txtPhone.Text;
            u.Address = txtAddress.Text;
            
            db.Users.Add(u);
            db.SaveChanges();
            MessageBox.Show("تم الحفظ");
        }
    }
}
