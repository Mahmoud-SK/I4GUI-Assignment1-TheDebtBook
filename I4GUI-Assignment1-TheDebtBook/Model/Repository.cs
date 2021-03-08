using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace I4GUI_Assignment1_TheDebtBook
{
	public class Repository
	{
		internal static bool ReadFile(string fileName, out ObservableCollection<Debtor> debtor)
		{
			// Create an instance of the XmlSerializer class and specify the type of object to deserialize.
			XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Debtor>));

			TextReader reader = new StreamReader(fileName);
			// Deserialize all the agents.
			debtor = (ObservableCollection<Debtor>)serializer.Deserialize(reader);
			reader.Close();

			return true;
		}

		internal static void SaveFile(string fileName, ObservableCollection<Debtor> debtor)
		{
			// Create an instance of the XmlSerializer class and specify the type of object to serialize.
			XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Debtor>));
			TextWriter writer = new StreamWriter(fileName);
			// Serialize all the agents.
			serializer.Serialize(writer, debtor);
			writer.Close();
		}
	}
}
