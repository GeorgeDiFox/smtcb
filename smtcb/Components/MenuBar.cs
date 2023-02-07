using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smtcb.Components
{
    public class MenuBar : Menu
    {
        public MenuBar() : base(GetMenuItems()) {}

        private static MenuItem[] GetMenuItems()
        {

            var logout = new MenuItem();
            logout.Text = "Выйти";

            MenuItem[] items = new MenuItem[]
            {
                logout
            };

            return items;
        }
    }
}
