using System;
namespace TravelLibrary
{
    public class Concession
    {
        public string CalculateConcession(string name, int age, double totalFare)
        {
            if (age <= 5)
            {
                return "Little Champs - Free Ticket";
            }
            else if (age > 60)
            {
                double discountedFare = totalFare - (totalFare * 0.30);
                return "Senior Citizen - Fare: " + discountedFare;
            }
            else
            {
                return "Ticket Booked - Fare: " + totalFare;
            }
        }
    }
}
