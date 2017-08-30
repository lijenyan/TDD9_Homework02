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

        public decimal FindTheLowerTotalPrice(List<Book> originalBooks)
        {
            List<decimal> allPossiblePrice = new List<decimal>();
            //Normal Case
            CalculatePrice calculatePriceNormalCase = new CalculatePrice(originalBooks, _UnitOfPrice, false);
            decimal price = calculatePriceNormalCase.TryPossibleCalculateCase();
            allPossiblePrice.Add(price);

            //Special Case
            CalculatePrice calculatePriceSpecialCase = new CalculatePrice(originalBooks, _UnitOfPrice, true);
            price = calculatePriceSpecialCase.TryPossibleCalculateCase();
            allPossiblePrice.Add(price);

            decimal theLowestPrice = allPossiblePrice.OrderBy(x => x).FirstOrDefault();
            allPossiblePrice.Clear();
            return theLowestPrice;
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

    public class CalculatePrice
    {
        public CalculatePrice(List<Book> OriginalBooks, decimal UnitOfPrice,bool IsSpecialCase)
        {
            this.CloneOriginalBooks = new List<Book>(OriginalBooks.Select(x => x.Clone()));
            this.UnitOfPrice = UnitOfPrice;
            this.TotalBookQty = OriginalBooks.Where(x => x.Unit > 0).Select(x => x.Unit).Sum();
            this.EachCaculatedPrice = 0;
            this.IsSpecialCase = IsSpecialCase;
        }
        public bool IsSpecialCase { get; set; }
        private decimal UnitOfPrice { get; set; }
        private int TotalBookQty { get; set; }
        private int DiscountBookQty { get; set; }

        private decimal EachCaculatedPrice { get; set; }

        private List<Book> MoreThanOneUnitBooks { get; set; }
        private List<Book> OnlyOneUnitBooks { get; set; }

        private List<Book> CloneOriginalBooks { get; set; }

        public decimal TryPossibleCalculateCase()
        {
            while (TotalBookQty > 0)
            {
                //兩本(以上)相同的書是沒有折扣,故先將其拿出來和其他一本的書計算總價
                MoreThanOneUnitBooks = CloneOriginalBooks.Where(x => x.Unit > 1).ToList<Book>();
                OnlyOneUnitBooks = CloneOriginalBooks.Where(x => x.Unit == 1).ToList<Book>();

                TakeBooksForMatchDiscountBookQty(MoreThanOneUnitBooks);
                TakeBooksForMatchDiscountBookQty(OnlyOneUnitBooks);

                EachCaculatedPrice += CalculateDiscountTimeQtyTimeUnitOfPirce(DiscountBookQty);
                DiscountBookQty = 0;
            }
           
            return EachCaculatedPrice;
        }

        private void TakeBooksForMatchDiscountBookQty(List<Book> Books)
        {
            foreach (var item in Books)
            {
                if (IsSpecialCase && DiscountBookQty == 4)
                    break;
                DiscountBookQty++;
                TotalBookQty--;
                foreach (Book book in CloneOriginalBooks)
                {
                    if (book.Name == item.Name && book.Unit > 0)
                        book.Unit = book.Unit - 1;
                }
            }
        }

        private decimal CalculateDiscountTimeQtyTimeUnitOfPirce(int BooksQty)
        {
            decimal discount = GetDiscount(BooksQty);
            return (1 - discount) * BooksQty * UnitOfPrice;
        }

        private decimal GetDiscount(int qty)
        {
            decimal[] discount = new decimal[] { 0, 0.05M, 0.1M, 0.2M, 0.25M };
            return discount[qty - 1];
        }
    }
}
