using CmboxLibrary;
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
            PopulateCourseComboBox();
            PopulateYearLevelComboBox();
            comboBoxCourse.SelectedItem = course ?? "";
            comboBoxYearLevel.SelectedItem = yearLevel ?? "";
            SetSelectedViolations(violation);
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
        }
        private void PopulateCourseComboBox()
        {
            comboBoxCourse.Items.Clear();
            foreach (var course in CmboxLibrary.CmboxList.AllCourses)
            {
                comboBoxCourse.Items.Add(course);
            }
        }
        private void PopulateYearLevelComboBox()
        {
            comboBoxYearLevel.Items.Clear();
            foreach (var yearLevel in CmboxLibrary.CmboxList.YearLevels)
            {
                comboBoxYearLevel.Items.Add(yearLevel);
            }
        }
        private void SetSelectedViolations(string violations)
        {
            foreach (var item in violations.Split(','))
            {
                for (int i = 0; i < checkedListBoxViolations.Items.Count; i++)
                {
                    if (checkedListBoxViolations.Items[i].ToString().Trim() == item.Trim())
                    {
                        checkedListBoxViolations.SetItemChecked(i, true);
                    }
                }
            }
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
            new SqlParameter("@Course", comboBoxCourse.SelectedItem?.ToString() ?? ""),
            new SqlParameter("@YearLevel", comboBoxYearLevel.SelectedItem?.ToString() ?? ""),
            new SqlParameter("@Violation", GetSelectedViolations()),
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

        private string GetSelectedViolations()
        {
            string violations = string.Empty;
            foreach (var item in checkedListBoxViolations.CheckedItems)
            {
                violations += item.ToString() + ", ";
            }
            return violations.TrimEnd(',', ' ');
        }
    }
}
