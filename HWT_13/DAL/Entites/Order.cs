namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;

    public enum enumOrderState
    {
        New, Underway, Executed
    }

    public class Order
    {
        public int OrderID { get; set; }

        public string CustomerID { get; set; }

        public int? EmployeeID { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public decimal? Freight { get; set; }

        public string ShipName { get; set; }

        public string ShipAddress { get; set; }

        public string ShipCity { get; set; }

        public string ShipRegion { get; set; }

        public string ShipPostalCode { get; set; }

        public string ShipCountry { get; set; }

        public List<Product> Products { get; set; }

        public enumOrderState OrderState
        {
            get
            {
                return (this.OrderDate == null) ? enumOrderState.New :
                (this.ShippedDate == null) ? enumOrderState.Underway : enumOrderState.Executed;
            }
        }
    }
}