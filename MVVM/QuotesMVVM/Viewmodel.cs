using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuotesMVVM
{
    // Uitgevoerde stappen
    // 1. Aanmaken deze klasse en connecteer het vanuit het Mainwindow.xaml.cs
    // 2. Verzorg databinding tussen UI-elementen en public properties in het Viewmodel
    // 3. Bij het drukken op knoppen, etc worden commando's verstuurd
        // 3.A. Command binden met het commando in het viewmodel
        // 3.B. RelayCommand klasse maken (implementeert ICommand / gedeeld door alle Command-klassen)
        // 3.C. Voor elke UI-element commando verstuurt maak je zo een Command aan (argument is de functie die het event afhandeld)
    // 4. Zorg ervoor dat de UI notificaties krijgt om zijn updates door te sturen
        // 4.A. List -> Observable Collection
        // 4.B. Update inhoud van de textboxjes als de waarde van de public properties aangepast wordt.

    public class Viewmodel: INotifyPropertyChanged
    {
        private string auteur = "";
        public string Auteur { get => auteur; set
            {
                auteur = value;
                //PropertyChanged(this, new PropertyChangedEventArgs("Auteur"));
                OnPropertyChanged();
            }
        }

        private string tekst = "";
        public string Tekst { get => tekst; set
            {
                tekst = value;
                //PropertyChanged(this, new PropertyChangedEventArgs("Tekst"));
                OnPropertyChanged();
            }
        }

        public Quote SelectedQuote { set
            {
                SelectionChanged(value);
            }
        }

        public ObservableCollection<Quote> Quotes { get; set;}

        public ICommand SaveQuoteCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Viewmodel()
        {
            Quotes = new ObservableCollection<Quote>();

            SaveQuoteCommand = new RelayCommand(SaveQuote);
        }


        private void SaveQuote()
        {
            Quote q = new Quote(Tekst, Auteur);
            Quotes.Add(q);
        }

        private void SelectionChanged(Quote quote)
        {
            Auteur = quote.Author;
            Tekst = quote.Text;
        }

        // CallerMemberName -> hier wordt automatisch de naam van de functie die het oproept ingeplaatst
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
