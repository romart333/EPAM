﻿namespace ClassLibrary
{
    using System;

    public enum StateOrder
    {
        New, Underway, Executed
    }

    public class Order
    {
        public int OrderID { get; set; }

        public string CustomerID { get; set; }

        public int? EmployeeID { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime RequireDate { get; set; }

        public DateTime ShippedDate { get; set; }

        public int? ShipVia { get; set; }

        public double? Freight { get; set; }

        public string ShipName { get; set; }

        public string ShipAddress { get; set; }

        public string ShipCity { get; set; }

        public string ShipRegion { get; set; }

        public string ShipPostalCode { get; set; }

        public string ShipCountry { get; set; }

        public string ProductName { get; set; }

        public int ProductID { get; set; }

        public StateOrder GetStateOrder()
        {
            return (this.OrderDate == null) ? StateOrder.New :
                (this.ShippedDate == null) ? StateOrder.Underway : StateOrder.Executed;
        }
    }
}