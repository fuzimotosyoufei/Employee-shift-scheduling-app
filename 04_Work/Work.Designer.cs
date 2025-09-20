namespace Taguma
{
    partial class Work
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
            this.ReturnButton = new System.Windows.Forms.Button();
            this.workmanagementView = new System.Windows.Forms.DataGridView();
            this.cmbDay = new System.Windows.Forms.ComboBox();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.combYear = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.workmanagementView)).BeginInit();
            this.SuspendLayout();
            // 
            // ReturnButton
            // 
            this.ReturnButton.Location = new System.Drawing.Point(1004, 506);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(150, 67);
            this.ReturnButton.TabIndex = 6;
            this.ReturnButton.Text = "戻る";
            this.ReturnButton.UseVisualStyleBackColor = true;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // workmanagementView
            // 
            this.workmanagementView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.workmanagementView.Location = new System.Drawing.Point(40, 63);
            this.workmanagementView.Name = "workmanagementView";
            this.workmanagementView.RowHeadersWidth = 62;
            this.workmanagementView.RowTemplate.Height = 27;
            this.workmanagementView.Size = new System.Drawing.Size(1114, 420);
            this.workmanagementView.TabIndex = 7;
            // 
            // cmbDay
            // 
            this.cmbDay.FormattingEnabled = true;
            this.cmbDay.Location = new System.Drawing.Point(1039, 18);
            this.cmbDay.Name = "cmbDay";
            this.cmbDay.Size = new System.Drawing.Size(115, 26);
            this.cmbDay.TabIndex = 8;
            // 
            // cmbMonth
            // 
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(918, 18);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(115, 26);
            this.cmbMonth.TabIndex = 8;
            // 
            // combYear
            // 
            this.combYear.FormattingEnabled = true;
            this.combYear.Location = new System.Drawing.Point(797, 18);
            this.combYear.Name = "combYear";
            this.combYear.Size = new System.Drawing.Size(115, 26);
            this.combYear.TabIndex = 9;
            // 
            // Work
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 597);
            this.Controls.Add(this.combYear);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.cmbDay);
            this.Controls.Add(this.workmanagementView);
            this.Controls.Add(this.ReturnButton);
            this.Name = "Work";
            this.Text = "勤怠管理";
            ((System.ComponentModel.ISupportInitialize)(this.workmanagementView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ReturnButton;
        private System.Windows.Forms.DataGridView workmanagementView;
        private System.Windows.Forms.ComboBox cmbDay;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.ComboBox combYear;
    }
}