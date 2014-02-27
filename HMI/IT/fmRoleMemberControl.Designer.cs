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
            this.userControl11 = new HMI.PublicUnit.UserControl1();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 154);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(297, 133);
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
            this.btnProfile.Location = new System.Drawing.Point(326, 212);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(75, 23);
            this.btnProfile.TabIndex = 5;
            this.btnProfile.Text = "解析";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // userControl11
            // 
            this.userControl11.Location = new System.Drawing.Point(338, 12);
            this.userControl11.Margin = new System.Windows.Forms.Padding(2);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(367, 46);
            this.userControl11.TabIndex = 1;
            // 
            // fmRoleMemberControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 592);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.lbRoleID);
            this.Controls.Add(this.lbModule);
            this.Controls.Add(this.userControl11);
            this.Controls.Add(this.dataGridView1);
            this.Name = "fmRoleMemberControl";
            this.Text = "腳色成員管理";
            this.Load += new System.EventHandler(this.fmRoleMemberControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private PublicUnit.UserControl1 userControl11;
        private System.Windows.Forms.ListBox lbModule;
        private System.Windows.Forms.ListBox lbRoleID;
        private System.Windows.Forms.Button btnProfile;
    }
}