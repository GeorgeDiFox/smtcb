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

namespace smtcb.Components
{
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
            //this.Load += loadingHandler;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agreagator agreagator = Agreagator.Instance;

            ApplicationContext ctx = agreagator.ApplicationContext;

            var loginForm = new Login();

            var current = ctx.MainForm;
            ctx.MainForm = loginForm;
            current.Close();
            loginForm.Show();
        }

        private void loadUsername()
        {
            Agreagator agreagator = Agreagator.Instance;

            bool isLoggedIn = agreagator.SessionData.IsLoggedIn;

            if (isLoggedIn || agreagator.SessionData.CurrentUser != null)
            {
                string username = agreagator.SessionData.CurrentUser.UserName;

                this.userNameToolStripMenuItem.Text = username;
            }
            else
            {
                this.userNameToolStripMenuItem.Text = "Гость";
            }
        }

        private void loadingHandler(object sender, EventArgs e)
        {
            this.loadUsername();
        }
    }
}
