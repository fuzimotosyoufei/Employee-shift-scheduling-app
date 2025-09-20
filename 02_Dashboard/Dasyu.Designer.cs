namespace Taguma
{
    partial class Dashboard
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
            this.WorkViewButton = new System.Windows.Forms.Button();
            this.ShiftViewButton = new System.Windows.Forms.Button();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WorkViewButton
            // 
            this.WorkViewButton.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.WorkViewButton.Location = new System.Drawing.Point(218, 145);
            this.WorkViewButton.Name = "WorkViewButton";
            this.WorkViewButton.Size = new System.Drawing.Size(308, 91);
            this.WorkViewButton.TabIndex = 0;
            this.WorkViewButton.Text = "勤務状況";
            this.WorkViewButton.UseVisualStyleBackColor = true;
            this.WorkViewButton.Click += new System.EventHandler(this.WorkViewButton_Click);
            // 
            // ShiftViewButton
            // 
            this.ShiftViewButton.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ShiftViewButton.Location = new System.Drawing.Point(218, 12);
            this.ShiftViewButton.Name = "ShiftViewButton";
            this.ShiftViewButton.Size = new System.Drawing.Size(308, 86);
            this.ShiftViewButton.TabIndex = 1;
            this.ShiftViewButton.Text = "シフト確認";
            this.ShiftViewButton.UseVisualStyleBackColor = true;
            this.ShiftViewButton.Click += new System.EventHandler(this.ShiftViewButton_Click);
            // 
            // LogoutButton
            // 
            this.LogoutButton.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LogoutButton.Location = new System.Drawing.Point(218, 294);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(308, 91);
            this.LogoutButton.TabIndex = 2;
            this.LogoutButton.Text = "ログアウト";
            this.LogoutButton.UseVisualStyleBackColor = true;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LogoutButton);
            this.Controls.Add(this.ShiftViewButton);
            this.Controls.Add(this.WorkViewButton);
            this.Name = "Dashboard";
            this.Text = "ダッシュボード画面";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button WorkViewButton;
        private System.Windows.Forms.Button ShiftViewButton;
        private System.Windows.Forms.Button LogoutButton;
    }
}