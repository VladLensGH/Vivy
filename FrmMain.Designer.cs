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
            pnlNaw = new Panel();
            Pnlscroll = new Panel();
            btnsettings = new Button();
            btnContactUs = new Button();
            btnCalendar = new Button();
            btnAnalytics = new Button();
            BtnDashboard = new Button();
            panel2 = new Panel();
            label1 = new Label();
            Usder = new Label();
            pictureBox1 = new PictureBox();
            panelAbout = new Panel();
            panelContact = new Panel();
            linkLabel2 = new LinkLabel();
            label9 = new Label();
            label10 = new Label();
            panelaboutUs = new Panel();
            label6 = new Label();
            label5 = new Label();
            panelSupport = new Panel();
            linkSupportCard = new LinkLabel();
            lblSupportCardText = new Label();
            label8 = new Label();
            label7 = new Label();
            panelProjects = new Panel();
            label4 = new Label();
            linkLabel1 = new LinkLabel();
            panelAboutVivy = new Panel();
            lblAboutTitle = new Label();
            pictureBox2 = new PictureBox();
            lblAboutText = new Label();
            label3 = new Label();
            label2 = new Label();
            panelSettings = new Panel();
            panelCalendar = new Panel();
            panelEvents = new Panel();
            panelAddEvent = new Panel();
            panelMiniCalendar = new Panel();
            monthCalendar1 = new MonthCalendar();
            panelAnalytics = new Panel();
            panelInput = new Panel();
            btnSend = new Button();
            textBoxInput = new TextBox();
            panelVivy = new Panel();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            pnlNaw.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelAbout.SuspendLayout();
            panelContact.SuspendLayout();
            panelaboutUs.SuspendLayout();
            panelSupport.SuspendLayout();
            panelProjects.SuspendLayout();
            panelAboutVivy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panelCalendar.SuspendLayout();
            panelMiniCalendar.SuspendLayout();
            panelInput.SuspendLayout();
            panelVivy.SuspendLayout();
            SuspendLayout();
            // 
            // pnlNaw
            // 
            pnlNaw.BackColor = Color.FromArgb(24, 30, 54);
            pnlNaw.Controls.Add(Pnlscroll);
            pnlNaw.Controls.Add(btnsettings);
            pnlNaw.Controls.Add(btnContactUs);
            pnlNaw.Controls.Add(btnCalendar);
            pnlNaw.Controls.Add(btnAnalytics);
            pnlNaw.Controls.Add(BtnDashboard);
            pnlNaw.Controls.Add(panel2);
            pnlNaw.Dock = DockStyle.Left;
            pnlNaw.Location = new Point(0, 0);
            pnlNaw.Name = "pnlNaw";
            pnlNaw.Size = new Size(186, 577);
            pnlNaw.TabIndex = 0;
            pnlNaw.Paint += panel1_Paint;
            // 
            // Pnlscroll
            // 
            Pnlscroll.BackColor = Color.FromArgb(0, 126, 249);
            Pnlscroll.Location = new Point(0, 193);
            Pnlscroll.Name = "Pnlscroll";
            Pnlscroll.Size = new Size(3, 100);
            Pnlscroll.TabIndex = 8;
            // 
            // btnsettings
            // 
            btnsettings.FlatAppearance.BorderSize = 0;
            btnsettings.FlatStyle = FlatStyle.Flat;
            btnsettings.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnsettings.ForeColor = Color.FromArgb(0, 126, 249);
            btnsettings.Image = (Image)resources.GetObject("btnsettings.Image");
            btnsettings.ImageAlign = ContentAlignment.TopCenter;
            btnsettings.Location = new Point(0, 502);
            btnsettings.Name = "btnsettings";
            btnsettings.Padding = new Padding(10, 0, 0, 10);
            btnsettings.Size = new Size(186, 75);
            btnsettings.TabIndex = 7;
            btnsettings.Text = "Налаштування";
            btnsettings.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnsettings.UseVisualStyleBackColor = true;
            btnsettings.Click += btnsettings_Click;
            btnsettings.Leave += btnsettings_Leave;
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
            btnContactUs.Text = "Про нас";
            btnContactUs.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnContactUs.UseVisualStyleBackColor = true;
            btnContactUs.Click += btnContactUs_Click;
            btnContactUs.Leave += btnContactUs_Leave;
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
            btnCalendar.Text = "Календар";
            btnCalendar.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnCalendar.UseVisualStyleBackColor = true;
            btnCalendar.Click += btnCalendar_Click;
            btnCalendar.Leave += btnCalendar_Leave;
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
            btnAnalytics.Padding = new Padding(22, 0, 0, 0);
            btnAnalytics.Size = new Size(186, 42);
            btnAnalytics.TabIndex = 4;
            btnAnalytics.Text = "Аналітика";
            btnAnalytics.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnAnalytics.UseVisualStyleBackColor = true;
            btnAnalytics.Click += btnAnalytics_Click;
            btnAnalytics.Leave += btnAnalytics_Leave;
            // 
            // BtnDashboard
            // 
            BtnDashboard.Dock = DockStyle.Top;
            BtnDashboard.FlatAppearance.BorderSize = 0;
            BtnDashboard.FlatStyle = FlatStyle.Flat;
            BtnDashboard.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnDashboard.ForeColor = Color.FromArgb(0, 126, 249);
            BtnDashboard.Image = (Image)resources.GetObject("BtnDashboard.Image");
            BtnDashboard.Location = new Point(0, 175);
            BtnDashboard.Name = "BtnDashboard";
            BtnDashboard.Padding = new Padding(22, 0, 0, 0);
            BtnDashboard.Size = new Size(186, 42);
            BtnDashboard.TabIndex = 3;
            BtnDashboard.Text = "Vivy";
            BtnDashboard.TextImageRelation = TextImageRelation.TextBeforeImage;
            BtnDashboard.UseVisualStyleBackColor = true;
            BtnDashboard.Click += BtnDashboard_Click_1;
            BtnDashboard.Leave += BtnDashboard_Leave;
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
            label1.Location = new Point(71, 130);
            label1.Name = "label1";
            label1.Size = new Size(52, 12);
            label1.TabIndex = 2;
            label1.Text = "Про себе";
            label1.Click += label1_Click_1;
            // 
            // Usder
            // 
            Usder.AutoSize = true;
            Usder.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Usder.ForeColor = Color.FromArgb(0, 126, 149);
            Usder.Location = new Point(26, 98);
            Usder.Name = "Usder";
            Usder.Size = new Size(133, 16);
            Usder.TabIndex = 1;
            Usder.Text = "Ім'я користувача";
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
            // panelAbout
            // 
            panelAbout.Controls.Add(panelContact);
            panelAbout.Controls.Add(panelaboutUs);
            panelAbout.Controls.Add(panelSupport);
            panelAbout.Controls.Add(panelProjects);
            panelAbout.Controls.Add(panelAboutVivy);
            panelAbout.Dock = DockStyle.Fill;
            panelAbout.Location = new Point(0, 0);
            panelAbout.Name = "panelAbout";
            panelAbout.Size = new Size(951, 577);
            panelAbout.TabIndex = 11;
            panelAbout.Paint += panel4_Paint;
            // 
            // panelContact
            // 
            panelContact.BackColor = Color.FromArgb(40, 40, 60);
            panelContact.Controls.Add(linkLabel2);
            panelContact.Controls.Add(label9);
            panelContact.Controls.Add(label10);
            panelContact.Location = new Point(595, 259);
            panelContact.Name = "panelContact";
            panelContact.Size = new Size(328, 134);
            panelContact.TabIndex = 22;
            // 
            // linkLabel2
            // 
            linkLabel2.ActiveLinkColor = Color.White;
            linkLabel2.LinkColor = Color.LightGray;
            linkLabel2.Location = new Point(158, 15);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(152, 64);
            linkLabel2.TabIndex = 16;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Telegram: @vivy_ai Instagram: @vivy.project phone: +49 15164337343 Gmail: apivivy@gmail.com";
            // 
            // label9
            // 
            label9.Font = new Font("Segoe UI", 8F);
            label9.ForeColor = SystemColors.ButtonHighlight;
            label9.Location = new Point(3, 93);
            label9.Name = "label9";
            label9.Size = new Size(322, 41);
            label9.TabIndex = 15;
            label9.Text = "Слідкуйте за новинами та оновленнями проєкту в наших соцмережах. Якщо є питання, звертайтесь на будь-який з контактів і ми постараємося вам швидко відповісти";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Black", 12.75F, FontStyle.Bold);
            label10.ForeColor = Color.White;
            label10.Location = new Point(36, 36);
            label10.Name = "label10";
            label10.Size = new Size(91, 23);
            label10.TabIndex = 14;
            label10.Text = "Контакти";
            // 
            // panelaboutUs
            // 
            panelaboutUs.BackColor = Color.FromArgb(40, 40, 60);
            panelaboutUs.Controls.Add(label6);
            panelaboutUs.Controls.Add(label5);
            panelaboutUs.Location = new Point(207, 259);
            panelaboutUs.Name = "panelaboutUs";
            panelaboutUs.Size = new Size(364, 134);
            panelaboutUs.TabIndex = 21;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 9.1F);
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(29, 42);
            label6.Name = "label6";
            label6.Size = new Size(318, 81);
            label6.TabIndex = 15;
            label6.Text = "Цей проект — наша перша спроба створити інтелектуального помічника. Цей проєкт не був би можливим без вас. Ми цінуємо кожен внесок і зворотний зв'язок.\r\n";
            label6.Click += label6_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Black", 12.75F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(145, 11);
            label5.Name = "label5";
            label5.Size = new Size(62, 23);
            label5.TabIndex = 14;
            label5.Text = "О нас ";
            // 
            // panelSupport
            // 
            panelSupport.BackColor = Color.FromArgb(40, 40, 60);
            panelSupport.Controls.Add(linkSupportCard);
            panelSupport.Controls.Add(lblSupportCardText);
            panelSupport.Controls.Add(label8);
            panelSupport.Controls.Add(label7);
            panelSupport.Location = new Point(259, 428);
            panelSupport.Name = "panelSupport";
            panelSupport.Size = new Size(630, 114);
            panelSupport.TabIndex = 20;
            panelSupport.Paint += panelSupport_Paint;
            // 
            // linkSupportCard
            // 
            linkSupportCard.ActiveLinkColor = Color.Black;
            linkSupportCard.AutoSize = true;
            linkSupportCard.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            linkSupportCard.LinkColor = Color.LightBlue;
            linkSupportCard.Location = new Point(318, 86);
            linkSupportCard.Name = "linkSupportCard";
            linkSupportCard.Size = new Size(120, 17);
            linkSupportCard.TabIndex = 19;
            linkSupportCard.TabStop = true;
            linkSupportCard.Text = "4441114498935962";
            linkSupportCard.LinkClicked += linkSupportCard_LinkClicked;
            // 
            // lblSupportCardText
            // 
            lblSupportCardText.AutoSize = true;
            lblSupportCardText.ForeColor = Color.LightGray;
            lblSupportCardText.Location = new Point(142, 86);
            lblSupportCardText.Name = "lblSupportCardText";
            lblSupportCardText.Size = new Size(170, 15);
            lblSupportCardText.TabIndex = 18;
            lblSupportCardText.Text = "Номер картки для підтримки:";
            lblSupportCardText.Click += lblSupportCardText_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Black", 10.75F, FontStyle.Bold);
            label8.ForeColor = Color.White;
            label8.Location = new Point(187, 11);
            label8.Name = "label8";
            label8.Size = new Size(251, 20);
            label8.TabIndex = 17;
            label8.Text = "🙏 Дякуємо за вашу підтримку";
            // 
            // label7
            // 
            label7.ForeColor = SystemColors.ButtonFace;
            label7.Location = new Point(48, 43);
            label7.Name = "label7";
            label7.Size = new Size(546, 33);
            label7.TabIndex = 16;
            label7.Text = "Цей проєкт не був би можливим без вас. Ми цінуємо кожен внесок і зворотний зв'язок. Підтримайте нас, щоб ми могли створювати ще розумніші, корисні та надихаючі інструменти.";
            // 
            // panelProjects
            // 
            panelProjects.BackColor = Color.FromArgb(40, 40, 60);
            panelProjects.Controls.Add(label4);
            panelProjects.Controls.Add(linkLabel1);
            panelProjects.Location = new Point(595, 30);
            panelProjects.Name = "panelProjects";
            panelProjects.Size = new Size(328, 187);
            panelProjects.TabIndex = 19;
            panelProjects.Paint += panelProjects_Paint;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Black", 15.75F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(86, 28);
            label4.Name = "label4";
            label4.Size = new Size(172, 34);
            label4.TabIndex = 12;
            label4.Text = "Наши проекты";
            label4.UseCompatibleTextRendering = true;
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.LightGray;
            linkLabel1.AutoSize = true;
            linkLabel1.ForeColor = Color.LightGray;
            linkLabel1.LinkColor = Color.LightGray;
            linkLabel1.Location = new Point(23, 78);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(287, 60);
            linkLabel1.TabIndex = 13;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "• CrossLang — мультиязычный переводчик с ИИ\n• StreamMind — генерация сценариев для YouTube\n• ZenNote — минималистичный трекер привычек\n • SportBet — сайт букмекерська контора";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // panelAboutVivy
            // 
            panelAboutVivy.BackColor = Color.FromArgb(40, 40, 60);
            panelAboutVivy.Controls.Add(lblAboutTitle);
            panelAboutVivy.Controls.Add(pictureBox2);
            panelAboutVivy.Controls.Add(lblAboutText);
            panelAboutVivy.Controls.Add(label3);
            panelAboutVivy.Controls.Add(label2);
            panelAboutVivy.Location = new Point(207, 30);
            panelAboutVivy.Name = "panelAboutVivy";
            panelAboutVivy.Size = new Size(364, 187);
            panelAboutVivy.TabIndex = 18;
            panelAboutVivy.Paint += panelAboutVivy_Paint;
            // 
            // lblAboutTitle
            // 
            lblAboutTitle.AutoSize = true;
            lblAboutTitle.Font = new Font("Segoe UI Black", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblAboutTitle.ForeColor = Color.White;
            lblAboutTitle.Location = new Point(29, 28);
            lblAboutTitle.Name = "lblAboutTitle";
            lblAboutTitle.Size = new Size(215, 30);
            lblAboutTitle.TabIndex = 0;
            lblAboutTitle.Text = "Про програму Vivy";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(269, 11);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(64, 64);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // lblAboutText
            // 
            lblAboutText.Font = new Font("Segoe UI", 10F);
            lblAboutText.ForeColor = Color.LightGray;
            lblAboutText.Location = new Point(29, 78);
            lblAboutText.Name = "lblAboutText";
            lblAboutText.Size = new Size(284, 67);
            lblAboutText.TabIndex = 1;
            lblAboutText.Text = "Vivy - ваш інтелектуальний помічник, створений для підтримки, натхнення та продуктивної роботи.";
            lblAboutText.Click += lblAboutText_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 8F);
            label3.ForeColor = Color.Gray;
            label3.Location = new Point(29, 161);
            label3.Name = "label3";
            label3.Size = new Size(74, 13);
            label3.TabIndex = 3;
            label3.Text = "Версия: 1.0.0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.LightGray;
            label2.Location = new Point(173, 159);
            label2.Name = "label2";
            label2.Size = new Size(163, 15);
            label2.TabIndex = 2;
            label2.Text = " Поддержка: support@vivy.ai";
            label2.Click += label2_Click;
            // 
            // panelSettings
            // 
            panelSettings.Dock = DockStyle.Fill;
            panelSettings.Location = new Point(0, 0);
            panelSettings.Name = "panelSettings";
            panelSettings.Size = new Size(951, 577);
            panelSettings.TabIndex = 0;
            panelSettings.Visible = false;
            // 
            // panelCalendar
            // 
            panelCalendar.Controls.Add(panelEvents);
            panelCalendar.Controls.Add(panelAddEvent);
            panelCalendar.Controls.Add(panelMiniCalendar);
            panelCalendar.Dock = DockStyle.Fill;
            panelCalendar.Location = new Point(0, 0);
            panelCalendar.Name = "panelCalendar";
            panelCalendar.Size = new Size(951, 577);
            panelCalendar.TabIndex = 0;
            panelCalendar.Visible = false;
            // 
            // panelEvents
            // 
            panelEvents.Location = new Point(388, 30);
            panelEvents.Name = "panelEvents";
            panelEvents.Size = new Size(200, 100);
            panelEvents.TabIndex = 0;
            // 
            // panelAddEvent
            // 
            panelAddEvent.Location = new Point(255, 359);
            panelAddEvent.Name = "panelAddEvent";
            panelAddEvent.Size = new Size(200, 100);
            panelAddEvent.TabIndex = 0;
            // 
            // panelMiniCalendar
            // 
            panelMiniCalendar.Controls.Add(monthCalendar1);
            panelMiniCalendar.ForeColor = Color.White;
            panelMiniCalendar.Location = new Point(25, 30);
            panelMiniCalendar.Name = "panelMiniCalendar";
            panelMiniCalendar.Size = new Size(230, 180);
            panelMiniCalendar.TabIndex = 1;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(9, 9);
            monthCalendar1.MaxSelectionCount = 1;
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 0;
            // 
            // panelAnalytics
            // 
            panelAnalytics.Dock = DockStyle.Fill;
            panelAnalytics.Location = new Point(0, 0);
            panelAnalytics.Name = "panelAnalytics";
            panelAnalytics.Size = new Size(951, 577);
            panelAnalytics.TabIndex = 0;
            panelAnalytics.Visible = false;
            panelAnalytics.Paint += panelAnalytics_Paint;
            // 
            // panelInput
            // 
            panelInput.BackColor = Color.FromArgb(40, 40, 40);
            panelInput.Controls.Add(btnSend);
            panelInput.Controls.Add(textBoxInput);
            panelInput.Location = new Point(63, 507);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(600, 45);
            panelInput.TabIndex = 0;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.FromArgb(60, 60, 60);
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(538, 17);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(41, 18);
            btnSend.TabIndex = 1;
            btnSend.Text = "⬆️\r\n\r\n";
            btnSend.UseVisualStyleBackColor = false;
            // 
            // textBoxInput
            // 
            textBoxInput.BackColor = SystemColors.WindowFrame;
            textBoxInput.BorderStyle = BorderStyle.None;
            textBoxInput.Font = new Font("Segoe UI", 10F);
            textBoxInput.ForeColor = Color.White;
            textBoxInput.Location = new Point(29, 17);
            textBoxInput.Name = "textBoxInput";
            textBoxInput.Size = new Size(550, 18);
            textBoxInput.TabIndex = 0;
            // 
            // panelVivy
            // 
            panelVivy.Controls.Add(panelInput);
            panelVivy.Dock = DockStyle.Fill;
            panelVivy.Location = new Point(0, 0);
            panelVivy.Name = "panelVivy";
            panelVivy.Size = new Size(951, 577);
            panelVivy.TabIndex = 0;
            panelVivy.Visible = false;
            panelVivy.Paint += panelVivy_Paint;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(951, 577);
            Controls.Add(pnlNaw);
            Controls.Add(panelAbout);
            Controls.Add(panelCalendar);
            Controls.Add(panelSettings);
            Controls.Add(panelVivy);
            Controls.Add(panelAnalytics);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += FrmMain_Load;
            pnlNaw.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelAbout.ResumeLayout(false);
            panelContact.ResumeLayout(false);
            panelContact.PerformLayout();
            panelaboutUs.ResumeLayout(false);
            panelaboutUs.PerformLayout();
            panelSupport.ResumeLayout(false);
            panelSupport.PerformLayout();
            panelProjects.ResumeLayout(false);
            panelProjects.PerformLayout();
            panelAboutVivy.ResumeLayout(false);
            panelAboutVivy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panelCalendar.ResumeLayout(false);
            panelMiniCalendar.ResumeLayout(false);
            panelInput.ResumeLayout(false);
            panelInput.PerformLayout();
            panelVivy.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion


        private Panel pnlNaw;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label Usder;
        private Label label1;
        private Button BtnDashboard;
        private Button btnCalendar;
        private Button btnAnalytics;
        private Button btnsettings;
        private Button btnContactUs;
        private Panel Pnlscroll;
        private Panel panelAbout;
        private Panel panelAnalytics;
        private Panel panelCalendar;
        private Panel panelVivy;
        private Panel panelSettings;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Panel panelInput;
        private TextBox textBoxInput;
        private Button btnSend;
        private Label lblAboutTitle;
        private Label lblAboutText;
        private Label label2;
        private PictureBox pictureBox2;
        private Label label3;
        private LinkLabel linkLabel1;
        private Label label4;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Panel panelAboutVivy;
        private Panel panelProjects;
        private Panel panelSupport;
        private LinkLabel linkSupportCard;
        private Label lblSupportCardText;
        private Panel panelaboutUs;
        private Panel panelContact;
        private Label label9;
        private Label label10;
        private LinkLabel linkLabel2;
        private Panel panelEvents;
        private Panel panelAddEvent;
        private Panel panelMiniCalendar;
        private MonthCalendar monthCalendar1;

    }
}
