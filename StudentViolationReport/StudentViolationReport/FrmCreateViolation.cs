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
    public partial class FrmCreateViolation : Form
    {
        public FrmCreateViolation()
        {
            InitializeComponent();
            PopulateCourseComboBox();
            PopulateYearLevelComboBox();
            btnCreate.Click += BtnCreate_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnExport.Click += BtnExport_Click;
            this.Load += FrmCreateViolation_Load1;
            this.FormClosed += FrmCreateViolation_FormClosed;
        }

        private void FrmCreateViolation_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void FrmCreateViolation_Load1(object sender, EventArgs e)
        {
            LoadRecentViolationsIntoDataGridView();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseHelper.EnsureTablesExist();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ensuring tables exist: " + ex.Message);
                return;
            }

            string name = txtName.Text;
            DateTime date = dateTimePickerDate.Value;
            string studentId = txtStudentID.Text;
            string course = comboBoxCourse.SelectedItem?.ToString();
            string yearLevel = comboBoxYearLevel.SelectedItem?.ToString();
            string violations = GetSelectedViolations();

            if (string.IsNullOrEmpty(course) || string.IsNullOrEmpty(yearLevel))
            {
                MessageBox.Show("Please select both Course and Year Level.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrEmpty(violations))
            {
                string query = @"INSERT INTO Violations (Name, Date, StudentID, Course, YearLevel, Violation)
                             VALUES (@Name, @Date, @StudentID, @Course, @YearLevel, @Violation)";

                using (SqlConnection connection = new SqlConnection("Data Source=(local)\\SQLEXPRESS;Initial Catalog=UniformPolicyDB;Integrated Security=True"))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@StudentID", studentId);
                    command.Parameters.AddWithValue("@Course", course);
                    command.Parameters.AddWithValue("@YearLevel", yearLevel);
                    command.Parameters.AddWithValue("@Violation", violations);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Violation added successfully!");
                        LoadRecentViolationsIntoDataGridView();
                        ClearForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select at least one violation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewViolations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to edit.", "Edit Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGridViewViolations.SelectedRows[0];
            FrmEditViolation editForm = new FrmEditViolation(
                selectedRow.Cells["Id"].Value.ToString(),
                selectedRow.Cells["Name"].Value.ToString(),
                selectedRow.Cells["Date"].Value.ToString(),
                selectedRow.Cells["StudentID"].Value.ToString(),
                selectedRow.Cells["Course"].Value.ToString(),
                selectedRow.Cells["YearLevel"].Value.ToString(),
                selectedRow.Cells["Violation"].Value.ToString()
            );

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadRecentViolationsIntoDataGridView();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewViolations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to delete.", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGridViewViolations.SelectedRows[0];
            string id = selectedRow.Cells["Id"].Value.ToString();

            DialogResult confirmResult = MessageBox.Show(
                "Are you sure you want to delete this record? This action cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmResult == DialogResult.Yes)
            {
                string query = "DELETE FROM Violations WHERE Id = @Id";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@Id", id)
                };

                try
                {
                    DatabaseHelper.ExecuteQuery(query, parameters);
                    MessageBox.Show("Record deleted successfully!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            if (dataGridViewViolations.Rows.Count == 0)
            {
                MessageBox.Show("No data to export!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderDialog.SelectedPath;
                    string filePath = Path.Combine(selectedPath, "ViolationsReport.txt");

                    try
                    {
                        using (StreamWriter writer = new StreamWriter(filePath))
                        {
                            foreach (DataGridViewRow row in dataGridViewViolations.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    writer.WriteLine($"ID: {row.Cells["Id"].Value}");
                                    writer.WriteLine($"Name: {row.Cells["Name"].Value}");
                                    writer.WriteLine($"Date: {Convert.ToDateTime(row.Cells["Date"].Value):MM/dd/yyyy}");
                                    writer.WriteLine($"StudentID: {row.Cells["StudentID"].Value}");
                                    writer.WriteLine($"Course: {row.Cells["Course"].Value}");
                                    writer.WriteLine($"YearLevel: {row.Cells["YearLevel"].Value}");
                                    writer.WriteLine($"Violation: {row.Cells["Violation"].Value}");
                                    writer.WriteLine(new string('-', 50)); // Adds a line separator
                                }
                            }
                        }

                        MessageBox.Show($"Report exported successfully to:\n{filePath}", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while exporting the report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
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
        private void LoadRecentViolationsIntoDataGridView()
        {
            string query = "SELECT Id, Name, Date, StudentID, Course, YearLevel, Violation FROM Violations ORDER BY Date DESC";
            try
            {
                DataTable violationsData = DatabaseHelper.ExecuteQuery(query);
                dataGridViewViolations.DataSource = violationsData;

                if (dataGridViewViolations.Columns["Id"] != null)
                {
                    dataGridViewViolations.Columns["Id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
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
        private void ClearForm()
        {
            txtName.Clear();
            txtStudentID.Clear();
            comboBoxCourse.SelectedIndex = -1;
            comboBoxYearLevel.SelectedIndex = -1;
            foreach (int i in checkedListBoxViolations.CheckedIndices)
            {
                checkedListBoxViolations.SetItemChecked(i, false);
            }
        }
        private void FrmCreateViolation_Load(object sender, EventArgs e)
        {
            LoadRecentViolationsIntoDataGridView();
        }
    }
}