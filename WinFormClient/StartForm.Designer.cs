namespace BlackJack
{
    partial class StartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.newGameButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.tablesListBox = new System.Windows.Forms.ListBox();
            this.createTableButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newGameButton
            // 
            this.newGameButton.BackColor = System.Drawing.Color.Transparent;
            this.newGameButton.BackgroundImage = global::BlackJack.Properties.Resources.ButtonSquare;
            this.newGameButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.newGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.newGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newGameButton.Location = new System.Drawing.Point(490, 229);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(153, 34);
            this.newGameButton.TabIndex = 0;
            this.newGameButton.Text = "Join Table";
            this.newGameButton.UseVisualStyleBackColor = false;
            this.newGameButton.Click += new System.EventHandler(this.NewGameBtn_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.BackgroundImage = global::BlackJack.Properties.Resources.ButtonSquare;
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(490, 459);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(153, 34);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // tablesListBox
            // 
            this.tablesListBox.FormattingEnabled = true;
            this.tablesListBox.Location = new System.Drawing.Point(263, 229);
            this.tablesListBox.Name = "tablesListBox";
            this.tablesListBox.Size = new System.Drawing.Size(179, 264);
            this.tablesListBox.TabIndex = 3;
            // 
            // createTableButton
            // 
            this.createTableButton.BackColor = System.Drawing.Color.Transparent;
            this.createTableButton.BackgroundImage = global::BlackJack.Properties.Resources.ButtonSquare;
            this.createTableButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.createTableButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.createTableButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createTableButton.Location = new System.Drawing.Point(490, 288);
            this.createTableButton.Name = "createTableButton";
            this.createTableButton.Size = new System.Drawing.Size(153, 34);
            this.createTableButton.TabIndex = 4;
            this.createTableButton.Text = "Create Table";
            this.createTableButton.UseVisualStyleBackColor = false;
            this.createTableButton.Click += new System.EventHandler(this.createTableButton_Click);
            // 
            // StartForm
            // 
            this.BackgroundImage = global::BlackJack.Properties.Resources.SplashPage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(734, 623);
            this.Controls.Add(this.createTableButton);
            this.Controls.Add(this.tablesListBox);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.newGameButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BlackJack Casino";
            this.ResumeLayout(false);

		}

        #endregion

        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.ListBox tablesListBox;
        private System.Windows.Forms.Button createTableButton;
    }
}