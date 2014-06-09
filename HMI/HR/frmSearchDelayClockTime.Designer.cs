namespace HMI.HR
{
    partial class frmSearchDelayClockTime
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
            this.btnFindMissing = new System.Windows.Forms.Button();
            this.btnMakeExcel = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(2, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(737, 459);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnFindMissing
            // 
            this.btnFindMissing.Font = new System.Drawing.Font("Buxton Sketch", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindMissing.Location = new System.Drawing.Point(745, 77);
            this.btnFindMissing.Name = "btnFindMissing";
            this.btnFindMissing.Size = new System.Drawing.Size(90, 72);
            this.btnFindMissing.TabIndex = 1;
            this.btnFindMissing.Text = "MissingLog";
            this.btnFindMissing.UseVisualStyleBackColor = true;
            this.btnFindMissing.Click += new System.EventHandler(this.btnFindMissing_Click);
            // 
            // btnMakeExcel
            // 
            this.btnMakeExcel.Font = new System.Drawing.Font("Buxton Sketch", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMakeExcel.Location = new System.Drawing.Point(745, 176);
            this.btnMakeExcel.Name = "btnMakeExcel";
            this.btnMakeExcel.Size = new System.Drawing.Size(90, 72);
            this.btnMakeExcel.TabIndex = 1;
            this.btnMakeExcel.Text = "MakeExcel";
            this.btnMakeExcel.UseVisualStyleBackColor = true;
            this.btnMakeExcel.Click += new System.EventHandler(this.btnMakeExcel_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // frmSearchDelayClockTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 537);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnMakeExcel);
            this.Controls.Add(this.btnFindMissing);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmSearchDelayClockTime";
            this.Text = "延遲的卡鐘資料";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnFindMissing;
        private System.Windows.Forms.Button btnMakeExcel;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}