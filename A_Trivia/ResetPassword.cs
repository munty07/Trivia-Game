using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Trivia
{
    public partial class ResetPassword : Form
    {
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

        private void btnSend_Click(object sender, EventArgs e)
        {
            // Generare token unic pentru resetarea parolei
            string token = Guid.NewGuid().ToString();

            // Salvează token-ul și asocierea cu utilizatorul

            // Construiește mesajul de e-mail
            string to = "utilizator@example.com";
            string subject = "Resetare parolă";
            string body = "Pentru a reseta parola, accesați link-ul de mai jos:\n\n";
            body += "https://www.example.com/resetare-parola?token=" + token;

            // Trimite mesajul de e-mail
            using (MailMessage message = new MailMessage("de-la@example.com", to, subject, body))
            {
                using (SmtpClient client = new SmtpClient("smtp.example.com", 587))
                {
                    client.Credentials = new NetworkCredential("de-la@example.com", "parola");
                    client.EnableSsl = true;
                    client.Send(message);
                }
            }

        }
    }
}
