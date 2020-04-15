using System;
using System.Collections.ObjectModel;
using System.Linq;
using Zza.Data;
using ZzaDesktop.Services;

namespace ZzaDesktop.Customers
{
    class CustomerListViewModel : BindableBase
    {
        private ICustomersRepository _repo = new CustomersRepository();

        public CustomerListViewModel()
        {
            PlaceOrderCommand = new RelayCommand<Customer>(OnPlaceOrder);
            AddCustomerCommand = new RelayCommand(OnAddCustomer);
            EditCustomerCommand = new RelayCommand<Customer>(OnEditCustomer);
        }

        private ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set { SetProperty(ref _customers, value); }
        }


        public async void LoadCustomers()
        {
            Customers = new ObservableCollection<Customer>(
                await _repo.GetCustomersAsync());
        }

        public RelayCommand<Customer> PlaceOrderCommand { get; private set; }
        public RelayCommand AddCustomerCommand { get; private set; }
        public RelayCommand<Customer> EditCustomerCommand { get; private set; }

        public event Action<Guid> PlaceOrderRequested = delegate { };
        public event Action<Customer> AddCustomerRequested = delegate { };
        public event Action<Customer> EditCustomerRequested = delegate { };

        void OnPlaceOrder(Customer cust)
        {
            PlaceOrderRequested(cust.Id);
        }

        void OnAddCustomer()
        {
            AddCustomerRequested(new Customer { Id = Guid.NewGuid() });
        }

        void OnEditCustomer(Customer cust)
        {
            EditCustomerRequested(cust);
        }
    }
}
