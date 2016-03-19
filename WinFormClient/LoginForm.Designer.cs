namespace BlackJack
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.submitButton = new System.Windows.Forms.Button();
            this.lbUserName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tBuserName = new System.Windows.Forms.TextBox();
            this.tBpassword = new System.Windows.Forms.TextBox();
            this.lBwrongPass = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.Color.Transparent;
            this.submitButton.BackgroundImage = global::BlackJack.Properties.Resources.ButtonSquare;
            this.submitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.submitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.Location = new System.Drawing.Point(319, 455);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(153, 34);
            this.submitButton.TabIndex = 3;
            this.submitButton.Text = "Enter";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.BackColor = System.Drawing.Color.Transparent;
            this.lbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbUserName.ForeColor = System.Drawing.Color.White;
            this.lbUserName.Location = new System.Drawing.Point(84, 231);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(125, 25);
            this.lbUserName.TabIndex = 2;
            this.lbUserName.Text = "User Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(84, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Password:";
            // 
            // tBuserName
            // 
            this.tBuserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tBuserName.Location = new System.Drawing.Point(247, 231);
            this.tBuserName.Name = "tBuserName";
            this.tBuserName.Size = new System.Drawing.Size(204, 29);
            this.tBuserName.TabIndex = 1;
            // 
            // tBpassword
            // 
            this.tBpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tBpassword.Location = new System.Drawing.Point(247, 287);
            this.tBpassword.Name = "tBpassword";
            this.tBpassword.PasswordChar = '*';
            this.tBpassword.Size = new System.Drawing.Size(204, 29);
            this.tBpassword.TabIndex = 2;
            // 
            // lBwrongPass
            // 
            this.lBwrongPass.AutoSize = true;
            this.lBwrongPass.BackColor = System.Drawing.Color.Transparent;
            this.lBwrongPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lBwrongPass.ForeColor = System.Drawing.Color.White;
            this.lBwrongPass.Location = new System.Drawing.Point(12, 371);
            this.lBwrongPass.Name = "lBwrongPass";
            this.lBwrongPass.Size = new System.Drawing.Size(460, 24);
            this.lBwrongPass.TabIndex = 4;
            this.lBwrongPass.Text = "Invalid user name or password, please try again.";
            this.lBwrongPass.Visible = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::BlackJack.Properties.Resources.Blackjack11;
            this.ClientSize = new System.Drawing.Size(504, 600);
            this.Controls.Add(this.lBwrongPass);
            this.Controls.Add(this.tBpassword);
            this.Controls.Add(this.tBuserName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.submitButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.Text = ".Net Final BlackJack Multiplayer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBuserName;
        private System.Windows.Forms.TextBox tBpassword;
        private System.Windows.Forms.Label lBwrongPass;
    }
}