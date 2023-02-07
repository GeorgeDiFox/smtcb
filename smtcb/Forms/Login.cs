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

            if (authService.CheckCredentials(username, password))
            {
                Console.WriteLine("Вы вошли");
            } 
            else
            {
                Console.WriteLine("Вы не вошли");
            }
        }
    }
}
