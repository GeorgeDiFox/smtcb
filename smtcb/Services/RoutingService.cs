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
        }

        public void RouteToForm(params string[] path)
        {
            string fullPath = string.Join("/", path);

            Form toJump = routes[fullPath];

            if (toJump == null)
            {
                throw new ArgumentException($"The route {fullPath} does not exists");
            }

            applicationContext.MainForm = toJump;
            sessionData.CurrentForm.Close();
            sessionData.CurrentForm = toJump;
            toJump.Show();
        }

        public void AddRoute(Form form, params string[] path)
        {
            string fullPath = string.Join("/", path);

            routes.Add(fullPath, form);
        }

        private SessionData sessionData;

        private ApplicationContext applicationContext;

        private Dictionary<string, Form> routes;
    }
}
