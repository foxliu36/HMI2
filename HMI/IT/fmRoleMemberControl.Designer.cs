namespace HMI.IT
{
    partial class fmRoleMemberControl
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbModule = new System.Windows.Forms.ListBox();
            this.lbRoleID = new System.Windows.Forms.ListBox();
            this.btnProfile = new System.Windows.Forms.Button();
            this.dgvAuth = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbAuthAdd = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.lblDetail2 = new System.Windows.Forms.Label();
            this.lblDetail1 = new System.Windows.Forms.Label();
            this.txtDetail2 = new System.Windows.Forms.TextBox();
            this.btnDetailCheck = new System.Windows.Forms.Button();
            this.txtDetail1 = new System.Windows.Forms.TextBox();
            this.btnAuthAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRenewXml = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnDeleteRange = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuth)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 154);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(297, 81);
            this.dataGridView1.TabIndex = 0;
            // 
            // lbModule
            // 
            this.lbModule.FormattingEnabled = true;
            this.lbModule.ItemHeight = 12;
            this.lbModule.Location = new System.Drawing.Point(12, 12);
            this.lbModule.Name = "lbModule";
            this.lbModule.Size = new System.Drawing.Size(120, 136);
            this.lbModule.TabIndex = 2;
            this.lbModule.SelectedIndexChanged += new System.EventHandler(this.lbModule_SelectedIndexChanged);
            // 
            // lbRoleID
            // 
            this.lbRoleID.FormattingEnabled = true;
            this.lbRoleID.ItemHeight = 12;
            this.lbRoleID.Location = new System.Drawing.Point(189, 12);
            this.lbRoleID.Name = "lbRoleID";
            this.lbRoleID.Size = new System.Drawing.Size(120, 136);
            this.lbRoleID.TabIndex = 3;
            this.lbRoleID.SelectedIndexChanged += new System.EventHandler(this.lbRoleID_SelectedIndexChanged);
            // 
            // btnProfile
            // 
            this.btnProfile.Location = new System.Drawing.Point(327, 154);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(75, 23);
            this.btnProfile.TabIndex = 5;
            this.btnProfile.Text = "解析";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // dgvAuth
            // 
            this.dgvAuth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuth.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvAuth.Location = new System.Drawing.Point(408, 12);
            this.dgvAuth.Name = "dgvAuth";
            this.dgvAuth.RowTemplate.Height = 24;
            this.dgvAuth.Size = new System.Drawing.Size(550, 474);
            this.dgvAuth.TabIndex = 7;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "範圍種類";
            this.Column1.HeaderText = "範圍種類";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "範圍1";
            this.Column2.HeaderText = "範圍1";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "範圍2";
            this.Column3.HeaderText = "範圍2";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "key1";
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "key2";
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            // 
            // cbAuthAdd
            // 
            this.cbAuthAdd.FormattingEnabled = true;
            this.cbAuthAdd.Location = new System.Drawing.Point(79, 36);
            this.cbAuthAdd.Name = "cbAuthAdd";
            this.cbAuthAdd.Size = new System.Drawing.Size(121, 20);
            this.cbAuthAdd.TabIndex = 8;
            this.cbAuthAdd.SelectedIndexChanged += new System.EventHandler(this.cbAuthAdd_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCheck);
            this.groupBox1.Controls.Add(this.lblDetail2);
            this.groupBox1.Controls.Add(this.lblDetail1);
            this.groupBox1.Controls.Add(this.txtDetail2);
            this.groupBox1.Controls.Add(this.btnDetailCheck);
            this.groupBox1.Controls.Add(this.txtDetail1);
            this.groupBox1.Controls.Add(this.btnAuthAdd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbAuthAdd);
            this.groupBox1.Location = new System.Drawing.Point(12, 241);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 245);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "新增腳色範圍";
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(164, 78);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(36, 23);
            this.btnCheck.TabIndex = 16;
            this.btnCheck.Text = "...";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // lblDetail2
            // 
            this.lblDetail2.AutoSize = true;
            this.lblDetail2.Enabled = false;
            this.lblDetail2.Location = new System.Drawing.Point(11, 162);
            this.lblDetail2.Name = "lblDetail2";
            this.lblDetail2.Size = new System.Drawing.Size(62, 12);
            this.lblDetail2.TabIndex = 15;
            this.lblDetail2.Text = "範圍細節2:";
            // 
            // lblDetail1
            // 
            this.lblDetail1.AutoSize = true;
            this.lblDetail1.Location = new System.Drawing.Point(11, 83);
            this.lblDetail1.Name = "lblDetail1";
            this.lblDetail1.Size = new System.Drawing.Size(62, 12);
            this.lblDetail1.TabIndex = 14;
            this.lblDetail1.Text = "範圍細節1:";
            // 
            // txtDetail2
            // 
            this.txtDetail2.Enabled = false;
            this.txtDetail2.Location = new System.Drawing.Point(79, 159);
            this.txtDetail2.Name = "txtDetail2";
            this.txtDetail2.Size = new System.Drawing.Size(77, 22);
            this.txtDetail2.TabIndex = 13;
            // 
            // btnDetailCheck
            // 
            this.btnDetailCheck.Location = new System.Drawing.Point(19, 203);
            this.btnDetailCheck.Name = "btnDetailCheck";
            this.btnDetailCheck.Size = new System.Drawing.Size(75, 23);
            this.btnDetailCheck.TabIndex = 12;
            this.btnDetailCheck.Text = "查詢";
            this.btnDetailCheck.UseVisualStyleBackColor = true;
            this.btnDetailCheck.Click += new System.EventHandler(this.btnDetailCheck_Click);
            // 
            // txtDetail1
            // 
            this.txtDetail1.Location = new System.Drawing.Point(79, 80);
            this.txtDetail1.Name = "txtDetail1";
            this.txtDetail1.Size = new System.Drawing.Size(77, 22);
            this.txtDetail1.TabIndex = 11;
            // 
            // btnAuthAdd
            // 
            this.btnAuthAdd.Location = new System.Drawing.Point(134, 203);
            this.btnAuthAdd.Name = "btnAuthAdd";
            this.btnAuthAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAuthAdd.TabIndex = 10;
            this.btnAuthAdd.Text = "新增範圍";
            this.btnAuthAdd.UseVisualStyleBackColor = true;
            this.btnAuthAdd.Click += new System.EventHandler(this.btnAuthAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "範圍種類:";
            // 
            // btnRenewXml
            // 
            this.btnRenewXml.Location = new System.Drawing.Point(408, 505);
            this.btnRenewXml.Name = "btnRenewXml";
            this.btnRenewXml.Size = new System.Drawing.Size(124, 54);
            this.btnRenewXml.TabIndex = 10;
            this.btnRenewXml.Text = "更新Xml";
            this.btnRenewXml.UseVisualStyleBackColor = true;
            this.btnRenewXml.Click += new System.EventHandler(this.btnRenewXml_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(282, 277);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 88);
            this.listBox1.TabIndex = 11;
            // 
            // btnDeleteRange
            // 
            this.btnDeleteRange.Location = new System.Drawing.Point(273, 444);
            this.btnDeleteRange.Name = "btnDeleteRange";
            this.btnDeleteRange.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteRange.TabIndex = 12;
            this.btnDeleteRange.Text = "刪除範圍";
            this.btnDeleteRange.UseVisualStyleBackColor = true;
            this.btnDeleteRange.Click += new System.EventHandler(this.btnDeleteRange_Click);
            // 
            // fmRoleMemberControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 592);
            this.Controls.Add(this.btnDeleteRange);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnRenewXml);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvAuth);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.lbRoleID);
            this.Controls.Add(this.lbModule);
            this.Controls.Add(this.dataGridView1);
            this.Name = "fmRoleMemberControl";
            this.Text = "腳色成員管理";
            this.Load += new System.EventHandler(this.fmRoleMemberControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuth)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox lbModule;
        private System.Windows.Forms.ListBox lbRoleID;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.DataGridView dgvAuth;
        private System.Windows.Forms.ComboBox cbAuthAdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAuthAdd;
        private System.Windows.Forms.Button btnDetailCheck;
        private System.Windows.Forms.TextBox txtDetail1;
        private System.Windows.Forms.Label lblDetail2;
        private System.Windows.Forms.Label lblDetail1;
        private System.Windows.Forms.TextBox txtDetail2;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnRenewXml;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnDeleteRange;
    }
}