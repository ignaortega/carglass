using System;

namespace MovieRentals.Movies
{
    public class Movie
    {
        public string Title { get; private set; }
        private MoviePriceState moviePriceState;

        public Movie(string title, MoviePriceState moviePriceState)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("The title is required");
            }

            if (moviePriceState == null)
            {
                throw new ArgumentException("The price code is required");
            }

            this.Title = title;
            this.moviePriceState = moviePriceState;
        }

        public double GetRentalPrice(int daysRented)
        {
            return this.moviePriceState.GetRentalPrice(daysRented);
        }

        public int GetFrecuentRentalPoints(int daysRented)
        {
            return this.moviePriceState.GetFrecuentRentalPoints(daysRented);
        }
    }
}
