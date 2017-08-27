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
            decimal totalPrice = 0;
            int totalQty = books.Where(x => x.Unit > 0).Select(x => x.Unit).Sum();

            while (totalQty > 0)
            {
                //有多少書是不重複的
                var distinctBooks = books.Where(x => x.Unit > 0).Distinct().ToArray();
                int distinctBooksQty = distinctBooks.Count();
                decimal discount = GetDiscount(distinctBooksQty);
                totalPrice = totalPrice + (1 - discount) * distinctBooksQty * originalUnitPrice;

                //剩餘要繼續計算價錢的書的總數量
                totalQty = totalQty - distinctBooksQty;
                //購買數量大於 0 本的書,其數量皆減 1
                foreach (Book book in distinctBooks)
                {
                    book.Unit = book.Unit - 1;
                }
            }

            return totalPrice;
        }

        private decimal GetDiscount(int qty)
        {
            decimal[] discount = new decimal[] { 0, 0.05M, 0.1M, 0.2M, 0.25M };
            return discount[qty - 1];
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
