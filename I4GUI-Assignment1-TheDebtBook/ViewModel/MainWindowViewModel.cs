﻿using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;

namespace I4GUI_Assignment1_TheDebtBook
{
	class MainWindowViewModel : BindableBase
	{
		private ObservableCollection<Debtor> debtors;
		private Debtor currentDebtor = null;
		private string filepath = "";
		private string filename = "";

		public MainWindowViewModel()
		{
			debtors = new ObservableCollection<Debtor>();
			debtors.Add(new Debtor("Lars",2000));
			debtors.Add(new Debtor("Morten", 1500));
			debtors.Add(new Debtor("Nikolaj", 1000));
			debtors.Add(new Debtor("Yuhu", 3000));
		}

		#region Properties

		public ObservableCollection<Debtor> Debtors
		{
			get { return debtors; }
			set { SetProperty(ref debtors, value); }
		}

		public Debtor CurrentDebtor
		{
			get { return currentDebtor; }
			set
			{
				SetProperty(ref currentDebtor, value);
			}
		}

		int currentIndex = -1;
		public int CurrentIndex
		{
			get { return currentIndex; }
			set
			{
				SetProperty(ref currentIndex, value);
			}
		}
		#endregion

		#region Commands
		ICommand _SaveAsCommand;
		public ICommand SaveAsCommand
		{
			get { return _SaveAsCommand ?? (_SaveAsCommand = new DelegateCommand<string>(SaveAsCommand_Execute)); }
		}

		private void SaveAsCommand_Execute(string argFilename)
		{
			var dialog = new SaveFileDialog();

			dialog.Filter = "Debtor/Creditor documents|*.tdb|All Files|*.*";
			dialog.DefaultExt = "tdb";
			if (filepath == "")
				dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			else
				dialog.InitialDirectory = Path.GetDirectoryName(filepath);

			if (dialog.ShowDialog(App.Current.MainWindow) == true)
			{
				filepath = dialog.FileName;
				filename = Path.GetFileName(filepath);
				SaveFile();
			}
		}

		private void SaveFile()
		{
			try
			{
				Repository.SaveFile(filepath, Debtors);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Unable to save file", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		ICommand _SaveCommand;
		public ICommand SaveCommand
		{
			get
			{
				return _SaveCommand ?? (_SaveCommand = new DelegateCommand(SaveFileCommand_Execute, SaveFileCommand_CanExecute)
				  .ObservesProperty(() => debtors.Count));
			}
		}

		private void SaveFileCommand_Execute()
		{
			// Create an instance of the XmlSerializer class and specify the type of object to serialize.
			XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Debtor>));
			TextWriter writer = new StreamWriter(filename);
			// Serialize all the agents.
			serializer.Serialize(writer, Debtors);
			writer.Close();
		}

		private bool SaveFileCommand_CanExecute()
		{
			return (filename != "") && (Debtors.Count > 0);
		}

		ICommand _NewFileCommand;
		public ICommand NewFileCommand
		{
			get { return _NewFileCommand ?? (_NewFileCommand = new DelegateCommand(NewFileCommand_Execute)); }
		}

		private void NewFileCommand_Execute()
		{
			MessageBoxResult res = MessageBox.Show("Any unsaved data will be lost. Are you sure you want to initiate a new file?", "Warning",
				MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
			if (res == MessageBoxResult.Yes)
			{
				Debtors.Clear();
				filename = "";
			}
		}


		ICommand _OpenFileCommand;
		public ICommand OpenFileCommand
		{
			get { return _OpenFileCommand ?? (_OpenFileCommand = new DelegateCommand<string>(OpenFileCommand_Execute)); }
		}

		private void OpenFileCommand_Execute(string argFilename)
		{
			var dialog = new OpenFileDialog();

			dialog.Filter = "Debtor/Creditor documents|*.tdb|All Files|*.*";
			dialog.DefaultExt = "tdb";
			if (filepath == "")
				dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			else
				dialog.InitialDirectory = Path.GetDirectoryName(filepath);

			if (dialog.ShowDialog(App.Current.MainWindow) == true)
			{
				filepath = dialog.FileName;
				filename = Path.GetFileName(filepath);
				try
				{
					ObservableCollection<Debtor> tempDebtors;
					Repository.ReadFile(filepath, out tempDebtors);
					Debtors = tempDebtors;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Unable to open file", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
		}
		#endregion
	}
}
