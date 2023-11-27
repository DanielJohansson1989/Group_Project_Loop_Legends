using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_Loop_Legends
{
    internal class CurrencyConverter
    {
        private double _sEK;
        private double _uSD;
        private double _eURO;
        private double _gBP;
        private double _jPY;
        private double _baseCurrency = 1;

        public static void ConvertCurrency(Account account, string desiredCurrency)
        {
           // if (desiredCurrency == account.Currency) { }
        }

        public double SEK
        {
            get { return _sEK; }
            set { _sEK = value;  }
        }
        public double USD
        {
            get { return _uSD; }
            set { _uSD = value;  }
        }
        public double EURO
        {
            get { return _eURO; }
            set { _eURO = value;  }
        }
        public double GBP
        {
            get { return _gBP; }
            set { _gBP = value;  }
        }
        public double JPY
        {
            get { return _jPY; }
            set { _jPY = value;  }
        }
    }
}
