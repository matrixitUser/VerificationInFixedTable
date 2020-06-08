namespace VerificationInFixedTable
{
    partial class FormVerification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVerification));
            this.dgvVerification = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObjectId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colS1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colG1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVerification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbText = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDeleteRows = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.splitter2 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerification)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvVerification
            // 
            this.dgvVerification.AllowUserToAddRows = false;
            this.dgvVerification.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVerification.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colObjectId,
            this.colName,
            this.colPname,
            this.colS1,
            this.colDate,
            this.colValue,
            this.colG1,
            this.colVerification});
            this.dgvVerification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVerification.Location = new System.Drawing.Point(0, 0);
            this.dgvVerification.Name = "dgvVerification";
            this.dgvVerification.RowHeadersWidth = 20;
            this.dgvVerification.Size = new System.Drawing.Size(708, 332);
            this.dgvVerification.TabIndex = 0;
            // 
            // colId
            // 
            this.colId.HeaderText = "id";
            this.colId.Name = "colId";
            // 
            // colObjectId
            // 
            this.colObjectId.HeaderText = "objectId";
            this.colObjectId.Name = "colObjectId";
            this.colObjectId.Visible = false;
            // 
            // colName
            // 
            this.colName.HeaderText = "Название объекта";
            this.colName.Name = "colName";
            this.colName.Width = 150;
            // 
            // colPname
            // 
            this.colPname.HeaderText = "Название точки учета";
            this.colPname.Name = "colPname";
            this.colPname.Width = 150;
            // 
            // colS1
            // 
            this.colS1.HeaderText = "s1";
            this.colS1.Name = "colS1";
            this.colS1.Width = 200;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "date";
            this.colDate.Name = "colDate";
            this.colDate.Width = 115;
            // 
            // colValue
            // 
            this.colValue.HeaderText = "value";
            this.colValue.Name = "colValue";
            this.colValue.Width = 70;
            // 
            // colG1
            // 
            this.colG1.HeaderText = "g1";
            this.colG1.Name = "colG1";
            this.colG1.Visible = false;
            // 
            // colVerification
            // 
            this.colVerification.HeaderText = "Верификация";
            this.colVerification.Name = "colVerification";
            this.colVerification.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbText);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(708, 68);
            this.panel1.TabIndex = 1;
            // 
            // lbText
            // 
            this.lbText.AutoSize = true;
            this.lbText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbText.Location = new System.Drawing.Point(12, 18);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(440, 24);
            this.lbText.TabIndex = 0;
            this.lbText.Text = "Вы точно хотите верифицировать эти данные?";
            this.lbText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 68);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(708, 3);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel2.Controls.Add(this.dgvVerification);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(708, 332);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.btnDeleteRows);
            this.panel3.Controls.Add(this.btnYes);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 403);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(708, 89);
            this.panel3.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.NavajoWhite;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(630, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Закрыть";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDeleteRows
            // 
            this.btnDeleteRows.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDeleteRows.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteRows.Location = new System.Drawing.Point(3, 6);
            this.btnDeleteRows.Name = "btnDeleteRows";
            this.btnDeleteRows.Size = new System.Drawing.Size(75, 30);
            this.btnDeleteRows.TabIndex = 1;
            this.btnDeleteRows.Text = "Удалить";
            this.btnDeleteRows.UseVisualStyleBackColor = false;
            this.btnDeleteRows.Click += new System.EventHandler(this.btnDeleteRows_Click);
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnYes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnYes.Location = new System.Drawing.Point(630, 6);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 30);
            this.btnYes.TabIndex = 0;
            this.btnYes.Text = "Да";
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 403);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(708, 3);
            this.splitter2.TabIndex = 5;
            this.splitter2.TabStop = false;
            // 
            // FormVerification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 492);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(724, 530);
            this.MinimumSize = new System.Drawing.Size(724, 530);
            this.Name = "FormVerification";
            this.Text = "MatrixIT";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerification)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvVerification;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Splitter splitter2;
        public System.Windows.Forms.Label lbText;
        private System.Windows.Forms.Button btnDeleteRows;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObjectId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPname;
        private System.Windows.Forms.DataGridViewTextBoxColumn colS1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colG1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVerification;
    }
}