using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I4GUI_Assignment1_TheDebtBook
{
	public class Debtor : BindableBase
	{

		private ObservableCollection<Debit> debits;
		public Debtor()
		{

		}

		public Debtor(string name, int startValue)
		{
			Name = name;
			currentDebt = startValue;
		}

		private string name;

		public string Name
		{
			get 
			{
				return name;
			}
			set
			{
				SetProperty(ref name, value);
			}
		}

		private int currentDebt;

		public int CurrentDebt
		{
			get
			{
				return currentDebt;
			}
			set
			{
				SetProperty(ref currentDebt, value);
			}
		}

		public ObservableCollection<Debit> Debits
		{
			get { return debits; }
			set
			{
				if (debits != value)
				{
					SetProperty(ref debits, value);
				}
			}
		}

	}
}
