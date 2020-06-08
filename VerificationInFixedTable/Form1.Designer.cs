namespace VerificationInFixedTable
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbConsole = new System.Windows.Forms.ListBox();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvTableFixed = new System.Windows.Forms.DataGridView();
            this.colNamef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPnameF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNetworkAddressf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObjectIdf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colS1f = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colG1f = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsForDgvTableFixed = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiGetDataFromHub = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVerif = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvTable = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObjectId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colS1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVerification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colG1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsForDgvTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiVerification = new System.Windows.Forms.ToolStripMenuItem();
            this.panelGetDataOnlyWithType = new System.Windows.Forms.Panel();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.btnGetDataOnlyWithType = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.btnConnection = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnAutoVerification = new System.Windows.Forms.Button();
            this.mtbSetPoint = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnDelAutoVerif = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableFixed)).BeginInit();
            this.cmsForDgvTableFixed.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            this.cmsForDgvTable.SuspendLayout();
            this.panelGetDataOnlyWithType.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(1059, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 595);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbConsole);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 500);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1059, 95);
            this.panel2.TabIndex = 2;
            // 
            // lbConsole
            // 
            this.lbConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbConsole.FormattingEnabled = true;
            this.lbConsole.Location = new System.Drawing.Point(0, 0);
            this.lbConsole.Name = "lbConsole";
            this.lbConsole.Size = new System.Drawing.Size(1059, 95);
            this.lbConsole.TabIndex = 0;
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.splitter2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(0, 497);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(1059, 3);
            this.splitter2.TabIndex = 3;
            this.splitter2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1059, 497);
            this.panel3.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1059, 497);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvTableFixed);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1051, 471);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Вид 1";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvTableFixed
            // 
            this.dgvTableFixed.AllowUserToAddRows = false;
            this.dgvTableFixed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableFixed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNamef,
            this.colPnameF,
            this.colNetworkAddressf,
            this.colIdf,
            this.colObjectIdf,
            this.colS1f,
            this.colG1f});
            this.dgvTableFixed.ContextMenuStrip = this.cmsForDgvTableFixed;
            this.dgvTableFixed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTableFixed.Location = new System.Drawing.Point(3, 3);
            this.dgvTableFixed.Name = "dgvTableFixed";
            this.dgvTableFixed.RowHeadersWidth = 20;
            this.dgvTableFixed.Size = new System.Drawing.Size(1045, 465);
            this.dgvTableFixed.TabIndex = 0;
            this.dgvTableFixed.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTableFixed_CellDoubleClick);
            this.dgvTableFixed.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTableFixed_CellValueChanged);
            // 
            // colNamef
            // 
            this.colNamef.HeaderText = "Название объекта учета";
            this.colNamef.Name = "colNamef";
            this.colNamef.Width = 160;
            // 
            // colPnameF
            // 
            this.colPnameF.HeaderText = "Название точки учета";
            this.colPnameF.Name = "colPnameF";
            this.colPnameF.Width = 150;
            // 
            // colNetworkAddressf
            // 
            this.colNetworkAddressf.HeaderText = "Сетевой адрес";
            this.colNetworkAddressf.Name = "colNetworkAddressf";
            this.colNetworkAddressf.Width = 50;
            // 
            // colIdf
            // 
            this.colIdf.HeaderText = "id";
            this.colIdf.Name = "colIdf";
            this.colIdf.Visible = false;
            // 
            // colObjectIdf
            // 
            this.colObjectIdf.HeaderText = "objectId";
            this.colObjectIdf.Name = "colObjectIdf";
            this.colObjectIdf.Visible = false;
            // 
            // colS1f
            // 
            this.colS1f.HeaderText = "s1";
            this.colS1f.Name = "colS1f";
            this.colS1f.Visible = false;
            // 
            // colG1f
            // 
            this.colG1f.HeaderText = "g1";
            this.colG1f.Name = "colG1f";
            this.colG1f.Visible = false;
            // 
            // cmsForDgvTableFixed
            // 
            this.cmsForDgvTableFixed.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGetDataFromHub,
            this.tsmiVerif});
            this.cmsForDgvTableFixed.Name = "cmsForDgvTableFixed";
            this.cmsForDgvTableFixed.Size = new System.Drawing.Size(287, 48);
            // 
            // tsmiGetDataFromHub
            // 
            this.tsmiGetDataFromHub.Name = "tsmiGetDataFromHub";
            this.tsmiGetDataFromHub.Size = new System.Drawing.Size(286, 22);
            this.tsmiGetDataFromHub.Text = "Посмотреть данные из концентратора";
            this.tsmiGetDataFromHub.Click += new System.EventHandler(this.tsmiGetDataFromHub_Click);
            // 
            // tsmiVerif
            // 
            this.tsmiVerif.Name = "tsmiVerif";
            this.tsmiVerif.Size = new System.Drawing.Size(286, 22);
            this.tsmiVerif.Text = "Верификация";
            this.tsmiVerif.Click += new System.EventHandler(this.tsmiVerif_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvTable);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1051, 471);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Вид 2";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvTable
            // 
            this.dgvTable.AllowUserToAddRows = false;
            this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colPname,
            this.colObjectId,
            this.colS1,
            this.colDate,
            this.colValue,
            this.colVerification,
            this.colDt,
            this.colG1});
            this.dgvTable.ContextMenuStrip = this.cmsForDgvTable;
            this.dgvTable.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTable.Location = new System.Drawing.Point(3, 3);
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.RowHeadersWidth = 20;
            this.dgvTable.ShowCellToolTips = false;
            this.dgvTable.Size = new System.Drawing.Size(1045, 465);
            this.dgvTable.TabIndex = 0;
            this.dgvTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTable_CellClick);
            this.dgvTable.SelectionChanged += new System.EventHandler(this.dgvTable_SelectionChanged);
            this.dgvTable.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvTable_MouseClick);
            // 
            // colId
            // 
            this.colId.Frozen = true;
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 30;
            // 
            // colName
            // 
            this.colName.Frozen = true;
            this.colName.HeaderText = "Название объекта";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 150;
            // 
            // colPname
            // 
            this.colPname.Frozen = true;
            this.colPname.HeaderText = "Название точки учета";
            this.colPname.Name = "colPname";
            this.colPname.ReadOnly = true;
            this.colPname.Width = 150;
            // 
            // colObjectId
            // 
            this.colObjectId.Frozen = true;
            this.colObjectId.HeaderText = "objectId";
            this.colObjectId.Name = "colObjectId";
            this.colObjectId.ReadOnly = true;
            this.colObjectId.Width = 150;
            // 
            // colS1
            // 
            this.colS1.Frozen = true;
            this.colS1.HeaderText = "s1";
            this.colS1.Name = "colS1";
            this.colS1.ReadOnly = true;
            this.colS1.Width = 200;
            // 
            // colDate
            // 
            this.colDate.Frozen = true;
            this.colDate.HeaderText = "date";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Width = 115;
            // 
            // colValue
            // 
            this.colValue.Frozen = true;
            this.colValue.HeaderText = "value";
            this.colValue.Name = "colValue";
            this.colValue.ReadOnly = true;
            this.colValue.Width = 80;
            // 
            // colVerification
            // 
            this.colVerification.HeaderText = "verif";
            this.colVerification.Name = "colVerification";
            this.colVerification.ReadOnly = true;
            this.colVerification.Width = 30;
            // 
            // colDt
            // 
            this.colDt.HeaderText = "dt";
            this.colDt.Name = "colDt";
            this.colDt.ReadOnly = true;
            this.colDt.Width = 115;
            // 
            // colG1
            // 
            this.colG1.HeaderText = "g1";
            this.colG1.Name = "colG1";
            this.colG1.ReadOnly = true;
            this.colG1.Visible = false;
            // 
            // cmsForDgvTable
            // 
            this.cmsForDgvTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiVerification});
            this.cmsForDgvTable.Name = "cmsForDgvTable";
            this.cmsForDgvTable.Size = new System.Drawing.Size(135, 26);
            // 
            // tsmiVerification
            // 
            this.tsmiVerification.Name = "tsmiVerification";
            this.tsmiVerification.Size = new System.Drawing.Size(134, 22);
            this.tsmiVerification.Text = "Verification";
            this.tsmiVerification.Click += new System.EventHandler(this.tsmiVerification_Click);
            // 
            // panelGetDataOnlyWithType
            // 
            this.panelGetDataOnlyWithType.BackColor = System.Drawing.SystemColors.Control;
            this.panelGetDataOnlyWithType.Controls.Add(this.dtpStart);
            this.panelGetDataOnlyWithType.Controls.Add(this.btnGetDataOnlyWithType);
            this.panelGetDataOnlyWithType.Controls.Add(this.label2);
            this.panelGetDataOnlyWithType.Controls.Add(this.label1);
            this.panelGetDataOnlyWithType.Controls.Add(this.dtpEnd);
            this.panelGetDataOnlyWithType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGetDataOnlyWithType.Location = new System.Drawing.Point(0, 0);
            this.panelGetDataOnlyWithType.Name = "panelGetDataOnlyWithType";
            this.panelGetDataOnlyWithType.Size = new System.Drawing.Size(173, 123);
            this.panelGetDataOnlyWithType.TabIndex = 5;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(47, 16);
            this.dtpStart.MaxDate = new System.DateTime(2200, 1, 1, 0, 0, 0, 0);
            this.dtpStart.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(120, 20);
            this.dtpStart.TabIndex = 2;
            // 
            // btnGetDataOnlyWithType
            // 
            this.btnGetDataOnlyWithType.Location = new System.Drawing.Point(50, 77);
            this.btnGetDataOnlyWithType.Name = "btnGetDataOnlyWithType";
            this.btnGetDataOnlyWithType.Size = new System.Drawing.Size(92, 29);
            this.btnGetDataOnlyWithType.TabIndex = 1;
            this.btnGetDataOnlyWithType.Text = "Запрос данных";
            this.btnGetDataOnlyWithType.UseVisualStyleBackColor = true;
            this.btnGetDataOnlyWithType.Click += new System.EventHandler(this.btnGetDataOnlyWithType_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Конец";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Начало";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(47, 52);
            this.dtpEnd.MaxDate = new System.DateTime(2200, 1, 1, 0, 0, 0, 0);
            this.dtpEnd.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(120, 20);
            this.dtpEnd.TabIndex = 3;
            // 
            // btnConnection
            // 
            this.btnConnection.Location = new System.Drawing.Point(42, 3);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(92, 34);
            this.btnConnection.TabIndex = 0;
            this.btnConnection.Text = "Подключиться к серверу";
            this.btnConnection.UseVisualStyleBackColor = true;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelAutoVerif);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.splitter3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1062, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(173, 595);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnAutoVerification);
            this.panel6.Controls.Add(this.mtbSetPoint);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 168);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(173, 91);
            this.panel6.TabIndex = 9;
            // 
            // btnAutoVerification
            // 
            this.btnAutoVerification.Location = new System.Drawing.Point(42, 46);
            this.btnAutoVerification.Name = "btnAutoVerification";
            this.btnAutoVerification.Size = new System.Drawing.Size(106, 38);
            this.btnAutoVerification.TabIndex = 2;
            this.btnAutoVerification.Text = "Автоматическая верификация";
            this.btnAutoVerification.UseVisualStyleBackColor = true;
            this.btnAutoVerification.Click += new System.EventHandler(this.btnAutoVerification_Click);
            // 
            // mtbSetPoint
            // 
            this.mtbSetPoint.Location = new System.Drawing.Point(42, 20);
            this.mtbSetPoint.Mask = "00000";
            this.mtbSetPoint.Name = "mtbSetPoint";
            this.mtbSetPoint.PromptChar = '.';
            this.mtbSetPoint.Size = new System.Drawing.Size(100, 20);
            this.mtbSetPoint.TabIndex = 1;
            this.mtbSetPoint.Text = "1000";
            this.mtbSetPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtbSetPoint.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Максимальное потребление";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panelGetDataOnlyWithType);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 45);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(173, 123);
            this.panel5.TabIndex = 8;
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter3.Location = new System.Drawing.Point(0, 42);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(173, 3);
            this.splitter3.TabIndex = 7;
            this.splitter3.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnConnection);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(173, 42);
            this.panel4.TabIndex = 6;
            // 
            // btnDelAutoVerif
            // 
            this.btnDelAutoVerif.Location = new System.Drawing.Point(42, 265);
            this.btnDelAutoVerif.Name = "btnDelAutoVerif";
            this.btnDelAutoVerif.Size = new System.Drawing.Size(106, 50);
            this.btnDelAutoVerif.TabIndex = 10;
            this.btnDelAutoVerif.Text = "Убрать автоматическую верификацию";
            this.btnDelAutoVerif.UseVisualStyleBackColor = true;
            this.btnDelAutoVerif.Click += new System.EventHandler(this.btnDelAutoVerif_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 595);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "MatrixIT верификация данных";
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableFixed)).EndInit();
            this.cmsForDgvTableFixed.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            this.cmsForDgvTable.ResumeLayout(false);
            this.panelGetDataOnlyWithType.ResumeLayout(false);
            this.panelGetDataOnlyWithType.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListBox lbConsole;
        public System.Windows.Forms.DataGridView dgvTable;
        private System.Windows.Forms.Panel panelGetDataOnlyWithType;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Button btnGetDataOnlyWithType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Button btnConnection;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip cmsForDgvTable;
        private System.Windows.Forms.ToolStripMenuItem tsmiVerification;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.DataGridView dgvTableFixed;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNamef;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPnameF;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNetworkAddressf;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdf;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObjectIdf;
        private System.Windows.Forms.DataGridViewTextBoxColumn colS1f;
        private System.Windows.Forms.DataGridViewTextBoxColumn colG1f;
        private System.Windows.Forms.ContextMenuStrip cmsForDgvTableFixed;
        private System.Windows.Forms.ToolStripMenuItem tsmiGetDataFromHub;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPname;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObjectId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colS1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVerification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colG1;
        private System.Windows.Forms.ToolStripMenuItem tsmiVerif;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnAutoVerification;
        private System.Windows.Forms.MaskedTextBox mtbSetPoint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDelAutoVerif;
    }
}

