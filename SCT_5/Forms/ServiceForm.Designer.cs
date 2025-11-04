namespace SCT_5.Forms
{
	partial class ServiceForm
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
			label1 = new Label();
			label2 = new Label();
			groupBox1 = new GroupBox();
			priceConstraintGoodButton = new Button();
			priceConstraintBadButton = new Button();
			titleTextBox = new TextBox();
			priceTextBox = new TextBox();
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
			label1.Size = new Size(123, 15);
			label1.TabIndex = 0;
			label1.Text = "Наименоваие услуги";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(17, 83);
			label2.Margin = new Padding(8);
			label2.Name = "label2";
			label2.Size = new Size(35, 15);
			label2.TabIndex = 3;
			label2.Text = "Цена";
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(priceConstraintGoodButton);
			groupBox1.Controls.Add(priceConstraintBadButton);
			groupBox1.Location = new Point(395, 74);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(231, 100);
			groupBox1.TabIndex = 9;
			groupBox1.TabStop = false;
			groupBox1.Text = "Тестирование ограничения цены";
			// 
			// priceConstraintGoodButton
			// 
			priceConstraintGoodButton.Location = new Point(6, 22);
			priceConstraintGoodButton.Name = "priceConstraintGoodButton";
			priceConstraintGoodButton.Size = new Size(219, 23);
			priceConstraintGoodButton.TabIndex = 7;
			priceConstraintGoodButton.Text = "Хороший пример";
			priceConstraintGoodButton.UseVisualStyleBackColor = true;
			priceConstraintGoodButton.Click += OnPriceConstraintGoodButtonClick;
			// 
			// priceConstraintBadButton
			// 
			priceConstraintBadButton.Location = new Point(6, 69);
			priceConstraintBadButton.Name = "priceConstraintBadButton";
			priceConstraintBadButton.Size = new Size(219, 23);
			priceConstraintBadButton.TabIndex = 8;
			priceConstraintBadButton.Text = "Плохой пример";
			priceConstraintBadButton.UseVisualStyleBackColor = true;
			priceConstraintBadButton.Click += OnPriceConstraintBadButtonClick;
			// 
			// titleTextBox
			// 
			titleTextBox.Location = new Point(17, 44);
			titleTextBox.Margin = new Padding(8, 4, 8, 8);
			titleTextBox.Name = "titleTextBox";
			titleTextBox.Size = new Size(355, 23);
			titleTextBox.TabIndex = 1;
			// 
			// priceTextBox
			// 
			priceTextBox.Location = new Point(17, 109);
			priceTextBox.Name = "priceTextBox";
			priceTextBox.Size = new Size(355, 23);
			priceTextBox.TabIndex = 5;
			// 
			// saveButton
			// 
			saveButton.Location = new Point(17, 226);
			saveButton.Name = "saveButton";
			saveButton.Size = new Size(355, 23);
			saveButton.TabIndex = 6;
			saveButton.Text = "Сохранить";
			saveButton.UseVisualStyleBackColor = true;
			saveButton.Click += OnSaveServiceButtonClick;
			// 
			// ServiceForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(649, 277);
			Controls.Add(groupBox1);
			Controls.Add(saveButton);
			Controls.Add(priceTextBox);
			Controls.Add(label2);
			Controls.Add(titleTextBox);
			Controls.Add(label1);
			Name = "ServiceForm";
			Text = "ServiceForm";
			groupBox1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		#endregion

		private TextBox titleTextBox;
		private TextBox priceTextBox;
		private Button saveButton;
		private Button priceConstraintGoodButton;
		private Button priceConstraintBadButton;
		private Label label1;
		private Label label2;
		private GroupBox groupBox1;
	}
}