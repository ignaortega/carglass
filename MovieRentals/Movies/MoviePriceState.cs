using System;
using System.Runtime.Remoting.Messaging;

namespace MovieRentals.Movies
{
    public abstract class MoviePriceState
    {
        protected double baseRentAmount;
        protected double extraDailyRentAmount;
        protected int rentalDaysWithoutExtraCharge;

        public double GetRentalPrice(int daysRented)
        {
            if (daysRented < 1)
            {
                throw new ArgumentException("Days rented must be positive.");
            }

            return this.GetRentalPriceInner(daysRented);
        }

        protected virtual double GetRentalPriceInner(int daysRented)
        {
            double rentalPrice = this.baseRentAmount;

            if (daysRented > this.rentalDaysWithoutExtraCharge)
            {
                rentalPrice += (daysRented - this.rentalDaysWithoutExtraCharge) * this.extraDailyRentAmount;
            }

            return rentalPrice;
        }

        public int GetFrecuentRentalPoints(int daysRented)
        {
            if (daysRented < 1)
            {
                throw new ArgumentException("Days rented must be positive.");
            }

            return this.GetFrecuentRentalPointsInner(daysRented);
        }

        protected virtual int GetFrecuentRentalPointsInner(int daysRented)
        {
            return 1;
        }
    }
}
