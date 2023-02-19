using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Trivia
{
    public partial class Game : Form
    {
        public Game(string txtUsername)
        {
            InitializeComponent();
            lblUsername.Text = txtUsername;
        }

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login formLogin = new Login();
            formLogin.ShowDialog();
        }
    }
}
