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
            this.cbAuthAdd = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAuthAdd = new System.Windows.Forms.Button();
            this.txtDetail1 = new System.Windows.Forms.TextBox();
            this.btnDetailCheck = new System.Windows.Forms.Button();
            this.txtDetail2 = new System.Windows.Forms.TextBox();
            this.lblDetail1 = new System.Windows.Forms.Label();
            this.lblDetail2 = new System.Windows.Forms.Label();
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
            this.dgvAuth.Location = new System.Drawing.Point(408, 12);
            this.dgvAuth.Name = "dgvAuth";
            this.dgvAuth.RowTemplate.Height = 24;
            this.dgvAuth.Size = new System.Drawing.Size(550, 474);
            this.dgvAuth.TabIndex = 7;
            // 
            // cbAuthAdd
            // 
            this.cbAuthAdd.FormattingEnabled = true;
            this.cbAuthAdd.Items.AddRange(new object[] {
            "人員",
            "部門",
            "職級",
            "職務和部門"});
            this.cbAuthAdd.Location = new System.Drawing.Point(79, 36);
            this.cbAuthAdd.Name = "cbAuthAdd";
            this.cbAuthAdd.Size = new System.Drawing.Size(121, 20);
            this.cbAuthAdd.TabIndex = 8;
            this.cbAuthAdd.SelectedIndexChanged += new System.EventHandler(this.cbAuthAdd_SelectedIndexChanged);
            // 
            // groupBox1
            // 
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
            this.groupBox1.Size = new System.Drawing.Size(246, 339);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "新增權限";
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
            // btnAuthAdd
            // 
            this.btnAuthAdd.Location = new System.Drawing.Point(134, 310);
            this.btnAuthAdd.Name = "btnAuthAdd";
            this.btnAuthAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAuthAdd.TabIndex = 10;
            this.btnAuthAdd.Text = "新增範圍";
            this.btnAuthAdd.UseVisualStyleBackColor = true;
            this.btnAuthAdd.Click += new System.EventHandler(this.btnAuthAdd_Click);
            // 
            // txtDetail1
            // 
            this.txtDetail1.Location = new System.Drawing.Point(79, 80);
            this.txtDetail1.Name = "txtDetail1";
            this.txtDetail1.Size = new System.Drawing.Size(118, 22);
            this.txtDetail1.TabIndex = 11;
            // 
            // btnDetailCheck
            // 
            this.btnDetailCheck.Location = new System.Drawing.Point(19, 310);
            this.btnDetailCheck.Name = "btnDetailCheck";
            this.btnDetailCheck.Size = new System.Drawing.Size(75, 23);
            this.btnDetailCheck.TabIndex = 12;
            this.btnDetailCheck.Text = "查詢";
            this.btnDetailCheck.UseVisualStyleBackColor = true;
            this.btnDetailCheck.Click += new System.EventHandler(this.btnDetailCheck_Click);
            // 
            // txtDetail2
            // 
            this.txtDetail2.Enabled = false;
            this.txtDetail2.Location = new System.Drawing.Point(79, 159);
            this.txtDetail2.Name = "txtDetail2";
            this.txtDetail2.Size = new System.Drawing.Size(118, 22);
            this.txtDetail2.TabIndex = 13;
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
            // fmRoleMemberControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 592);
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
    }
}