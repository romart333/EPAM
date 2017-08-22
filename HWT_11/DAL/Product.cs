namespace ClassLibrary
{
    using System;

    public class Product
    {
        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public int Discount { get; set; }

        public decimal ExtendedPrice { get; set; }

        public int Total { get; set; }

        public Int16 Quantity { get; set; }
    }
}