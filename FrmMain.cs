using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Text.Json;
using RestSharp;
using System.Text.Json;
using Microsoft.VisualBasic.Logging;
using System.Speech.Synthesis;


namespace Vivy
{
    public partial class FrmMain : Form
    {
        private string currentLogin;

        // Імпорт функції для створення області з заокругленими кутами для форми
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        // Конструктор головної форми
        public FrmMain(string login)
        {

            InitializeComponent();
            currentLogin = login;

            AddWindowControlButtons();


            // Застосовуємо заокруглення кутів до вікна
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            // Встановлюємо положення та розмір панелі-індикатора для кнопки Dashboard
            Pnlscroll.Height = BtnDashboard.Height;
            Pnlscroll.Top = BtnDashboard.Top;
            Pnlscroll.Left = BtnDashboard.Left;
            BtnDashboard.BackColor = Color.FromArgb(46, 51, 73);

        }
        private Dictionary<string, List<(string sender, string message)>> chatHistory = new();
        private string currentChatTitle = "";

        // Подія завантаження форми
        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Заокруглюємо кути панелі вводу
            RoundPanelCorners(panelInput, 10);

            // Встановлюємо текст для LinkLabel українською
            linkLabel1.Text =
                "• CrossLang — багатомовний перекладач з ІІ\n" +
                "• StreamMind — генерація сценаріїв для YouTube\n" +
                "• ZenNote — мінімалістичний трекер звичок";

            // Очищаємо старі посилання (на всякий випадок)
            linkLabel1.Links.Clear();

            // Додаємо посилання до відповідних сервісів
            linkLabel1.Links.Add(2, 9, "https://crosslang.com");
            linkLabel1.Links.Add(44, 11, "https://streammind.com");
            linkLabel1.Links.Add(92, 8, "https://zennote.com");

            // Налаштовуємо кольори посилань
            linkLabel1.LinkColor = Color.LightGray;
            linkLabel1.ActiveLinkColor = Color.Black;
            linkLabel1.VisitedLinkColor = Color.LightGray;
            linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;

            // Додаємо посилання для підтримки
            linkSupportCard.Links.Clear();
            linkSupportCard.Links.Add(0, linkSupportCard.Text.Length, "https://send.monobank.ua/jar/4441114498935962"); // ← замініть на своє посилання
            Usder.Text = currentLogin;
            LoadUserAvatar();

            toolTip1.SetToolTip(cbNotifications, "Надсилати сповіщення про нові функції або повідомлення.");
            toolTip1.SetToolTip(cbSpeakResponses, "Озвучувати відповіді асистента голосом.");
            toolTip1.SetToolTip(cbSaveHistory, "Зберігати історію ваших чатів, поки ви не видалите її вручну.");

            string savedTheme = LoadTheme();
            cbTheme.SelectedItem = savedTheme;
            ApplyTheme(savedTheme);

        }

        // Обробка натискання на різні кнопки меню для перемикання панелей
        private void BtnDashboard_Click_1(object sender, EventArgs e)
        {
            // Переміщуємо індикатор до кнопки Dashboard
            Pnlscroll.Height = BtnDashboard.Height;
            Pnlscroll.Top = BtnDashboard.Top;
            Pnlscroll.Left = BtnDashboard.Left;
            BtnDashboard.BackColor = Color.FromArgb(46, 51, 73);

            // Відображаємо лише панель Vivy
            panelVivy.Visible = true;
            panelAnalytics.Visible = false;
            panelCalendar.Visible = false;
            panelAbout.Visible = false;
            panelSettings.Visible = false;
        }

        private void btnAnalytics_Click(object sender, EventArgs e)
        {
            // Переміщуємо індикатор до кнопки Analytics
            Pnlscroll.Height = btnAnalytics.Height;
            Pnlscroll.Top = btnAnalytics.Top;
            btnAnalytics.BackColor = Color.FromArgb(46, 51, 73);

            // Відображаємо лише панель аналітики
            panelVivy.Visible = false;
            panelAnalytics.Visible = true;
            panelCalendar.Visible = false;
            panelAbout.Visible = false;
            panelSettings.Visible = false;
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            // Переміщуємо індикатор до кнопки Calendar
            Pnlscroll.Height = btnCalendar.Height;
            Pnlscroll.Top = btnCalendar.Top;
            btnCalendar.BackColor = Color.FromArgb(46, 51, 73);

            // Відображаємо лише панель календаря
            panelVivy.Visible = false;
            panelAnalytics.Visible = false;
            panelCalendar.Visible = true;
            panelAbout.Visible = false;
            panelSettings.Visible = false;
        }

