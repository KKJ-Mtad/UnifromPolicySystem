using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //remove if using SQL na!

namespace StudentViolationList
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            btn_LogIn.Click += btn_LogIn_Click;
            btn_CreateAccount.Click += btn_CreateAccount_Click;
        }
        private void btn_LogIn_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            string[] savedCredentials = ReadCredentialsFromFile();
            if (savedCredentials != null)
            {
                string savedUsername = savedCredentials[1];
                string savedPassword = savedCredentials[2];
                if (username == "test" && password == "test") //pang test, default siya no need create account
                {
                    MessageBox.Show("Login successful!");
                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Hide();
                    return;
                }
                if (username == savedUsername && password == savedPassword)
                {
                    MessageBox.Show("Login successful!");
                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Hide();
                    return;
                }
            }
            MessageBox.Show("Invalid username or password.");
        }
        private string[] ReadCredentialsFromFile()
        {
            try
            {
                if (File.Exists("credentials.txt"))
                {
                    string[] lines = File.ReadAllLines("credentials.txt");
                    if (lines.Length > 0)
                    {
                        return lines[0].Split(',');
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading credentials file: " + ex.Message);
            }

            return null;
        }

        private void btn_CreateAccount_Click(object sender, EventArgs e)
        {
            Form3 createAccountForm = new Form3();
            createAccountForm.Show();
            this.Hide();
        }
    }
}
