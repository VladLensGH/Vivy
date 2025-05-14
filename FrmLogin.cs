using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Linq;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vivy
{
    public partial class FrmLogin : Form
    {
        // Методы хеширования и проверки пароля
        private static (string hash, string salt) HashPassword(string password)
        {
            byte[] saltBytes = System.Security.Cryptography.RandomNumberGenerator.GetBytes(16);
            using var pbkdf2 = new System.Security.Cryptography.Rfc2898DeriveBytes(password, saltBytes, 100_000, System.Security.Cryptography.HashAlgorithmName.SHA256);
            byte[] hashBytes = pbkdf2.GetBytes(32);
            return (Convert.ToBase64String(hashBytes), Convert.ToBase64String(saltBytes));
        }

        private static bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            byte[] saltBytes = Convert.FromBase64String(storedSalt);
            using var pbkdf2 = new System.Security.Cryptography.Rfc2898DeriveBytes(password, saltBytes, 100_000, System.Security.Cryptography.HashAlgorithmName.SHA256);
            byte[] hashBytes = pbkdf2.GetBytes(32);
            return Convert.ToBase64String(hashBytes) == storedHash;
        }

        private string registeredLogin = "admin";
        private string registeredPassword = "1234";


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


        public FrmLogin() 
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        Bitmap bmpHide = Properties.Resources.hide;
        Bitmap bmpReveal = Properties.Resources.reveal;

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=vivy.db";
            using var connection = new Microsoft.Data.Sqlite.SqliteConnection(connectionString);
            connection.Open();

            string selectCmd = "SELECT PasswordHash, PasswordSalt FROM Users WHERE Login = @login";
            using var cmd = new Microsoft.Data.Sqlite.SqliteCommand(selectCmd, connection);
            cmd.Parameters.AddWithValue("@login", txtUsername.Text);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string hash = reader.GetString(0);
                string salt = reader.GetString(1);

                if (VerifyPassword(txtPassword.Text, hash, salt))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }
            }

            MessageBox.Show("Невірний логін або пароль!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtPassword.Clear();
            txtPassword.Focus();
        }

        


        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblExitReg_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblAlreadyReg_Click(object sender, EventArgs e)
        {
            pnlReg.Visible = false;
            pnlLog.Visible = true;
        }

        private void lblNotRegistred_Click(object sender, EventArgs e)
        {
            pnlReg.Visible = true;
            pnlLog.Visible = false;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            pnlReg.Visible = false;
            pnlLog.Visible = true;
            btnReveal.Image = bmpReveal;
        }



        private void btnReveal_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                txtPassword.PasswordChar = '*';
                btnReveal.Image = bmpReveal;
            }
            else
            {
                txtPassword.PasswordChar = '\0';
                btnReveal.Image = bmpHide;
            }
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxLogin.Text) ||
                string.IsNullOrWhiteSpace(tbxPassword.Text) ||
                string.IsNullOrWhiteSpace(tbxEmail.Text))
            {
                MessageBox.Show("Введіть логін, пароль та e-mail!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!tbxEmail.Text.Contains("@") || !tbxEmail.Text.Contains("."))
            {
                MessageBox.Show("Введіть коректний e-mail!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var (hash, salt) = HashPassword(tbxPassword.Text);

            string connectionString = "Data Source=vivy.db";
            using var connection = new Microsoft.Data.Sqlite.SqliteConnection(connectionString);
            connection.Open();

            string checkCmd = "SELECT COUNT(*) FROM Users WHERE Login = @login";
            using (var check = new Microsoft.Data.Sqlite.SqliteCommand(checkCmd, connection))
            {
                check.Parameters.AddWithValue("@login", tbxLogin.Text);
                long exists = (long)check.ExecuteScalar();
                if (exists > 0)
                {
                    MessageBox.Show("Користувач з таким логіном вже існує!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string insertCmd = "INSERT INTO Users (Login, PasswordHash, PasswordSalt, Email) VALUES (@login, @hash, @salt, @email)";
            using (var cmd = new Microsoft.Data.Sqlite.SqliteCommand(insertCmd, connection))
            {
                cmd.Parameters.AddWithValue("@login", tbxLogin.Text);
                cmd.Parameters.AddWithValue("@hash", hash);
                cmd.Parameters.AddWithValue("@salt", salt);
                cmd.Parameters.AddWithValue("@email", tbxEmail.Text);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Реєстрація успішна! Тепер увійдіть.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

            pnlReg.Visible = false;
            pnlLog.Visible = true;
        }




    }
}
