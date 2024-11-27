using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentViolationReport
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            btn_LogIn.Click += Btn_LogIn_Click;
            btn_CreateAccount.Click += Btn_CreateAccount_Click;
        }

        private void Btn_LogIn_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            string connectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=UniformPolicyDB;Integrated Security=True"; //laging pangalan ng DB pag gagawa: UniformPolicyDB
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                try
                {
                    connection.Open();
                    int userCount = (int)command.ExecuteScalar();

                    if (userCount > 0)
                    {
                        FrmCreateViolation createViolationForm = new FrmCreateViolation();
                        createViolationForm.Show(); 
                        this.Hide(); 
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
        private void Btn_CreateAccount_Click(object sender, EventArgs e)
        {
            FrmUserCreate userCreate = new FrmUserCreate();
            userCreate.ShowDialog();
        }
    }
}