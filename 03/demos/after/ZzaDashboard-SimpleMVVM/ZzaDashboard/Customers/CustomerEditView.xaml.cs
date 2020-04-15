using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ZzaDashboard.Customers
{
    public partial class CustomerEditView : UserControl
    {
        public CustomerEditView()
        {
            InitializeComponent();
        }

        public Guid CustomerId
        {
            get { return (Guid)GetValue(CustomerIdProperty); }
            set { SetValue(CustomerIdProperty, value); }
        }

        public static readonly DependencyProperty CustomerIdProperty =
            DependencyProperty.Register("CustomerId", typeof(Guid), 
            typeof(CustomerEditView), new PropertyMetadata(Guid.Empty));
    }
}
