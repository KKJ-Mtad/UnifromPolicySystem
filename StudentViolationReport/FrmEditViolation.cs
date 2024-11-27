using DataAccessLibrary;
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
    public partial class FrmEditViolation : Form
    {
        private string Id;
        public FrmEditViolation(string id, string name, string date, string studentId, string course, string yearLevel, string violation)
        {
            InitializeComponent();
            Id = id;
            txtName.Text = name;
            dateTimePickerDate.Value = DateTime.Parse(date);
            txtStudentID.Text = studentId;
            comboBoxCourse.SelectedItem = course;
            comboBoxYearLevel.SelectedItem = yearLevel;
            checkedListBoxViolations.Text = violation;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string query = @"UPDATE Violations SET 
                         Name = @Name, 
                         Date = @Date, 
                         StudentID = @StudentID, 
                         Course = @Course, 
                         YearLevel = @YearLevel, 
                         Violation = @Violation
                         WHERE Id = @Id";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Name", txtName.Text),
            new SqlParameter("@Date", dateTimePickerDate.Value),
            new SqlParameter("@StudentID", txtStudentID.Text),
            new SqlParameter("@Course", comboBoxCourse.SelectedItem?.ToString()),
            new SqlParameter("@YearLevel", comboBoxYearLevel.SelectedItem?.ToString()),
            new SqlParameter("@Violation", checkedListBoxViolations.Text),
            new SqlParameter("@Id", Id)
            };

            try
            {
                DatabaseHelper.ExecuteQuery(query, parameters);
                MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
