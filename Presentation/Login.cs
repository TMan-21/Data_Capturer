using PRG_Project_Final.Data_Layer;
using PRG_Project_Final.Presentation;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PRG_Project_Final
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            FileHandler handler = new FileHandler();
            bool isAuthenticated = false;

            foreach (var pas in handler.readfromfile())
            {
                if (txtUser.Text == pas.Key && txtPassword.Text == pas.Value)
                {
                    isAuthenticated = true;
                    break;
                }
            }

            if (isAuthenticated)
            {
                Student_Capture stu = new Student_Capture();
                stu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            FileHandler handler = new FileHandler();
            handler.writeToFile(txtUser.Text, txtPassword.Text);
            MessageBox.Show("New user successfully added");

            Login login = new Login();
            login.Show();
            
        }
    }
}
