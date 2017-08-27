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
        public void GetTotalPriceTest_Buy_5_DifferentBook_TotalPrice_500()
        {
            //arrange
            List<Book> Books = new List<Book>
            {
                new Book { Name = HarryPortalBooksName.Series1st},
                new Book { Name = HarryPortalBooksName.Series2nd},
                new Book { Name = HarryPortalBooksName.Series3rd},
                new Book { Name = HarryPortalBooksName.Series4th},
                new Book { Name = HarryPortalBooksName.Series5th}
            };
            var target = new PortalShoppingCart();
            decimal expected = 500.0M;

            //act
            decimal actual = target.GetTotalPrice(Books,100);

            //assert
            Assert.AreEqual(expected,actual);
        }
    }

    

}