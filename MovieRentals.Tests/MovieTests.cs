using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieRentals.Movies;
using System;

namespace MovieRentals.Tests
{
    [TestClass]
    [System.Runtime.InteropServices.Guid("1157B6B4-296F-442A-A75E-76F0928560C1")]
    public class MovieTests
    {
        [TestMethod]
        public void MovieWithoutTitleThrowsExceptionTest()
        {
            Exception exception = null;

            try
            {
                Movie movie = new Movie(string.Empty, null);
            }
            catch (ArgumentException ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(ArgumentException));
            Assert.AreEqual("The title is required", exception.Message);
        }

        [TestMethod]
        public void MovieWithoutPriceStateThrowsExceptionTest()
        {
            Exception expectedException = null;

            try
            {
                Movie movie = new Movie("someTitle", null);
            }
            catch (ArgumentException ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
            Assert.IsInstanceOfType(expectedException, typeof(ArgumentException));
            Assert.AreEqual("The price code is required", expectedException.Message);
        }

        [TestMethod]
        public void LessThanADaysRentalNewReleasePriceThrowsExceptionTest()
        {
            MoviePriceState moviePriceState = new MoviePriceStateNewRelease();

            int daysRented = 0;
            Exception expectedException = null;

            try
            {
                var result = moviePriceState.GetRentalPrice(daysRented);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
            Assert.IsInstanceOfType(expectedException, typeof(ArgumentException));
            Assert.AreEqual("Days rented must be positive.", expectedException.Message);
        }

        [TestMethod]
        public void LessThanADaysRentalNewReleasePointsThrowsExceptionTest()
        {
            MoviePriceState moviePriceState = new MoviePriceStateNewRelease();

            int daysRented = 0;
            Exception expectedException = null;

            try
            {
                var result = moviePriceState.GetFrecuentRentalPoints(daysRented);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
            Assert.IsInstanceOfType(expectedException, typeof(ArgumentException));
            Assert.AreEqual("Days rented must be positive.", expectedException.Message);
        }

        [TestMethod]
        public void LessThanADaysRentalChildrensPriceThrowsExceptionTest()
        {
            MoviePriceState moviePriceState = new MoviePriceStateChildrens();

            int daysRented = 0;
            Exception expectedException = null;

            try
            {
                var result = moviePriceState.GetRentalPrice(daysRented);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
            Assert.IsInstanceOfType(expectedException, typeof(ArgumentException));
            Assert.AreEqual("Days rented must be positive.", expectedException.Message);
        }

        [TestMethod]
        public void LessThanADaysRentalChildrensPointsThrowsExceptionTest()
        {
            MoviePriceState moviePriceState = new MoviePriceStateChildrens();

            int daysRented = 0;
            Exception expectedException = null;

            try
            {
                var result = moviePriceState.GetFrecuentRentalPoints(daysRented);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
            Assert.IsInstanceOfType(expectedException, typeof(ArgumentException));
            Assert.AreEqual("Days rented must be positive.", expectedException.Message);
        }

        [TestMethod]
        public void LessThanADaysRentalRegularPriceThrowsExceptionTest()
        {
            MoviePriceState moviePriceState = new MoviePriceStateRegular();

            int daysRented = 0;
            Exception expectedException = null;

            try
            {
                var result = moviePriceState.GetRentalPrice(daysRented);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
            Assert.IsInstanceOfType(expectedException, typeof(ArgumentException));
            Assert.AreEqual("Days rented must be positive.", expectedException.Message);
        }

        [TestMethod]
        public void LessThanADaysRentalRegularPointsThrowsExceptionTest()
        {
            MoviePriceState moviePriceState = new MoviePriceStateRegular();

            int daysRented = 0;
            Exception expectedException = null;

            try
            {
                var result = moviePriceState.GetFrecuentRentalPoints(daysRented);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
            Assert.IsInstanceOfType(expectedException, typeof(ArgumentException));
            Assert.AreEqual("Days rented must be positive.", expectedException.Message);
        }

        [TestMethod]
        public void OneDaysRentalNewReleaseTest()
        {
            MoviePriceState moviePriceState = new MoviePriceStateNewRelease();

            int daysRented = 1;

            var rentalPrice = moviePriceState.GetRentalPrice(daysRented);
            var pointsEarned = moviePriceState.GetFrecuentRentalPoints(daysRented);

            Assert.AreEqual(3, rentalPrice);
            Assert.AreEqual(1, pointsEarned);
        }

        [TestMethod]
        public void TwoDaysRentalNewReleaseTest()
        {
            MoviePriceState moviePriceState = new MoviePriceStateNewRelease();

            int daysRented = 2;

            var rentalPrice = moviePriceState.GetRentalPrice(daysRented);
            var pointsEarned = moviePriceState.GetFrecuentRentalPoints(daysRented);

            Assert.AreEqual(6, rentalPrice);
            Assert.AreEqual(2, pointsEarned);
        }

        [TestMethod]
        public void TwoDaysRentalChildrensTest()
        {
            MoviePriceState moviePriceState = new MoviePriceStateChildrens();

            int daysRented = 2;

            var rentalPrice = moviePriceState.GetRentalPrice(daysRented);
            var pointsEarned = moviePriceState.GetFrecuentRentalPoints(daysRented);

            Assert.AreEqual(1.5, rentalPrice);
            Assert.AreEqual(1, pointsEarned);
        }

        [TestMethod]
        public void FourDaysRentalChildrensTest()
        {
            MoviePriceState moviePriceState = new MoviePriceStateChildrens();

            int daysRented = 4;

            var rentalPrice = moviePriceState.GetRentalPrice(daysRented);
            var pointsEarned = moviePriceState.GetFrecuentRentalPoints(daysRented);

            Assert.AreEqual(3, rentalPrice);
            Assert.AreEqual(1, pointsEarned);
        }

        [TestMethod]
        public void OneDaysRentalRegularTest()
        {
            MoviePriceState moviePriceState = new MoviePriceStateRegular();

            int daysRented = 1;

            var rentalPrice = moviePriceState.GetRentalPrice(daysRented);
            var pointsEarned = moviePriceState.GetFrecuentRentalPoints(daysRented);

            Assert.AreEqual(2, rentalPrice);
            Assert.AreEqual(1, pointsEarned);
        }

        [TestMethod]
        public void FourDaysRentalRrgularTest()
        {
            MoviePriceState moviePriceState = new MoviePriceStateRegular();

            int daysRented = 4;

            var rentalPrice = moviePriceState.GetRentalPrice(daysRented);
            var pointsEarned = moviePriceState.GetFrecuentRentalPoints(daysRented);

            Assert.AreEqual(5, rentalPrice);
            Assert.AreEqual(1, pointsEarned);
        }
    }
}
