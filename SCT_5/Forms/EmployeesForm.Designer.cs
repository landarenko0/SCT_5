namespace SCT_5.Forms
{
    partial class EmployeesForm
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
            components = new System.ComponentModel.Container();
            employeesGrid = new DataGridView();
            employeeBindingSource = new BindingSource(components);
            id = new DataGridViewTextBoxColumn();
            firstName = new DataGridViewTextBoxColumn();
            lastName = new DataGridViewTextBoxColumn();
            salary = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)employeesGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)employeeBindingSource).BeginInit();
            SuspendLayout();
            // 
            // employeesGrid
            // 
            employeesGrid.AllowUserToAddRows = false;
            employeesGrid.AllowUserToDeleteRows = false;
            employeesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            employeesGrid.Columns.AddRange(new DataGridViewColumn[] { id, firstName, lastName, salary });
            employeesGrid.Location = new Point(12, 12);
            employeesGrid.Name = "employeesGrid";
            employeesGrid.ReadOnly = true;
            employeesGrid.Size = new Size(776, 426);
            employeesGrid.TabIndex = 0;
            // 
            // employeeBindingSource
            // 
            employeeBindingSource.DataSource = typeof(Core.Models.Employee);
            // 
            // id
            // 
            id.Frozen = true;
            id.HeaderText = "ID";
            id.Name = "id";
            id.ReadOnly = true;
            id.Width = 50;
            // 
            // firstName
            // 
            firstName.Frozen = true;
            firstName.HeaderText = "Имя";
            firstName.Name = "firstName";
            firstName.ReadOnly = true;
            // 
            // lastName
            // 
            lastName.Frozen = true;
            lastName.HeaderText = "Фамилия";
            lastName.Name = "lastName";
            lastName.ReadOnly = true;
            // 
            // salary
            // 
            salary.Frozen = true;
            salary.HeaderText = "Зарплата";
            salary.Name = "salary";
            salary.ReadOnly = true;
            // 
            // EmployeesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(employeesGrid);
            Name = "EmployeesForm";
            Text = "Управление сотрудниками сервиса";
            ((System.ComponentModel.ISupportInitialize)employeesGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)employeeBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView employeesGrid;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn firstName;
        private DataGridViewTextBoxColumn lastName;
        private DataGridViewTextBoxColumn salary;
        private BindingSource employeeBindingSource;
    }
}