﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        const decimal unitOfPrice = 100;
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
            var target = new PortalShoppingCart(unitOfPrice);
            decimal expected = 100.0M;

            //act
            decimal actual = target.FindTheLowerTotalPrice(Books);

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
            var target = new PortalShoppingCart(unitOfPrice);
            decimal expected = 190.0M;

            //act
            decimal actual = target.FindTheLowerTotalPrice(Books);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetTotalPriceTest_Buy_3_Diff_Book_Discount_10Percentage_TotalPrice_270()
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
            var target = new PortalShoppingCart(unitOfPrice);
            decimal expected = 270.0M;

            //act
            decimal actual = target.FindTheLowerTotalPrice(Books);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetTotalPriceTest_Buy_4_Diff_Book_Discount_20Percentage_TotalPrice_320()
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
            var target = new PortalShoppingCart(unitOfPrice);
            decimal expected = 320.0M;

            //act
            decimal actual = target.FindTheLowerTotalPrice(Books);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetTotalPriceTest_Buy_5_Diff_Book_Discount_25Percentage_TotalPrice_375()
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
            var target = new PortalShoppingCart(unitOfPrice);
            decimal expected = 375.0M;

            //act
            decimal actual = target.FindTheLowerTotalPrice(Books);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetTotalPriceTest_Buy_1st_1Qty_2nd_1Qty_3rd_2Qty_TotalPrice_370()
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
            var target = new PortalShoppingCart(unitOfPrice);
            decimal expected = 370.0M;

            //act
            decimal actual = target.FindTheLowerTotalPrice(Books);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetTotalPriceTest_Buy_1st_1Qty_2nd_2Qty_3rd_2Qty_TotalPrice_460()
        {
            //arrange
            List<Book> Books = new List<Book>
            {
                new Book { Name = HarryPortalBooksName.Series1st,Unit=1},
                new Book { Name = HarryPortalBooksName.Series2nd,Unit=2},
                new Book { Name = HarryPortalBooksName.Series3rd,Unit=2},
                new Book { Name = HarryPortalBooksName.Series4th,Unit=0},
                new Book { Name = HarryPortalBooksName.Series5th,Unit=0}
            };
            var target = new PortalShoppingCart(unitOfPrice);
            decimal expected = 460.0M;

            //act
            decimal actual = target.FindTheLowerTotalPrice(Books);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetTotalPriceTest_Buy_1st_2Qty_2nd_2Qty_3rd_2Qty_4th_1Qty_5th_1Qty_TotalPrice_640()
        {
            //arrange
            List<Book> Books = new List<Book>
            {
                new Book { Name = HarryPortalBooksName.Series1st,Unit=2},
                new Book { Name = HarryPortalBooksName.Series2nd,Unit=2},
                new Book { Name = HarryPortalBooksName.Series3rd,Unit=2},
                new Book { Name = HarryPortalBooksName.Series4th,Unit=1},
                new Book { Name = HarryPortalBooksName.Series5th,Unit=1}
            };
            var target = new PortalShoppingCart(unitOfPrice);
            decimal expected = 640.0M;

            //act
            decimal actual = target.FindTheLowerTotalPrice(Books);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetTotalPriceTest_Buy_1st_2Qty_2nd_2Qty_3rd_2Qty_4th_2Qty_5th_1Qty_TotalPrice_695()
        {
            //arrange
            List<Book> Books = new List<Book>
            {
                new Book { Name = HarryPortalBooksName.Series1st,Unit=2},
                new Book { Name = HarryPortalBooksName.Series2nd,Unit=2},
                new Book { Name = HarryPortalBooksName.Series3rd,Unit=2},
                new Book { Name = HarryPortalBooksName.Series4th,Unit=2},
                new Book { Name = HarryPortalBooksName.Series5th,Unit=1}
            };
            var target = new PortalShoppingCart(unitOfPrice);
            decimal expected = 695.0M;

            //act
            decimal actual = target.FindTheLowerTotalPrice(Books);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetTotalPriceTest_Buy_1st_4Qty_2nd_4Qty_3rd_4Qty_4th_2Qty_5th_2Qty_TotalPrice_1280()
        {
            //arrange
            List<Book> Books = new List<Book>
            {
                new Book { Name = HarryPortalBooksName.Series1st,Unit=4},
                new Book { Name = HarryPortalBooksName.Series2nd,Unit=4},
                new Book { Name = HarryPortalBooksName.Series3rd,Unit=4},
                new Book { Name = HarryPortalBooksName.Series4th,Unit=2},
                new Book { Name = HarryPortalBooksName.Series5th,Unit=2}
            };
            var target = new PortalShoppingCart(unitOfPrice);
            decimal expected = 1280.0M;

            //act
            decimal actual = target.FindTheLowerTotalPrice(Books);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }

    

}