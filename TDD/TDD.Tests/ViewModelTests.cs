using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Tests
{
    [TestFixture]
    public class ViewModelTests
    {
        ISlotRepository sub_slot;

        [SetUp]
        public void Setup()
        {
            sub_slot = Substitute.For<ISlotRepository>();
        }

        [Test]
        public void Add2EuroCommand_Adds2EuroToBudget()
        {
            // Arrange
            ViewModel sut = new ViewModel(sub_slot);
            sut.Budget = 1;

            // Act
            sut.Add2EuroCommand.Execute(null);

            // Assert
            Assert.That(sut.Budget, Is.EqualTo(3));
        }

        [Test]
        public void Add1EuroCommand_Adds1EuroToBudget()
        {
            // Arrange
            ViewModel sut = new ViewModel(sub_slot);
            sut.Budget = 1;

            // Act
            sut.Add1EuroCommand.Execute(null);

            // Assert
            Assert.That(sut.Budget, Is.EqualTo(2));
        }

        [Test]
        public void Budget_Changed_OnPropertyChangedIsCalled()
        {
            // Arrange
            ViewModel sut = new ViewModel(sub_slot);
            string changedProperty = "";
            sut.PropertyChanged += (e, args) =>
            {
                changedProperty = args.PropertyName;
            };

            // Act
            sut.Budget = 5;

            // Assert
            Assert.That(changedProperty, Is.EqualTo("Budget"));
        }

        [Test]
        public void RefundCommand_WithBudget5_BudgetBecomesZero()
        {
            // Arrange
            ViewModel sut = new ViewModel(sub_slot);
            sut.Budget = 5;

            // Act
            sut.RefundCommand.Execute(null);

            // Assert
            Assert.That(sut.Budget, Is.EqualTo(0));
        }

        [Test]
        public void Ctor_WithNoItems_CreatesEmptyList()
        {
            // Arrange

            // Act
            ViewModel sut = new ViewModel(sub_slot);

            // Assert
            Assert.That(sut.Slots, Is.EqualTo(new List<Slot>()));
        }

        [Test]
        public void Ctor_WithItems_FillsList()
        {
            // Arrange
            List<Slot> slots = new List<Slot>()
            {
                new Slot("cola", 2.2, 2, 5),
                new Slot("water", 1.5, 4, 4)
            };
            // stub nagebootst die altijd de list slots returned
            sub_slot.GetAllSlots().Returns(slots);

            // Act
            ViewModel sut = new ViewModel(sub_slot);

            // Assert
            Assert.That(sut.Slots, Is.EqualTo(slots));
        }

        [Test]
        public void TestVoorRepositories()
        {
            // Arrange
            // link met de database
            //ViewModel sutWithDatabaseConnection = new ViewModel();

            ISlotRepository substitute = Substitute.For<ISlotRepository>();
            ViewModel sutWithoutDatabaseConnection = new ViewModel(substitute);

            // Act

            // Assert
        }

        // Laatste requirement: Drankje kopen
        // Slot kiezen
        // Koop commando
        // Budget gaan controleren
        [Test]
        public void BuyCommand_WithEnoughMoneyAndValidSlot_RemovesOneItemFromInventoryAndBudgetAdjusted()
        {
            // Arrange
            List<Slot> beforeBuy = new List<Slot>()
            {
                new Slot("cola", 2.2, 3, 5)
            };
            List<Slot> afterBuy = new List<Slot>()
            {
                new Slot("cola", 2.2, 3, 4)
            };
            sub_slot.GetAllSlots().Returns(beforeBuy);
            ViewModel sut = new ViewModel(sub_slot);
            sut.Budget = 5;
            sut.SelectedSlot = 3;

            // Act
            sut.BuyCommand.Execute(null);

            // Assert
            sub_slot.Received(1).UpdateSlot(Arg.Any<Slot>());
            Assert.That(sut.Slots, Is.EqualTo(afterBuy));
            Assert.That(sut.SelectedSlot, Is.EqualTo(null));
            Assert.That(sut.Budget, Is.EqualTo(2.8));
        }

        // een test toevoegen dat een foutboodschap toont als slot niet gevonden wordt
        [Test]
        public void BuyCommand_WithInvalidSelectedSlot_ShowsErrorMessageAndNothingChanged()
        {
            // Arrange
            List<Slot> beforeBuy = new List<Slot>()
            {
                new Slot("cola", 2.2, 3, 5)
            };
            sub_slot.GetAllSlots().Returns(beforeBuy);
            ViewModel sut = new ViewModel(sub_slot);
            sut.Budget = 5;
            sut.SelectedSlot = 7;

            // Act
            sut.BuyCommand.Execute(null);

            // Assert
            sub_slot.DidNotReceive().UpdateSlot(Arg.Any<Slot>());
            Assert.That(sut.Slots, Is.EqualTo(beforeBuy));
            Assert.That(sut.SelectedSlot, Is.EqualTo(null));
            Assert.That(sut.Budget, Is.EqualTo(5));
            Assert.That(sut.Message, Is.EqualTo("Invalid Slot"));
        }
    }
}
