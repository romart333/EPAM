namespace Task01.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class PageInfo
    {
        private const int PAGESIZE = 30;

        public int PageNumber { get; set; } // номер текущей страницы

        public int PageSize
        {
            get
            {
                return PAGESIZE;
            }
        }// кол-во объектов на странице

        public int TotalItems { get; set; } // всего объектов

        public int TotalPages  // всего страниц
        {
            get
            {
                return (int)Math.Ceiling((decimal)TotalItems / PageSize);
            }
        }
    }
}