using Library.Admin.AdminScreens.adminHorror;
using Library.Librarian;
using Library.Librarian.Screens.Customer;
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
    public partial class AdminHomeScreen : Form
    {
        public AdminHomeScreen()
        {
            InitializeComponent();
        }

        private void HomeScreen_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {

            

        }
        

        private void button1_Click(object sender, EventArgs e)
        {

           

        }
       

        private void button2_Click(object sender, EventArgs e)
        {

           
        }
        

        private void button5_Click(object sender, EventArgs e)
        {

            this.Close();
            Thread th = new Thread(OpenBooksList);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }
        void OpenBooksList()
        {
            Application.Run(new BooksList());
        }

        private void button4_Click(object sender, EventArgs e)
        {


        }
      

        private void button3_Click(object sender, EventArgs e)
        {
        }
        

        private void sallesBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesBillForm salesBillForm = new SalesBillForm();
            salesBillForm.Show();
        }

        private void addNewLibrarianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewLibrarian frm = new NewLibrarian();
            frm.Show();
        }

        private void addNewLibrarianToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            NewLibrarian frm = new NewLibrarian();
            frm.Show();
        }

        private void addNewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewBook newBook = new NewBook();
            newBook.Show();
        }

        private void showAllBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BooksList booksList = new BooksList();
            booksList.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            this.Close();
            Thread th = new Thread(OpenSupplierForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }
        void OpenSupplierForm()
        {
            Application.Run(new SuppliersForm());
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
