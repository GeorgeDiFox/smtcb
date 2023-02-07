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

namespace smtcb.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = this.nameTextBox.Text;
            string password = this.passwordTextBox.Text;
            string passwordConfirm = this.confirmPasswordTextBox.Text;

            if (password == passwordConfirm)
            {
                Agreagator agreagator = Agreagator.Instance;

                if (agreagator.AuthService.RegisterUser(name, password))
                {
                    User user = agreagator.AuthService.TryLoggIn(name, password);

                    if (user != null) 
                    {
                        agreagator.SessionData.CurrentUser = user;
                        agreagator.SessionData.IsLoggedIn = true;
                        agreagator.RoutingService.RouteToForm("Main");
                    }
                }
            }
        }
    }
}
