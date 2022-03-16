using System.Collections.Generic;

namespace TDD
{
    public interface ISlotRepository
    {
        List<Slot> GetAllSlots();
        void AddSlot(Slot slot);
        void RemoveSlot(Slot slot);
        void UpdateSlot(Slot slot);
    }
}