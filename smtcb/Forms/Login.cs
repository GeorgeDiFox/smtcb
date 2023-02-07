using smtcb.Forms;
using smtcb.Models;
using smtcb.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smtcb
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LogInHandler(object sender, EventArgs e)
        {
            string username = this.nameTextBox.Text;
            string password = this.passwordTextBox.Text;

            Agreagator agreagator = Agreagator.Instance;

            AuthService authService = agreagator.AuthService;

            User user = authService.TryLoggIn(username, password);

            if (user != null)
            {
                agreagator.SessionData.CurrentUser = user;
                agreagator.SessionData.IsLoggedIn = true;

                ApplicationContext ctx = agreagator.ApplicationContext;
                MainForm main = new MainForm();
                ctx.MainForm = main;
                this.Close();
                main.Show();
            } 
            else
            {
                Console.WriteLine("Вы не вошли");
            }
        }
    }
}
