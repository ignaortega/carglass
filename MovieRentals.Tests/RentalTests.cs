using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieRentals.Movies;
using System;

namespace MovieRentals.Tests
{
    [TestClass]
    public class RentalTests
    {
        [TestMethod]
        public void RentalWithoutMovieThrowsExceptionTest()
        {
            Exception expectedException = null;

            try
            {
                Rental rental = new Rental(null,1);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
            Assert.IsInstanceOfType(expectedException, typeof(ArgumentException));
            Assert.AreEqual("The movie is required", expectedException.Message);
        }

        [TestMethod]
        public void RentalWitLessThanARentalDayThrowsExceptionTest()
        {
            Exception expectedException = null;

            try
            {
                Rental rental = new Rental(new Movie("SomeTitle", new MoviePriceStateRegular()), 0);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
            Assert.IsInstanceOfType(expectedException, typeof(ArgumentException));
            Assert.AreEqual("Days rented must be positive.", expectedException.Message);
        }
    }
}
