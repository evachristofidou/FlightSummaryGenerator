using FlightSummaryGenerator.Validators.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSummaryGenerator.Passenger
{
    public class GeneralPassenger : IPassengerDetails
    {
        private readonly IValidator _validator;

        /// <summary>
        /// General Passenger Constructors.
        /// Injecting Validator for validating Values
        /// </summary>
        /// <param name="validator"></param>
        public GeneralPassenger(IValidator validator)
        {
            _validator = validator;
        }
        public decimal GetPassengerFare(decimal passengerFare)
        {
            if (_validator.isValid(passengerFare.ToString()))
            {
                return passengerFare;
            }
            else { throw new Exception(); }
        }
        public PassengerFareExceptions GetPassengerFareExceptions()
        {
            return new PassengerFareExceptions() { Discount = 0, loyaltyBenefits = new LoyaltyBenefitss.LoyaltyBenefits(false, 0, false ) { isUsingLoyalty = false, Loyaltypoints = 0,  } };
        }
    }
}
