using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I4GUI_Assignment1_TheDebtBook
{
    public class Debit
    {
        private int amount;
        private DateTime date;

        public Debit()
        {
        }

        public Debit(int dAmount, DateTime dDate)
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

        public DateTime Date
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
