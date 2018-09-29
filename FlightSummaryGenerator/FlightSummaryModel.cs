using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSummaryGenerator
{
    public class FlightSummaryModel
    {
        public int passengers { get; set; }
        public int GeneralPassengers { get; set; }
        public int AirlinePassengers { get; set; }
        public int LoyaltyPassengers { get; set; }
        public int bags { get; set; }
        public int LoyaltyPointsUsed { get; set; }
        public decimal costOffFlight { get; set; }
        public decimal revenueBeforeDiscounts { get; set; }
        public decimal revenueAfterDiscounts { get; set; }
        public bool canFlightProceed { get; set; }
    }
}
