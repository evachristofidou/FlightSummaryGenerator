using FlightSummaryGenerator.Passenger.LoayaltyMember;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSummaryGenerator.Passenger.LoyaltyBenefitss
{
   public class LoyaltyBenefits : ILoyaltyBenefits
    {
        public bool isUsingLoyalty { get; set; }
        public int Loyaltypoints { get; set; }
        public bool HasExtraBags { get; set; }

        /// <summary>
        /// Generates Loyalty Benefits for Passengers eligible for Loyalty members benefits.
        /// </summary>
        /// <param name="_isUsingLoyalty"></param>
        /// <param name="_LoyaltyPoints"></param>
        /// <param name="_hasExtraBags"></param>
        public LoyaltyBenefits(bool _isUsingLoyalty,int _LoyaltyPoints, bool _hasExtraBags)
        {
            isUsingLoyalty = _isUsingLoyalty;
            Loyaltypoints = _LoyaltyPoints;
            HasExtraBags = _hasExtraBags;
        }

        public int GetLoyaltyPointsUsed()
        {
            return isUsingLoyalty ? Loyaltypoints : 0;
        }
        public int GetExtraBagsCount()
        {
            return HasExtraBags ? 2 : 1;
        }
    }
}
