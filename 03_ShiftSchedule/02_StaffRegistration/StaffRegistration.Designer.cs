namespace Taguma
{
    partial class StaffRegistration
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
            this.NameBox = new System.Windows.Forms.TextBox();
            this.TellBox = new System.Windows.Forms.TextBox();
            this.e_mailBox = new System.Windows.Forms.TextBox();
            this.bankBox = new System.Windows.Forms.TextBox();
            this.AddressBox = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.Label();
            this.call = new System.Windows.Forms.Label();
            this.mail = new System.Windows.Forms.Label();
            this.bank = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.Label();
            this.howtuukinn = new System.Windows.Forms.Label();
            this.ReturnButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.how = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(192, 69);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(352, 25);
            this.NameBox.TabIndex = 0;
            // 
            // TellBox
            // 
            this.TellBox.Location = new System.Drawing.Point(192, 110);
            this.TellBox.Name = "TellBox";
            this.TellBox.Size = new System.Drawing.Size(352, 25);
            this.TellBox.TabIndex = 0;
            // 
            // e_mailBox
            // 
            this.e_mailBox.Location = new System.Drawing.Point(192, 156);
            this.e_mailBox.Name = "e_mailBox";
            this.e_mailBox.Size = new System.Drawing.Size(352, 25);
            this.e_mailBox.TabIndex = 0;
            // 
            // bankBox
            // 
            this.bankBox.Location = new System.Drawing.Point(192, 200);
            this.bankBox.Name = "bankBox";
            this.bankBox.Size = new System.Drawing.Size(352, 25);
            this.bankBox.TabIndex = 0;
            // 
            // AddressBox
            // 
            this.AddressBox.Location = new System.Drawing.Point(192, 252);
            this.AddressBox.Name = "AddressBox";
            this.AddressBox.Size = new System.Drawing.Size(352, 25);
            this.AddressBox.TabIndex = 0;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(134, 69);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(44, 18);
            this.name.TabIndex = 1;
            this.name.Text = "名前";
            // 
            // call
            // 
            this.call.AutoSize = true;
            this.call.Location = new System.Drawing.Point(106, 110);
            this.call.Name = "call";
            this.call.Size = new System.Drawing.Size(80, 18);
            this.call.TabIndex = 1;
            this.call.Text = "電話番号";
            // 
            // mail
            // 
            this.mail.AutoSize = true;
            this.mail.Location = new System.Drawing.Point(81, 159);
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(105, 18);
            this.mail.TabIndex = 1;
            this.mail.Text = "メールアドレス";
            // 
            // bank
            // 
            this.bank.AutoSize = true;
            this.bank.Location = new System.Drawing.Point(106, 203);
            this.bank.Name = "bank";
            this.bank.Size = new System.Drawing.Size(80, 18);
            this.bank.TabIndex = 1;
            this.bank.Text = "銀行口座";
            // 
            // address
            // 
            this.address.AutoSize = true;
            this.address.Location = new System.Drawing.Point(106, 252);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(44, 18);
            this.address.TabIndex = 1;
            this.address.Text = "住所";
            // 
            // howtuukinn
            // 
            this.howtuukinn.AutoSize = true;
            this.howtuukinn.Location = new System.Drawing.Point(106, 297);
            this.howtuukinn.Name = "howtuukinn";
            this.howtuukinn.Size = new System.Drawing.Size(80, 18);
            this.howtuukinn.TabIndex = 1;
            this.howtuukinn.Text = "通勤手段";
            // 
            // ReturnButton
            // 
            this.ReturnButton.Location = new System.Drawing.Point(495, 384);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(293, 63);
            this.ReturnButton.TabIndex = 2;
            this.ReturnButton.Text = "戻る";
            this.ReturnButton.UseVisualStyleBackColor = true;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(84, 375);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(293, 63);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "登録";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // how
            // 
            this.how.FormattingEnabled = true;
            this.how.Items.AddRange(new object[] {
            "車",
            "徒歩",
            "自転車"});
            this.how.Location = new System.Drawing.Point(192, 297);
            this.how.Name = "how";
            this.how.Size = new System.Drawing.Size(352, 26);
            this.how.TabIndex = 4;
            // 
            // StaffRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.how);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.howtuukinn);
            this.Controls.Add(this.address);
            this.Controls.Add(this.bank);
            this.Controls.Add(this.mail);
            this.Controls.Add(this.call);
            this.Controls.Add(this.name);
            this.Controls.Add(this.AddressBox);
            this.Controls.Add(this.bankBox);
            this.Controls.Add(this.e_mailBox);
            this.Controls.Add(this.TellBox);
            this.Controls.Add(this.NameBox);
            this.Name = "StaffRegistration";
            this.Text = "従業員登録";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox TellBox;
        private System.Windows.Forms.TextBox e_mailBox;
        private System.Windows.Forms.TextBox bankBox;
        private System.Windows.Forms.TextBox AddressBox;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label call;
        private System.Windows.Forms.Label mail;
        private System.Windows.Forms.Label bank;
        private System.Windows.Forms.Label address;
        private System.Windows.Forms.Label howtuukinn;
        private System.Windows.Forms.Button ReturnButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ComboBox how;
    }
}