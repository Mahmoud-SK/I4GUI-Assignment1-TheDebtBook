using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace I4GUI_Assignment1_TheDebtBook.View
{
    /// <summary>
    /// Interaction logic for AddDebtorWindow.xaml
    /// </summary>
    public partial class AddDebtorWindow : Window
    {
        public AddDebtorWindow()
        {
            InitializeComponent();
        }

        private void txb3_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as AddDebtorViewModel;
            if (vm.IsValid)
                DialogResult = true;
            else
                MessageBox.Show("Enter name and initial value","Missing data");
        }
    }
}
