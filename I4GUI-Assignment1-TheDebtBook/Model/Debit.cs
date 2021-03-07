using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I4GUI_Assignment1_TheDebtBook.Model
{
    public class Debit
    {
        private int amount;
        private string date;

        public Debit()
        {
        }

        public Debit(int dAmount, string dDate)
        {
            amount = dAmount;
            date = dDate;
        }

        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }

        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }

    }
}
