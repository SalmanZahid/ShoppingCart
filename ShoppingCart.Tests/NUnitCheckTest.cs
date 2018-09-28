using NUnit.Framework;
using ShoppingCart.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Tests
{
    [TestFixture]
    public class NUnitCheckTest
    {
        [Test]
        public void GetListOfItemsInCart()
        {
            List<Item> _items = new List<Item>() {
                    new Item(){
                        ProductName = "A",
                        Price = 10
                    },
                    new Item(){
                        ProductName = "B",
                        Price = 20
                    }
                };

            var userCart = new UserCart();
            foreach (var item in _items)
            {
                userCart.AddItem(item);
            }

            Assert.IsTrue(userCart.Items.Count == 2);
        }

        [Test]
        [TestCase(30)]
        public void GetTotalPrice(int result)
        {
            List<Item> _items = new List<Item>() {
                    new Item(){
                        ProductName = "A",
                        Price = 10
                    },
                    new Item(){
                        ProductName = "B",
                        Price = 20
                    }
                };

            var userCart = new UserCart();
            foreach (var item in _items)
            {
                userCart.AddItem(item);
            }

            Assert.AreEqual(userCart.TotalPrice(), result);
        }

        [Test]
        public void ProvideDiscountToCustomer()
        {
            // SETUP ITEMS
            List<Item> _items = new List<Item>() {
                    new Item(){
                        ProductName = "A",
                        Price = 10,
                        Quantity = 4
                    },
                    new Item(){
                        ProductName = "B",
                        Price = 20,
                        Quantity = 4
                    }
             };


            // SETUP DISCOUNTS
            List<Discount> discounts = new List<Discount>();
            discounts.Add(new Discount()
            {
                Product = "A",
                Percentage = 50,
                Threshold = 3
            });

            discounts.Add(new Discount()
            {
                Product = "B",
                Percentage = 25,
                Threshold = 4
            });

            // AFTER DISCOUNT TOTAL PRICE
            // A: 35
            // B: 75
            // TOTAL: 110

            var userCart = new UserCart();
            foreach (var item in _items)
            {
                userCart.AddItem(item);
            }

            Assert.AreEqual(userCart.TotalPrice(), 120);

            userCart.ApplyDiscounts(discounts);

            Assert.AreEqual(userCart.TotalPrice(), 110);
        }

        [Test]
        public void ProvideDiscountToCustomerWithTenProductEach()
        {
            // SETUP ITEMS
            List<Item> _items = new List<Item>() {
                    new Item(){
                        ProductName = "A",
                        Price = 10,
                        Quantity = 10
                    },
                    new Item(){
                        ProductName = "B",
                        Price = 20,
                        Quantity = 10
                    }
             };

            var userCart = new UserCart();

            foreach (var item in _items)
            {
                userCart.AddItem(item);
            }

            // TOTAL AMOUNT BEFORE DISCOUNTS 
            // A: 100
            // B: 200
            // TOTAL: 300


            // SETUP DISCOUNTS
            List<Discount> discounts = new List<Discount>();
            discounts.Add(new Discount()
            {
                Product = "A",
                Percentage = 50,
                Threshold = 3
            });

            discounts.Add(new Discount()
            {
                Product = "B",
                Percentage = 25,
                Threshold = 4
            });

            // AFTER DISCOUNT TOTAL PRICE
            // A: 85
            // B: 190
            // TOTAL: 275            
            userCart.ApplyDiscounts(discounts);

            Assert.AreEqual(userCart.TotalPrice(), 275);
        }

        [Test]
        public void JustTest()
        {
            // SETUP ITEMS
            List<Item> _items = new List<Item>() {
                    new Item(){
                        ProductName = "A",
                        Price = 10,
                        Quantity = 10
                    },
                    new Item(){
                        ProductName = "B",
                        Price = 20,
                        Quantity = 3
                    }
             };

            _items.Add(new Item()
            {
                ProductName = "B",
                Price = 20,
                Quantity = 7
            });

            var userCart = new UserCart();

            foreach (var item in _items)
            {
                userCart.AddItem(item);
            }

            // SETUP DISCOUNTS
            List<Discount> discounts = new List<Discount>();
            discounts.Add(new Discount()
            {
                Product = "A",
                Percentage = 50,
                Threshold = 3
            });

            discounts.Add(new Discount()
            {
                Product = "B",
                Percentage = 25,
                Threshold = 4
            });

            // AFTER DISCOUNT TOTAL PRICE
            // A: 85
            // B: 190
            // TOTAL: 275            
            userCart.ApplyDiscounts(discounts);

            Assert.AreEqual(userCart.TotalPrice(), 275);
        }
    }
}