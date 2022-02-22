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
    /// Interaction logic for Visa.xaml
    /// </summary>
    public partial class Visa : Window, IPayWindow
    {
        private bool _visaPaymentSucceeded = false; 
        public bool PaymentSucceeded => _visaPaymentSucceeded;

        public string PaymentSucceededMessage => "Visa payment succeeded";

        public string PaymentFailedMessage => "Visa payment failed";

        public Visa()
        {
            InitializeComponent();
        }

        private void payButton_Click(object sender, RoutedEventArgs e)
        {
            _visaPaymentSucceeded = true;
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
