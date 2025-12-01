using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace BarnCaseApi
{
    public partial class SignUp : Form
    {
        private string connectionString = @"Data Source=ALI;Initial Catalog=BarnCaseDB;Integrated Security=True";

        public SignUp()
        {
            InitializeComponent();

            textBox1.MaxLength = 40;
            textBox2.MaxLength = 100;
            textBox3.MaxLength = 50;
            textBox4.MaxLength = 50;

            textBox3.UseSystemPasswordChar = true;
            textBox4.UseSystemPasswordChar = true;

            lblError.Visible = false;
            lblErrorPassword.Visible = false;

            textBox2.TextChanged += TextBoxes_TextChanged;
            textBox3.TextChanged += TextBoxes_TextChanged;
            textBox4.TextChanged += TextBoxes_TextChanged;

            textBox1.KeyPress += OnlyLetters_KeyPress;
            textBox2.KeyPress += NoWhitespace_KeyPress;
            textBox3.KeyPress += NoWhitespace_KeyPress;
            textBox4.KeyPress += NoWhitespace_KeyPress;

            ShowPassword.CheckedChanged += ShowPassword_CheckedChanged;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
 
        private void ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool show = ShowPassword.Checked;
            textBox3.UseSystemPasswordChar = !show;
            textBox4.UseSystemPasswordChar = !show;
        }

        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            ValidateAll();
        }

        private void OnlyLetters_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void NoWhitespace_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void ValidateAll()
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            bool emailEmpty = string.IsNullOrWhiteSpace(textBox2.Text);
            bool emailValid = Regex.IsMatch(textBox2.Text, emailPattern);
            bool passwordsMatch = textBox3.Text == textBox4.Text;
            string password = textBox3.Text;
            bool passwordRule = password.Length >= 8 &&
                                Regex.IsMatch(password, "[A-Z]") &&
                                Regex.IsMatch(password, "[a-z]") &&
                                Regex.IsMatch(password, "[0-9]");

            string errors = "";

            if (!emailEmpty && !emailValid)
                errors += "Please enter a valid email address\n";

            if (!string.IsNullOrEmpty(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) &&
                !passwordsMatch)
                errors += "Passwords do not match\n";

            lblError.Text = errors.Trim();
            lblError.ForeColor = Color.DarkRed;
            lblError.Visible = !string.IsNullOrEmpty(lblError.Text);

            if (!string.IsNullOrEmpty(password) && !passwordRule)
            {
                lblErrorPassword.Text = "Password must be at least 8 characters, include uppercase, lowercase, and a number";
                lblErrorPassword.ForeColor = Color.DarkRed;
                lblErrorPassword.Visible = true;
            }
            else
            {
                lblErrorPassword.Text = "";
                lblErrorPassword.Visible = false;
            }

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            ValidateAll();

            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!string.IsNullOrEmpty(lblError.Text) || !string.IsNullOrEmpty(lblErrorPassword.Text))
            {
                MessageBox.Show("Please correct the errors.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try 
            {               
                string password = textBox3.Text;
                byte[] salt = GenerateSalt(16);
                int iterations = 100000;
                byte[] hash = HashPassword(password, salt, iterations);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO Hash (Username, Email, PasswordHash, PasswordSalt, Iterations)
                                     VALUES (@Username, @Email, @PasswordHash, @PasswordSalt, @Iterations)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Email", textBox2.Text);
                        cmd.Parameters.Add("@PasswordHash", System.Data.SqlDbType.VarBinary, 32).Value = hash;
                        cmd.Parameters.Add("@PasswordSalt", System.Data.SqlDbType.VarBinary, 16).Value = salt;
                        cmd.Parameters.AddWithValue("@Iterations", iterations);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Registration successful ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SignIn form2 = new SignIn();
                form2.Show();
                this.Hide();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("This email is already registered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private static byte[] GenerateSalt(int size)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
               byte[] salt = new byte[size];
               rng.GetBytes(salt);
               return salt;
            }
        }

        private static byte[] HashPassword(string password, byte[] salt, int iterations)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
            {
              return pbkdf2.GetBytes(32); 
            }
        }

        private void PicToLogin_Click(object sender, EventArgs e)
        {
           SignIn loginForm = new SignIn();
           loginForm.Show();
           this.Hide();
        }
    }
}