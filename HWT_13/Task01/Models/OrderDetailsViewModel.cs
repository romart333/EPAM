namespace Task01.Models
{
    using ClassLibrary;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class OrderDetailsViewModel
    {
        public int OrderID { get; set; }

        public string CustomerID { get; set; }
        
        [DataType(DataType.Date)]
        [Required]
        public DateTime? OrderDate { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime? RequiredDate { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime? ShippedDate { get; set; }

        [Required()]
        public decimal? Freight { get; set; }

        [Required]
        public string ShipName { get; set; }

        [Required]
        public string ShipAddress { get; set; }

        [Required]
        public string ShipCity { get; set; }

        [Required]
        public string ShipRegion { get; set; }

        [Required]
        public string ShipPostalCode { get; set; }

        [Required]
        public string ShipCountry { get; set; }
        
        [ScaffoldColumn(false)]
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