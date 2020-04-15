using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZzaDesktop.Orders
{
    class OrderViewModel : BindableBase
    {
        private Guid _CustomerId;

        public Guid CustomerId
        {
            get { return _CustomerId; }
            set { SetProperty(ref _CustomerId, value); }
        }
    }
}
