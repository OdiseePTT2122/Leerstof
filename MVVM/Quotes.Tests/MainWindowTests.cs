using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Quotes.Tests
{
    [TestFixture]
    [RequiresThread(ApartmentState.STA)]
    public class MainWindowTests
    {
        [Test]
        public void Ctor__LoadData()
        {
            // Arrange
            IQuoteRepository quoteRepository = Substitute.For<IQuoteRepository>();
            quoteRepository.GetAllQuotes().Returns(new List<Quote>());

            // Act
            MainWindow mainWindow = new MainWindow(quoteRepository);

            // Assert
            quoteRepository.Received(1).GetAllQuotes();
        }

        [Test]
        public void quotesListBox_SelectionChanged_SelectionMinus1_ShowItem()
        {
            // Arrange
            IQuoteRepository quoteRepository = Substitute.For<IQuoteRepository>();
            quoteRepository.GetAllQuotes().Returns(new List<Quote>());
            MainWindow mainWindow = new MainWindow(quoteRepository);
            mainWindow.QuotesListBox.ItemsSource = new List<ListBoxItem>(){
                new ListBoxItem() { Content = "test", Tag = 1 },
                new ListBoxItem() { Content = "test2", Tag = 2 } };
            mainWindow.QuotesListBox.SelectedIndex = -1;
            
            // Act
            mainWindow.quotesListBox_SelectionChanged(null, null);

            // Assert
            quoteRepository.Received(1).GetAllQuotes();

            Assert.AreEqual("", mainWindow.QuoteTextBox.Text);
            Assert.AreEqual("", mainWindow.AuthorTextBox.Text);
        }
    }
}
