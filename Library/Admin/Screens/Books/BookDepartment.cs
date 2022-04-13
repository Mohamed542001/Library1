using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.Admin.Screens.Books
{
    public partial class BookDepartment : Form
    {
        LibraryEntities db = new LibraryEntities();
        public BookDepartment()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Department department = new Department();
            department.Name = txtName.Text;
            db.Departments.Add(department);
            db.SaveChanges();
            MessageBox.Show("تم إضافة الصنف");
            txtName.Text = "";
            comboBox1.DataSource = db.Departments.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Department d = new Department();
            d.Id = int.Parse(comboBox1.SelectedValue.ToString());
            db.Departments.Remove(d);
            db.SaveChanges();
            MessageBox.Show("تم الحذف");
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BookDepartment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'libraryDataSet19.Department' table. You can move, or remove it, as needed.
            this.departmentTableAdapter1.Fill(this.libraryDataSet19.Department);

        }
    }
}
