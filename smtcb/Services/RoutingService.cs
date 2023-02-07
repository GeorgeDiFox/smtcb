using smtcb.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smtcb.Services
{
    public class RoutingService
    {
        public RoutingService(SessionData sessionData, ApplicationContext applicationContext) 
        {
            this.sessionData = sessionData;
            this.applicationContext = applicationContext;
            this.routes = new Dictionary<string, AbstractFormFactory>();
        }

        public void RouteToForm(params string[] path)
        {
            string fullPath = string.Join("/", path);

            AbstractFormFactory toJump = this.routes[fullPath];

            if (toJump == null)
            {
                throw new ArgumentException($"The route {fullPath} does not exists");
            }

            Form nextForm = toJump.CreateInstance();

            applicationContext.MainForm = nextForm;
            sessionData.CurrentForm.Close();
            sessionData.CurrentForm = nextForm;
            nextForm.Show();
        }

        public void AddRoute(AbstractFormFactory form, params string[] path)
        {
            string fullPath = string.Join("/", path);

            this.routes.Add(fullPath, form);
        }

        private SessionData sessionData;

        private ApplicationContext applicationContext;

        private Dictionary<string, AbstractFormFactory> routes;
    }
}
