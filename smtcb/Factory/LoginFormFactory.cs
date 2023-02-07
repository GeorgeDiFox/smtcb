using smtcb.Forms;
using System.Windows.Forms;

namespace smtcb.Factory
{
    public class LoginFormFactory : AbstractFormFactory
    {
        public override Form CreateInstance()
        {
            return new Login();
        }
    }
}
