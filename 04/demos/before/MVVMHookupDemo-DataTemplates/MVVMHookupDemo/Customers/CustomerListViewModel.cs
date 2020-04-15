using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMHookupDemo.Services;
using Zza.Data;

namespace MVVMHookupDemo.Customers
{
    public class CustomerListViewModel
    {
        private ObservableCollection<Customer> _customers;
        private ICustomersRepository _repository = new CustomersRepository();
        
        public CustomerListViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(
                new System.Windows.DependencyObject())) return;

            Customers = new ObservableCollection<Customer>( _repository.GetCustomersAsync().Result);
        }

        public ObservableCollection<Customer> Customers
        {
            get
            {
                return _customers;
            }
            set
            {
                _customers = value;
            }
        }
    }
}
