namespace Vivy
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            panel1 = new Panel();
            PnlNav = new Panel();
            btnsettings = new Button();
            btnContactUs = new Button();
            btnCalendar = new Button();
            btnAnalytics = new Button();
            BtnDashboard = new Button();
            panel2 = new Panel();
            label1 = new Label();
            Usder = new Label();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(24, 30, 54);
            panel1.Controls.Add(PnlNav);
            panel1.Controls.Add(btnsettings);
            panel1.Controls.Add(btnContactUs);
            panel1.Controls.Add(btnCalendar);
            panel1.Controls.Add(btnAnalytics);
            panel1.Controls.Add(BtnDashboard);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(186, 577);
            panel1.TabIndex = 0;
            // 
            // PnlNav
            // 
            PnlNav.BackColor = Color.FromArgb(0, 126, 249);
            PnlNav.Location = new Point(0, 193);
            PnlNav.Name = "PnlNav";
            PnlNav.Size = new Size(3, 100);
            PnlNav.TabIndex = 8;
            // 
            // btnsettings
            // 
            btnsettings.FlatAppearance.BorderSize = 0;
            btnsettings.FlatStyle = FlatStyle.Flat;
            btnsettings.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnsettings.ForeColor = Color.FromArgb(0, 126, 249);
            btnsettings.Image = Properties.Resources.dom_icon_smaller;
            btnsettings.Location = new Point(0, 535);
            btnsettings.Name = "btnsettings";
            btnsettings.Size = new Size(186, 42);
            btnsettings.TabIndex = 7;
            btnsettings.Text = "Settings";
            btnsettings.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnsettings.UseVisualStyleBackColor = true;
            // 
            // btnContactUs
            // 
            btnContactUs.Dock = DockStyle.Top;
            btnContactUs.FlatAppearance.BorderSize = 0;
            btnContactUs.FlatStyle = FlatStyle.Flat;
            btnContactUs.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnContactUs.ForeColor = Color.FromArgb(0, 126, 249);
            btnContactUs.Image = (Image)resources.GetObject("btnContactUs.Image");
            btnContactUs.Location = new Point(0, 301);
            btnContactUs.Name = "btnContactUs";
            btnContactUs.Size = new Size(186, 42);
            btnContactUs.TabIndex = 6;
            btnContactUs.Text = "Contact Us";
            btnContactUs.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnContactUs.UseVisualStyleBackColor = true;
            // 
            // btnCalendar
            // 
            btnCalendar.Dock = DockStyle.Top;
            btnCalendar.FlatAppearance.BorderSize = 0;
            btnCalendar.FlatStyle = FlatStyle.Flat;
            btnCalendar.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCalendar.ForeColor = Color.FromArgb(0, 126, 249);
            btnCalendar.Image = (Image)resources.GetObject("btnCalendar.Image");
            btnCalendar.Location = new Point(0, 259);
            btnCalendar.Name = "btnCalendar";
            btnCalendar.Size = new Size(186, 42);
            btnCalendar.TabIndex = 5;
            btnCalendar.Text = "Calendar";
            btnCalendar.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnCalendar.UseVisualStyleBackColor = true;
            // 
            // btnAnalytics
            // 
            btnAnalytics.Dock = DockStyle.Top;
            btnAnalytics.FlatAppearance.BorderSize = 0;
            btnAnalytics.FlatStyle = FlatStyle.Flat;
            btnAnalytics.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAnalytics.ForeColor = Color.FromArgb(0, 126, 249);
            btnAnalytics.Image = (Image)resources.GetObject("btnAnalytics.Image");
            btnAnalytics.Location = new Point(0, 217);
            btnAnalytics.Name = "btnAnalytics";
            btnAnalytics.Size = new Size(186, 42);
            btnAnalytics.TabIndex = 4;
            btnAnalytics.Text = "Analytics";
            btnAnalytics.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnAnalytics.UseVisualStyleBackColor = true;
            // 
            // BtnDashboard
            // 
            BtnDashboard.Dock = DockStyle.Top;
            BtnDashboard.FlatAppearance.BorderSize = 0;
            BtnDashboard.FlatStyle = FlatStyle.Flat;
            BtnDashboard.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnDashboard.ForeColor = Color.FromArgb(0, 126, 249);
            BtnDashboard.Image = Properties.Resources.dom_icon_smaller;
            BtnDashboard.Location = new Point(0, 175);
            BtnDashboard.Name = "BtnDashboard";
            BtnDashboard.Size = new Size(186, 42);
            BtnDashboard.TabIndex = 3;
            BtnDashboard.Text = "Dashboard";
            BtnDashboard.TextImageRelation = TextImageRelation.TextBeforeImage;
            BtnDashboard.UseVisualStyleBackColor = true;
            BtnDashboard.Click += BtnDashboard_Click_1;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Controls.Add(Usder);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(186, 175);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 6.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.FromArgb(158, 161, 178);
            label1.Location = new Point(39, 124);
            label1.Name = "label1";
            label1.Size = new Size(110, 12);
            label1.TabIndex = 2;
            label1.Text = "Some User Text here";
            // 
            // Usder
            // 
            Usder.AutoSize = true;
            Usder.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Usder.ForeColor = Color.FromArgb(0, 126, 149);
            Usder.Location = new Point(50, 97);
            Usder.Name = "Usder";
            Usder.Size = new Size(85, 16);
            Usder.TabIndex = 1;
            Usder.Text = "User Name";
            Usder.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(60, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(63, 63);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(465, 253);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(951, 577);
            Controls.Add(button1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            Load += FrmMain_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label Usder;
        private Label label1;
        private Button BtnDashboard;
        private Button btnCalendar;
        private Button btnAnalytics;
        private Button btnsettings;
        private Button btnContactUs;
        private Panel PnlNav;
        private Button button1;
    }
}
