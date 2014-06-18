namespace HMI.IT
{
    partial class fmEipFormControl
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
            this.cbModule = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbGroup = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.txtModule = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtParent = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDataKey = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtOrders = new System.Windows.Forms.TextBox();
            this.cboxOpen = new System.Windows.Forms.CheckBox();
            this.userControl11 = new HMI.PublicUnit.UserControl1();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 268);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(722, 248);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // cbModule
            // 
            this.cbModule.FormattingEnabled = true;
            this.cbModule.Location = new System.Drawing.Point(91, 22);
            this.cbModule.Name = "cbModule";
            this.cbModule.Size = new System.Drawing.Size(121, 20);
            this.cbModule.TabIndex = 1;
            this.cbModule.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "TYPE=Module";
            // 
            // cbGroup
            // 
            this.cbGroup.FormattingEnabled = true;
            this.cbGroup.Location = new System.Drawing.Point(293, 22);
            this.cbGroup.Name = "cbGroup";
            this.cbGroup.Size = new System.Drawing.Size(121, 20);
            this.cbGroup.TabIndex = 1;
            this.cbGroup.SelectedIndexChanged += new System.EventHandler(this.cbGroup_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "TYPE=Group";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(32, 68);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(53, 12);
            this.lblname.TabIndex = 3;
            this.lblname.Text = "模組名稱";
            // 
            // txtModule
            // 
            this.txtModule.Location = new System.Drawing.Point(91, 65);
            this.txtModule.Name = "txtModule";
            this.txtModule.Size = new System.Drawing.Size(100, 22);
            this.txtModule.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "上層畫面";
            // 
            // txtParent
            // 
            this.txtParent.Location = new System.Drawing.Point(91, 108);
            this.txtParent.Name = "txtParent";
            this.txtParent.Size = new System.Drawing.Size(100, 22);
            this.txtParent.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "URL";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(91, 148);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(409, 22);
            this.txtURL.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(223, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 3;
            this.label10.Text = "類型";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(262, 68);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(100, 22);
            this.txtType.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(207, 111);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 12);
            this.label11.TabIndex = 3;
            this.label11.Text = "DataKey";
            // 
            // txtDataKey
            // 
            this.txtDataKey.Location = new System.Drawing.Point(262, 108);
            this.txtDataKey.Name = "txtDataKey";
            this.txtDataKey.Size = new System.Drawing.Size(100, 22);
            this.txtDataKey.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(381, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 3;
            this.label12.Text = "順序";
            // 
            // txtOrders
            // 
            this.txtOrders.Location = new System.Drawing.Point(420, 68);
            this.txtOrders.Name = "txtOrders";
            this.txtOrders.Size = new System.Drawing.Size(100, 22);
            this.txtOrders.TabIndex = 4;
            // 
            // cboxOpen
            // 
            this.cboxOpen.AutoSize = true;
            this.cboxOpen.Location = new System.Drawing.Point(91, 196);
            this.cboxOpen.Name = "cboxOpen";
            this.cboxOpen.Size = new System.Drawing.Size(84, 16);
            this.cboxOpen.TabIndex = 5;
            this.cboxOpen.Text = "開啟新視窗";
            this.cboxOpen.UseVisualStyleBackColor = true;
            // 
            // userControl11
            // 
            this.userControl11.Location = new System.Drawing.Point(34, 217);
            this.userControl11.Margin = new System.Windows.Forms.Padding(2);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(367, 46);
            this.userControl11.TabIndex = 6;
            // 
            // fmEipFormControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 518);
            this.Controls.Add(this.userControl11);
            this.Controls.Add(this.cboxOpen);
            this.Controls.Add(this.txtOrders);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtDataKey);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtParent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtModule);
            this.Controls.Add(this.lblname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbGroup);
            this.Controls.Add(this.cbModule);
            this.Controls.Add(this.dataGridView1);
            this.Name = "fmEipFormControl";
            this.Text = "畫面掛載";
            this.Load += new System.EventHandler(this.fmEipFormControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbModule;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.TextBox txtModule;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtParent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDataKey;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtOrders;
        private System.Windows.Forms.CheckBox cboxOpen;
        private PublicUnit.UserControl1 userControl11;
    }
}