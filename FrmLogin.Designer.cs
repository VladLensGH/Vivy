namespace Vivy
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            pcbLogo = new PictureBox();
            lblLogin = new Label();
            pcbLogin = new PictureBox();
            pnlLogin = new Panel();
            pnlPassword = new Panel();
            pcbPassword = new PictureBox();
            btnLogin = new Button();
            lblNotRegistred = new Label();
            lblExit = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pcbLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcbLogin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcbPassword).BeginInit();
            SuspendLayout();
            // 
            // pcbLogo
            // 
            pcbLogo.Image = (Image)resources.GetObject("pcbLogo.Image");
            pcbLogo.Location = new Point(110, 62);
            pcbLogo.Name = "pcbLogo";
            pcbLogo.Size = new Size(87, 71);
            pcbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pcbLogo.TabIndex = 0;
            pcbLogo.TabStop = false;
            pcbLogo.Click += pictureBox1_Click;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Tahoma", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblLogin.ForeColor = Color.FromArgb(0, 126, 249);
            lblLogin.Location = new Point(88, 156);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(133, 39);
            lblLogin.TabIndex = 1;
            lblLogin.Text = "LOG IN";
            // 
            // pcbLogin
            // 
            pcbLogin.Image = (Image)resources.GetObject("pcbLogin.Image");
            pcbLogin.Location = new Point(36, 203);
            pcbLogin.Name = "pcbLogin";
            pcbLogin.Size = new Size(40, 40);
            pcbLogin.SizeMode = PictureBoxSizeMode.Zoom;
            pcbLogin.TabIndex = 2;
            pcbLogin.TabStop = false;
            // 
            // pnlLogin
            // 
            pnlLogin.BackColor = Color.FromArgb(0, 126, 249);
            pnlLogin.Location = new Point(36, 248);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(236, 1);
            pnlLogin.TabIndex = 3;
            // 
            // pnlPassword
            // 
            pnlPassword.BackColor = Color.FromArgb(0, 126, 249);
            pnlPassword.Location = new Point(36, 310);
            pnlPassword.Name = "pnlPassword";
            pnlPassword.Size = new Size(236, 1);
            pnlPassword.TabIndex = 5;
            // 
            // pcbPassword
            // 
            pcbPassword.Image = (Image)resources.GetObject("pcbPassword.Image");
            pcbPassword.Location = new Point(36, 271);
            pcbPassword.Name = "pcbPassword";
            pcbPassword.Size = new Size(40, 40);
            pcbPassword.SizeMode = PictureBoxSizeMode.Zoom;
            pcbPassword.TabIndex = 4;
            pcbPassword.TabStop = false;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(0, 126, 249);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Bahnschrift", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnLogin.ForeColor = Color.FromArgb(46, 51, 73);
            btnLogin.Location = new Point(36, 338);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(236, 37);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "ВОЙТИ";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblNotRegistred
            // 
            lblNotRegistred.AutoSize = true;
            lblNotRegistred.Font = new Font("Bahnschrift", 9.75F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            lblNotRegistred.ForeColor = Color.FromArgb(0, 126, 249);
            lblNotRegistred.Location = new Point(84, 378);
            lblNotRegistred.Name = "lblNotRegistred";
            lblNotRegistred.Size = new Size(141, 16);
            lblNotRegistred.TabIndex = 7;
            lblNotRegistred.Text = "Не зарегестрированы?";
            // 
            // lblExit
            // 
            lblExit.AutoSize = true;
            lblExit.Font = new Font("Bahnschrift", 9.75F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            lblExit.ForeColor = Color.FromArgb(0, 126, 249);
            lblExit.Location = new Point(132, 434);
            lblExit.Name = "lblExit";
            lblExit.Size = new Size(45, 16);
            lblExit.TabIndex = 8;
            lblExit.Text = "Выйти";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(25, 28, 41);
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Bahnschrift", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            txtUsername.ForeColor = Color.FromArgb(0, 126, 249);
            txtUsername.Location = new Point(82, 218);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(190, 24);
            txtUsername.TabIndex = 9;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(25, 28, 41);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Bahnschrift", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            txtPassword.ForeColor = Color.FromArgb(0, 126, 249);
            txtPassword.Location = new Point(88, 280);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(184, 24);
            txtPassword.TabIndex = 10;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 28, 41);
            ClientSize = new Size(308, 486);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblExit);
            Controls.Add(lblNotRegistred);
            Controls.Add(btnLogin);
            Controls.Add(pnlPassword);
            Controls.Add(pcbPassword);
            Controls.Add(pnlLogin);
            Controls.Add(pcbLogin);
            Controls.Add(lblLogin);
            Controls.Add(pcbLogo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmMain";
            ((System.ComponentModel.ISupportInitialize)pcbLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcbLogin).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcbPassword).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pcbLogo;
        private Label lblLogin;
        private PictureBox pcbLogin;
        private Panel pnlLogin;
        private Panel pnlPassword;
        private PictureBox pcbPassword;
        private Button btnLogin;
        private Label lblNotRegistred;
        private Label lblExit;
        private TextBox txtUsername;
        private TextBox txtPassword;
    }
}