namespace HMI
{
    partial class fmCheckOldClockTime
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
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.hRDataSet = new HMI.HRDataSet();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eMPLOYEEIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eMPLOYEEEIPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dATETIMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tERMINALIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vERIFICATIONSOURCEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tBHRCLOCKTIMEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userControl11 = new HMI.PublicUnit.UserControl1();
            this.tB_HR_CLOCKTIMETableAdapter = new HMI.HRDataSetTableAdapters.TB_HR_CLOCKTIMETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hRDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBHRCLOCKTIMEBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.hRDataSet;
            this.bindingSource1.Position = 0;
            this.bindingSource1.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // hRDataSet
            // 
            this.hRDataSet.DataSetName = "HRDataSet";
            this.hRDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.eMPLOYEEIDDataGridViewTextBoxColumn,
            this.eMPLOYEEEIPDataGridViewTextBoxColumn,
            this.dATETIMEDataGridViewTextBoxColumn,
            this.tERMINALIDDataGridViewTextBoxColumn,
            this.vERIFICATIONSOURCEDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tBHRCLOCKTIMEBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(3, 184);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(862, 415);
            this.dataGridView1.TabIndex = 1;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // eMPLOYEEIDDataGridViewTextBoxColumn
            // 
            this.eMPLOYEEIDDataGridViewTextBoxColumn.DataPropertyName = "EMPLOYEE_ID";
            this.eMPLOYEEIDDataGridViewTextBoxColumn.HeaderText = "EMPLOYEE_ID";
            this.eMPLOYEEIDDataGridViewTextBoxColumn.Name = "eMPLOYEEIDDataGridViewTextBoxColumn";
            // 
            // eMPLOYEEEIPDataGridViewTextBoxColumn
            // 
            this.eMPLOYEEEIPDataGridViewTextBoxColumn.DataPropertyName = "EMPLOYEE_EIP";
            this.eMPLOYEEEIPDataGridViewTextBoxColumn.HeaderText = "EMPLOYEE_EIP";
            this.eMPLOYEEEIPDataGridViewTextBoxColumn.Name = "eMPLOYEEEIPDataGridViewTextBoxColumn";
            // 
            // dATETIMEDataGridViewTextBoxColumn
            // 
            this.dATETIMEDataGridViewTextBoxColumn.DataPropertyName = "DATE_TIME";
            this.dATETIMEDataGridViewTextBoxColumn.HeaderText = "DATE_TIME";
            this.dATETIMEDataGridViewTextBoxColumn.Name = "dATETIMEDataGridViewTextBoxColumn";
            // 
            // tERMINALIDDataGridViewTextBoxColumn
            // 
            this.tERMINALIDDataGridViewTextBoxColumn.DataPropertyName = "TERMINAL_ID";
            this.tERMINALIDDataGridViewTextBoxColumn.HeaderText = "TERMINAL_ID";
            this.tERMINALIDDataGridViewTextBoxColumn.Name = "tERMINALIDDataGridViewTextBoxColumn";
            // 
            // vERIFICATIONSOURCEDataGridViewTextBoxColumn
            // 
            this.vERIFICATIONSOURCEDataGridViewTextBoxColumn.DataPropertyName = "VERIFICATION_SOURCE";
            this.vERIFICATIONSOURCEDataGridViewTextBoxColumn.HeaderText = "VERIFICATION_SOURCE";
            this.vERIFICATIONSOURCEDataGridViewTextBoxColumn.Name = "vERIFICATIONSOURCEDataGridViewTextBoxColumn";
            // 
            // tBHRCLOCKTIMEBindingSource
            // 
            this.tBHRCLOCKTIMEBindingSource.DataMember = "TB_HR_CLOCKTIME";
            this.tBHRCLOCKTIMEBindingSource.DataSource = this.bindingSource1;
            // 
            // userControl11
            // 
            this.userControl11.Location = new System.Drawing.Point(23, 94);
            this.userControl11.Margin = new System.Windows.Forms.Padding(2);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(391, 67);
            this.userControl11.TabIndex = 2;
            // 
            // tB_HR_CLOCKTIMETableAdapter
            // 
            this.tB_HR_CLOCKTIMETableAdapter.ClearBeforeFill = true;
            // 
            // fmCheckOldClockTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 600);
            this.Controls.Add(this.userControl11);
            this.Controls.Add(this.dataGridView1);
            this.Name = "fmCheckOldClockTime";
            this.Text = "fmCheckOldClockTime";
            this.Load += new System.EventHandler(this.fmCheckOldClockTime_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hRDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBHRCLOCKTIMEBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private HRDataSet hRDataSet;
        private PublicUnit.UserControl1 userControl11;
        private System.Windows.Forms.BindingSource tBHRCLOCKTIMEBindingSource;
        private HRDataSetTableAdapters.TB_HR_CLOCKTIMETableAdapter tB_HR_CLOCKTIMETableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eMPLOYEEIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eMPLOYEEEIPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dATETIMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tERMINALIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vERIFICATIONSOURCEDataGridViewTextBoxColumn;
    }
}