using FlightSummaryGenerator.Passenger.LoayaltyMember;
using FlightSummaryGenerator.Validators.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSummaryGenerator.Passenger
{
   public class LoyaltyMember : IPassengerDetails
    {
        private readonly ILoyaltyBenefits _loyaltyBenefits;
        private readonly IValidator _validator;

        /// <summary>
        /// Constructor for Loyalty Members.
        /// Dependency Injection for Loyalty Benefits and IValidator Service
        /// </summary>
        /// <param name="loyaltyBenefits"></param>
        /// <param name="validator"></param>

        public LoyaltyMember(ILoyaltyBenefits loyaltyBenefits,IValidator validator)
        {
            _loyaltyBenefits = loyaltyBenefits;
            _validator = validator;
        }

        public decimal GetPassengerFare(decimal passengerFare)
        {
            if (_validator.isValid(passengerFare.ToString()))
            {
                return _loyaltyBenefits.isUsingLoyalty ? passengerFare - _loyaltyBenefits.Loyaltypoints : passengerFare;
            }else
            {
                 throw new Exception();
            }
        }

        public PassengerFareExceptions GetPassengerFareExceptions()
        {
            return new PassengerFareExceptions() { Discount = 0, loyaltyBenefits = _loyaltyBenefits};

        }
    }
}
