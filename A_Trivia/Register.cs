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

namespace A_Trivia
{
    public partial class Register : Form
    {
        MySqlConnection conn = new MySqlConnection("DATASOURCE=localhost;PORT=3306;USERNAME=root;PASSWORD=root");
        MySqlCommand cmd;
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
                            MessageBox.Show("Datele au fost inserate!");
                        else
                            MessageBox.Show("Datele NU au fost inserate!");
                    }
                    else
                    {
                        MessageBox.Show("Parolele nu corespund!");
                    }
                        
                }
                catch (Exception ex)
                {
                       MessageBox.Show(ex.Message + "btn ");
                }

                conn.Close();
            }

            this.Hide();
            Login formLogin = new Login();
            formLogin.ShowDialog();

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
    }
}
