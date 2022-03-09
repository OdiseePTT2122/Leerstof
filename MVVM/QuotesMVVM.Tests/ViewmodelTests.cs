using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesMVVM.Tests
{
    [TestFixture]
    internal class ViewmodelTests
    {
        [Test]
        public void SelectedQuote_ItemSelected_AuteurEnTekstAangepast()
        {
            // Arrange
            Viewmodel sut = new Viewmodel();
            Quote quote = new Quote("tekst", "auteur");

            // Act
            sut.SelectedQuote = quote;

            // Assert
            Assert.That(sut.Auteur, Is.EqualTo("auteur"));
            Assert.That(sut.Tekst, Is.EqualTo("tekst"));
        }

        [Test]
        public void Auteur_Changed_NotifyEventSend()
        {
            // Arrange
            Viewmodel sut = new Viewmodel();
            string property = "";
            // dit is onze eigen event handler
            sut.PropertyChanged += (sender, eventargs) =>
            {
                property = eventargs.PropertyName; 
            };

            // Act
            sut.Auteur = "auteur";

            // Assert
            Assert.That(property, Is.EqualTo("Auteur"));
        }

        [Test]
        public void Tekst_Changed_NotifyEventSend()
        {
            // Arrange
            Viewmodel sut = new Viewmodel();
            string property = "";
            // dit is onze eigen event handler
            sut.PropertyChanged += (sender, eventargs) =>
            {
                property = eventargs.PropertyName;
            };

            // Act
            sut.Tekst = "auteur";

            // Assert
            Assert.That(property, Is.EqualTo("Tekst"));
        }

        [Test]
        public void SaveQuoteCommand_WithAuthorEnTekstIngevuld_AddNewItem()
        {
            // Arrange
            Viewmodel sut = new Viewmodel();
            sut.Auteur = "auteur";
            sut.Tekst = "tekst";

            // Act
            sut.SaveQuoteCommand.Execute(null);

            // Assert
            Assert.That(sut.Quotes.Count, Is.EqualTo(1));
            Assert.That(sut.Quotes[0].Text, Is.EqualTo("tekst"));
            Assert.That(sut.Quotes[0].Author, Is.EqualTo("auteur"));
        }
    }
}
