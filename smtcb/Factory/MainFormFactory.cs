using smtcb.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smtcb.Factory
{
    public class MainFormFactory : AbstractFormFactory
    {
        public override Form CreateInstance()
        {
            return new MainForm();
        }
    }
}
