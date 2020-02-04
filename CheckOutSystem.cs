using System.Collections.Generic;

namespace CheckOutSystemTest
{
    public class CheckOutSystem
    {
        private decimal _total;

        public decimal CheckOut(List<Item> listOfItems)
        {
            foreach (var item in listOfItems) _total += item.Price;
            return _total;
        }
    }
}