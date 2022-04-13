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

namespace Library.Librarian
{
    public partial class LibrarianHomeScreen : Form
    {
        LibraryEntities db = new LibraryEntities();

        public LibrarianHomeScreen()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        private void txtinvNum_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void LibrarianHomeScreen_Load(object sender, EventArgs e)
        {
          
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(OpenSalesBillForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }
        void OpenSalesBillForm()
        {
            Application.Run(new SalesBillForm());
        }

        private void sallesBillToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Close();
            Thread th = new Thread(OpenSalesBillForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();
            Thread th = new Thread(OpenCustomersFrm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }
        void OpenCustomersFrm()
        {
            Application.Run(new CustomersFrm());
        }

        private void addNewLibrarianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(OpenCustomersFrm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
    }
}
