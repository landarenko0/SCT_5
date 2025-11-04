namespace SCT_5.Forms
{
	partial class ServicesForm
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
			groupBox1 = new GroupBox();
			servicesTableLayoutPanel = new TableLayoutPanel();
			deleteServiceButton = new Button();
			createServiceButton = new Button();
			updateServiceButton = new Button();
			servicesGrid = new DataGridView();
			id = new DataGridViewTextBoxColumn();
			title = new DataGridViewTextBoxColumn();
			price = new DataGridViewTextBoxColumn();
			groupBox1.SuspendLayout();
			servicesTableLayoutPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)servicesGrid).BeginInit();
			SuspendLayout();
			// 
			// groupBox1
			// 
			groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			groupBox1.Controls.Add(servicesTableLayoutPanel);
			groupBox1.Location = new Point(16, 16);
			groupBox1.Margin = new Padding(8);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new Padding(8);
			groupBox1.Size = new Size(769, 80);
			groupBox1.TabIndex = 2;
			groupBox1.TabStop = false;
			groupBox1.Text = "Редактирование";
			// 
			// servicesTableLayoutPanel
			// 
			servicesTableLayoutPanel.AutoSize = true;
			servicesTableLayoutPanel.ColumnCount = 3;
			servicesTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
			servicesTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
			servicesTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
			servicesTableLayoutPanel.Controls.Add(deleteServiceButton, 2, 0);
			servicesTableLayoutPanel.Controls.Add(createServiceButton, 0, 0);
			servicesTableLayoutPanel.Controls.Add(updateServiceButton, 1, 0);
			servicesTableLayoutPanel.Dock = DockStyle.Fill;
			servicesTableLayoutPanel.Location = new Point(8, 24);
			servicesTableLayoutPanel.Margin = new Padding(8);
			servicesTableLayoutPanel.Name = "servicesTableLayoutPanel";
			servicesTableLayoutPanel.RowCount = 1;
			servicesTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			servicesTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			servicesTableLayoutPanel.Size = new Size(753, 48);
			servicesTableLayoutPanel.TabIndex = 0;
			// 
			// deleteServiceButton
			// 
			deleteServiceButton.AutoSize = true;
			deleteServiceButton.Dock = DockStyle.Fill;
			deleteServiceButton.Location = new Point(510, 8);
			deleteServiceButton.Margin = new Padding(8);
			deleteServiceButton.MaximumSize = new Size(0, 30);
			deleteServiceButton.Name = "deleteServiceButton";
			deleteServiceButton.Size = new Size(235, 30);
			deleteServiceButton.TabIndex = 3;
			deleteServiceButton.Text = "Удалить услугу";
			deleteServiceButton.UseVisualStyleBackColor = true;
			deleteServiceButton.Click += OnDeleteServiceButtonClick;
			// 
			// createServiceButton
			// 
			createServiceButton.AutoSize = true;
			createServiceButton.Dock = DockStyle.Fill;
			createServiceButton.Location = new Point(8, 8);
			createServiceButton.Margin = new Padding(8);
			createServiceButton.MaximumSize = new Size(0, 30);
			createServiceButton.Name = "createServiceButton";
			createServiceButton.Size = new Size(235, 30);
			createServiceButton.TabIndex = 1;
			createServiceButton.Text = "Добавить новую услугу";
			createServiceButton.UseVisualStyleBackColor = true;
			createServiceButton.Click += OnCreateServiceButtonClick;
			// 
			// updateServiceButton
			// 
			updateServiceButton.AutoSize = true;
			updateServiceButton.Dock = DockStyle.Fill;
			updateServiceButton.Location = new Point(259, 8);
			updateServiceButton.Margin = new Padding(8);
			updateServiceButton.MaximumSize = new Size(0, 30);
			updateServiceButton.Name = "updateServiceButton";
			updateServiceButton.Size = new Size(235, 30);
			updateServiceButton.TabIndex = 2;
			updateServiceButton.Text = "Редактировать услугу";
			updateServiceButton.UseVisualStyleBackColor = true;
			updateServiceButton.Click += OnEditServiceButtonClick;
			// 
			// servicesGrid
			// 
			servicesGrid.AllowUserToAddRows = false;
			servicesGrid.AllowUserToDeleteRows = false;
			servicesGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			servicesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			servicesGrid.Columns.AddRange(new DataGridViewColumn[] { id, title, price });
			servicesGrid.Location = new Point(0, 112);
			servicesGrid.Margin = new Padding(8);
			servicesGrid.MultiSelect = false;
			servicesGrid.Name = "servicesGrid";
			servicesGrid.ReadOnly = true;
			servicesGrid.Size = new Size(800, 337);
			servicesGrid.TabIndex = 0;
			// 
			// id
			// 
			id.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			id.HeaderText = "ID";
			id.Name = "id";
			id.ReadOnly = true;
			id.SortMode = DataGridViewColumnSortMode.NotSortable;
			// 
			// title
			// 
			title.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			title.HeaderText = "Название услуги";
			title.Name = "title";
			title.ReadOnly = true;
			title.SortMode = DataGridViewColumnSortMode.NotSortable;
			// 
			// price
			// 
			price.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			price.HeaderText = "Стоимость";
			price.Name = "price";
			price.ReadOnly = true;
			price.SortMode = DataGridViewColumnSortMode.NotSortable;
			// 
			// ServicesForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(groupBox1);
			Controls.Add(servicesGrid);
			Name = "ServicesForm";
			Text = "Управление услугами сервиса";
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			servicesTableLayoutPanel.ResumeLayout(false);
			servicesTableLayoutPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)servicesGrid).EndInit();
			ResumeLayout(false);

		}

		#endregion

		private DataGridView servicesGrid;
		private Button createServiceButton;
		private Button deleteServiceButton;
		private Button updateServiceButton;
		private TableLayoutPanel servicesTableLayoutPanel;
		private DataGridViewTextBoxColumn id;
		private DataGridViewTextBoxColumn title;
		private DataGridViewTextBoxColumn price;
		private GroupBox groupBox1;
	}
}