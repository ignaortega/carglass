using MovieRentals.Movies;
using System;

namespace MovieRentals
{
    public class Rental
    {
        public Movie Movie { get; private set; }
        private int daysRented;

        public Rental(Movie movie, int daysRented)
        {
            if (movie == null)
            {
                throw new ArgumentException("The movie is required");
            }

            if (daysRented < 1)
            {
                throw new ArgumentException("Days rented must be positive.");
            }

            this.Movie = movie;
            this.daysRented = daysRented;
        }

        public double GetRentalPrice()
        {
            return this.Movie.GetRentalPrice(this.daysRented);
        }

        public int GetFrecuentRentalPoints()
        {
            return this.Movie.GetFrecuentRentalPoints(this.daysRented);
        }
    }
}
