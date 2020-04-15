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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Zza.Data;

namespace MVVMCommsDemo.Customers
{
    /// <summary>
    /// Interaction logic for CustomerListView.xaml
    /// </summary>
    public partial class CustomerListView : UserControl
    {
        public CustomerListView()
        {
            InitializeComponent();
        }

        private void OnChangeCustomer(object sender, RoutedEventArgs e)
        {
            var cust = customerDataGrid.SelectedItem as Customer;
            cust.FirstName = "Changed in background";

        }
    }
}
