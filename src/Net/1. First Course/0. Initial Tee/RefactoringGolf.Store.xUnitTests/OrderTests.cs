using System;
using Xunit;

namespace RefactoringGolf.Store.xUnitTests
{
    public class OrderTests
    {
        [Fact]
        public void HoldManyOrderItems()
        {
            Order order = CreateOrder(null);
            OrderItem orderItem = CreateOrderItem(10, ProductCategory.Accessories, 1);

            AddItemToOrder(order, orderItem);

            Assert.Equal(1, order.Items.Count);
        }
        
        [Fact]
        public void ReturnTheTotalWithAccessoriesDiscount()
        {
            Order order = CreateOrder("USA");
            OrderItem orderItem = CreateOrderItem(50, ProductCategory.Accessories, 2);
            AddItemToOrder(order, orderItem);

            decimal total = order.Total();

            Assert.Equal(94.5m, total);
        }

        [Fact]
        public void ReturnTheTotalWithBikesDiscount()
        {
            Order order = CreateOrder("USA");
            OrderItem orderItem = CreateOrderItem(200, ProductCategory.Bikes, 2);
            AddItemToOrder(order, orderItem);

            decimal total = order.Total();

            Assert.Equal(336m, total);
        }

        [Fact]
        public void ReturnTheTotalWithCloathingDiscount()
        {
            Order order = CreateOrder("USA");
            OrderItem orderItem = CreateOrderItem(100, ProductCategory.Cloathing, 3);
            AddItemToOrder(order, orderItem);

            decimal total = order.Total();

            Assert.Equal(210m, total);
        }

        [Fact]
        public void ReturnTheTotalWithShippingCostWhenDeliveryCountryIsOutsideUSA()
        {
            Order order = CreateOrder("Peru");

            decimal total = order.Total();

            Assert.Equal(15m, total);
        }

        private Order CreateOrder(string deliveryCountry)
        {
            var customer = new Customer("Luis", "Palacios", "54115678654");
            var salesman = new Salesman("Alberto", "Martinez", 4000, 4);
            return new Order(customer, salesman, "Los claveles 452", "New York", deliveryCountry, DateTime.Now);
        }

        private OrderItem CreateOrderItem(int unitPrice, ProductCategory productCategory, int quantity)
        {
            Product product = new Product("Nombre", unitPrice, productCategory, null);
            return new OrderItem(product, quantity);
        }

        private void AddItemToOrder(Order order, OrderItem orderItem)
        {
            order.Items.Add(orderItem);
        }
    }
}