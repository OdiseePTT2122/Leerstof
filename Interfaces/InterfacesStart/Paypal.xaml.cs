using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using InterfacesStart;

namespace Interfaces
{
    /// <summary>
    /// Interaction logic for Paypal.xaml
    /// </summary>
    public partial class Paypal : Window, IPayWindow
    {
        private bool _paypalPaymentSucceeded = false; 
        public bool PaymentSucceeded => _paypalPaymentSucceeded;

        public string PaymentSucceededMessage => "Paypal payment succeeded";

        public string PaymentFailedMessage => "Paypal payment failed";

        public Paypal()
        {
            InitializeComponent();
        }

        public void payButton_Click(object sender, RoutedEventArgs e)
        {
            _paypalPaymentSucceeded = true;
            Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void OpenPaymentScreen()
        {
            ShowDialog();
        }
    }
}
