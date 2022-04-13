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
    public partial class SelectLogin : Form
    {
        public SelectLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(OpenLoginAsUser);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            
        }
        void OpenLoginAsUser()
        {
            Application.Run(new LoginAsLibrarian());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(OpenLoginAsAdmin);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void OpenLoginAsAdmin()
        {
            Application.Run(new LoginAsAdmin());
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
