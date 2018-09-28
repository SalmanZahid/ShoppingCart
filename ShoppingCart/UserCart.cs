using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart
{
    public sealed class UserCart
    {
        private static List<Item> _items;

        public List<Item> Items { get { return _items; } }

        public UserCart()
        {
            _items = new List<Item>();
        }
        
        public void AddItem(Item item)
        {
            item.TotalPrice = item.Quantity * item.Price;
            _items.Add(item);
        }   

        public int TotalPrice()
        {
            return _items.Sum(x => x.TotalPrice);
        }

        public void ApplyDiscounts(List<Discount> discounts)
        {
            foreach (var discount in discounts)
            {
                var item = _items.FirstOrDefault(x => x.ProductName == discount.Product);
                int totalQuantity = item.Quantity; // TOTAL QUANTITY
                int pricePerProduct = item.Price; // PRICE PER PRODUCT

                int totalDiscountedItems = totalQuantity / discount.Threshold; // NUMBER OF ITEMS TO APPLY DISCOUNTS ON
               
                double priceAfterDiscount =  pricePerProduct - ((discount.Percentage / 100.0) * pricePerProduct); // NEW DISCOUNTED PRICE
              
                int totalPriceOfNonDiscountedItems = ((totalQuantity - totalDiscountedItems) * pricePerProduct);
                int totalPriceOfDiscountedItems = (int)(totalDiscountedItems * priceAfterDiscount);

                // CALCULATE NOW LATEST TOTAL PRICE AFTER APPLYING DISCOUNT
                item.TotalPrice = totalPriceOfNonDiscountedItems + totalPriceOfDiscountedItems;                     
            }
        }
    }
}
