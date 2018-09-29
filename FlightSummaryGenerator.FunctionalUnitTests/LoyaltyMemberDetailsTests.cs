using FlightSummaryGenerator.Passenger;
using FlightSummaryGenerator.Passenger.LoayaltyMember;
using FlightSummaryGenerator.Passenger.LoyaltyBenefitss;
using FlightSummaryGenerator.Validators;
using FlightSummaryGenerator.Validators.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System;
using Xunit;

namespace FlightSummaryGenerator.FunctionalUnitTests
{
    [TestFixture]
    public class LoyaltyMemberDetailsTests
    {
        private IValidator _iValidator;
        private ILoyaltyBenefits _loyaltyBenefits;
        private IPassengerDetails _iPassengerDetails;
        private LoyaltyMember _generalPassenger;
        [SetUp]
        public void Setup()
        {
            _iPassengerDetails = Substitute.For<IPassengerDetails>();
            _loyaltyBenefits = new LoyaltyBenefits(true, 50,true);
            _generalPassenger = new LoyaltyMember(_loyaltyBenefits, new FlightSummaryValidator());
        }

        [Test]
        public void ShouldCreate()
        {
            _generalPassenger.Received().GetPassengerFare(1000);
            _generalPassenger.Received().GetPassengerFareExceptions().loyaltyBenefits.GetLoyaltyPointsUsed();
            NUnit.Framework.Assert.NotNull(_generalPassenger.Received().GetPassengerFareExceptions().loyaltyBenefits.isUsingLoyalty);
            NUnit.Framework.Assert.NotNull(_generalPassenger.Received().GetPassengerFareExceptions().loyaltyBenefits.Loyaltypoints);


        }
    }
}
