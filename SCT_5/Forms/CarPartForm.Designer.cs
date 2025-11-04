namespace SCT_5.Forms
{
    partial class CarPartForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            quantityConstraintGoodButton = new Button();
            quantityConstraintBadButton = new Button();
            titleTextBox = new TextBox();
            quantityTextBox = new TextBox();
            saveButton = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 17);
            label1.Margin = new Padding(8);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 0;
            label1.Text = "Название";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 83);
            label2.Margin = new Padding(8);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 3;
            label2.Text = "Количество";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(quantityConstraintGoodButton);
            groupBox1.Controls.Add(quantityConstraintBadButton);
            groupBox1.Location = new Point(383, 50);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(243, 100);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Тестирование ограничения количества";
            groupBox1.Enter += groupBox1_Enter_1;
            // 
            // quantityConstraintGoodButton
            // 
            quantityConstraintGoodButton.Location = new Point(6, 22);
            quantityConstraintGoodButton.Name = "quantityConstraintGoodButton";
            quantityConstraintGoodButton.Size = new Size(219, 23);
            quantityConstraintGoodButton.TabIndex = 7;
            quantityConstraintGoodButton.Text = "Хороший пример";
            quantityConstraintGoodButton.UseVisualStyleBackColor = true;
            quantityConstraintGoodButton.Click += OnQuantityConstraintGoodButtonClick;
            // 
            // quantityConstraintBadButton
            // 
            quantityConstraintBadButton.Location = new Point(6, 69);
            quantityConstraintBadButton.Name = "quantityConstraintBadButton";
            quantityConstraintBadButton.Size = new Size(219, 23);
            quantityConstraintBadButton.TabIndex = 8;
            quantityConstraintBadButton.Text = "Плохой пример";
            quantityConstraintBadButton.UseVisualStyleBackColor = true;
            quantityConstraintBadButton.Click += OnQuantityConstraintBadButtonClick;
            // 
            // titleTextBox
            // 
            titleTextBox.Location = new Point(17, 44);
            titleTextBox.Margin = new Padding(8, 4, 8, 8);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new Size(355, 23);
            titleTextBox.TabIndex = 1;
            // 
            // quantityTextBox
            // 
            quantityTextBox.Location = new Point(17, 109);
            quantityTextBox.Margin = new Padding(8);
            quantityTextBox.Name = "quantityTextBox";
            quantityTextBox.Size = new Size(355, 23);
            quantityTextBox.TabIndex = 2;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(17, 166);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(355, 23);
            saveButton.TabIndex = 6;
            saveButton.Text = "Сохранить";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += OnSaveCarPartButtonClick;
            // 
            // CarPartForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(649, 250);
            Controls.Add(groupBox1);
            Controls.Add(saveButton);
            Controls.Add(quantityTextBox);
            Controls.Add(label2);
            Controls.Add(titleTextBox);
            Controls.Add(label1);
            Name = "CarPartForm";
            Text = "CarPartForm";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox titleTextBox;
        private TextBox quantityTextBox;
        private Button saveButton;
        private Button quantityConstraintGoodButton;
        private Button quantityConstraintBadButton;
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
    }
}