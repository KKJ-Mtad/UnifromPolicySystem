namespace StudentViolationList
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.Label();
            this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
            this.date = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxCourse = new System.Windows.Forms.ComboBox();
            this.comboBoxYearLevel = new System.Windows.Forms.ComboBox();
            this.dataGridViewViolations = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxNoID = new System.Windows.Forms.CheckBox();
            this.checkBoxIncompleteUniform = new System.Windows.Forms.CheckBox();
            this.checkBoxNoUniform = new System.Windows.Forms.CheckBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewViolations)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(98, 36);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(160, 20);
            this.txtName.TabIndex = 0;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(38, 39);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(38, 13);
            this.name.TabIndex = 1;
            this.name.Text = "Name:";
            // 
            // dateTimePickerDate
            // 
            this.dateTimePickerDate.Location = new System.Drawing.Point(473, 36);
            this.dateTimePickerDate.Name = "dateTimePickerDate";
            this.dateTimePickerDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDate.TabIndex = 2;
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.Location = new System.Drawing.Point(434, 40);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(33, 13);
            this.date.TabIndex = 3;
            this.date.Text = "Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Student ID:";
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(98, 73);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(160, 20);
            this.txtStudentID.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Course:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "YR.";
            // 
            // comboBoxCourse
            // 
            this.comboBoxCourse.FormattingEnabled = true;
            this.comboBoxCourse.Location = new System.Drawing.Point(98, 103);
            this.comboBoxCourse.Name = "comboBoxCourse";
            this.comboBoxCourse.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCourse.TabIndex = 8;
            // 
            // comboBoxYearLevel
            // 
            this.comboBoxYearLevel.FormattingEnabled = true;
            this.comboBoxYearLevel.Location = new System.Drawing.Point(98, 138);
            this.comboBoxYearLevel.Name = "comboBoxYearLevel";
            this.comboBoxYearLevel.Size = new System.Drawing.Size(121, 21);
            this.comboBoxYearLevel.TabIndex = 9;
            // 
            // dataGridViewViolations
            // 
            this.dataGridViewViolations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewViolations.Location = new System.Drawing.Point(352, 73);
            this.dataGridViewViolations.Name = "dataGridViewViolations";
            this.dataGridViewViolations.Size = new System.Drawing.Size(416, 234);
            this.dataGridViewViolations.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(93, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Violations";
            // 
            // checkBoxNoID
            // 
            this.checkBoxNoID.AutoSize = true;
            this.checkBoxNoID.Location = new System.Drawing.Point(121, 225);
            this.checkBoxNoID.Name = "checkBoxNoID";
            this.checkBoxNoID.Size = new System.Drawing.Size(54, 17);
            this.checkBoxNoID.TabIndex = 15;
            this.checkBoxNoID.Text = "No ID";
            this.checkBoxNoID.UseVisualStyleBackColor = true;
            // 
            // checkBoxIncompleteUniform
            // 
            this.checkBoxIncompleteUniform.AutoSize = true;
            this.checkBoxIncompleteUniform.Location = new System.Drawing.Point(121, 248);
            this.checkBoxIncompleteUniform.Name = "checkBoxIncompleteUniform";
            this.checkBoxIncompleteUniform.Size = new System.Drawing.Size(86, 17);
            this.checkBoxIncompleteUniform.TabIndex = 16;
            this.checkBoxIncompleteUniform.Text = "INC. Uniform";
            this.checkBoxIncompleteUniform.UseVisualStyleBackColor = true;
            // 
            // checkBoxNoUniform
            // 
            this.checkBoxNoUniform.AutoSize = true;
            this.checkBoxNoUniform.Location = new System.Drawing.Point(121, 271);
            this.checkBoxNoUniform.Name = "checkBoxNoUniform";
            this.checkBoxNoUniform.Size = new System.Drawing.Size(79, 17);
            this.checkBoxNoUniform.TabIndex = 17;
            this.checkBoxNoUniform.Text = "No Uniform";
            this.checkBoxNoUniform.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(15, 343);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(70, 24);
            this.btnCreate.TabIndex = 18;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(121, 343);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(70, 24);
            this.btnUpdate.TabIndex = 19;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(229, 343);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(70, 24);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 381);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.checkBoxNoUniform);
            this.Controls.Add(this.checkBoxIncompleteUniform);
            this.Controls.Add(this.checkBoxNoID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridViewViolations);
            this.Controls.Add(this.comboBoxYearLevel);
            this.Controls.Add(this.comboBoxCourse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStudentID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.date);
            this.Controls.Add(this.dateTimePickerDate);
            this.Controls.Add(this.name);
            this.Controls.Add(this.txtName);
            this.Name = "Form1";
            this.Text = "Uniform Violation";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewViolations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.DateTimePicker dateTimePickerDate;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxCourse;
        private System.Windows.Forms.ComboBox comboBoxYearLevel;
        private System.Windows.Forms.DataGridView dataGridViewViolations;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxNoID;
        private System.Windows.Forms.CheckBox checkBoxIncompleteUniform;
        private System.Windows.Forms.CheckBox checkBoxNoUniform;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
    }
}

