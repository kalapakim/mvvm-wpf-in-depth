using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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

            Customers = new ObservableCollection<Customer>( _repository.GetCustomersAsync().Result);
            DeleteCommand = new RelayCommand(OnDelete,CanDelete);

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

        private Customer _selectedCustomer;
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


        private void OnDelete()
        {
            Customers.Remove(SelectedCustomer);
        }

        private bool CanDelete()
        {
            return SelectedCustomer != null;
        }


    }
}
