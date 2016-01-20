namespace qdocs
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRun = new System.Windows.Forms.ToolStripButton();
            this.btnExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuOpis = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLenta = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContrAgents = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tbMinusPrixod = new System.Windows.Forms.CheckBox();
            this.tbDt2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDt1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvConditions = new System.Windows.Forms.DataGridView();
            this.NamePar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VidOp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.da = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConditions)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgv);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(679, 546);
            this.splitContainer1.SplitterDistance = 292;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Num,
            this.VidOp,
            this.Column1,
            this.Column5,
            this.Column2,
            this.da,
            this.Column6,
            this.Column3,
            this.cr,
            this.nd,
            this.nc,
            this.note});
            this.dgv.DataSource = this.bs;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 39);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(677, 251);
            this.dgv.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRun,
            this.btnExcel,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(677, 39);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnRun
            // 
            this.btnRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRun.Image = ((System.Drawing.Image)(resources.GetObject("btnRun.Image")));
            this.btnRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(36, 36);
            this.btnRun.Text = "toolStripButton1";
            this.btnRun.ToolTipText = "Выполнить запрос";
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(36, 36);
            this.btnExcel.Text = "toolStripButton1";
            this.btnExcel.ToolTipText = "Выгрузить в Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpis,
            this.mnuLenta,
            this.mnuContrAgents});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(59, 36);
            this.toolStripDropDownButton1.Text = "Печать";
            // 
            // mnuOpis
            // 
            this.mnuOpis.Name = "mnuOpis";
            this.mnuOpis.Size = new System.Drawing.Size(252, 22);
            this.mnuOpis.Text = "Опись документов по допофису";
            this.mnuOpis.Click += new System.EventHandler(this.mnuOpis_Click);
            // 
            // mnuLenta
            // 
            this.mnuLenta.Name = "mnuLenta";
            this.mnuLenta.Size = new System.Drawing.Size(252, 22);
            this.mnuLenta.Text = "Ленточка";
            this.mnuLenta.Click += new System.EventHandler(this.mnuLenta_Click);
            // 
            // mnuContrAgents
            // 
            this.mnuContrAgents.Name = "mnuContrAgents";
            this.mnuContrAgents.Size = new System.Drawing.Size(252, 22);
            this.mnuContrAgents.Text = "Контрагенты";
            this.mnuContrAgents.Click += new System.EventHandler(this.mnuContrAgents_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tbMinusPrixod);
            this.splitContainer2.Panel1.Controls.Add(this.tbDt2);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.tbDt1);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvConditions);
            this.splitContainer2.Size = new System.Drawing.Size(679, 250);
            this.splitContainer2.SplitterDistance = 151;
            this.splitContainer2.TabIndex = 0;
            // 
            // tbMinusPrixod
            // 
            this.tbMinusPrixod.AutoSize = true;
            this.tbMinusPrixod.Location = new System.Drawing.Point(17, 105);
            this.tbMinusPrixod.Name = "tbMinusPrixod";
            this.tbMinusPrixod.Size = new System.Drawing.Size(120, 17);
            this.tbMinusPrixod.TabIndex = 5;
            this.tbMinusPrixod.Text = "Исключить приход";
            this.tbMinusPrixod.UseVisualStyleBackColor = true;
            // 
            // tbDt2
            // 
            this.tbDt2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbDt2.Location = new System.Drawing.Point(36, 59);
            this.tbDt2.Name = "tbDt2";
            this.tbDt2.Size = new System.Drawing.Size(87, 20);
            this.tbDt2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "по";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "с";
            // 
            // tbDt1
            // 
            this.tbDt1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbDt1.Location = new System.Drawing.Point(36, 33);
            this.tbDt1.Name = "tbDt1";
            this.tbDt1.Size = new System.Drawing.Size(87, 20);
            this.tbDt1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Период";
            // 
            // dgvConditions
            // 
            this.dgvConditions.AllowUserToAddRows = false;
            this.dgvConditions.AllowUserToDeleteRows = false;
            this.dgvConditions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConditions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NamePar,
            this.p1,
            this.p2,
            this.p3,
            this.p4});
            this.dgvConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConditions.Location = new System.Drawing.Point(0, 0);
            this.dgvConditions.Name = "dgvConditions";
            this.dgvConditions.Size = new System.Drawing.Size(522, 248);
            this.dgvConditions.TabIndex = 0;
            // 
            // NamePar
            // 
            this.NamePar.Frozen = true;
            this.NamePar.HeaderText = "Параметр";
            this.NamePar.Name = "NamePar";
            this.NamePar.ReadOnly = true;
            this.NamePar.Width = 120;
            // 
            // p1
            // 
            this.p1.HeaderText = "Значение1";
            this.p1.Name = "p1";
            // 
            // p2
            // 
            this.p2.HeaderText = "Значение2";
            this.p2.Name = "p2";
            // 
            // p3
            // 
            this.p3.HeaderText = "Значение 3";
            this.p3.Name = "p3";
            // 
            // p4
            // 
            this.p4.HeaderText = "Значение 4";
            this.p4.Name = "p4";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "accountingdate";
            this.Column4.HeaderText = "Дата";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Num
            // 
            this.Num.DataPropertyName = "num";
            this.Num.HeaderText = "№ док.";
            this.Num.Name = "Num";
            this.Num.ReadOnly = true;
            this.Num.Width = 50;
            // 
            // VidOp
            // 
            this.VidOp.DataPropertyName = "operationcode";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.VidOp.DefaultCellStyle = dataGridViewCellStyle1;
            this.VidOp.HeaderText = "Вид оп";
            this.VidOp.Name = "VidOp";
            this.VidOp.ReadOnly = true;
            this.VidOp.Width = 50;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "sm";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "Сумма";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 90;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "inndebet";
            this.Column5.HeaderText = "ИНН деб.";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ticdebet";
            this.Column2.HeaderText = "БИК деб";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // da
            // 
            this.da.DataPropertyName = "debetaccount";
            this.da.HeaderText = "Дебет";
            this.da.Name = "da";
            this.da.ReadOnly = true;
            this.da.Width = 130;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "inncredit";
            this.Column6.HeaderText = "ИНН кред.";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ticcredit";
            this.Column3.HeaderText = "БИК кред";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // cr
            // 
            this.cr.DataPropertyName = "creditaccount";
            this.cr.HeaderText = "Кредит";
            this.cr.Name = "cr";
            this.cr.ReadOnly = true;
            this.cr.Width = 130;
            // 
            // nd
            // 
            this.nd.DataPropertyName = "namedebet";
            this.nd.HeaderText = "Плательщик";
            this.nd.Name = "nd";
            this.nd.ReadOnly = true;
            this.nd.Width = 200;
            // 
            // nc
            // 
            this.nc.DataPropertyName = "namecredit";
            this.nc.HeaderText = "Получатель";
            this.nc.Name = "nc";
            this.nc.ReadOnly = true;
            this.nc.Width = 200;
            // 
            // note
            // 
            this.note.DataPropertyName = "note";
            this.note.HeaderText = "Назн.платежа";
            this.note.Name = "note";
            this.note.ReadOnly = true;
            this.note.Width = 300;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 546);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmMain";
            this.Text = "qdocs";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConditions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvConditions;
        private System.Windows.Forms.DateTimePicker tbDt1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker tbDt2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnRun;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.BindingSource bs;
        private System.Windows.Forms.ToolStripButton btnExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamePar;
        private System.Windows.Forms.DataGridViewTextBoxColumn p1;
        private System.Windows.Forms.DataGridViewTextBoxColumn p2;
        private System.Windows.Forms.DataGridViewTextBoxColumn p3;
        private System.Windows.Forms.DataGridViewTextBoxColumn p4;
        private System.Windows.Forms.CheckBox tbMinusPrixod;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem mnuOpis;
        private System.Windows.Forms.ToolStripMenuItem mnuLenta;
        private System.Windows.Forms.ToolStripMenuItem mnuContrAgents;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn VidOp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn da;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn cr;
        private System.Windows.Forms.DataGridViewTextBoxColumn nd;
        private System.Windows.Forms.DataGridViewTextBoxColumn nc;
        private System.Windows.Forms.DataGridViewTextBoxColumn note;



    }
}

