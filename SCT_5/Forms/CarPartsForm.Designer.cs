namespace SCT_5.Forms
{
    partial class CarPartsForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            deleteCarPartButton = new Button();
            createCarPartButton = new Button();
            updateCarPartButton = new Button();
            carPartsGrid = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            title = new DataGridViewTextBoxColumn();
            quantity = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)carPartsGrid).BeginInit();
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
            tableLayoutPanel1.Controls.Add(deleteCarPartButton, 2, 0);
            tableLayoutPanel1.Controls.Add(createCarPartButton, 0, 0);
            tableLayoutPanel1.Controls.Add(updateCarPartButton, 1, 0);
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
            // deleteCarPartButton
            // 
            deleteCarPartButton.AutoSize = true;
            deleteCarPartButton.Dock = DockStyle.Fill;
            deleteCarPartButton.Location = new Point(510, 8);
            deleteCarPartButton.Margin = new Padding(8);
            deleteCarPartButton.MaximumSize = new Size(0, 30);
            deleteCarPartButton.Name = "deleteCarPartButton";
            deleteCarPartButton.Size = new Size(235, 30);
            deleteCarPartButton.TabIndex = 3;
            deleteCarPartButton.Text = "Удалить запчасть";
            deleteCarPartButton.UseVisualStyleBackColor = true;
            deleteCarPartButton.Click += OnDeleteCarPartButtonClick;
            // 
            // createCarPartButton
            // 
            createCarPartButton.AutoSize = true;
            createCarPartButton.Dock = DockStyle.Fill;
            createCarPartButton.Location = new Point(8, 8);
            createCarPartButton.Margin = new Padding(8);
            createCarPartButton.MaximumSize = new Size(0, 30);
            createCarPartButton.Name = "createCarPartButton";
            createCarPartButton.Size = new Size(235, 30);
            createCarPartButton.TabIndex = 1;
            createCarPartButton.Text = "Добавить новую запчасть";
            createCarPartButton.UseVisualStyleBackColor = true;
            createCarPartButton.Click += OnCreateCarPartButtonClick;
            // 
            // updateCarPartButton
            // 
            updateCarPartButton.AutoSize = true;
            updateCarPartButton.Dock = DockStyle.Fill;
            updateCarPartButton.Location = new Point(259, 8);
            updateCarPartButton.Margin = new Padding(8);
            updateCarPartButton.MaximumSize = new Size(0, 30);
            updateCarPartButton.Name = "updateCarPartButton";
            updateCarPartButton.Size = new Size(235, 30);
            updateCarPartButton.TabIndex = 2;
            updateCarPartButton.Text = "Редактировать запчасть";
            updateCarPartButton.UseVisualStyleBackColor = true;
            updateCarPartButton.Click += OnEditCarPartButtonClick;
            // 
            // carPartsGrid
            // 
            carPartsGrid.AllowUserToAddRows = false;
            carPartsGrid.AllowUserToDeleteRows = false;
            carPartsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            carPartsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            carPartsGrid.Columns.AddRange(new DataGridViewColumn[] { id, title, quantity });
            carPartsGrid.Location = new Point(0, 112);
            carPartsGrid.Margin = new Padding(8);
            carPartsGrid.MultiSelect = false;
            carPartsGrid.Name = "carPartsGrid";
            carPartsGrid.ReadOnly = true;
            carPartsGrid.Size = new Size(800, 337);
            carPartsGrid.TabIndex = 0;
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
            title.HeaderText = "Название";
            title.Name = "title";
            title.ReadOnly = true;
            title.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // quantity
            // 
            quantity.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            quantity.HeaderText = "Количество";
            quantity.Name = "quantity";
            quantity.ReadOnly = true;
            quantity.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // CarPartsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(carPartsGrid);
            Name = "CarPartsForm";
            Text = "Управление запчастями";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)carPartsGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView carPartsGrid;
        private Button createCarPartButton;
        private Button deleteCarPartButton;
        private Button updateCarPartButton;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn title;
        private DataGridViewTextBoxColumn quantity;
        private GroupBox groupBox1;
    }
}