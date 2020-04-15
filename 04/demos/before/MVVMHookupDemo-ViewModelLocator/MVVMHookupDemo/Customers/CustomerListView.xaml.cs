using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MVVMHookupDemo.Customers
{
    public partial class CustomerListView : UserControl
    {
        public CustomerListView()
        {
            this.DataContext = new CustomerListViewModel();
            InitializeComponent();
        }
    }
}
