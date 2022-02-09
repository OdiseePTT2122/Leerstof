using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests
{
    [TestFixture]
    internal class CustomerTests
    {
        private Store store;
        private Customer sut;
        private int q_store_start;
        private int q_purchase;
        private Product product;

        // factory methoden
        public Store createStore(Product product, int quantity)
        {
            Store store = new Store();

            store.AddInventory(product, quantity);

            return store;
        }

        public void createSetup(int purchase_amount)
        {
            q_store_start = 5;
            q_purchase = purchase_amount;
            product = Product.Bread;

            store = new Store();
            store.AddInventory(product, q_store_start);

            sut = new Customer();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // deze functie gebeurt maar 1 keer voor alle testen
            // deze data hier wordt gedeeld door alle testen
            //createSetup(1);
        }

        [SetUp]
        public void Setup()
        {
            // deze functie gebeurt elke test opnieuw
            // initialisatie van de data reset na de test
            // veel veiliger om geen beinvloeding te hebben van testen onderling
            createSetup(1);
        }

        // Teardown gebeurt na ELKE test
        [TearDown]
        public void TearDown()
        {

        }

        [OneTimeTearDown]
        public void TearDownOneTime()
        {
            // omgekeerde OneTimeSetUp
            // na ALLE testen eenmalig
        }

        //Test in comment to disable them
        //[Test]
        public void Purchase_StoreEmpty_ReturnFalse()
        {
            //Arrange
            Customer sut = new Customer();
            Store store = new Store();

            //Act
            bool result = sut.Purchase(store, Product.Shampoo, 5);

            //Assert
            Assert.IsFalse(result);
        }

        //Test in comment to disable them
        //[Test]
        public void Purchase_StoreHasProduct_ReturnTrueAndAddedToBasket()
        {
            //Arrange
            //Store store = new Store();
            
            //store.AddInventory(product, q_store_start);

            //Arrange met factory
            //createStore(product, q_store_start);
            createSetup(3);
            
            //Act
            bool result = sut.Purchase(store, product, q_purchase);

            //Assert
            Assert.IsTrue(result);
            Assert.That(store.GetInventory(product), Is.EqualTo(q_store_start - q_purchase));
            Assert.That(sut.Basket[product], Is.EqualTo(q_purchase));
        }

        [Test]
        public void Purchase_OneTimeSetup_Test1()
        { 
            //Act
            bool result = sut.Purchase(store, product, q_purchase);

            //Assert
            Assert.IsTrue(result);
            Assert.That(store.GetInventory(product), Is.EqualTo(q_store_start - q_purchase));
            Assert.That(sut.Basket[product], Is.EqualTo(q_purchase));
        }

        [Test]
        public void Purchase_OneTimeSetup_Test2()
        {
            // net dezelfde code
            //Act
            bool result = sut.Purchase(store, product, q_purchase);

            //Assert
            Assert.IsTrue(result);
            Assert.That(store.GetInventory(product), Is.EqualTo(q_store_start - q_purchase));
            Assert.That(sut.Basket[product], Is.EqualTo(q_purchase));
        }

    }
}
