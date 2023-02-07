using System.Windows.Forms;
using smtcb.Forms;

namespace smtcb.Factory
{
    public class RegistrationFormFactory : AbstractFormFactory
    {
        public override Form CreateInstance()
        {
            return new RegisterForm();
        }
    }
}
