using CmboxLibrary;
using DataAccessLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentViolationReport
{
    public partial class FrmUserCreate : Form
    {
        public FrmUserCreate()
        {
            InitializeComponent();
            btn_CreateAccount.Click += Btn_CreateAccount_Click;
        }

        private void Btn_CreateAccount_Click(object sender, EventArgs e)
        {
            string name = tbName.Text.Trim();
            string username = tbUsername.Text.Trim();
            string password = tbPassword.Text;
            string confirmPassword = tbConfirmpassword.Text;
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string query = "INSERT INTO Users (Name, Username, Password) VALUES (@Name, @Username, @Password)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Name", name),
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };
            try
            {
                DatabaseHelper.ExecuteQuery(query, parameters);
                SaveToFile(name, username, password);
                MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FrmLogin loginForm = new FrmLogin();
                loginForm.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveToFile(string name, string username, string password)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("credentials.txt", true))
                {
                    writer.WriteLine($"{name},{username},{password}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving to file: {ex.Message}", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}