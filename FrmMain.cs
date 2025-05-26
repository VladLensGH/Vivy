using Microsoft.VisualBasic.Logging;
using RestSharp;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;

namespace Vivy
{
    public partial class FrmMain : Form
    {
        private string currentLogin;
        private Color activeButtonColor;
        private Color inactiveButtonColor;

        // Внутри класса FrmMain
        private Color sideButtonTextColor = Color.FromArgb(0, 126, 249); // по умолчанию для тёмной темы
        private Color panelElementTextColor = Color.White;                // по умолчанию для элементов панелей
        private Color userNameTextColor = Color.FromArgb(0, 126, 149);   // по умолчанию для имени пользователя

        // Для боковых кнопок
        private Color sideButtonTextColorDark = Color.FromArgb(0, 126, 249);
        private Color sideButtonTextColorLight = Color.Black;

        // Для элементов панелей
        private Color panelElementTextColorDark = Color.White;
        private Color panelElementTextColorLight = Color.Black;

        // Для имени пользователя
        private Color userNameTextColorDark = Color.FromArgb(0, 126, 149);
        private Color userNameTextColorLight = Color.Black;

        // Публичные свойства для изменения из кода
        public Color SideButtonTextColor
        {
            get => sideButtonTextColor;
            set { sideButtonTextColor = value; ApplyTheme(selectedTheme); }
        }
        public Color PanelElementTextColor
        {
            get => panelElementTextColor;
            set { panelElementTextColor = value; ApplyTheme(selectedTheme); }
        }
        public Color UserNameTextColor
        {
            get => userNameTextColor;
            set { userNameTextColor = value; ApplyTheme(selectedTheme); }
        }
        public Color SideButtonTextColorDark
        {
            get => sideButtonTextColorDark;
            set { sideButtonTextColorDark = value; ApplyTheme(selectedTheme); }
        }
        public Color SideButtonTextColorLight
        {
            get => sideButtonTextColorLight;
            set { sideButtonTextColorLight = value; ApplyTheme(selectedTheme); }
        }
        public Color PanelElementTextColorDark
        {
            get => panelElementTextColorDark;
            set { panelElementTextColorDark = value; ApplyTheme(selectedTheme); }
        }
        public Color PanelElementTextColorLight
        {
            get => panelElementTextColorLight;
            set { panelElementTextColorLight = value; ApplyTheme(selectedTheme); }
        }
        public Color UserNameTextColorDark
        {
            get => userNameTextColorDark;
            set { userNameTextColorDark = value; ApplyTheme(selectedTheme); }
        }
        public Color UserNameTextColorLight
        {
            get => userNameTextColorLight;
            set { userNameTextColorLight = value; ApplyTheme(selectedTheme); }
        }

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

            // Apply initial colors
            SideButtonTextColor = Color.FromArgb(0, 126, 249);
            PanelElementTextColor = Color.White;
            UserNameTextColor = Color.FromArgb(0, 126, 149);
        }
        private Dictionary<string, List<(string sender, string message)>> chatHistory = new();
        private string currentChatTitle = "";

        public static void SetLanguage(string langCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(langCode);
        }

        // Подія завантаження форми
        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadAndApplyUserSettings();

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

            UpdateEventsForDate(monthCalendar1.SelectionStart.Date);

            RoundPanelCorners(panelAboutVivy, 15);
            RoundPanelCorners(panelProjects, 15);
            RoundPanelCorners(panelContact, 15);
            RoundPanelCorners(panelSupport, 15);
            RoundPanelCorners(panelaboutUs, 15);
            // Добавьте все панели, которые должны быть закруглены

