using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using MVVMCommsDemo.Services;
using Zza.Data;

namespace MVVMCommsDemo.Customers
{
    public class CustomerListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Customer> _customers;
        private ICustomersRepository _repository = new CustomersRepository();
        
        public CustomerListViewModel()
        {
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
                if (_customers != value)
                {
                    _customers = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Customers"));
                }
            }
        }

        private Customer _selectedCustomer;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public Customer SelectedCustomer
        {
            get
            {
                return _selectedCustomer;
            }
            set
            {
                if (_selectedCustomer != value)
                {
                    _selectedCustomer = value;
                    DeleteCommand.RaiseCanExecuteChanged();
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedCustomer"));
                }
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

        public async void LoadCustomers()
        {
            if (DesignerProperties.GetIsInDesignMode(
                new System.Windows.DependencyObject())) return;

            Customers = new ObservableCollection<Customer>(await _repository.GetCustomersAsync());

        }

    }
}