        private void btnContactUs_Click(object sender, EventArgs e)
        {
            // Переміщуємо індикатор до кнопки ContactUs
            Pnlscroll.Height = btnContactUs.Height;
            Pnlscroll.Top = btnContactUs.Top;
            btnContactUs.BackColor = Color.FromArgb(46, 51, 73);

            // Відображаємо лише панель "Про нас"
            panelVivy.Visible = false;
            panelAnalytics.Visible = false;
            panelCalendar.Visible = false;
            panelAbout.Visible = true;
            panelSettings.Visible = false;
        }

        private void btnsettings_Click(object sender, EventArgs e)
        {
            // Переміщуємо індикатор до кнопки Settings
            Pnlscroll.Height = btnsettings.Height;
            Pnlscroll.Top = btnsettings.Top;
            btnsettings.BackColor = Color.FromArgb(46, 51, 73);

            // Відображаємо лише панель налаштувань
            panelVivy.Visible = false;
            panelAnalytics.Visible = false;
            panelCalendar.Visible = false;
            panelAbout.Visible = false;
            panelSettings.Visible = true;
        }

        // Відновлення стандартного кольору кнопок при втраті фокусу
        private void BtnDashboard_Leave(object sender, EventArgs e)
        {
            BtnDashboard.BackColor = Color.FromArgb(24, 30, 54);
        }
        private void btnAnalytics_Leave(object sender, EventArgs e)
        {
            btnAnalytics.BackColor = Color.FromArgb(24, 30, 54);
        }
        private void btnCalendar_Leave(object sender, EventArgs e)
        {
            btnCalendar.BackColor = Color.FromArgb(24, 30, 54);
        }
        private void btnContactUs_Leave(object sender, EventArgs e)
        {
            btnContactUs.BackColor = Color.FromArgb(24, 30, 54);
        }
        private void btnsettings_Leave(object sender, EventArgs e)
        {
            btnsettings.BackColor = Color.FromArgb(24, 30, 54);
        }

        // Метод для заокруглення кутів панелі
        private void RoundPanelCorners(Panel panel, int radius)
        {
            Rectangle bounds = new Rectangle(0, 0, panel.Width, panel.Height);
            GraphicsPath path = new GraphicsPath();
            int r = radius * 2;
            path.AddArc(bounds.X, bounds.Y, r, r, 180, 90);
            path.AddArc(bounds.Right - r, bounds.Y, r, r, 270, 90);
            path.AddArc(bounds.Right - r, bounds.Bottom - r, r, r, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - r, r, r, 90, 90);
            path.CloseAllFigures();
            panel.Region = new Region(path);
        }

