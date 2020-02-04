using System.Collections.Generic;

namespace CheckOutSystemTest
{
    public class Item
    {
        public Item(ProductName productName)
        {
            Price = GetPrice(productName);
        }

        private IDictionary<ProductName, ProductType> _productDictionary =>
            new Dictionary<ProductName, ProductType>
            {
                //Add, Remove or Update product here 
                {ProductName.Samosas, ProductType.Starter},
                {ProductName.ChickenWings, ProductType.Starter},
                {ProductName.RoastChicken, ProductType.Main},
                {ProductName.Lasagna, ProductType.Main},
                {ProductName.FishAndChips, ProductType.Main}
            };

        public decimal Price { get; set; }

        private decimal GetPrice(ProductName productName)
        {
            var productType = _productDictionary[productName];
            return productType == ProductType.Main ? 7.00m : 4.40m;
        }
    }
}