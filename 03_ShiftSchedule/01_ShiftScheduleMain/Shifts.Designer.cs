namespace Taguma
{
    partial class Shifts
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
            this.shiftView = new System.Windows.Forms.DataGridView();
            this.AddButton = new System.Windows.Forms.Button();
            this.Registration = new System.Windows.Forms.Button();
            this.ReturnButton = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.MonthComboBox = new System.Windows.Forms.ComboBox();
            this.YearComboBox = new System.Windows.Forms.ComboBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.shiftView)).BeginInit();
            this.SuspendLayout();
            // 
            // shiftView
            // 
            this.shiftView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shiftView.Location = new System.Drawing.Point(33, 72);
            this.shiftView.Name = "shiftView";
            this.shiftView.RowHeadersWidth = 62;
            this.shiftView.Size = new System.Drawing.Size(1270, 854);
            this.shiftView.TabIndex = 0;
            // 
            // AddButton
            // 
            this.AddButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.AddButton.Location = new System.Drawing.Point(33, 941);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(314, 59);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "シフト希望";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // Registration
            // 
            this.Registration.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Registration.Location = new System.Drawing.Point(353, 941);
            this.Registration.Name = "Registration";
            this.Registration.Size = new System.Drawing.Size(154, 59);
            this.Registration.TabIndex = 2;
            this.Registration.Text = "登録";
            this.Registration.UseVisualStyleBackColor = true;
            this.Registration.Click += new System.EventHandler(this.Registration_Click);
            // 
            // ReturnButton
            // 
            this.ReturnButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ReturnButton.Location = new System.Drawing.Point(1132, 941);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(152, 66);
            this.ReturnButton.TabIndex = 5;
            this.ReturnButton.Text = "戻る";
            this.ReturnButton.UseVisualStyleBackColor = true;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSave.Location = new System.Drawing.Point(655, 941);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(148, 59);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保存ボタン";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // MonthComboBox
            // 
            this.MonthComboBox.FormattingEnabled = true;
            this.MonthComboBox.Location = new System.Drawing.Point(297, 40);
            this.MonthComboBox.Name = "MonthComboBox";
            this.MonthComboBox.Size = new System.Drawing.Size(258, 26);
            this.MonthComboBox.TabIndex = 7;
            this.MonthComboBox.SelectedIndexChanged += new System.EventHandler(this.MonthComboBox_SelectedIndexChanged);
            // 
            // YearComboBox
            // 
            this.YearComboBox.FormattingEnabled = true;
            this.YearComboBox.Location = new System.Drawing.Point(33, 40);
            this.YearComboBox.Name = "YearComboBox";
            this.YearComboBox.Size = new System.Drawing.Size(258, 26);
            this.YearComboBox.TabIndex = 8;
            this.YearComboBox.SelectedIndexChanged += new System.EventHandler(this.YearComboBox_SelectedIndexChanged);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DeleteButton.Location = new System.Drawing.Point(513, 941);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(136, 59);
            this.DeleteButton.TabIndex = 9;
            this.DeleteButton.Text = "削除";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // Shifts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1438, 1028);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.YearComboBox);
            this.Controls.Add(this.MonthComboBox);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.Registration);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.shiftView);
            this.Name = "Shifts";
            this.Text = "シフト表";
            this.Load += new System.EventHandler(this.Shifts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.shiftView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView shiftView;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button Registration;
        private System.Windows.Forms.Button ReturnButton;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox MonthComboBox;
        private System.Windows.Forms.ComboBox YearComboBox;
        private System.Windows.Forms.Button DeleteButton;
    }
}