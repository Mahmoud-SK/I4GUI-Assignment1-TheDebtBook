using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I4GUI_Assignment1_TheDebtBook
{
	public class Debtor : BindableBase
	{
		public Debtor() { }

		public Debtor(string name, double startValue)
		{
			Name = name;
			CurrentDebt = startValue;
		}

		private string name_;
		public string Name
		{
			get
			{
				return name_;
			}
			set
			{
				SetProperty(ref name_, value);
			}
		}
		private double currentDebt_;

		public double CurrentDebt
		{
			get
			{
				return currentDebt_;
			}
			set
			{
				SetProperty(ref currentDebt_, value);
			}
		}

	}
}
