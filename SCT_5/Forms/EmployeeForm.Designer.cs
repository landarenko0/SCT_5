namespace SCT_5.Forms
{
    partial class EmployeeForm
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
            Label label1;
            Label label2;
            Label label3;
            GroupBox groupBox1;
            salaryConstraintGoodButton = new Button();
            salaryConstraintBadButton = new Button();
            firstNameTextBox = new TextBox();
            lastNameTextBox = new TextBox();
            salaryTextBox = new TextBox();
            saveButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 17);
            label1.Margin = new Padding(8);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 0;
            label1.Text = "Имя";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 83);
            label2.Margin = new Padding(8);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 3;
            label2.Text = "Фамилия";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 148);
            label3.Margin = new Padding(8);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 4;
            label3.Text = "Зарплата";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(salaryConstraintGoodButton);
            groupBox1.Controls.Add(salaryConstraintBadButton);
            groupBox1.Location = new Point(395, 74);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(231, 100);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Тестирование ограничения зарплаты";
            // 
            // salaryConstraintGoodButton
            // 
            salaryConstraintGoodButton.Location = new Point(6, 22);
            salaryConstraintGoodButton.Name = "salaryConstraintGoodButton";
            salaryConstraintGoodButton.Size = new Size(219, 23);
            salaryConstraintGoodButton.TabIndex = 7;
            salaryConstraintGoodButton.Text = "Хороший пример";
            salaryConstraintGoodButton.UseVisualStyleBackColor = true;
            salaryConstraintGoodButton.Click += OnSalaryConstraintGoodButtonClick;
            // 
            // salaryConstraintBadButton
            // 
            salaryConstraintBadButton.Location = new Point(6, 69);
            salaryConstraintBadButton.Name = "salaryConstraintBadButton";
            salaryConstraintBadButton.Size = new Size(219, 23);
            salaryConstraintBadButton.TabIndex = 8;
            salaryConstraintBadButton.Text = "Плохой пример";
            salaryConstraintBadButton.UseVisualStyleBackColor = true;
            salaryConstraintBadButton.Click += OnSalaryConstraintBadButtonClick;
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(17, 44);
            firstNameTextBox.Margin = new Padding(8, 4, 8, 8);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(355, 23);
            firstNameTextBox.TabIndex = 1;
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(17, 109);
            lastNameTextBox.Margin = new Padding(8);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(355, 23);
            lastNameTextBox.TabIndex = 2;
            // 
            // salaryTextBox
            // 
            salaryTextBox.Location = new Point(17, 174);
            salaryTextBox.Name = "salaryTextBox";
            salaryTextBox.Size = new Size(355, 23);
            salaryTextBox.TabIndex = 5;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(17, 226);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(355, 23);
            saveButton.TabIndex = 6;
            saveButton.Text = "Сохранить";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += OnSaveEmployeeButtonClick;
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(649, 277);
            Controls.Add(groupBox1);
            Controls.Add(saveButton);
            Controls.Add(salaryTextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lastNameTextBox);
            Controls.Add(firstNameTextBox);
            Controls.Add(label1);
            Name = "EmployeeForm";
            Text = "EmployeeForm";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox firstNameTextBox;
        private TextBox lastNameTextBox;
        private TextBox salaryTextBox;
        private Button saveButton;
        private Button salaryConstraintGoodButton;
        private Button salaryConstraintBadButton;
    }
}