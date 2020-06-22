namespace MovieRentals.Movies
{
    public class MoviePriceStateRegular : MoviePriceState
    {
        public MoviePriceStateRegular()
        {
            this.extraDailyRentAmount = 1.5;
            this.baseRentAmount = 2;
            this.rentalDaysWithoutExtraCharge = 2;
        }
    }
}
