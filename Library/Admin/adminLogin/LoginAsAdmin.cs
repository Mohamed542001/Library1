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

namespace Library
{
    public partial class LoginAsAdmin : Form
    {
        LibraryEntities db = new LibraryEntities();
        public LoginAsAdmin()
        {
            InitializeComponent();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Backbtn_Click(object sender, EventArgs e)
        {

            this.Close();
            Thread th = new Thread(OpenMain);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }
        void OpenMain()
        {
            Application.Run(new SelectLogin());
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            var result = db.admins.Where(x => x.UserName == txtUser.Text && x.Password == txtPassword.Text).ToList();
            if (result.Count() > 0)
            {
                this.Close();

                Thread th = new Thread(OpenHomeScreen);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                MessageBox.Show("UserName or Password is incorrect");
            }
        }
        void OpenHomeScreen()
        {
            Application.Run(new AdminHomeScreen());
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
