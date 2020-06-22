namespace MovieRentals.Movies
{
    public class MoviePriceStateNewRelease : MoviePriceState
    {
        public MoviePriceStateNewRelease()
        {
            this.extraDailyRentAmount = 3;
        }

        protected override double GetRentalPriceInner(int daysRented)
        {
            return this.extraDailyRentAmount * daysRented;
        }

        protected override int GetFrecuentRentalPointsInner(int daysRented)
        {
            return (daysRented > 1) ? 2 : 1;
        }
    }
}
