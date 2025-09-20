namespace Taguma
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.LoginButton = new System.Windows.Forms.Button();
            this.passTB = new System.Windows.Forms.TextBox();
            this.idTB = new System.Windows.Forms.TextBox();
            this.passlbl = new System.Windows.Forms.Label();
            this.idlbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.Font = new System.Drawing.Font("メイリオ", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LoginButton.Location = new System.Drawing.Point(113, 304);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(546, 110);
            this.LoginButton.TabIndex = 0;
            this.LoginButton.Text = "ログイン";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // passTB
            // 
            this.passTB.Location = new System.Drawing.Point(268, 194);
            this.passTB.Multiline = true;
            this.passTB.Name = "passTB";
            this.passTB.Size = new System.Drawing.Size(391, 42);
            this.passTB.TabIndex = 1;
            // 
            // idTB
            // 
            this.idTB.Location = new System.Drawing.Point(268, 123);
            this.idTB.Multiline = true;
            this.idTB.Name = "idTB";
            this.idTB.Size = new System.Drawing.Size(391, 45);
            this.idTB.TabIndex = 1;
            // 
            // passlbl
            // 
            this.passlbl.AutoSize = true;
            this.passlbl.Font = new System.Drawing.Font("メイリオ", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.passlbl.Location = new System.Drawing.Point(93, 194);
            this.passlbl.Name = "passlbl";
            this.passlbl.Size = new System.Drawing.Size(158, 42);
            this.passlbl.TabIndex = 2;
            this.passlbl.Text = "パスワード";
            // 
            // idlbl
            // 
            this.idlbl.Font = new System.Drawing.Font("メイリオ", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.idlbl.Location = new System.Drawing.Point(106, 123);
            this.idlbl.Name = "idlbl";
            this.idlbl.Size = new System.Drawing.Size(156, 45);
            this.idlbl.TabIndex = 2;
            this.idlbl.Text = "管理者ID";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(836, 598);
            this.Controls.Add(this.idlbl);
            this.Controls.Add(this.passlbl);
            this.Controls.Add(this.idTB);
            this.Controls.Add(this.passTB);
            this.Controls.Add(this.LoginButton);
            this.Name = "Form1";
            this.Text = "ログイン画面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.TextBox passTB;
        private System.Windows.Forms.TextBox idTB;
        private System.Windows.Forms.Label passlbl;
        private System.Windows.Forms.Label idlbl;
    }
}

