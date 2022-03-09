using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuotesCoordinator
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private IQuoteRepository quoteRepository;
        private ICoordinator coordinator;
        private ICloseable view;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddNewQuoteCommand { get; private set; }

        private List<Quote> quotes = new List<Quote>();
        public List<Quote> Quotes { get => quotes; set
            {
                quotes = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(ICoordinator coordinator, ICloseable view)
            : this(coordinator, view, new QuoteRepository())
        {

        }

        public MainViewModel(ICoordinator coordinator, ICloseable view, IQuoteRepository quoteRepository)
        {
            this.quoteRepository = quoteRepository;
            this.coordinator = coordinator;
            this.view = view;

            AddNewQuoteCommand = new RelayCommand(AddNewQuote);

            Quotes = new List<Quote>();

            Load();
        }

        public void AddNewQuote()
        {
            // open het andere schermpje
            coordinator.ShowAddQuoteWindow();
            Load();
        }

        public void Load()
        {
            Quotes = quoteRepository.GetAllQuotes();
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
