using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD9_Homework02
{
    public class PortalShoppingCart
    {
        public decimal GetTotalPrice(List<Book> books, decimal originalUnitPrice)
        {
            var qty = books.Where(x => x.Unit > 0).Select(x => x.Unit).Sum();
            decimal discount = 0;

            if (qty >= 2)
                discount = 0.05M;

            if (qty >= 3)
                discount = 0.1M;

            return (1 - discount) * qty * originalUnitPrice;
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
