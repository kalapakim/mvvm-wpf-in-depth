using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;
using ZzaDesktop.Services;

namespace ZzaDesktop.Customers
{
    class AddEditCustomerViewModel : BindableBase
    {
        private ICustomersRepository _repo;

        public AddEditCustomerViewModel(ICustomersRepository repo)
        {
            _repo = repo;
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave, CanSave);
        }

        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        public event Action Done = delegate { };

        private bool _EditMode;

        public bool EditMode
        {
            get { return _EditMode; }
            set { SetProperty(ref _EditMode, value); }
        }

        private SimpleEditableCustomer _Customer;

        public SimpleEditableCustomer Customer
        {
            get { return _Customer; }
            set { SetProperty(ref _Customer, value); }
        }


        private Customer _editingCustomer = null;

        public void SetCustomer(Customer cust)
        {
            _editingCustomer = cust;
            if (Customer != null) Customer.ErrorsChanged -= RaiseCanExecuteChanged;
            Customer = new SimpleEditableCustomer();
            Customer.ErrorsChanged += RaiseCanExecuteChanged;
            CopyCustomer(cust, Customer);
        }

        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        private void CopyCustomer(Customer source, SimpleEditableCustomer target)
        {
            target.Id = source.Id;
            if (EditMode)
            {
                target.FirstName = source.FirstName;
                target.LastName = source.LastName;
                target.Phone = source.Phone;
                target.Email = source.Email;
            }
        }

        private void OnCancel()
        {
            Done();
        }

        private async void OnSave()
        {
            UpdateCustomer(Customer, _editingCustomer);
            if (EditMode)
                await _repo.UpdateCustomerAsync(_editingCustomer);
            else
                await _repo.AddCustomerAsync(_editingCustomer);
            Done();
        }

        private void UpdateCustomer(SimpleEditableCustomer source, Customer target)
        {
            target.FirstName = source.FirstName;
            target.LastName = source.LastName;
            target.Phone = source.Phone;
            target.Email = source.Email;
        }

        bool CanSave()
        {
            return !Customer.HasErrors;
        }
    }
}
