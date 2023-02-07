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
            this.routes = new Dictionary<string, Type>();
        }

        public void RouteToForm(params string[] path)
        {
            string fullPath = string.Join("/", path);

            Type toJump = this.routes[fullPath];

            if (toJump == null)
            {
                throw new ArgumentException($"The route {fullPath} does not exists");
            }

            Form nextForm = (Form) Activator.CreateInstance(toJump);

            applicationContext.MainForm = nextForm;
            sessionData.CurrentForm.Close();
            sessionData.CurrentForm = nextForm;
            nextForm.Show();
        }

        public void AddRoute(Type form, params string[] path)
        {
            string fullPath = string.Join("/", path);

            this.routes.Add(fullPath, form);
        }

        private SessionData sessionData;

        private ApplicationContext applicationContext;

        private Dictionary<string, Type> routes;
    }
}
