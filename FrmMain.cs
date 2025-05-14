

﻿using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Text.Json;
using RestSharp;
using System.Text.Json;


namespace Vivy
{
    public partial class FrmMain : Form
    {
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
        public FrmMain()
        {
            InitializeComponent();

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            Pnlscroll.Height = BtnDashboard.Height;
            Pnlscroll.Top = BtnDashboard.Top;
            Pnlscroll.Left = BtnDashboard.Left;
            BtnDashboard.BackColor = Color.FromArgb(46, 51, 73);
        }
        private Dictionary<string, List<(string sender, string message)>> chatHistory = new();
        private string currentChatTitle = "";

        private void FrmMain_Load(object sender, EventArgs e)
        {
            RoundPanelCorners(panelInput, 10);

            // Встановлюємо текст для LinkLabel українською
            linkLabel1.Text =
            "• CrossLang — багатомовний перекладач з ІІ\n" +
            "• StreamMind — генерація сценаріїв для YouTube\n" +
            "• ZenNote — мінімалістичний трекер звичок";

            // Очищаємо старі посилання (на всякий випадок)
            linkLabel1.Links.Clear();

            linkLabel1.Links.Add(2, 9, "https://crosslang.com");
            linkLabel1.Links.Add(44, 11, "https://streammind.com");
            linkLabel1.Links.Add(92, 8, "https://zennote.com");

            linkLabel1.LinkColor = Color.LightGray;
            linkLabel1.ActiveLinkColor = Color.Black;
            linkLabel1.VisitedLinkColor = Color.LightGray;
            linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;

            linkSupportCard.Links.Clear();
            linkSupportCard.Links.Add(0, linkSupportCard.Text.Length, "https://send.monobank.ua/jar/4441114498935962"); // ← замени на свою ссылку






        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnDashboard_Click_1(object sender, EventArgs e)
        {
            Pnlscroll.Height = BtnDashboard.Height;
            Pnlscroll.Top = BtnDashboard.Top;
            Pnlscroll.Left = BtnDashboard.Left;
            BtnDashboard.BackColor = Color.FromArgb(46, 51, 73);
            // показываем только panel
            panelVivy.Visible = true;
            panelAnalytics.Visible = false;
            panelCalendar.Visible = false;
            panelAbout.Visible = false;
            panelSettings.Visible = false;


        }

        private void btnAnalytics_Click(object sender, EventArgs e)
        {
            Pnlscroll.Height = btnAnalytics.Height;
            Pnlscroll.Top = btnAnalytics.Top;
            btnAnalytics.BackColor = Color.FromArgb(46, 51, 73);
            // показываем только panel
            panelVivy.Visible = false;
            panelAnalytics.Visible = true;
            panelCalendar.Visible = false;
            panelAbout.Visible = false;
            panelSettings.Visible = false;


        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            Pnlscroll.Height = btnCalendar.Height;
            Pnlscroll.Top = btnCalendar.Top;
            btnCalendar.BackColor = Color.FromArgb(46, 51, 73);
            // показываем только panel
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
            btnContactUs.BackColor = Color.FromArgb(46, 51, 73);
            // показываем только panel
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
            btnsettings.BackColor = Color.FromArgb(46, 51, 73);
            // показываем только panel
            panelVivy.Visible = false;
            panelAnalytics.Visible = false;
            panelCalendar.Visible = false;
            panelAbout.Visible = false;
            panelSettings.Visible = true;

        }

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


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelAnalytics_Paint(object sender, PaintEventArgs e)
        {

        }
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

        private void lblAboutText_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panelAboutVivy_Paint(object sender, PaintEventArgs e)
        {
            RoundPanelCorners(panelAboutVivy, 15);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panelProjects_Paint(object sender, PaintEventArgs e)
        {
            RoundPanelCorners(panelProjects, 15);
        }

        private void panelSupport_Paint(object sender, PaintEventArgs e)
        {
            RoundPanelCorners(panelSupport, 15);

        }

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

        private void lblSupportCardText_Click(object sender, EventArgs e)
        {

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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panelVivy_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelCalendar_Paint(object sender, PaintEventArgs e)
        {

        }
        private async Task<string> GetGPTResponse(string userMessage)
        {
            var client = new RestClient("https://openrouter.ai/api/v1/chat/completions");
            var request = new RestRequest();
            request.AddHeader("Authorization", "Bearer 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");
            request.AddHeader("Content-Type", "application/json");

            var body = new
            {
                model = "openai/gpt-3.5-turbo", //
                messages = new[]
                {
            new { role = "user", content = userMessage }
        }
            };

            request.AddJsonBody(body);
            var response = await client.PostAsync(request);

            if (response != null && response.Content != null)
            {
                using var doc = JsonDocument.Parse(response.Content);
                return doc.RootElement
                          .GetProperty("choices")[0]
                          .GetProperty("message")
                          .GetProperty("content")
                          .GetString();
            }

            return "Помилка при отриманні відповіді.";
        }


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
            richTextBox1.AppendText("Вы: ");
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.AppendText(userMessage + "\n\n");
            textBoxInput.Clear();

            // Получаем ответ от GPT
            string gptResponse = await GetGPTResponse(userMessage);

            // Показываем и сохраняем ответ Vivy
            chatHistory[currentChatTitle].Add(("Vivy", gptResponse));
            richTextBox1.SelectionColor = Color.MediumPurple;
            richTextBox1.AppendText("Vivy: ");
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.AppendText(gptResponse + "\n\n");

            // Прокручиваем вниз
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
    }
}
