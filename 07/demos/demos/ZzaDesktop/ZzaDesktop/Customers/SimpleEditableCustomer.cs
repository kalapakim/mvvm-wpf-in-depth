using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ZzaDesktop.Customers
{
    public class SimpleEditableCustomer : ValidatableBindableBase
    {
        private Guid _id;

        public Guid Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _firstName;
        [Required]
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        private string _lastName;
        [Required]
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        private string _email;
        [EmailAddress]
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private string _phone;
        [Phone]
        public string Phone
        {
            get { return _phone; }
            set { SetProperty(ref _phone, value); }
        }


    }

}
