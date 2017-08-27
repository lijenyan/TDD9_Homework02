using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD9_Homework02
{
    public class PortalShoppingCart
    {
        public decimal GetTotalPrice(List<Book> books,decimal originalUnitPrice)
        {
            var qty = books.Where(x => x.Unit > 0).Select(x=>x.Unit).Sum();
            return qty * originalUnitPrice;
        }
    }

    public class Book
    {
        public HarryPortalBooksName Name { get; set; }

        public int Unit { get; set; }
    }

    public enum HarryPortalBooksName
    {
        Series1st, Series2nd, Series3rd, Series4th, Series5th
    }
}
