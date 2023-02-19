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
using BCrypt.Net;
using System.IO;

namespace A_Trivia
{
    public partial class Login : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=root");
        MySqlCommand cmd;
        MySqlDataReader reader;

        public Login()
        {
            InitializeComponent();
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register formRegister = new Register();
            formRegister.ShowDialog();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public string decryptPass(string encryptedPassword)
        {
            // Separation of encrypted values
            string[] values = encryptedPassword.Split(':');
            string encryptedPass = values[0];
            string keyString = values[1];
            string ivString = values[2];

            // Converting the key and IV back to byte arrays
            byte[] key = Convert.FromBase64String(keyString);
            byte[] iv = Convert.FromBase64String(ivString);

            // decrypt password
            byte[] encryptedBytes = Convert.FromBase64String(encryptedPass);
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            using (ICryptoTransform decryptor = aes.CreateDecryptor(key, iv))
            using (MemoryStream msDecrypt = new MemoryStream(encryptedBytes))
            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            {
                byte[] plainBytes = new byte[encryptedBytes.Length];
                int decryptedByteCount = csDecrypt.Read(plainBytes, 0, plainBytes.Length);
                return Encoding.UTF8.GetString(plainBytes, 0, decryptedByteCount);
            }
        }

        public bool SearchUsername()
        {
            string data = "";
            bool found = false;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT userName FROM trivia_db.accounts WHERE userName = @username";
            // define the username and password parameters
            MySqlParameter userParameter = new MySqlParameter("@username", txtUsername.Text);
            // add the username parameter and password parameter to the command
            cmd.Parameters.Add(userParameter);
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

        public bool SearchAccount()
        {
            if(SearchUsername() == true)
            {
                // define the sql query
                string queryPass = "SELECT userPass FROM trivia_db.accounts WHERE userName = @username";

                // define the username and password parameters
                MySqlParameter userParameter = new MySqlParameter("@username", txtUsername.Text);

                // create sql command
                using (MySqlCommand cmdPass = new MySqlCommand(queryPass, conn))
                {
                    // add the username parameter and password parameter to the command
                    cmdPass.Parameters.Add(userParameter);

                    // open the connection
                    conn.Open();

                    string encryptedPassword = (string)cmdPass.ExecuteScalar();

                    conn.Close();

                    string password = decryptPass(encryptedPassword);

                    if (password.Equals(txtPass.Text))
                    {
                        lblError.Text = "";
                        MessageBox.Show("Successful authentication!");
                        return true;
                    }
                }
            }
            return false; 
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUsername.Text) && String.IsNullOrEmpty(txtPass.Text))
            {
                lblError.Text = "Enter your username and password!";
            }
            else if (String.IsNullOrEmpty(txtUsername.Text))
            {
                lblError.Text = "Enter your username!";
            }
            else if (String.IsNullOrEmpty(txtPass.Text))
            {
                lblError.Text = "Enter your password!";
            }else if (SearchAccount() == true)
            {
                this.Hide();
                Game formGame = new Game(txtUsername.Text);
                formGame.ShowDialog();
            }
            else
            {
                lblError.Text = "Username or Password is wrong!!";
            }
        }
        
        private void lblRegister_MouseEnter(object sender, EventArgs e)
        {
            lblRegister.Font = new Font(lblRegister.Font, FontStyle.Bold);
            this.Cursor = Cursors.Hand;
        }

        private void lblRegister_MouseLeave(object sender, EventArgs e)
        {
            lblRegister.Font = new Font(lblRegister.Font, FontStyle.Regular);
            this.Cursor = Cursors.Default;
        }

        private void lblFPass_MouseEnter(object sender, EventArgs e)
        {
            lblFPass.Font = new Font(lblFPass.Font, FontStyle.Bold);
            this.Cursor = Cursors.Hand;
        }

        private void lblFPass_MouseLeave(object sender, EventArgs e)
        {
            lblFPass.Font = new Font(lblFPass.Font, FontStyle.Regular | FontStyle.Underline);
            this.Cursor = Cursors.Default;
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnLogin.PerformClick();
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnLogin.PerformClick();
            }
        }
    }
}
