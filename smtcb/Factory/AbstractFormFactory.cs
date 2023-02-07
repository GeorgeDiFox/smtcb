using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smtcb.Factory
{
    public abstract class AbstractFormFactory
    {
        public abstract Form CreateInstance();
    }
}
