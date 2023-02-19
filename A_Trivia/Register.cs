using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Text.RegularExpressions;

namespace A_Trivia
{
    public partial class Register : Form
    {
        MySqlConnection conn = new MySqlConnection("DATASOURCE=localhost;PORT=3306;USERNAME=root;PASSWORD=root");
        MySqlCommand cmd;
        MySqlDataReader reader;
        string query;
        DateTime currentDate = DateTime.Now;

        public Register()
        {
            InitializeComponent();
        }

        public string encryptPass(string password)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(password);

            // Alegem o cheie și un IV aleatorii
            byte[] key = new byte[32];
            byte[] iv = new byte[16];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(key);
                rng.GetBytes(iv);
            }

            // Criptarea datelor
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            using (ICryptoTransform encryptor = aes.CreateEncryptor(key, iv))
            using (MemoryStream msEncrypt = new MemoryStream())
            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
                csEncrypt.Write(plainBytes, 0, plainBytes.Length);
                csEncrypt.FlushFinalBlock();
                byte[] encryptedBytes = msEncrypt.ToArray();
                string encryptedPassword = Convert.ToBase64String(encryptedBytes) + ":" + Convert.ToBase64String(key) + ":" + Convert.ToBase64String(iv);

                return encryptedPassword;
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtMail.Text) || string.IsNullOrEmpty(txtPass.Text) || string.IsNullOrEmpty(txtCPass.Text))
            {
               lblError.Text = "Fill in all the fields!";
            }
            else
            {
                string validFields = "✔";
                bool allValid = true;

                foreach(Label lblFields in new Label[] {lblErrorName, lblErrorUsername, lblErrorMail, lblErrorPass, lblErrorCPass })
                {
                    if(lblFields.Text != validFields)
                    {
                        allValid = false;
                        break;
                    }
                }

                if (allValid)
                {
                    query = "INSERT INTO trivia_db.accounts (userName, userFullName, userMail, userPass, userDate) VALUES (@username, @userfullname, @usermail, @userpass, @userdate)";


                    using (cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@userfullname", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@usermail", txtMail.Text.Trim());
                        cmd.Parameters.AddWithValue("@userpass", encryptPass(txtPass.Text));
                        cmd.Parameters.AddWithValue("@userdate", currentDate);

                        conn.Open();

                        try
                        {
                            if ((txtPass.Text).Equals(txtCPass.Text))
                            {
                                if (cmd.ExecuteNonQuery() == 1)
                                {
                                    lblError.Text = "";
                                    MessageBox.Show("The account has been created successfully!");
                                }
                                else
                                {
                                    lblError.Text = "";
                                    MessageBox.Show("Account creation failed!");
                                }
                            }
                            else
                            {
                                lblError.Text = "Passwords don't match!";
                            }

                        }
                        catch (Exception ex)
                        {
                            lblError.Text = "Database ERROR!";
                        }

                        conn.Close();
                    }

                    this.Hide();
                    Login formLogin = new Login();
                    formLogin.ShowDialog();
                }
                else
                {
                    lblError.Text = "At least one field is not valid";
                }
            }      
        }

        private void lblSignIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login formLogin = new Login();
            formLogin.ShowDialog();
        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnSignUp_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSignUp_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblSignIn_MouseEnter(object sender, EventArgs e)
        {
            lblSignIn.Font = new Font(lblSignIn.Font, FontStyle.Bold);
            this.Cursor = Cursors.Hand;
        }

        private void lblSignIn_MouseLeave(object sender, EventArgs e)
        {
            lblSignIn.Font = new Font(lblSignIn.Font, FontStyle.Regular | FontStyle.Underline);
            this.Cursor = Cursors.Default;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login formLogin = new Login();
            formLogin.ShowDialog();
        }
        

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"^[a-zA-Z\s]+$");

            if (reg.IsMatch(txtName.Text.Trim()))
            {
                lblErrorName.Text = "✔";
                lblErrorName.ForeColor = Color.Green;
            }
            else
            {
                lblErrorName.ForeColor = Color.Red;
                lblErrorName.Text = "✘ The name must contain only letters!";
            }
        }

        public bool SearchData(string field, string info)
        {
            string data = "";
            bool found = false;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT " + field + " FROM trivia_db.accounts WHERE " + field + " = '" + info + "'";
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    data = reader.GetString(0);
                    found = true;
                }
                conn.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Eroare cautare\n" + erro);
                this.Close();
            }

            if (found)
                return true;
            else
                return false;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"^[^\s]+$");

            if (reg.IsMatch(txtUsername.Text.Trim()))
            {
                if(SearchData("userName", txtUsername.Text) == false)
                {
                    lblErrorUsername.Text = "✔";
                    lblErrorUsername.ForeColor = Color.Green;
                }
                else
                {
                    lblErrorUsername.ForeColor = Color.Red;
                    lblErrorUsername.Text = "✘ The user already exists!";
                }
            }
            else
            {
                lblErrorUsername.ForeColor = Color.Red;
                lblErrorUsername.Text = "✘ The username must not contain spaces!";
            }
        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

            if (reg.IsMatch(txtMail.Text.Trim()))
            {
                if (SearchData("userMail", txtMail.Text) == false)
                {
                    lblErrorMail.Text = "✔";
                    lblErrorMail.ForeColor = Color.Green;
                }
                else
                {
                    lblErrorMail.ForeColor = Color.Red;
                    lblErrorMail.Text = "✘ There is already a user with this email address!";
                }
            }
            else
            {
                lblErrorMail.ForeColor = Color.Red;
                lblErrorMail.Text = "✘ The email address is invalid!";
            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"^(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{8,}$");

            if (reg.IsMatch(txtPass.Text.Trim()))
            {
                lblErrorPass.Text = "✔";
                lblErrorPass.ForeColor = Color.Green;
            }
            else
            {
                lblErrorPass.ForeColor = Color.Red;
                lblErrorPass.Text = "✘ The password is in an incorrect format!";
            }

            if ((txtPass.Text).Equals(txtCPass.Text))
            {
                lblErrorCPass.Text = "✔";
                lblErrorCPass.ForeColor = Color.Green;
            }
            else
            {
                lblErrorCPass.ForeColor = Color.Red;
                lblErrorCPass.Text = "✘ The passwords don't match!";
            }
        }

        private void txtCPass_TextChanged(object sender, EventArgs e)
        {
            if ((txtPass.Text).Equals(txtCPass.Text))
            {
                lblErrorCPass.Text = "✔";
                lblErrorCPass.ForeColor = Color.Green;
            }
            else
            {
                lblErrorCPass.ForeColor = Color.Red;
                lblErrorCPass.Text = "✘ The passwords don't match!";
            }
        }

        private void lblInfo_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblInfo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSignUp.PerformClick();
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSignUp.PerformClick();
            }
        }

        private void txtMail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSignUp.PerformClick();
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSignUp.PerformClick();
            }
        }

        private void txtCPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSignUp.PerformClick();
            }
        }
    }
}
