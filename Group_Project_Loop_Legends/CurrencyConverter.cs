﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_Loop_Legends
{
    internal class CurrencyConverter
    {
        private static double _sekRate = 1;
        private static double _usdRate = 0.096;
        private static double _euroRate = 0.088;
        private static double _gbpRate = 0.076;
        private static double _jpyRate = 14.31;

        
        public static double ConvertCurrency(Account currentAccount, Account receivingAccount, double amount)
        {
            double baseValue = 0;

            switch (currentAccount.Currency)
            {
                case "SEK":
                    baseValue = amount / _sekRate;
                    break;
                case "USD":
                    baseValue = amount / _usdRate;
                    break;
                case "EURO":
                    baseValue = amount / _euroRate;
                    break;
                case "GBP":
                    baseValue = amount / _gbpRate;
                    break;
                case "JPY":
                    baseValue = amount / _jpyRate;
                    break;
                default:
                    throw new ArgumentException($"Unsupported currency: {currentAccount.Currency}");
            }

            switch (receivingAccount.Currency)
            {
                case "SEK":
                    return baseValue * _sekRate;

                case "USD":
                    return baseValue * _usdRate;

                case "EURO":
                    return baseValue * _euroRate;

                case "GBP":
                    return baseValue * _gbpRate;

                case "JPY":
                    return baseValue * _jpyRate;

                default:
                    throw new ArgumentException($"Unsupported currency: {receivingAccount.Currency}");
            }
        }
        public double SEKRate
        {
            get { return _sekRate; }
            set { _sekRate = value;  }
        }
        public double USDRate
        {
            get { return _usdRate; }
            set { _usdRate = value;  }
        }
        public double EuroRate
        {
            get { return _euroRate; }
            set { _euroRate = value;  }
        }
        public double GBPRate
        {
            get { return _gbpRate; }
            set { _gbpRate = value;  }
        }
        public double JPYRate
        {
            get { return _jpyRate; }
            set { _jpyRate = value;  }
        }
    }
}
