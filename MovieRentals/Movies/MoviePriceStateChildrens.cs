namespace MovieRentals.Movies
{
    public class MoviePriceStateChildrens : MoviePriceState
    {
        public MoviePriceStateChildrens()
        {
            this.extraDailyRentAmount = 1.5;
            this.baseRentAmount = 1.5;
            this.rentalDaysWithoutExtraCharge = 3;
        }
    }
}
