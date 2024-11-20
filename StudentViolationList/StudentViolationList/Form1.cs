using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StudentViolationList
{
    public partial class Form1 : Form
    {
        private List<StudentViolation> violationsList = new List<StudentViolation>();
        private int currentIndex = -1; // To track the current index of the selected violation for updating.

        public Form1()
        {
            InitializeComponent();
            PopulateCourses();
            PopulateYearLevels();
            InitializeDataGridView();
            LoadData();
        }

        private void InitializeDataGridView()
        {
            dataGridViewViolations.Columns.Clear();
            dataGridViewViolations.Columns.Add("Id", "ID");
            dataGridViewViolations.Columns["Id"].Visible = false; // di na kailangan tignan to ng user
            dataGridViewViolations.Columns.Add("Name", "Name");
            dataGridViewViolations.Columns.Add("Date", "Date");
            dataGridViewViolations.Columns.Add("StudentID", "Student ID");
            dataGridViewViolations.Columns.Add("Course", "Course");
            dataGridViewViolations.Columns.Add("YearLevel", "Year Level");
            dataGridViewViolations.Columns.Add("Violation", "Violation");

        }

        private void PopulateCourses()
        {
            comboBoxCourse.Items.AddRange(new string[] { "BSIT", "BSTM", "BSBA", "BSHM", "Senior HS" });
        }

        private void PopulateYearLevels()
        {
            comboBoxYearLevel.Items.AddRange(new string[] { "1st Year", "2nd Year", "3rd Year", "4th Year" });
        }

        private void LoadData()
        {
            // Clear the DataGridView and load data from the in-memory list.
            dataGridViewViolations.Rows.Clear();
            foreach (var violation in violationsList)
            {
                dataGridViewViolations.Rows.Add(violation.Id, violation.Name, violation.Date, violation.StudentID, violation.Course, violation.YearLevel, violation.Violation);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string violations = GetSelectedViolations();
            if (!string.IsNullOrEmpty(violations))
            {
                var newViolation = new StudentViolation
                {
                    Id = violationsList.Count + 1,
                    Name = txtName.Text,
                    Date = dateTimePickerDate.Value,
                    StudentID = txtStudentID.Text,
                    Course = comboBoxCourse.SelectedItem.ToString(),
                    YearLevel = comboBoxYearLevel.SelectedItem.ToString(),
                    Violation = violations
                };

                violationsList.Add(newViolation);
                LoadData();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Please select at least one violation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetSelectedViolations()
        {
            string violations = "";
            if (checkBoxNoID.Checked) violations += "NO ID; ";
            if (checkBoxIncompleteUniform.Checked) violations += "Incomplete Uniform; ";
            if (checkBoxNoUniform.Checked) violations += "No Uniform; ";
            return violations.TrimEnd(' ', ';');
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (currentIndex >= 0 && currentIndex < violationsList.Count)
            {
                // Update the selected violation with the data from the input fields.
                var violation = violationsList[currentIndex];
                violation.Name = txtName.Text;
                violation.Date = dateTimePickerDate.Value;
                violation.StudentID = txtStudentID.Text;
                violation.Course = comboBoxCourse.SelectedItem.ToString();
                violation.YearLevel = comboBoxYearLevel.SelectedItem.ToString();
                violation.Violation = GetSelectedViolations();

                LoadData(); // Reload the DataGridView to show updated data.
                ClearForm(); // Clear input fields.
                currentIndex = -1; // Reset index after update.
            }
            else
            {
                MessageBox.Show("Please select a violation to update.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Implement delete logic based on selected row.
            if (dataGridViewViolations.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridViewViolations.SelectedRows[0].Index;
                violationsList.RemoveAt(selectedIndex);
                LoadData();
            }
        }

        private void dataGridViewViolations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell click event to populate the form with the selected violation data.
            if (e.RowIndex >= 0)
            {
                var selectedRow = dataGridViewViolations.Rows[e.RowIndex];
                txtName.Text = selectedRow.Cells["Name"].Value.ToString();
                dateTimePickerDate.Value = Convert.ToDateTime(selectedRow.Cells["Date"].Value);
                txtStudentID.Text = selectedRow.Cells["StudentID"].Value.ToString();
                comboBoxCourse.SelectedItem = selectedRow.Cells["Course"].Value.ToString();
                comboBoxYearLevel.SelectedItem = selectedRow.Cells["YearLevel"].Value.ToString();
                currentIndex = e.RowIndex; // Set the current index to the selected row.
                // Update checkboxes based on stored violations
                var violations = selectedRow.Cells["Violation"].Value.ToString().Split(new[] { "; " }, StringSplitOptions.None);
                checkBoxNoID.Checked = violations.Contains("NO ID");
                checkBoxIncompleteUniform.Checked = violations.Contains("Incomplete Uniform");
                checkBoxNoUniform.Checked = violations.Contains("No Uniform");
            }
        }
        //still under construct
        /*private void dataGridViewViolations_SelectionChanged(object sender, EventArgs e) // para pag sinelect user anong date, kung ano nakaspecify yun lang mga lalabas sa gridlist
        {
            if (dataGridViewViolations.SelectedRows.Count > 0)
            {
                DateTime selectedDate = Convert.ToDateTime(dataGridViewViolations.SelectedRows[0].Cells["Date"].Value);
                dataGridViewViolations.DataSource = violationsList.Where(violation => violation.Date == selectedDate).ToList();
            }
            else
            {
                dataGridViewViolations.DataSource = violationsList;
            }
        }*/


        private void ClearForm()
        {
            txtName.Clear();
            txtStudentID.Clear();
            comboBoxCourse.SelectedIndex = -1;
            comboBoxYearLevel.SelectedIndex = -1;
            checkBoxNoID.Checked = false;
            checkBoxIncompleteUniform.Checked = false;
            checkBoxNoUniform.Checked = false;
            currentIndex = -1; // Reset current index after clearing the form.
        }
    }

    // Class representing a student violation record.
    public class StudentViolation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string StudentID { get; set; }
        public string Course { get; set; }
        public string YearLevel { get; set; }
        public string Violation { get; set; }
    }
}