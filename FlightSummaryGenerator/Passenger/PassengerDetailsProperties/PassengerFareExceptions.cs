using System;
using System.Collections.Generic;
using System.Text;
using FlightSummaryGenerator.Passenger.LoayaltyMember;
using FlightSummaryGenerator.Passenger.LoyaltyBenefitss;

namespace FlightSummaryGenerator.Passenger
{
    public class PassengerFareExceptions : IPassengerFareExceptions
    {
        public decimal Discount { get; set; }
        public ILoyaltyBenefits loyaltyBenefits { get; set; }
    }
}
