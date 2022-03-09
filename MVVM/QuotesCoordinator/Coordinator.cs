using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuotesCoordinator
{
    public interface ICoordinator
    {
        void ShowDialog(string text);

        void ShowMainWindow();

        void ShowAddQuoteWindow();
    }
    // we willen nu dat er gestart wordt vanuit de coordinator
    // en niet meer vanaf de mainwindow.xaml
    // dit kan je instellen in de app.xaml
        // verwijder startupuri
    // in app.xaml.cs
        // maak constructor aan, waarin je de coordinator aanmaakt en toon het main window

    public class Coordinator: ICoordinator
    {
        public void ShowDialog(string text)
        {
            MessageBox.Show(text);
        }

        public void ShowMainWindow()
        {
            MainWindow window = new MainWindow();
            MainViewModel viewModel = new MainViewModel(this, window);
            window.DataContext = viewModel;

            window.Show();
        }

        public void ShowAddQuoteWindow()
        {
            AddQuoteWindow window = new AddQuoteWindow();
            AddQuoteViewModel viewModel = new AddQuoteViewModel(this, window);
            window.DataContext = viewModel;
            
            window.ShowDialog();
        }
    }
}
