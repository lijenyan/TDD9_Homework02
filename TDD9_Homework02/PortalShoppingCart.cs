using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD9_Homework02
{
    public class PortalShoppingCart
    {
        private decimal _UnitOfPrice;
        public PortalShoppingCart(decimal UnitOfPrice)
        {
            _UnitOfPrice = UnitOfPrice;
        }

        private decimal CalPrice(int BooksQty)
        {
            decimal discount = GetDiscount(BooksQty);
            return (1 - discount) * BooksQty * _UnitOfPrice;
        }

        public decimal FindTheLowerTotalPrice(List<Book> originalBooks)
        {
            List<decimal> allPossiblePrice = new List<decimal>();
            List<Book> moreThanOneUnitBooks = null;
            List<Book> onlyOneUnitBooks = null;
            List<Book> calBooks = new List<Book>(originalBooks.Select(x => x.Clone()));

            int originalBooksQty = originalBooks.Where(x => x.Unit > 0).Select(x => x.Unit).Sum();
            decimal forCaculateEachPrice = 0;
            int forDiscountQty = 0;
            int forCaculateTotalQty = originalBooksQty;

            while (forCaculateTotalQty > 0)
            {
                //兩本(以上)相同的書是沒有折扣,故先將其拿出來和其他一本的書計算總價
                moreThanOneUnitBooks = calBooks.Where(x => x.Unit > 1).ToList<Book>();
                onlyOneUnitBooks = calBooks.Where(x => x.Unit == 1).ToList<Book>();

                foreach (var item in moreThanOneUnitBooks)
                {
                    forDiscountQty++;
                    forCaculateTotalQty--;
                    foreach (Book book in calBooks)
                    {
                        if (book.Name == item.Name && book.Unit > 0)
                            book.Unit = book.Unit - 1;
                    }
                }

                foreach (var item in onlyOneUnitBooks)
                {
                    forDiscountQty++;
                    forCaculateTotalQty--;
                    foreach (Book book in calBooks)
                    {
                        if (book.Name == item.Name && book.Unit > 0)
                            book.Unit = book.Unit - 1;
                    }
                }

                forCaculateEachPrice += CalPrice(forDiscountQty);
                forDiscountQty = 0;
            }
            allPossiblePrice.Add(forCaculateEachPrice);
            forCaculateEachPrice = 0;

            ////特例:計算4本或5本為一組是否有更低價
            calBooks = new List<Book>(originalBooks.Select(x => x.Clone()));
            forCaculateTotalQty = originalBooksQty;
            while (forCaculateTotalQty > 0)
            {
                //兩本(以上)相同的書是沒有折扣,故先將其拿出來和其他一本的書計算總價
                moreThanOneUnitBooks = calBooks.Where(x => x.Unit > 1).ToList<Book>();
                onlyOneUnitBooks = calBooks.Where(x => x.Unit == 1).ToList<Book>();

                foreach (var item in moreThanOneUnitBooks)
                {
                    if (forDiscountQty == 4)
                        break;
                    forDiscountQty++;
                    forCaculateTotalQty--;
                    foreach (Book book in calBooks)
                    {
                        if (book.Name == item.Name && book.Unit > 0)
                            book.Unit = book.Unit - 1;
                    }
                }

                foreach (var item in onlyOneUnitBooks)
                {
                    if (forDiscountQty == 4)
                        break;
                    forDiscountQty++;
                    forCaculateTotalQty--;
                    foreach (Book book in calBooks)
                    {
                        if (book.Name == item.Name && book.Unit > 0)
                            book.Unit = book.Unit - 1;
                    }
                }

                forCaculateEachPrice += CalPrice(forDiscountQty);
                forDiscountQty = 0;
            }
            allPossiblePrice.Add(forCaculateEachPrice);

            decimal theLowestPrice = allPossiblePrice.OrderBy(x => x).FirstOrDefault();
            allPossiblePrice.Clear();
            return theLowestPrice;
        }

        

        private decimal GetDiscount(int qty)
        {
            decimal[] discount = new decimal[] { 0, 0.05M, 0.1M, 0.2M, 0.25M };
            return discount[qty - 1];
        }
    }

    static class Extensions
    {
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }

    public class Book
    {
        public HarryPortalBooksName Name { get; set; }

        public int Unit { get; set; }

        public Book Clone()
        {
            var book = new Book();
            book.Name = this.Name;
            book.Unit = this.Unit;
            return book;
        }
    }

    public enum HarryPortalBooksName
    {
        Series1st, Series2nd, Series3rd, Series4th, Series5th
    }
}
