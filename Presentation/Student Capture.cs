using PRG_Project_Final.Data_Layer;
using PRG_Project_Final.Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PRG_Project_Final.Presentation
{
    public partial class Student_Capture : Form
    {
        public Student_Capture()
        {
            InitializeComponent();
        }

        DataHandler handler = new DataHandler();

        private void button3_Click(object sender, EventArgs e)
        {
            Students student = new Students(txtStNo.Text, txtFName.Text, dteDOB.Value, cbxGender.SelectedItem.ToString(), txtPhone.Text, txtAddress.Text, cbxModules.SelectedItem.ToString());
            handler.Capture(student);
            dataGridView1.DataSource = handler.GetStudents();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Students student = new Students(txtStNo.Text, txtFName.Text, dteDOB.Value, cbxGender.SelectedItem.ToString(), txtPhone.Text, txtAddress.Text, cbxModules.SelectedItem.ToString());
            handler.Update(student);
            dataGridView1.DataSource = handler.GetStudents();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Students student = new Students();
            student.StuNo = txtSearch.Text;
            handler.Delete(student.StuNo);
            dataGridView1.DataSource = handler.GetStudents();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = handler.GetStudents();
        }

        private void btnModules_Click(object sender, EventArgs e)
        {
            Modules modules = new Modules();
            modules.Show();
        }

        private void Student_Capture_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";
                openFileDialog.Title = "Select a Picture";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;
                    Image selectedImage = Image.FromFile(selectedImagePath);
                    pictureBox1.Image = selectedImage;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string input = txtSearch.Text;
            dataGridView1.DataSource = handler.searchValue(input);
        }
    }
}
