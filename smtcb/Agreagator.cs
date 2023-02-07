using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smtcb.Services
{
    public sealed class Agreagator
    {
        private static readonly Lazy<Agreagator> lazy =
            new Lazy<Agreagator>(() => new Agreagator());

        public static Agreagator Instance { get => lazy.Value; }

        public void LoadApplicationContext(ApplicationContext applicationContext) 
        {
            this.ApplicationContext = applicationContext;
        }

        public void LoadUserProvider(UserProvider userProvider) 
        {
            this.UserProvider = userProvider;
        }

        public void LoadAuthService(AuthService authService)
        {
            this.AuthService = authService;
        }

        public void LoadSessionData(SessionData sessionData)
        {
            this.SessionData = sessionData;
        }

        private Agreagator() { }

#if DEBUG
        public void AssertEverythingLoaded()
        {
            if (this.ApplicationContext == null)
            {
                throw new Exception("ApplicationContext is null");
            }

            if (this.UserProvider == null) {
                throw new Exception("UserProvider is null");
            }

            if (this.AuthService == null) 
            {
                throw new Exception("AuthService is null");
            }

            if (this.SessionData == null)
            {
                throw new Exception("SessionData is null");
            }
        }
#endif

        public ApplicationContext ApplicationContext { get; private set; }

        public UserProvider UserProvider { get; private set; }

        public AuthService AuthService { get; private set; }

        public SessionData SessionData { get; private set; }
    }
}
