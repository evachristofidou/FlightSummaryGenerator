using FlightSummaryGenerator.Passenger.LoyaltyBenefitss;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSummaryGenerator.Passenger
{
   public interface IPassengerDetails
    {
        decimal GetPassengerFare(decimal passengerFare);
        PassengerFareExceptions GetPassengerFareExceptions();
    }
}
