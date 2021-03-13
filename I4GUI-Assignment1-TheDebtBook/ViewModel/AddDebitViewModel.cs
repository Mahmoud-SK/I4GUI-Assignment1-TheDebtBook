using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;

namespace I4GUI_Assignment1_TheDebtBook
{

    class AddDebitViewModel: BindableBase
    {
        private Debtor currentDebtor;

        public AddDebitViewModel(Debtor debtor)
        {
            currentDebtor = debtor;
        }

        public Debtor CurrentDebtor
        {
            get
            {
                return currentDebtor;
            }
            set
            {
                SetProperty(ref currentDebtor, value);
            }
        }

        private ICommand _addDebitCommand;

        public ICommand AddDebitCommand
        {
            get
            {
                return _addDebitCommand ?? (_addDebitCommand =
                    new DelegateCommand<string>(AddDebitCommand_Execute, AddDebitCommand_CanExecute));
            }
        }

        public void AddDebitCommand_Execute(string value)
        {
            Debit newDebit = new Debit(int.Parse(value), DateTime.Now.Date);
            currentDebtor.Debits.Add(newDebit);
        }

        public bool AddDebitCommand_CanExecute(string value)
        {
            return int.TryParse(value,out _);
        }
    }
}
