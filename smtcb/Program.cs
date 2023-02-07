using smtcb.Factory;
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
            applicationContext.MainForm = new Login();
            //applicationContext.MainForm = new MainForm();
            agregator.SessionData.CurrentForm = applicationContext.MainForm;
            Application.Run(agregator.ApplicationContext);
        }

        static void Initialize()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ApplicationContext applicationContext = new ApplicationContext();

            UserProvider userProvider = new UserProvider();

            SessionData sessionData = new SessionData()
            {
                IsLoggedIn = false
            };

            AuthService authService = new AuthService(userProvider);
            authService.RegisterUser("admin", "admin");

            RoutingService router = InitializeRouter(sessionData, applicationContext);

            Agreagator agreagator = Agreagator.Instance;
            agreagator.LoadApplicationContext(applicationContext);
            agreagator.LoadUserProvider(userProvider);
            agreagator.LoadAuthService(authService);
            agreagator.LoadSessionData(sessionData);
            agreagator.LoadRoutingService(router);
        }

        static RoutingService InitializeRouter(SessionData sessionData, ApplicationContext applicationContext)
        {
            RoutingService router = new RoutingService(sessionData, applicationContext);

            router.AddRoute(new MainFormFactory(), "Main");

            router.AddRoute(new LoginFormFactory(), "Login");

            router.AddRoute(new RegistrationFormFactory(), "Login", "Registration");

            return router;
        }
    }
}
