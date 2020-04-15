using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
