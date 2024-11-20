using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace StudentViolationList
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            btn_CreateAccount.Click += btn_CreateAccount_Click;
        }
        private void btn_CreateAccount_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            string confirmPassword = tbConfirmpassword.Text;
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))

            {
                MessageBox.Show("Please fill in all fields.");
            return;
            }
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }
            //for SQL pa to kelangan install ng SQL sa laptop or PC or Admin access sa ComLab
            //pero since prototyping palang StreamFile muna
            SaveUserData(name, username, password);

            Form2 form2 = new Form2();
            form2.Show();
            this.Close();
        }
        //SQL underconstruction pa kailangan may laptop/pc para sa pathfile! 
        //wag kalimutan i-run as admin para maselect SQL Server
        private void SaveUserData(string name, string username, string password)
        {
            // SqlConnection connection = new SqlConnection();
            // SqlCommand command = new SqlCommand("INSERT INTO Users (Name, Username, Password) VALUES (@Name, @Username, @Password)", connection);
            // command.Parameters.AddWithValue("@Name", name);
            // command.Parameters.AddWithValue("@Username", username);
            // command.Parameters.AddWithValue("@Password",   
            // password);
            // connection.Open();
            // command.ExecuteNonQuery();
            // connection.Close();

            //Streamfile muna tayo habang prototype palang
            try
            {
                using (StreamWriter writer = new StreamWriter("credentials.txt", true)) //default path loob ng Debug Folder
                {
                    string data = $"{name},{username},{password}";
                    writer.WriteLine(data);
                }

                MessageBox.Show("Account created successfully!");
            }
                catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message);
            }
        }
    }
}
