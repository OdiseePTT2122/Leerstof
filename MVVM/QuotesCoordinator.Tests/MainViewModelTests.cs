using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesCoordinator.Tests
{
    [TestFixture]
    internal class MainViewModelTests
    {
        [Test]
        public void AddNewQuote_CommandSend_AddNewQuoteWindowShown()
        {
            // Arrange
            IQuoteRepository quoteRepository = Substitute.For<IQuoteRepository>();
            ICloseable closeable = Substitute.For<ICloseable>();
            ICoordinator coordinator = Substitute.For<ICoordinator>();

            MainViewModel sut = new MainViewModel(coordinator, closeable, quoteRepository);

                // Act
            sut.AddNewQuoteCommand.Execute(null);

            // Assert
            coordinator.Received(1).ShowAddQuoteWindow();
            quoteRepository.Received().GetAllQuotes();
            //closeable.Received(1).Close();
        }
    }
}
