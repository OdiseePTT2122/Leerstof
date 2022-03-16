using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TDD
{
    public class ViewModel: INotifyPropertyChanged
    {
        private ISlotRepository slotRepository;

        private double budget;
        public double Budget {
            get => budget;
            set
            {
                budget = value;
                OnPropertyChanged();
            }
        }

        public int? SelectedSlot { get; set; }

        public List<Slot> Slots { get; set; }
        public string Message { get; set; }

        public ICommand Add2EuroCommand { get; set; }
        public ICommand Add1EuroCommand { get; set; }
        public ICommand RefundCommand { get; set; }
        public ICommand BuyCommand { get; set; }
        public ViewModel()
            : this(new SlotRepository())
        {
        }

        public ViewModel(ISlotRepository slotRepository)
        {
            this.slotRepository = slotRepository;
            Add2EuroCommand = new RelayCommand(Add2Euro);
            Add1EuroCommand = new RelayCommand(Add1Euro);
            RefundCommand = new RelayCommand(Refund);
            BuyCommand = new RelayCommand(Buy);

            Slots = this.slotRepository.GetAllSlots();
            if(Slots == null)
            {
                Slots = new List<Slot>();  
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Add2Euro()
        {
            Budget += 2;
        }
        public void Add1Euro()
        {
            Budget += 1;
        }
        public void Refund()
        {
            Budget = 0;
        }
        public void Buy()
        {
            List<Slot> slotsOnNumber= Slots.Where(x=>x.SlotNumber == SelectedSlot).ToList();

            SelectedSlot = null;

            if (slotsOnNumber.Count() != 1)
            {
                Message = "Invalid Slot";
                return;
            }

            Slot slot = slotsOnNumber.First();

            slot.Quantity -= 1;
            Budget -= slot.Price;

            slotRepository.UpdateSlot(slot);
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
