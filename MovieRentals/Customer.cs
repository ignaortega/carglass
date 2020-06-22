using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRentals
{
    public class Customer
    {
        public string Name { get; private set; }
        private IList<Rental> rentals;

        public Customer(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("The name is required");
            }

            this.Name = name;
            this.rentals = new List<Rental>();
        }

        public void AddRental(Rental rental)
        {
            this.rentals.Add(rental);
        }

        public string GetRentalStatement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(string.Format("Rental record for {0}", this.Name));

            foreach (Rental rental in this.rentals)
            {
                double rentalPrice = rental.GetRentalPrice();
                totalAmount += rentalPrice;
                frequentRenterPoints += rental.GetFrecuentRentalPoints();

                stringBuilder.AppendLine(string.Format("\t{0}\t{1}", rental.Movie.Title, rentalPrice));
            }

            stringBuilder.AppendLine(string.Format("Amount owed is {0}", totalAmount));
            stringBuilder.AppendLine(string.Format("You earned {0} frequent renter points.", frequentRenterPoints));

            return stringBuilder.ToString();
        }
    }
}
