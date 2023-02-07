using smtcb.Forms;
using smtcb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smtcb
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Initialize();

            Agreagator agregator = Agreagator.Instance;

#if DEBUG
            agregator.AssertEverythingLoaded();
#endif

            ApplicationContext applicationContext = agregator.ApplicationContext;
            //applicationContext.MainForm = new Login();
            applicationContext.MainForm = new MainForm();
            Application.Run(agregator.ApplicationContext);
        }

        static void Initialize()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ApplicationContext applicationContext = new ApplicationContext();

            UserProvider userProvider = new UserProvider();

            AuthService authService = new AuthService(userProvider);
            authService.RegisterUser("admin", "admin");

            Agreagator agreagator = Agreagator.Instance;
            agreagator.LoadApplicationContext(applicationContext);
            agreagator.LoadUserProvider(userProvider);
            agreagator.LoadAuthService(authService);
        }
    }
}
