using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using ElasticEmail.Api;
using ElasticEmail.Client;
using ElasticEmail.Model;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Net;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace A_Trivia
{
    public partial class ResetPassword : Form
    {
        MySqlConnection conn = new MySqlConnection("DATASOURCE=localhost;PORT=3306;USERNAME=root;PASSWORD=root");
        MySqlCommand cmd;
        MySqlDataReader reader;

        Random rand = new Random();
        public int code;

        public ResetPassword()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login formLogin = new Login();
            formLogin.ShowDialog();
        }

        static string Send(string address, NameValueCollection values)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    byte[] apiResponse = client.UploadValues(address, values);
                    return Encoding.UTF8.GetString(apiResponse);

                }
                catch (Exception ex)
                {
                    return "Exception caught: " + ex.Message + "\n" + ex.StackTrace;
                }
            }
        }

        public bool SearchMail()
        {
            string data = "";
            bool found = false;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT userMail FROM trivia_db.accounts WHERE userMail = @usermail";
            // define the username and password parameters
            MySqlParameter userParameter = new MySqlParameter("@usermail", txtMail.Text);
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

        public string GetUsername()
        {
            string data = "";

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT userName FROM trivia_db.accounts WHERE userMail = @usermail";
            // define the username and password parameters
            MySqlParameter userParameter = new MySqlParameter("@usermail", txtMail.Text);
            // add the username parameter and password parameter to the command
            cmd.Parameters.Add(userParameter);
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    data = reader.GetString(0);
                }
                conn.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Eroare cautare\n" + erro);
                this.Close();
            }
            return data;
        }

        public bool SearchMailFromResetPass()
        {
            string data = "";
            bool found = false;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT mail FROM trivia_db.resetpass WHERE mail = @email";
            // define the username and password parameters
            MySqlParameter userParameter = new MySqlParameter("@email", txtMail.Text);
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

        public void InsertCode(string email, int code)
        {
            string query;
            if (SearchMailFromResetPass() == false)
            {
                query = "INSERT INTO trivia_db.resetpass (mail, codeReset) VALUES (@email, @codereset)";

                using (cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@codereset", code);

                    conn.Open();
                    try
                    {
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            lblErrorMail.Text = "";
                            MessageBox.Show("Codul a fost adaugat!");
                        }
                        else
                        {
                            lblErrorMail.ForeColor = Color.Red;
                            lblErrorMail.Text = "Error at insert";
                        }
                    }
                    catch (Exception ex)
                    {
                        lblErrorMail.ForeColor = Color.Red;
                        lblErrorMail.Text = ex.ToString();
                    }
                    conn.Close();
                }
            }
            else
            {
                query = "UPDATE trivia_db.resetpass SET codeReset = @codereset WHERE mail = @email";

                using (cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@codereset", code);

                    conn.Open();
                    try
                    {
                        reader = cmd.ExecuteReader();

                        while (reader.Read()) { }
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("Eroare\n" + erro);
                    }
                    conn.Close();
                }
            }
        }

        private void SendMail()
        {
            code = rand.Next(100000, 999999);

            if (SearchMail())
            {
                lblErrorMail.ForeColor = Color.Green;
                lblErrorMail.Text = "✔";

                NameValueCollection values = new NameValueCollection();
                values.Add("apikey", "2BA3D7FDE3CC019B7F91937C9ED61556C2087F4142721C21B43F1B4BD03BCD910F1C9934B59451186CE7E4909ED32EB1");
                values.Add("from", "muntyancraciunela@gmail.com");
                values.Add("fromName", "Trivia Game");
                values.Add("to", txtMail.Text);
                values.Add("subject", "Reset Password");
                values.Add("bodyHtml", "Hi " + GetUsername() + ", <br><br> Please use the code <strong><u>" + code + "</u></strong> to reset your Trivia-Game password. If you didn't request your password to be reset, ignore this message.<br><br>Sincerely, <br> Trivia Team");

                string address = "https://api.elasticemail.com/v2/email/send";

                string response = Send(address, values);

                MessageBox.Show(response);
                InsertCode(txtMail.Text, code);
                txtCode.Enabled = true;
            }
            else
            {
                lblErrorMail.Text = "✘ There is no account with this email address!";
                lblErrorMail.ForeColor = Color.Red;
                txtCode.Enabled = false;
            }
        }
    

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMail();
        }

        private void ResetPassword_Load(object sender, EventArgs e)
        {

        }

        private void btnSendAgain_Click(object sender, EventArgs e)
        {
            SendMail();
        }

        private void ResetPassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            txtNewPass.Enabled = true;
            txtConfirmPass.Enabled = true;
            btnChange.Enabled = true;
        }

        public bool CheckCode()
        {
            int data = 0;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT codeReset FROM trivia_db.resetpass WHERE mail = @email";
            // define the username and password parameters
            MySqlParameter userParameter = new MySqlParameter("@email", txtMail.Text);
            // add the username parameter and password parameter to the command
            cmd.Parameters.Add(userParameter);
            try
            {
                conn.Open();

                var result = cmd.ExecuteScalar();
                if(result != null && result != DBNull.Value)
                {
                    data = Convert.ToInt32(result);
                }

                conn.Close();

                if (data == Convert.ToInt32(txtCode.Text))
                {
                    return true;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Eroare cautare\n" + erro);
            }
            
            return false;
        }

        

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"^\d+$");
            if (reg.IsMatch(txtCode.Text.Trim()))
            {
                if (CheckCode() == false)
                {
                    lblErrorCode.Text = "✘ The code is incorrect!";
                    lblErrorCode.ForeColor = Color.Red;
                    btnNext.Enabled = false;
                }
                else
                {
                    lblErrorCode.Text = "✔";
                    lblErrorCode.ForeColor = Color.Green;
                    btnNext.Enabled = true;
                }
            }
            else
            {
                lblErrorCode.Text = "✘ The code must contain only digits!";
                lblErrorCode.ForeColor = Color.Red;
                btnNext.Enabled = false;
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if((lblNewPass.Text).Equals("✔") && (lblErrorConfirmPass.Text).Equals("✔"))
            {
                string query = "UPDATE trivia_db.accounts SET userPass = @userpass WHERE userMail = @usermail";

                using (cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@usermail", txtMail.Text);
                    cmd.Parameters.AddWithValue("@userpass", txtNewPass.Text);

                    conn.Open();
                    try
                    {
                        reader = cmd.ExecuteReader();

                        while (reader.Read()) { }

                        MessageBox.Show("Password has been updated!");
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("Eroare\n" + erro);
                    }
                    conn.Close();
                }
            }
        }

        private void txtNewPass_TextChanged(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"^(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{8,}$");

            if (reg.IsMatch(txtNewPass.Text.Trim()))
            {
                lblErrorNewPass.Text = "✔";
                lblErrorNewPass.ForeColor = Color.Green;
            }
            else
            {
                lblErrorNewPass.ForeColor = Color.Red;
                lblErrorNewPass.Text = "✘ The password is in an incorrect format!";
            }

            if ((txtNewPass.Text).Equals(txtConfirmPass.Text))
            {
                lblErrorConfirmPass.Text = "✔";
                lblErrorConfirmPass.ForeColor = Color.Green;
            }
            else
            {
                lblErrorConfirmPass.ForeColor = Color.Red;
                lblErrorConfirmPass.Text = "✘ The passwords don't match!";
            }
        }

        private void txtConfirmPass_TextChanged(object sender, EventArgs e)
        {
            if ((txtNewPass.Text).Equals(txtConfirmPass.Text))
            {
                lblErrorConfirmPass.Text = "✔";
                lblErrorConfirmPass.ForeColor = Color.Green;
            }
            else
            {
                lblErrorConfirmPass.ForeColor = Color.Red;
                lblErrorConfirmPass.Text = "✘ The passwords don't match!";
            }
        }
    }
}
