namespace ClassLibrary.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using ClassLibrary;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DALTests
    {
        [TestMethod]
        public void GetOrdersTest()
        {
            // arrange
            int countOrders = 1;
            DAL dal = new DAL();
            var orders = new List<Order>();
            int expectedOrderID = 10248;
            string expectedCustomerID = "VINET";
            DateTime expectedShippedDate = new DateTime(1996, 7, 16);
            DateTime expectedOrderDate = new DateTime(1996, 7, 4);
            StateOrder expectedStateOrder = StateOrder.Executed;

            // act
            orders = dal.GetOrders(countOrders);

            // assert
            Assert.AreEqual(expectedOrderID, orders[0].OrderID);
            Assert.AreEqual(expectedCustomerID, orders[0].CustomerID);
            Assert.AreEqual(expectedShippedDate, orders[0].ShippedDate);
            Assert.AreEqual(expectedOrderDate, orders[0].OrderDate);
            Assert.AreEqual(expectedStateOrder, orders[0].GetStateOrder());
        }

        [TestMethod]
        public void GetInfoOrderTest()
        {
            // arrange
            DAL dal = new DAL();
            List<Order> order = new List<Order>();
            int orderID = 10248;
            int expectedOrderID = orderID;
            int expectedProductID = 11;
            string expectedProductName = "Queso Cabrales";
            DateTime expectedShippedDate = new DateTime(1996, 7, 16);
            DateTime expectedOrderDate = new DateTime(1996, 7, 4);

            // act
            order = dal.GetInfoOrder(orderID);

            // arrange
            Assert.AreEqual(expectedOrderID, order[0].OrderID);
            Assert.AreEqual(expectedProductID, order[0].ProductID);
            Assert.AreEqual(expectedProductName, order[0].ProductName);
            Assert.AreEqual(expectedShippedDate, order[0].ShippedDate);
            Assert.AreEqual(expectedOrderDate, order[0].OrderDate);
        }

        [TestMethod]
        public void AddOrderTest()
        {
            int expected = 1;
            DAL dal = new DAL();
            int actual = dal.AddOrder(
                1,
                "use",
                1,
                new DateTime(1996, 7, 16),
                new DateTime(1996, 8, 16),
                new DateTime(1996, 9, 16),
                5,
                200,
                "ship",
                "York",
                "London",
                "Okinawa",
                "code",
                "GB");

            // arrange
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetOrderDateTest()
        {
            DateTime orderDate = new DateTime(1996, 4, 7);

            int orderID = 10248;

            int expected = 1;
            DAL dal = new DAL();

            int actual = dal.SetOrderDate(orderDate, orderID);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetShippedDateTest()
        {
            DateTime orderDate = new DateTime(1976, 1, 1);

            int orderID = 11000;

            int expected = 1;
            DAL dal = new DAL();

            int actual = dal.SetOrderDate(orderDate, orderID);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetOrderHistoryTest()
        {
            // arrange
            string customerID = "VINET";
            DAL dal = new DAL();
            List<Product> products = new List<Product>();
            string expectedProductName = "Filo Mix";
            int expectedTotal = 18;

            // act
            products = dal.GetOrderHistory(customerID);

            // arrange
            Assert.AreEqual(expectedProductName, products[0].ProductName);
            Assert.AreEqual(expectedTotal, products[0].Total);
        }

        [TestMethod]
        public void GetOrderDetailsTest()
        {
            // arrange
            int orderID = 10248;
            DAL dal = new DAL();
            List<Product> products = new List<Product>();
            string expectedProductName = "Queso Cabrales";
            double expectedUnitPrice = 14;
            int expectedQuantity = 12;
            int expectedDiscount = 0;
            double expectedExtendedPrice = 168;

            // act
            products = dal.GetOrderDetails(orderID);

            // arrange
            Assert.AreEqual(expectedProductName, products[0].ProductName);
            Assert.AreEqual(expectedUnitPrice, products[0].UnitPrice);
            Assert.AreEqual(expectedQuantity, products[0].Quantity);
            Assert.AreEqual(expectedDiscount, products[0].Discount);
            Assert.AreEqual(expectedExtendedPrice, products[0].ExtendedPrice);
        }
    }
}