        // Обробка кліку по посиланню (відкриває у браузері)
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = e.Link.LinkData as string;
            if (!string.IsNullOrEmpty(url))
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
        }

        private void linkSupportCard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = e.Link.LinkData as string;
            if (!string.IsNullOrEmpty(url))
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
        }

        // Асинхронний метод для отримання відповіді від GPT API
        private async Task<string> GetGPTResponse(string userMessage)
        {
            string apiKey = "2f87f79ad7945491793b3d76eb6c874a ";
            string model = "gpt-3.5-turbo";
            string apiUrl = $"http://195.179.229.119/gpt/api.php?prompt={Uri.EscapeDataString(userMessage)}&api_key={Uri.EscapeDataString(apiKey)}&model={Uri.EscapeDataString(model)}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Відправляємо GET-запит до API
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Парсимо JSON і повертаємо лише поле content
                    using (JsonDocument doc = JsonDocument.Parse(responseBody))
                    {
                        if (doc.RootElement.TryGetProperty("content", out var contentElement))
                        {
                            return contentElement.GetString();
                        }
                        else
                        {
                            return "Помилка: поле content не знайдено у відповіді.";
                        }
                    }
                }
                catch (HttpRequestException e)
                {
                    return $"Помилка запиту: {e.Message}";
                }
                catch (JsonException)
                {
                    return "Помилка парсингу відповіді від сервера.";
                }
            }
        }

        // Обробка натискання кнопки "Відправити" (Send)
        private async void btnSend_Click(object sender, EventArgs e)
        {
            string userMessage = textBoxInput.Text.Trim();
            if (string.IsNullOrEmpty(userMessage)) return;

            // Определяем название чата
            if (string.IsNullOrEmpty(currentChatTitle))
            {
                currentChatTitle = userMessage.Length > 30 ? userMessage.Substring(0, 30) + "..." : userMessage;
                listBoxHistory.Items.Add(currentChatTitle);
                chatHistory[currentChatTitle] = new List<(string, string)>();
            }

            // Сохраняем пользовательское сообщение
            chatHistory[currentChatTitle].Add(("Вы", userMessage));

            // Показываем сообщение пользователя
            richTextBox1.SelectionColor = Color.DeepSkyBlue;
            richTextBox1.AppendText("Ви: ");
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.AppendText(userMessage + "\n\n");

            // Очищаємо поле вводу
            textBoxInput.Clear();

            // Отримуємо відповідь від GPT
            string gptResponse = await GetGPTResponse(userMessage);

            // Показываем и сохраняем ответ Vivy
            chatHistory[currentChatTitle].Add(("Vivy", gptResponse));
            richTextBox1.SelectionColor = Color.MediumPurple;
            richTextBox1.AppendText("Vivy: ");
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.AppendText(gptResponse + "\n\n");
            if (cbSpeakResponses.Checked)
            {
                synthesizer.SpeakAsync(gptResponse);
            }

            // Прокручуємо чат до останнього повідомлення
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }


        private void panelaboutUs_Paint(object sender, PaintEventArgs e)
        {
            RoundPanelCorners(panelAboutVivy, 15);
        }

        private void panelContact_Paint(object sender, PaintEventArgs e)
        {
            RoundPanelCorners(panelAboutVivy, 15);
        }

        private void listBoxHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxHistory.SelectedItem == null) return;
            currentChatTitle = listBoxHistory.SelectedItem.ToString();

            richTextBox1.Clear();
            foreach (var (senderName, message) in chatHistory[currentChatTitle])
            {
                richTextBox1.SelectionColor = senderName == "Вы" ? Color.DeepSkyBlue : Color.MediumPurple;
                richTextBox1.AppendText($"{senderName}: ");
                richTextBox1.SelectionColor = Color.White;
                richTextBox1.AppendText(message + "\n\n");
            }
        }
        private void picUserAvatar_Click(object sender, EventArgs e)
        {
            using (var profileForm = new FrmProfile(currentLogin))
            {
                if (profileForm.ShowDialog() == DialogResult.OK)
                {
                    currentLogin = profileForm.NewLogin;
                    LoadUserAvatar();
                }
            }
        }


        private void LoadUserAvatar()
        {
            string connectionString = "Data Source=vivy.db";
            using var connection = new Microsoft.Data.Sqlite.SqliteConnection(connectionString);
            connection.Open();

            string selectCmd = "SELECT ProfileImage FROM Users WHERE Login = @login";
            using var cmd = new Microsoft.Data.Sqlite.SqliteCommand(selectCmd, connection);
            cmd.Parameters.AddWithValue("@login", currentLogin);

            var avatarPath = cmd.ExecuteScalar() as string;
            if (!string.IsNullOrEmpty(avatarPath) && System.IO.File.Exists(avatarPath))
            {
                using var ms = new System.IO.MemoryStream(System.IO.File.ReadAllBytes(avatarPath));
                picUserAvatar.Image = Image.FromStream(ms);
            }
            else
            {
                // Используем стандартный аватар из ресурсов
                picUserAvatar.Image = Properties.Resources.DefaultAvatar;
            }

        }


        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void panel4_Paint(object sender, PaintEventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void panelAnalytics_Paint(object sender, PaintEventArgs e) { }
        private void lblAboutText_Click(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
        private void panelAboutVivy_Paint(object sender, PaintEventArgs e) { RoundPanelCorners(panelAboutVivy, 15); }
        private void label2_Click(object sender, EventArgs e) { }
        private void panelProjects_Paint(object sender, PaintEventArgs e) { RoundPanelCorners(panelProjects, 15); }
        private void panelSupport_Paint(object sender, PaintEventArgs e) { RoundPanelCorners(panelSupport, 15); }
        private void lblSupportCardText_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void panelVivy_Paint(object sender, PaintEventArgs e) { }
        private void panelCalendar_Paint(object sender, PaintEventArgs e) { }

        private void panelSettings_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            if (cbTheme.SelectedItem != null)
            {
                string theme = cbTheme.SelectedItem.ToString();
                SaveTheme(theme);
                ApplyTheme(theme);
            }

            MessageBox.Show("Налаштування збережено!", "Vivy", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AddWindowControlButtons()
        {
            // Создание кнопки "Свернуть"
            Button btnMinimize = new Button
            {
                Text = "–",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(24, 30, 54),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(30, 30),
                Location = new Point(this.Width - 70, 10),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.Click += (s, e) => this.WindowState = FormWindowState.Minimized;

            // Создание кнопки "Закрыть"
            Button btnClose = new Button
            {
                Text = "×",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(24, 30, 54),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(30, 30),
                Location = new Point(this.Width - 35, 10),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => this.Close();

            // Добавляем кнопки на форму (будут поверх всех панелей)
            this.Controls.Add(btnMinimize);
            this.Controls.Add(btnClose);
            btnMinimize.BringToFront();
            btnClose.BringToFront();
        }

        private SpeechSynthesizer synthesizer = new SpeechSynthesizer();


        private void btnLogout_Click(object sender, EventArgs e)
        {
            File.Delete("user_session.txt");
            Application.Restart(); // перезапускаем приложение
        }

        private string selectedTheme = "Темна"; // По умолчанию

        private void ApplyTheme(string theme)
        {
            selectedTheme = theme;
            Color backColor, foreColor, buttonBack;

            if (theme == "Світла")
            {
                backColor = Color.WhiteSmoke;
                foreColor = Color.Black;
                buttonBack = Color.LightGray;
            }
            else
            {
                backColor = Color.FromArgb(46, 51, 73);
                foreColor = Color.White;
                buttonBack = Color.FromArgb(24, 30, 54);
            }

            this.BackColor = backColor;

            foreach (Control control in this.Controls)
            {
                ApplyThemeToControl(control, backColor, foreColor, buttonBack);
            }

            panel2.BackColor = theme == "Світла" ? Color.WhiteSmoke : Color.FromArgb(24, 30, 54);
            pnlNaw.BackColor = theme == "Світла" ? Color.WhiteSmoke : Color.FromArgb(24, 30, 54);
            panel2.BackColor = theme == "Світла" ? Color.LightGray : Color.FromArgb(24, 30, 54);
            pnlNaw.BackColor = theme == "Світла" ? Color.LightGray : Color.FromArgb(24, 30, 54);

        }


        private void ApplyThemeToControl(Control ctrl, Color backColor, Color foreColor, Color buttonBack)
        {
            if (ctrl is Panel panel)
            {
                panel.BackColor = backColor;

                // Цвет имени пользователя в panel2 при тёмной теме
                if (panel == panel2 && selectedTheme == "Темна")
                {
                    foreach (Control child in panel.Controls)
                    {
                        if (child is Label nameLabel && nameLabel.Name == "lblUserName") // замените на фактическое имя элемента
                        {
                            nameLabel.ForeColor = Color.FromArgb(0, 126, 149);
                        }
                    }
                }
            }
            else if (ctrl is Label label)
            {
                label.ForeColor = foreColor;
            }
            else if (ctrl is Button btn)
            {
                btn.BackColor = buttonBack;

                // Цвет текста кнопок в боковой панели
                if (pnlNaw.Controls.Contains(btn) && selectedTheme == "Темна")
                {
                    btn.ForeColor = Color.FromArgb(0, 126, 249); // ярко-синий
                }
                else
                {
                    btn.ForeColor = foreColor;
                }
            }
            else if (ctrl is ComboBox cb)
            {
                cb.BackColor = buttonBack;
                cb.ForeColor = foreColor;
            }
            // Цвет ника пользователя (Usder) при тёмной теме
            if (ctrl == Usder && selectedTheme == "Темна")
            {
                Usder.ForeColor = Color.FromArgb(0, 126, 149);
            }

            // Рекурсивно для всех дочерних контролов
            foreach (Control child in ctrl.Controls)
            {
                ApplyThemeToControl(child, backColor, foreColor, buttonBack);
            }
        }







        private void SaveTheme(string theme)
        {
            File.WriteAllText("theme.txt", theme);
        }

        private string LoadTheme()
        {
            if (File.Exists("theme.txt"))
                return File.ReadAllText("theme.txt").Trim();
            return "Темна";
        }

        private void cbTheme_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblTheme_Click(object sender, EventArgs e)
        {

        }

    }
}