            UpdateAboutPanelsTheme();
            UpdateAboutPanelsTheme();
        }

        // Обробка натискання на різні кнопки меню для перемикання панелей
        private void BtnDashboard_Click_1(object sender, EventArgs e)
        {
            Pnlscroll.Height = BtnDashboard.Height;
            Pnlscroll.Top = BtnDashboard.Top;
            Pnlscroll.Left = BtnDashboard.Left;
            BtnDashboard.BackColor = activeButtonColor;

            panelVivy.Visible = true;
            panelAnalytics.Visible = false;
            panelCalendar.Visible = false;
            panelAbout.Visible = false;
            panelSettings.Visible = false;
        }

        private void BtnDashboard_Leave(object sender, EventArgs e)
        {
            BtnDashboard.BackColor = inactiveButtonColor;
        }

        private void btnAnalytics_Click(object sender, EventArgs e)
        {
            Pnlscroll.Height = btnAnalytics.Height;
            Pnlscroll.Top = btnAnalytics.Top;
            btnAnalytics.BackColor = activeButtonColor;

            panelVivy.Visible = false;
            panelAnalytics.Visible = true;
            panelCalendar.Visible = false;
            panelAbout.Visible = false;
            panelSettings.Visible = false;
        }

        private void btnAnalytics_Leave(object sender, EventArgs e)
        {
            btnAnalytics.BackColor = inactiveButtonColor;
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            Pnlscroll.Height = btnCalendar.Height;
            Pnlscroll.Top = btnCalendar.Top;
            btnCalendar.BackColor = activeButtonColor;

            panelVivy.Visible = false;
            panelAnalytics.Visible = false;
            panelCalendar.Visible = true;
            panelAbout.Visible = false;
            panelSettings.Visible = false;
        }

        private void btnContactUs_Click(object sender, EventArgs e)
        {
            Pnlscroll.Height = btnContactUs.Height;
            Pnlscroll.Top = btnContactUs.Top;
            btnContactUs.BackColor = activeButtonColor;

            panelVivy.Visible = false;
            panelAnalytics.Visible = false;
            panelCalendar.Visible = false;
            panelAbout.Visible = true;
            panelSettings.Visible = false;
        }

        private void btnsettings_Click(object sender, EventArgs e)
        {
            Pnlscroll.Height = btnsettings.Height;
            Pnlscroll.Top = btnsettings.Top;
            btnsettings.BackColor = activeButtonColor;

            panelVivy.Visible = false;
            panelAnalytics.Visible = false;
            panelCalendar.Visible = false;
            panelAbout.Visible = false;
            panelSettings.Visible = true;
        }

        // Відновлення стандартного кольору кнопок при втраті фокусу
        private void btnCalendar_Leave(object sender, EventArgs e)
        {
            btnCalendar.BackColor = inactiveButtonColor;
        }
        private void btnContactUs_Leave(object sender, EventArgs e)
        {
            btnContactUs.BackColor = inactiveButtonColor;
        }
        private void btnsettings_Leave(object sender, EventArgs e)
        {
            btnsettings.BackColor = inactiveButtonColor;
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
            if (e.Link?.LinkData is string url && !string.IsNullOrEmpty(url))
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
            if (e.Link?.LinkData is string url && !string.IsNullOrEmpty(url))
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
            string apiKey = "97e3ea64686bdd7d9f3b656af511707f ";
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
                            return contentElement.GetString() ?? string.Empty;
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

            if (string.IsNullOrEmpty(currentChatTitle))
            {
                currentChatTitle = userMessage.Length > 30 ? userMessage.Substring(0, 30) + "..." : userMessage;
                listBoxHistory.Items.Add(currentChatTitle);
                if (!chatHistory.ContainsKey(currentChatTitle))
                {
                    chatHistory[currentChatTitle] = new List<(string, string)>();
                }
            }

            chatHistory[currentChatTitle].Add(("Вы", userMessage));

            Color mainTextColor = selectedTheme.Trim().StartsWith("Світла", StringComparison.OrdinalIgnoreCase)
                ? Color.Black
                : Color.White;

            richTextBox1.SelectionColor = Color.DeepSkyBlue;
            richTextBox1.AppendText("Ви: ");
            richTextBox1.SelectionColor = mainTextColor;
            richTextBox1.AppendText(userMessage + "\n\n");

            textBoxInput.Clear();

            string gptResponse = await GetGPTResponse(userMessage);

            chatHistory[currentChatTitle].Add(("Vivy", gptResponse));
            richTextBox1.SelectionColor = Color.MediumPurple;
            richTextBox1.AppendText("Vivy: ");
            richTextBox1.SelectionColor = mainTextColor;
            richTextBox1.AppendText(gptResponse + "\n\n");
            if (cbSpeakResponses.Checked)
            {
                synthesizer.SpeakAsync(gptResponse);
            }

            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();

            UpdateAnalytics();

        }


        private void listBoxHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxHistory.SelectedItem == null) return;
            var selected = listBoxHistory.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selected)) return;
            currentChatTitle = selected;

            if (!chatHistory.ContainsKey(currentChatTitle))
            {
                chatHistory[currentChatTitle] = new List<(string, string)>();
            }

            RedrawChatHistory();
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



        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            if (cbTheme.SelectedItem != null && cbModel.SelectedItem != null && cbLanguage.SelectedItem != null)
            {
                string? theme = cbTheme.SelectedItem?.ToString();
                string? model = cbModel.SelectedItem?.ToString();
                string? interfaceLanguage = cbLanguage.SelectedItem?.ToString();

                if (theme == null || model == null || interfaceLanguage == null)
                    return;

                ApplyTheme(theme);

                // Сохраняем настройки в БД
                string connectionString = "Data Source=vivy.db";
                using var connection = new Microsoft.Data.Sqlite.SqliteConnection(connectionString);
                connection.Open();

                string updateCmd = @"
            UPDATE Users SET 
                Theme = @theme, 
                NotificationsEnabled = @notifications, 
                SpeakResponsesEnabled = @speak, 
                SaveHistoryEnabled = @history,
                Model = @model,
                InterfaceLanguage = @interfaceLanguage
            WHERE Login = @login";
                using var cmd = new Microsoft.Data.Sqlite.SqliteCommand(updateCmd, connection);
                cmd.Parameters.AddWithValue("@theme", theme);
                cmd.Parameters.AddWithValue("@notifications", cbNotifications.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@speak", cbSpeakResponses.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@history", cbSaveHistory.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@model", model);
                cmd.Parameters.AddWithValue("@interfaceLanguage", interfaceLanguage);
                cmd.Parameters.AddWithValue("@login", currentLogin);
                cmd.ExecuteNonQuery();
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


        // В FrmMain.cs
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new FrmLogin();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                currentLogin = loginForm.UserLogin;
                Usder.Text = currentLogin;
                LoadUserAvatar();
                LoadAndApplyUserSettings(); // <--- добавьте этот вызов
                this.Show();
            }
            else
            {
                Application.Exit();
            }
        }

        private string selectedTheme = "Темна"; // По умолчанию

        private void ApplyTheme(string theme)
        {
            selectedTheme = theme;
            Color backColor, foreColor, buttonBack;

            // Выбор цветов для текущей темы
            Color sideButtonColor = theme == "Світла" ? sideButtonTextColorLight : sideButtonTextColorDark;
            Color panelElementColor = theme == "Світла" ? panelElementTextColorLight : panelElementTextColorDark;
            Color userNameColor = theme == "Світла" ? userNameTextColorLight : userNameTextColorDark;

            if (theme == "Світла")
            {
                backColor = Color.WhiteSmoke;
                foreColor = Color.Black;
                buttonBack = Color.LightGray;
                activeButtonColor = Color.Gainsboro;
                inactiveButtonColor = Color.LightGray;
            }
            else
            {
                backColor = Color.FromArgb(46, 51, 73);
                foreColor = Color.White;
                buttonBack = Color.FromArgb(24, 30, 54);
                activeButtonColor = Color.FromArgb(46, 51, 73);
                inactiveButtonColor = Color.FromArgb(24, 30, 54);
            }

            this.BackColor = backColor;

            foreach (Control control in this.Controls)
            {
                ApplyThemeToControl(control, backColor, foreColor, buttonBack, sideButtonColor, panelElementColor, userNameColor);
            }

            panel2.BackColor = theme == "Світла" ? Color.LightGray : Color.FromArgb(24, 30, 54);
            pnlNaw.BackColor = theme == "Світла" ? Color.LightGray : Color.FromArgb(24, 30, 54);

            if (!string.IsNullOrEmpty(currentChatTitle) && chatHistory.ContainsKey(currentChatTitle))
                RedrawChatHistory();

            UpdateAboutPanelsTheme();
        }

        private void ApplyThemeToControl(Control ctrl, Color backColor, Color foreColor, Color buttonBack, Color sideButtonColor, Color panelElementColor, Color userNameColor)
        {
            if (ctrl is Panel panel)
            {
                panel.BackColor = backColor;
            }
            else if (ctrl is Label label)
            {
                // Имя пользователя (Usder)
                if (label.Name == "Usder")
                    label.ForeColor = userNameColor;
                else
                    label.ForeColor = panelElementColor;
            }
            else if (ctrl is Button btn)
            {
                btn.BackColor = buttonBack;
                // Боковые кнопки
                if (pnlNaw.Controls.Contains(btn))
                    btn.ForeColor = sideButtonColor;
                else
                    btn.ForeColor = panelElementColor;
            }
            else if (ctrl is ComboBox cb)
            {
                cb.BackColor = buttonBack;
                cb.ForeColor = panelElementColor;
            }
            else if (ctrl is TextBox tb)
            {
                tb.BackColor = Color.White;
                tb.ForeColor = Color.Black;
            }
            else if (ctrl is RichTextBox rtb)
            {
                // Только фон, не трогаем ForeColor!
                if (rtb == richTextBox1 && panelVivy.Controls.Contains(rtb))
                {
                    if (selectedTheme == "Світла")
                        rtb.BackColor = Color.White;
                    else
                        rtb.BackColor = Color.FromArgb(46, 51, 73);
                    // Не меняем rtb.ForeColor!
                }
                else
                {
                    rtb.BackColor = backColor;
                    // Не меняем rtb.ForeColor!
                }
            }
            else if (ctrl is ListBox lb)
            {
                // Для listBoxHistory в panelHistory
                if (lb == listBoxHistory && panelHistory.Controls.Contains(lb))
                {
                    if (selectedTheme == "Світла")
                    {
                        lb.BackColor = Color.White;
                        lb.ForeColor = Color.Black;
                    }
                    else
                    {
                        lb.BackColor = Color.FromArgb(46, 51, 73);
                        lb.ForeColor = Color.White;
                    }
                }
                else
                {
                    lb.BackColor = backColor;
                    lb.ForeColor = foreColor;
                }
            }

            // Рекурсивно для всех дочерних контролов
            foreach (Control child in ctrl.Controls)
            {
                ApplyThemeToControl(child, backColor, foreColor, buttonBack, sideButtonColor, panelElementColor, userNameColor);
            }
        }

        private void LoadAndApplyUserSettings()
        {
            string connectionString = "Data Source=vivy.db";
            using var connection = new Microsoft.Data.Sqlite.SqliteConnection(connectionString);
            connection.Open();

            string selectCmd = "SELECT Theme, NotificationsEnabled, SpeakResponsesEnabled, SaveHistoryEnabled, Model, InterfaceLanguage FROM Users WHERE Login = @login";
            using var cmd = new Microsoft.Data.Sqlite.SqliteCommand(selectCmd, connection);
            cmd.Parameters.AddWithValue("@login", currentLogin);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string theme = reader.IsDBNull(0) ? "Темна" : reader.GetString(0);
                bool notifications = !reader.IsDBNull(1) && reader.GetInt32(1) == 1;
                bool speak = !reader.IsDBNull(2) && reader.GetInt32(2) == 1;
                bool saveHistory = !reader.IsDBNull(3) && reader.GetInt32(3) == 1;
                string model = reader.IsDBNull(4) ? "gpt-3.5-turbo" : reader.GetString(4);
                string interfaceLanguage = reader.IsDBNull(5) ? "uk-UA" : reader.GetString(5);

                cbTheme.SelectedItem = theme;
                cbNotifications.Checked = notifications;
                cbSpeakResponses.Checked = speak;
                cbSaveHistory.Checked = saveHistory;
                cbModel.SelectedItem = model;
                cbLanguage.SelectedItem = interfaceLanguage;
                ApplyTheme(theme);
            }
        }

        private void RedrawChatHistory()
        {
            if (string.IsNullOrEmpty(currentChatTitle) || !chatHistory.ContainsKey(currentChatTitle))
                return;

            richTextBox1.Clear();
            Color mainTextColor = selectedTheme.Trim().StartsWith("Світла", StringComparison.OrdinalIgnoreCase)
                ? Color.Black
                : Color.White;

            foreach (var (senderName, message) in chatHistory[currentChatTitle])
            {
                if (senderName == "Вы")
                    richTextBox1.SelectionColor = Color.DeepSkyBlue;
                else
                    richTextBox1.SelectionColor = Color.MediumPurple;

                richTextBox1.AppendText($"{senderName}: ");
                richTextBox1.SelectionColor = mainTextColor;
                richTextBox1.AppendText(message + "\n\n");
            }
        }

        private void cbTheme_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblTheme_Click(object sender, EventArgs e)
        {

        }


        private void ApplyLocalization()
        {

        }

        //private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cbLanguage.SelectedItem is not string selectedCulture || string.IsNullOrWhiteSpace(selectedCulture))
        //        return;

        //    // Преобразуем язык UI в код культуры
        //    string cultureCode = selectedCulture switch
        //    {
        //        "English" => "en",
        //        "Deutsch" => "de",
        //        "Українська" => "uk",
        //        _ => "uk"
        //    };

        //    Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode);
        //    Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureCode);

        //    this.Controls.Clear();
        //    InitializeComponent();
        //    ApplyTheme(selectedTheme);
        //    //ApplyLocalization();
        //}

        private void btnNewChat_Click(object sender, EventArgs e)
        {
            // Очистить поле и сбросить заголовок чата
            textBoxInput.Clear();
            richTextBox1.Clear();
            listBoxHistory.ClearSelected();
            currentChatTitle = "";
        }

        private void btnClearChat_Click_1(object sender, EventArgs e)
        {
            if (listBoxHistory.SelectedItem != null)
            {
                string selectedChat = listBoxHistory.SelectedItem.ToString();

                // Удаляем из истории
                if (chatHistory.ContainsKey(selectedChat))
                {
                    chatHistory.Remove(selectedChat);
                }

                // Удаляем из списка
                listBoxHistory.Items.Remove(selectedChat);

                // Очищаем поле сообщений
                richTextBox1.Clear();
                currentChatTitle = "";
            }
        }

        private Dictionary<DateTime, List<string>> eventsByDate = new(); // помести в начало формы

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            string eventText = textBoxNewEvent.Text.Trim();
            if (string.IsNullOrEmpty(eventText))
            {
                MessageBox.Show("Введіть текст події.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime selectedDate = monthCalendar1.SelectionStart.Date;
            DateTime selectedTime = timePickerEvent.Value;

            // Объединяем дату и время
            DateTime fullDateTime = new DateTime(
                selectedDate.Year, selectedDate.Month, selectedDate.Day,
                selectedTime.Hour, selectedTime.Minute, 0
            );

            // Формат отображения
            string formattedEvent = $"{fullDateTime:HH:mm} — {eventText}";

            // Добавляем событие в словарь
            if (!eventsByDate.ContainsKey(selectedDate))
                eventsByDate[selectedDate] = new List<string>();

            eventsByDate[selectedDate].Add(formattedEvent);

            // Обновляем отображение
            UpdateEventsList(selectedDate);

            textBoxNewEvent.Clear();
        }
        private void UpdateEventsList(DateTime date)
        {
            listBoxEvents.Items.Clear();
            lblEventsTitle.Text = $"Події на: [{date:dd.MM.yyyy}]";

            if (eventsByDate.ContainsKey(date))
            {
                foreach (string ev in eventsByDate[date])
                {
                    listBoxEvents.Items.Add(ev);
                }
            }
        }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            UpdateEventsList(monthCalendar1.SelectionStart.Date);
            DateTime selectedDate = e.Start.Date;
            UpdateEventsForDate(selectedDate);
        }
        private void btnDeleteEvent_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = monthCalendar1.SelectionStart.Date;
            if (listBoxEvents.SelectedItem == null || !eventsByDate.ContainsKey(selectedDate)) return;

            string selectedEvent = listBoxEvents.SelectedItem.ToString();
            eventsByDate[selectedDate].Remove(selectedEvent);

            UpdateEventsList(selectedDate);
        }
        private List<(DateTime dateTime, string text)> allEvents = new();

        private void buttonAddEvent_Click(object sender, EventArgs e)
        {
            string eventText = textBoxNewEvent.Text.Trim();
            if (string.IsNullOrEmpty(eventText))
            {
                MessageBox.Show("Введіть текст події.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime selectedDate = datePickerEvent.Value.Date; // <-- тут заменили
            DateTime selectedTime = timePickerEvent.Value;

            DateTime fullDateTime = new DateTime(
                selectedDate.Year, selectedDate.Month, selectedDate.Day,
                selectedTime.Hour, selectedTime.Minute, 0
            );

            allEvents.Add((fullDateTime, eventText));
            UpdateEventsForDate(monthCalendar1.SelectionStart.Date);
            UpdateAllEventsList();

            textBoxNewEvent.Clear();
        }

        private void UpdateAllEventsList()
        {
            // Сортируем события по дате и времени
            var sorted = allEvents.OrderBy(ev => ev.dateTime).ToList();

            listBoxAllEvents.Items.Clear();

            foreach (var ev in sorted)
            {
                string formatted = $"{ev.dateTime:dd.MM.yyyy HH:mm} — {ev.text}";
                listBoxAllEvents.Items.Add(formatted);
            }
        }

        private void UpdateEventsForDate(DateTime date)
        {
            listBoxEvents.Items.Clear();
            lblEventsTitle.Text = $"Події на: [{date:dd.MM.yyyy}]";

            var eventsForDate = allEvents
                .Where(ev => ev.dateTime.Date == date.Date)
                .OrderBy(ev => ev.dateTime.TimeOfDay)
                .ToList();

            if (eventsForDate.Count == 0)
            {
                listBoxEvents.Items.Add("Немає подій");
                listBoxEvents.Enabled = false; // блокируем выбор
                return;
            }

            listBoxEvents.Enabled = true;

            foreach (var ev in eventsForDate)
            {
                listBoxEvents.Items.Add($"{ev.dateTime:HH:mm} — {ev.text}");
            }
        }

        private void btnDeleteEvent2_Click(object sender, EventArgs e)
        {
            if (listBoxAllEvents.SelectedIndex >= 0)
            {
                var selected = listBoxAllEvents.SelectedItem.ToString();

                // Пытаемся найти и удалить
                var item = allEvents.FirstOrDefault(ev =>
                    $"{ev.dateTime:dd.MM.yyyy HH:mm} — {ev.text}" == selected);

                if (item != default)
                {
                    allEvents.Remove(item);
                    UpdateAllEventsList();
                    UpdateEventsForDate(monthCalendar1.SelectionStart.Date); // обновим текущую дату
                }
            }
        }

        private void btnDeleteEvent_Click_1(object sender, EventArgs e)
        {
            if (listBoxEvents.SelectedItem == null)
            {
                MessageBox.Show("Виберіть подію для видалення.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedItem = listBoxEvents.SelectedItem.ToString();
            DateTime selectedDate = monthCalendar1.SelectionStart.Date;

            // Найти и удалить из allEvents
            var eventToRemove = allEvents
                .FirstOrDefault(ev => ev.Item1.Date == selectedDate && $"{ev.Item1:HH:mm} — {ev.Item2}" == selectedItem);

            if (eventToRemove != default)
            {
                allEvents.Remove(eventToRemove);
                UpdateEventsForDate(selectedDate);
                UpdateAllEventsList();
            }
        }

        private void UpdateAnalytics()
        {
            if (chatHistory == null || chatHistory.Count == 0)
                return;

            int totalChats = chatHistory.Count;
            int totalMessages = 0;
            int totalGptResponsesLength = 0;
            int gptResponsesCount = 0;
            string longestChatTitle = "";
            int longestChatMessages = 0;

            foreach (var chat in chatHistory)
            {
                totalMessages += chat.Value.Count;

                int currentChatMessageCount = chat.Value.Count;
                if (currentChatMessageCount > longestChatMessages)
                {
                    longestChatMessages = currentChatMessageCount;
                    longestChatTitle = chat.Key;
                }

                foreach (var (sender, message) in chat.Value)
                {
                    if (sender == "Vivy") // или другой тег, который ты используешь
                    {
                        totalGptResponsesLength += message.Length;
                        gptResponsesCount++;
                    }
                }
            }

            int avgLength = gptResponsesCount > 0 ? totalGptResponsesLength / gptResponsesCount : 0;

            // Обновление UI
            lblChatsCount.Text = totalChats.ToString();
            lblMessagesCount.Text = totalMessages.ToString();
            lblAvgResponseLength.Text = $"{avgLength} символів";
            lblLongestChat.Text = longestChatTitle;
        }
        private void btnUpdateAnalytics_Click(object sender, EventArgs e)
        {
            UpdateAnalytics();
        }
        private string ExtractChatTopic(string message)
        {
            // Удалим знаки препинания и лишние пробелы
            string cleaned = Regex.Replace(message.ToLower(), @"[^\w\s]", "").Trim();

            // Разобьём на слова
            var words = cleaned.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // Возьмём максимум 2–4 слова с конца (они часто самые важные)
            var topicWords = words.Skip(Math.Max(0, words.Length - 4)).ToArray();

            return string.Join(" ", topicWords);
        }

        private void UpdateAboutPanelsTheme()
        {
            // Цвета для светлой и темной темы
            Color checkBoxForeColor = selectedTheme == "Світла" ? Color.Black : Color.White;
            Color checkBoxBackColor = selectedTheme == "Світла" ? Color.WhiteSmoke : Color.FromArgb(46, 51, 73);

            // Панели и фоновые картинки
            if (selectedTheme == "Світла")
            {
                panelAboutVivy.BackgroundImage = Properties.Resources.BackgroundWhite;
                panelProjects.BackgroundImage = Properties.Resources.BackgroundWhite;
                panelaboutUs.BackgroundImage = Properties.Resources.BackgroundWhite;
                panelContact.BackgroundImage = Properties.Resources.BackgroundWhite;
                panelSupport.BackgroundImage = Properties.Resources.BackgroundWhite;
                linkLabel1.LinkColor = Color.Blue;
                linkLabel2.LinkColor = Color.Blue;
                linkSupportCard.LinkColor = Color.Blue;
            }
            else
            {
                panelAboutVivy.BackgroundImage = Properties.Resources.BackgroundBlack;
                panelProjects.BackgroundImage = Properties.Resources.BackgroundBlack;
                panelaboutUs.BackgroundImage = Properties.Resources.BackgroundBlack;
                panelContact.BackgroundImage = Properties.Resources.BackgroundBlack;
                panelSupport.BackgroundImage = Properties.Resources.BackgroundBlack;
                linkLabel1.LinkColor = Color.Blue;
                linkLabel2.LinkColor = Color.Blue;
                linkSupportCard.LinkColor = Color.Blue;
            }

            // Чекбоксы — цвет текста и фона
            cbNotifications.ForeColor = checkBoxForeColor;
            cbNotifications.BackColor = checkBoxBackColor;
            cbSpeakResponses.ForeColor = checkBoxForeColor;
            cbSpeakResponses.BackColor = checkBoxBackColor;
            cbSaveHistory.ForeColor = checkBoxForeColor;
            cbSaveHistory.BackColor = checkBoxBackColor;
        }
        private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedLang = cbLanguage.SelectedItem.ToString();

            string langCode = selectedLang switch
            {
                "Українська" => "uk",
                "English" => "en",
                "Deutsch" => "de",
                _ => "uk"
            };

            // Применяем культуру
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(langCode);

            // Перезапускаем главную форму
            
            var mainForm = new FrmMain(currentLogin); // можно передать нужные параметры, если надо
            mainForm.Show();
            
        }
        private void FrmSettings_Load(object sender, EventArgs e)
        {
            var lang = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
            cbLanguage.SelectedItem = lang switch
            {
                "uk" => "Українська",
                "en" => "English",
                "de" => "Deutsch",
                _ => "Українська"
            };
        }
    }
}
