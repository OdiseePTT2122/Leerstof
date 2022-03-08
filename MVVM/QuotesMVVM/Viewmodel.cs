using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuotesMVVM
{
    public class Viewmodel: INotifyPropertyChanged
    {
        private string auteur = "";
        public string Auteur { get => auteur; set
            {
                auteur = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Auteur"));
            }
        }

        private string tekst = "";
        public string Tekst { get => tekst; set
            {
                tekst = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Tekst"));
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
    }
}
