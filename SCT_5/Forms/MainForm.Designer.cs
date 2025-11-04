namespace SCT_5.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			employeesButton = new Button();
			servicesButton = new Button();
			carPartsButton = new Button();

			SuspendLayout();
			// 
			// employeesButton
			// 
			employeesButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			employeesButton.Location = new Point(16, 16);
			employeesButton.Margin = new Padding(10);
			employeesButton.Name = "employeesButton";
			employeesButton.Size = new Size(768, 25);
			employeesButton.TabIndex = 0;
			employeesButton.Text = "Управление сотрудниками";
			employeesButton.UseVisualStyleBackColor = true;
			employeesButton.Click += OnShowEmployeesFormButtonClick;
			// 
			// button1
			// 
			servicesButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			servicesButton.Location = new Point(16, 61);
			servicesButton.Margin = new Padding(10);
			servicesButton.Name = "servicesButton";
			servicesButton.Size = new Size(768, 25);
			servicesButton.TabIndex = 1;
			servicesButton.Text = "Управление услугами";
			servicesButton.UseVisualStyleBackColor = true;
			servicesButton.Click += OnShowServicesFormButtonClick;
			// 
			// carPartsButton 
			// 
			carPartsButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			carPartsButton.Location = new Point(16, 61);
			carPartsButton.Margin = new Padding(10);
			carPartsButton.Name = "carPartsButton";
			carPartsButton.Size = new Size(768, 25);
			carPartsButton.TabIndex = 1;
			carPartsButton.Text = "Управление запчастями";
			carPartsButton.UseVisualStyleBackColor = true;
			carPartsButton.Click += OnShowCarPartsFormButtonClick;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(servicesButton);
			Controls.Add(carPartsButton);
			Controls.Add(employeesButton);
			Name = "MainForm";
			Text = "Автосервис";
			Load += MainForm_Load;
			ResumeLayout(false);
		}

		#endregion

		private Button employeesButton;
		private Button servicesButton;
        private Button carPartsButton;
    }
}
