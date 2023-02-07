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
    }
}
