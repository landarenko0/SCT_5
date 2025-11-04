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
            GroupBox groupBox1;
            TableLayoutPanel tableLayoutPanel1;
            deleteEmployeeButton = new Button();
            createEmployeeButton = new Button();
            updateEmployeeButton = new Button();
            employeesGrid = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            firstName = new DataGridViewTextBoxColumn();
            lastName = new DataGridViewTextBoxColumn();
            salary = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)employeesGrid).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Location = new Point(16, 16);
            groupBox1.Margin = new Padding(8);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(8);
            groupBox1.Size = new Size(769, 80);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Редактирование";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(deleteEmployeeButton, 2, 0);
            tableLayoutPanel1.Controls.Add(createEmployeeButton, 0, 0);
            tableLayoutPanel1.Controls.Add(updateEmployeeButton, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(8, 24);
            tableLayoutPanel1.Margin = new Padding(8);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(753, 48);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // deleteEmployeeButton
            // 
            deleteEmployeeButton.AutoSize = true;
            deleteEmployeeButton.Dock = DockStyle.Fill;
            deleteEmployeeButton.Location = new Point(510, 8);
            deleteEmployeeButton.Margin = new Padding(8);
            deleteEmployeeButton.MaximumSize = new Size(0, 30);
            deleteEmployeeButton.Name = "deleteEmployeeButton";
            deleteEmployeeButton.Size = new Size(235, 30);
            deleteEmployeeButton.TabIndex = 3;
            deleteEmployeeButton.Text = "Удалить сотрудника";
            deleteEmployeeButton.UseVisualStyleBackColor = true;
            deleteEmployeeButton.Click += OnDeleteEmployeeButtonClick;
            // 
            // createEmployeeButton
            // 
            createEmployeeButton.AutoSize = true;
            createEmployeeButton.Dock = DockStyle.Fill;
            createEmployeeButton.Location = new Point(8, 8);
            createEmployeeButton.Margin = new Padding(8);
            createEmployeeButton.MaximumSize = new Size(0, 30);
            createEmployeeButton.Name = "createEmployeeButton";
            createEmployeeButton.Size = new Size(235, 30);
            createEmployeeButton.TabIndex = 1;
            createEmployeeButton.Text = "Добавить нового сотрудника";
            createEmployeeButton.UseVisualStyleBackColor = true;
            createEmployeeButton.Click += OnCreateEmployeeButtonClick;
            // 
            // updateEmployeeButton
            // 
            updateEmployeeButton.AutoSize = true;
            updateEmployeeButton.Dock = DockStyle.Fill;
            updateEmployeeButton.Location = new Point(259, 8);
            updateEmployeeButton.Margin = new Padding(8);
            updateEmployeeButton.MaximumSize = new Size(0, 30);
            updateEmployeeButton.Name = "updateEmployeeButton";
            updateEmployeeButton.Size = new Size(235, 30);
            updateEmployeeButton.TabIndex = 2;
            updateEmployeeButton.Text = "Редактировать сотрудника";
            updateEmployeeButton.UseVisualStyleBackColor = true;
            updateEmployeeButton.Click += OnEditEmployeeButtonClick;
            // 
            // employeesGrid
            // 
            employeesGrid.AllowUserToAddRows = false;
            employeesGrid.AllowUserToDeleteRows = false;
            employeesGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            employeesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            employeesGrid.Columns.AddRange(new DataGridViewColumn[] { id, firstName, lastName, salary });
            employeesGrid.Location = new Point(0, 112);
            employeesGrid.Margin = new Padding(8);
            employeesGrid.MultiSelect = false;
            employeesGrid.Name = "employeesGrid";
            employeesGrid.ReadOnly = true;
            employeesGrid.Size = new Size(800, 337);
            employeesGrid.TabIndex = 0;
            employeesGrid.CellContentClick += employeesGrid_CellContentClick;
            // 
            // id
            // 
            id.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            id.HeaderText = "ID";
            id.Name = "id";
            id.ReadOnly = true;
            id.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // firstName
            // 
            firstName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            firstName.HeaderText = "Имя";
            firstName.Name = "firstName";
            firstName.ReadOnly = true;
            firstName.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // lastName
            // 
            lastName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            lastName.HeaderText = "Фамилия";
            lastName.Name = "lastName";
            lastName.ReadOnly = true;
            lastName.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // salary
            // 
            salary.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            salary.HeaderText = "Зарплата";
            salary.Name = "salary";
            salary.ReadOnly = true;
            salary.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // EmployeesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(employeesGrid);
            Name = "EmployeesForm";
            Text = "Управление сотрудниками сервиса";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)employeesGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView employeesGrid;
        private Button createEmployeeButton;
        private Button deleteEmployeeButton;
        private Button updateEmployeeButton;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn firstName;
        private DataGridViewTextBoxColumn lastName;
        private DataGridViewTextBoxColumn salary;
    }
}