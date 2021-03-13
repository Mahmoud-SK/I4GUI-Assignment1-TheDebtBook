using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace I4GUI_Assignment1_TheDebtBook
{
    class AddDebtorViewModel : BindableBase
    {
        private Debtor newDebtor;

        public AddDebtorViewModel(Debtor debtor)
        {
            newDebtor = debtor;
        }

        public Debtor NewDebtor
        {
            get
            {
                return newDebtor;
            }   
            set
            {
                SetProperty(ref newDebtor, value);
            }
        }

        public bool IsValid
        {
            get
            {
                bool isValid = true;
                if (string.IsNullOrWhiteSpace(NewDebtor.Name))
                    isValid = false;
                return isValid;
            }
        }
    }


}
