using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuotesCoordinator
{
    public class AddQuoteViewModel
    {
        public string Author { get; set; }
        public string Text { get; set; }

        private IQuoteRepository quoteRepository;
        private ICoordinator coordinator;
        private ICloseable view;

        public ICommand SaveQuoteCommand { get; private set; }

        public AddQuoteViewModel(ICoordinator coordinator, ICloseable view)
           : this(coordinator, view, new QuoteRepository())
        {

        }

        public AddQuoteViewModel(ICoordinator coordinator, ICloseable view, IQuoteRepository quoteRepository)
        {
            this.quoteRepository = quoteRepository;
            // coordinator kan je gebruiken om andere schermen te openen
            this.coordinator = coordinator;
            // view kan je gebruiken om je bijhorende window te sluiten
            this.view = view;

            SaveQuoteCommand = new RelayCommand(SaveQuote);

            Author = "";
            Text = "";
        }

        public void SaveQuote()
        {
            if(string.IsNullOrEmpty(Author) || string.IsNullOrEmpty(Text))
            {
                coordinator.ShowDialog("Vul de ontbrekende gegevens in");
            } else { 
                Quote quote = new Quote(Text, Author);
                quoteRepository.AddQuote(quote);
                view.Close();
            }
        }
    }
}
