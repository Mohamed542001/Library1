using Library.Admin.AdminScreens.adminHorror;
using Library.Admin.Screens.Books;
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

namespace Library
{
    public partial class BooksList : Form
    {
        LibraryEntities db = new LibraryEntities();
        string imagePath = "";
        
        int id;
        public BooksList()
        {
            InitializeComponent();
            comboBox1.DataSource = db.Departments.ToList();
            comboBox2.DataSource = db.Departments.ToList();
            dgv.DataSource = db.Books.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NewBook h = new NewBook();
            h.Show();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
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

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")

                dgv.DataSource = db.Books.Where(x => x.Code ==txtEditCode.Text).ToList();

            else
                dgv.DataSource = db.Books.Where(x => x.Code == txtEditCode.Text || x.Name.Contains(txtName.Text)).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgv.DataSource = db.Books.ToList();
            comboBox1.DataSource = db.Departments.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var result = db.Books.SingleOrDefault(x => x.Id == id);

            result.Name = txtEditName.Text;
            result.Note = txtNotes.Text;
            result.Price = decimal.Parse(txtPrice.Text);
            result.Qty = int.Parse(txtQty.Text);
            result.Department_Id = (int)comboBox1.SelectedValue;

            db.SaveChanges();
            dgv.DataSource = db.Books.ToList();
            MessageBox.Show("تم التعديل بنجاح");
            if (imagePath != "")
            {
                string newpath = Environment.CurrentDirectory + "\\images\\Books\\" + result.Id + ".jpg";
                File.Copy(imagePath, newpath, true);

                result.Image = newpath;
                db.SaveChanges();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("هل تريد الحذف ؟", "تأكيد الحذف", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                var result = db.Books.Find(id);
                db.Books.Remove(result);
                db.SaveChanges();
                dgv.DataSource = db.Books.ToList();
                MessageBox.Show("تم الحذف");
            }
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(dgv.CurrentRow.Cells[0].Value.ToString());
                var result = db.Books.SingleOrDefault(x => x.Id == id);
                txtEditName.Text = result.Name;
                txtNotes.Text = result.Note;
                txtPrice.Text = result.Price.ToString();
                txtQty.Text = result.Qty.ToString();
                pictureBox1.ImageLocation = result.Image;
                comboBox1.SelectedValue = result.Department_Id;
            }
            catch { }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imagePath = dialog.FileName;
                pictureBox2.ImageLocation = dialog.FileName;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imagePath = dialog.FileName;
                pictureBox2.ImageLocation = dialog.FileName;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CatId = (int)comboBox2.SelectedValue;
            dgv.DataSource = db.Books.Where(x => x.Department_Id == CatId).ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BookDepartment b = new BookDepartment();
            b.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BooksList_Load(object sender, EventArgs e)
        {

        }
    }
}
