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
using System.Windows.Navigation;
using System.Windows.Shapes;
using InterfacesStart;

namespace Interfaces
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            List<StockItem> stockItems = new List<StockItem>()
            {
                new StockItem("Brood", 2.5),
                new StockItem("Hesp", 3),
                new StockItem("Kaas", 2.10),
                new StockItem("Wijn", 7.85),
                new StockItem("Melk", 2)
            };

            stockListBox.ItemsSource = stockItems;
        }


        private void stockListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (stockListBox.SelectedItem != null)
            {
                var item = (StockItem)stockListBox.SelectedItem;
                List<StockItem> items = (List<StockItem>)stockListBox.ItemsSource;
                items.Remove(item);
                stockListBox.ItemsSource = null;
                stockListBox.ItemsSource = items;
                orderListBox.Items.Add(item);
                SetTotalAmount();
            }
        }

        private void SetTotalAmount()
        {
            double totalAmount = 0;
            foreach (StockItem item in orderListBox.Items)
            {
                totalAmount += item.Price;
            }

            totalAmountLabel.Content = totalAmount;
        }

        private void payButton_Click(object sender, RoutedEventArgs e)
        {
            // Implementeer deze knop zodanig dat het juiste scherm getoond wordt.
            // open het correcte scherm (paypol, bancontact of visa)
            // Toon in message box of het gelukt is.

            // deze oplossing vermijd een hele hoop copy-pase code
            // verkleint het aantal lijnen code
            // maar ook de kans op fouten/bugs
            // verplicht de verschillende methoden om dezelfde flow te hebben
            IPayWindow payWindow = null;
            if(visaRadioButton.IsChecked == true)
            {
                payWindow = new Visa();
            } else if(paypalRadioButton.IsChecked == true)
            {
                payWindow= new Paypal();
            } else if(bancontactRadioButton.IsChecked == true)
            {
                payWindow = new Bancontact();
            }else
            {
                return;
            }

            // objecten met een zelfde interface kan je in een gemeenschappelijk lijstje bijhouden
            List<IPayWindow> list = new List<IPayWindow>() { 
                new Visa(), 
                new Bancontact(),
                new Paypal() 
            };

            // je kan wel enkel maar aan de properties/methoden gedefinieerd in de interface
            //payWindow = new Paypal();

            payWindow.OpenPaymentScreen();
            if (payWindow.PaymentSucceeded)
            {
                MessageBox.Show(payWindow.PaymentSucceededMessage);
            } else
            {
                MessageBox.Show(payWindow.PaymentFailedMessage);
            }
            /*
            if(visaRadioButton.IsChecked == true)
            {
                Visa visaPaymentScreen = new Visa();
                // dit toont het payment screen in een popup
                visaPaymentScreen.ShowDialog();
                // controleer of de betaling gelukt is
                if (visaPaymentScreen.PaymentSucceeded)
                {
                    // toont een messagebox met het resultaat
                    MessageBox.Show("Visa payment succeeded");
                }
                else
                {
                    MessageBox.Show("Payment failed");
                }

            } else if(paypalRadioButton.IsChecked == true)
            {
                Paypal paymentScreen = new Paypal();
                // dit toont het payment screen in een popup
                paymentScreen.ShowDialog();
                // controleer of de betaling gelukt is
                if (paymentScreen.PaymentSucceeded)
                {
                    // toont een messagebox met het resultaat
                    MessageBox.Show("Paypal payment succeeded");
                }
                else
                {
                    MessageBox.Show("Payment failed");
                }
            } else if (bancontactRadioButton.IsChecked == true)
            {
                Bancontact banccontact = new Bancontact();
                // dit toont het payment screen in een popup
                banccontact.ShowDialog();
                // controleer of de betaling gelukt is
                if (banccontact.PaymentSucceeded)
                {
                    // toont een messagebox met het resultaat
                    MessageBox.Show("Bancontact payment succeeded");
                }
                else
                {
                    MessageBox.Show("Payment failed");
                }
            }*/
        }
    }
}
