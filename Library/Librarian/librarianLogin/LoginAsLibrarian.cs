using Library.Librarian;
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
    public partial class LoginAsLibrarian : Form
    {
        LibraryEntities db = new LibraryEntities();
        public LoginAsLibrarian()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewLibrarian newUser = new NewLibrarian();
            newUser.Show();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            var result = db.Users.FirstOrDefault(x => x.UserName == txtUser.Text && x.Password == txtPassword.Text);
            if (result != null)
            {
                this.Close();

                Thread th = new Thread(OpenLibrarianHomeScreen);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();


                Users.Name = result.UserName;
                Users.Id = result.Id;

            }
            else
            {
                MessageBox.Show("UserName or Password is incorrect");
            }
        }
        void OpenLibrarianHomeScreen()
        {
            Application.Run(new LibrarianHomeScreen());
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
    }
    
    static class Users
    {
        static public string Name { get; set; }
        static public int Id { get; set; }
    }
}
