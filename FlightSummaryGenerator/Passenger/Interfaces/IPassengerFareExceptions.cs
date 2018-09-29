using FlightSummaryGenerator.Passenger.LoayaltyMember;
using FlightSummaryGenerator.Passenger.LoyaltyBenefitss;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSummaryGenerator.Passenger
{
   public interface IPassengerFareExceptions
    {
        ILoyaltyBenefits loyaltyBenefits { get; set; }
         decimal Discount { get; set; }

    }
}
