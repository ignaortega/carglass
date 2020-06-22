using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieRentals.Movies;
using System;

namespace MovieRentals.Tests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void CustomerStatementNewReleaseOneNightTest()
        {
            Customer customer = new Customer("John Smith");

            customer.AddRental(new Rental(new Movie("Dawn of the Dead", new MoviePriceStateNewRelease()), 1));

            string result = customer.GetRentalStatement();

            Assert.AreEqual("Rental record for John Smith\r\n" +
                "\tDawn of the Dead\t3\r\n" +
                "Amount owed is 3\r\n" +
                "You earned 1 frequent renter points.\r\n", result);
        }

        [TestMethod]
        public void CustomerStatementNewReleaseSixNightsTest()
        {
            Customer customer = new Customer("John Smith");

            customer.AddRental(new Rental(new Movie("Yes Man", new MoviePriceStateNewRelease()), 6));

            string result = customer.GetRentalStatement();

            Assert.AreEqual("Rental record for John Smith\r\n" +
                "\tYes Man\t18\r\n" +
                "Amount owed is 18\r\n" +
                "You earned 2 frequent renter points.\r\n", result);
        }

        [TestMethod]
        public void CustomerStatementRegularOneNightTest()
        {
            Customer customer = new Customer("John Smith");

            customer.AddRental(new Rental(new Movie("Die Hard", new MoviePriceStateRegular()), 1));

            string result = customer.GetRentalStatement();

            Assert.AreEqual("Rental record for John Smith\r\n" +
                "\tDie Hard\t2\r\n" +
                "Amount owed is 2\r\n" +
                "You earned 1 frequent renter points.\r\n", result);
        }

        [TestMethod]
        public void CustomerStatementRegularSIxNightsTest()
        {
            Customer customer = new Customer("John Smith");

            customer.AddRental(new Rental(new Movie("Die Hard", new MoviePriceStateRegular()), 6));

            string result = customer.GetRentalStatement();

            Assert.AreEqual("Rental record for John Smith\r\n" +
                "\tDie Hard\t8\r\n" +
                "Amount owed is 8\r\n" +
                "You earned 1 frequent renter points.\r\n", result);
        }

        [TestMethod]
        public void CustomerStatementChildrensOneNightTest()
        {
            Customer customer = new Customer("John Smith");

            customer.AddRental(new Rental(new Movie("Neverending Story", new MoviePriceStateChildrens()), 1));

            string result = customer.GetRentalStatement();

            Assert.AreEqual("Rental record for John Smith\r\n" +
                "\tNeverending Story\t1,5\r\n" +
                "Amount owed is 1,5\r\n" +
                "You earned 1 frequent renter points.\r\n", result);
        }

        [TestMethod]
        public void CustomerStatementChildrenSIxNightsTest()
        {
            Customer customer = new Customer("John Smith");

            customer.AddRental(new Rental(new Movie("Neverending Story", new MoviePriceStateChildrens()), 6));

            string result = customer.GetRentalStatement();

            Assert.AreEqual("Rental record for John Smith\r\n" +
                "\tNeverending Story\t6\r\n" +
                "Amount owed is 6\r\n" +
                "You earned 1 frequent renter points.\r\n", result);
        }

        [TestMethod]
        public void CustomerStatementMultipleRentalsTest()
        {
            Customer customer = new Customer("John Smith");

            customer.AddRental(new Rental(new Movie("Yes Man", new MoviePriceStateNewRelease()), 2));
            customer.AddRental(new Rental(new Movie("Bedtime Stories", new MoviePriceStateChildrens()), 2));
            customer.AddRental(new Rental(new Movie("Mickey Mouse", new MoviePriceStateChildrens()), 6));
            customer.AddRental(new Rental(new Movie("Back To The Future", new MoviePriceStateRegular()), 6));

            string result = customer.GetRentalStatement();

            Assert.AreEqual("Rental record for John Smith\r\n" +
                "\tYes Man\t6\r\n" +
                "\tBedtime Stories\t1,5\r\n" +
                "\tMickey Mouse\t6\r\n" +
                "\tBack To The Future\t8\r\n" +
                "Amount owed is 21,5\r\n" +
                "You earned 5 frequent renter points.\r\n", result);
        }

        [TestMethod]
        public void CustomerWithoutNameThrowsExceptionTest()
        {
            Exception expectedException = null;

            try
            {
                Customer customer = new Customer(string.Empty);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
            Assert.IsInstanceOfType(expectedException, typeof(ArgumentException));
            Assert.AreEqual("The name is required", expectedException.Message);
        }
    }
}
