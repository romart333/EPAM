using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task01.Models
{
    public class IndexOrderViewModel
    {
        public IEnumerable<BriefOrder> Orders { get; set; }

        public PageInfo Page { get; set; }
    }
}