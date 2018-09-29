using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSummaryGenerator.Passenger.LoayaltyMember
{
    public interface ILoyaltyBenefits
    {
        bool HasExtraBags { get; set; }
        bool isUsingLoyalty { get; set; }
        int Loyaltypoints { get; set; }
        int GetLoyaltyPointsUsed();
        int GetExtraBagsCount();
    }
}
