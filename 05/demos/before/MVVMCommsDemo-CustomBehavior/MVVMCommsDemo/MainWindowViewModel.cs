using System;
using System.ComponentModel;
using System.Linq;
using MVVMCommsDemo.Customers;

namespace MVVMCommsDemo
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            CurrentViewModel = new CustomerListViewModel();
        }
        public object CurrentViewModel { get; set; }

    }
}
