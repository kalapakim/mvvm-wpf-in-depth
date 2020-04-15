using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using MVVMCommsDemo.Services;
using Zza.Data;

namespace MVVMCommsDemo.Customers
{
    public class CustomerListViewModel
    {
        private ObservableCollection<Customer> _customers;
        private ICustomersRepository _repository = new CustomersRepository();
        
        public CustomerListViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(
                new System.Windows.DependencyObject())) return;

            DeleteCommand = new RelayCommand(OnDelete, CanDelete);

            Customers = new ObservableCollection<Customer>( _repository.GetCustomersAsync().Result);
        }

        public RelayCommand DeleteCommand { get; private set; }

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

        Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get
            {
                return _selectedCustomer;
            }
            set
            {
                _selectedCustomer = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }
        void OnDelete()
        {
            Customers.Remove(SelectedCustomer);
        }
        bool CanDelete()
        {
            return SelectedCustomer != null;
        }

    }
}
