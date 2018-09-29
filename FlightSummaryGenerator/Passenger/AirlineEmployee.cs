using FlightSummaryGenerator.Validators.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSummaryGenerator.Passenger
{
    public class AirlineEmployee : IPassengerDetails
    {
        private decimal _passengerFare { get; set; }
        private readonly IValidator _validator;


        /// <summary>
        /// Airline Employee.
        /// Injecting Validator Service for class members validation.
        /// </summary>
        /// <param name="validator"></param>
        public AirlineEmployee(IValidator validator)
        {
            _validator = validator;
        }

        public decimal GetPassengerFare(decimal passengerFare)
        {
            _passengerFare = passengerFare;

            return 0;
        }
        public PassengerFareExceptions GetPassengerFareExceptions()
        {
            return new PassengerFareExceptions() { Discount = _passengerFare, loyaltyBenefits = new LoyaltyBenefitss.LoyaltyBenefits(false, 0, false) { isUsingLoyalty = false, Loyaltypoints = 0 } };


        }
    }
}
