using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD9_Homework02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD9_Homework02.Tests
{
    [TestClass()]
    public class PortalShoppingCartTests
    {
        [TestMethod()]
        public void GetTotalPriceTest_Buy_1_Book_TotalPrice_100()
        {
            //arrange
            List<Book> Books = new List<Book>
            {
                new Book { Name = HarryPortalBooksName.Series1st,Unit=1},
                new Book { Name = HarryPortalBooksName.Series2nd,Unit=0},
                new Book { Name = HarryPortalBooksName.Series3rd,Unit=0},
                new Book { Name = HarryPortalBooksName.Series4th,Unit=0},
                new Book { Name = HarryPortalBooksName.Series5th,Unit=0}
            };
            var target = new PortalShoppingCart();
            decimal expected = 100.0M;

            //act
            decimal actual = target.GetTotalPrice(Books,100);

            //assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod()]
        public void GetTotalPriceTest_Buy_2_Book_TotalPrice_190()
        {
            //arrange
            List<Book> Books = new List<Book>
            {
                new Book { Name = HarryPortalBooksName.Series1st,Unit=1},
                new Book { Name = HarryPortalBooksName.Series2nd,Unit=1},
                new Book { Name = HarryPortalBooksName.Series3rd,Unit=0},
                new Book { Name = HarryPortalBooksName.Series4th,Unit=0},
                new Book { Name = HarryPortalBooksName.Series5th,Unit=0}
            };
            var target = new PortalShoppingCart();
            decimal expected = 190.0M;

            //act
            decimal actual = target.GetTotalPrice(Books, 100);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetTotalPriceTest_Buy_3_Diff_Book_Discount_10Percentage_TotalPrice_270_()
        {
            //arrange
            List<Book> Books = new List<Book>
            {
                new Book { Name = HarryPortalBooksName.Series1st,Unit=1},
                new Book { Name = HarryPortalBooksName.Series2nd,Unit=1},
                new Book { Name = HarryPortalBooksName.Series3rd,Unit=1},
                new Book { Name = HarryPortalBooksName.Series4th,Unit=0},
                new Book { Name = HarryPortalBooksName.Series5th,Unit=0}
            };
            var target = new PortalShoppingCart();
            decimal expected = 270.0M;

            //act
            decimal actual = target.GetTotalPrice(Books, 100);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetTotalPriceTest_Buy_4_Diff_Book_Discount_20Percentage_TotalPrice_320_()
        {
            //arrange
            List<Book> Books = new List<Book>
            {
                new Book { Name = HarryPortalBooksName.Series1st,Unit=1},
                new Book { Name = HarryPortalBooksName.Series2nd,Unit=1},
                new Book { Name = HarryPortalBooksName.Series3rd,Unit=1},
                new Book { Name = HarryPortalBooksName.Series4th,Unit=1},
                new Book { Name = HarryPortalBooksName.Series5th,Unit=0}
            };
            var target = new PortalShoppingCart();
            decimal expected = 320.0M;

            //act
            decimal actual = target.GetTotalPrice(Books, 100);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetTotalPriceTest_Buy_5_Diff_Book_Discount_25Percentage_TotalPrice_375_()
        {
            //arrange
            List<Book> Books = new List<Book>
            {
                new Book { Name = HarryPortalBooksName.Series1st,Unit=1},
                new Book { Name = HarryPortalBooksName.Series2nd,Unit=1},
                new Book { Name = HarryPortalBooksName.Series3rd,Unit=1},
                new Book { Name = HarryPortalBooksName.Series4th,Unit=1},
                new Book { Name = HarryPortalBooksName.Series5th,Unit=1}
            };
            var target = new PortalShoppingCart();
            decimal expected = 375.0M;

            //act
            decimal actual = target.GetTotalPrice(Books, 100);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetTotalPriceTest_Buy_1st_1Qty_2nd_1Qty_3rd_2Qty_TotalPrice_370_()
        {
            //arrange
            List<Book> Books = new List<Book>
            {
                new Book { Name = HarryPortalBooksName.Series1st,Unit=1},
                new Book { Name = HarryPortalBooksName.Series2nd,Unit=1},
                new Book { Name = HarryPortalBooksName.Series3rd,Unit=2},
                new Book { Name = HarryPortalBooksName.Series4th,Unit=0},
                new Book { Name = HarryPortalBooksName.Series5th,Unit=0}
            };
            var target = new PortalShoppingCart();
            decimal expected = 370.0M;

            //act
            decimal actual = target.GetTotalPrice(Books, 100);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }

    

}