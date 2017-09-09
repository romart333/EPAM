namespace Task01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class BriefOrder
    {
        public int OrderID { get; set; }

        public string CustomerID { get; set; }

        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }

        public string OrderState { get; set; }

        [DataType(DataType.Currency)]
        public decimal? Sum { get; set; }
    }
}