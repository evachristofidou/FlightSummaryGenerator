using FlightSummaryGenerator.Passenger;
using FlightSummaryGenerator.Validators;
using NSubstitute;
using NUnit.Framework;
using System;
using Xunit;

namespace FlightSummaryGenerator.FunctionalUnitTests
{
    [TestFixture]
    public class GeneralPassengerDetailsTests
    {
        private IPassengerDetails _iPassengerDetails;
        private GeneralPassenger _generalPassenger;
        [SetUp]
        public void Setup()
        {
            _iPassengerDetails = Substitute.For<IPassengerDetails>();

            _generalPassenger = new GeneralPassenger(new FlightSummaryValidator());
        }

        [Test]
        public void ShouldCreate()
        {
            _generalPassenger.Received().GetPassengerFare(1000);
        }
    }
}
