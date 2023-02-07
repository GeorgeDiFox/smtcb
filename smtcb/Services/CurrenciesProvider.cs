using smtcb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smtcb.Services
{
    public class CurrenciesProvider
    {
        public CurrenciesProvider() 
        {
            currencies = new List<Currency>();
        }

        public IEnumerable<Currency> Currencies { get => currencies; }

        private List<Currency> currencies;
    }
}
