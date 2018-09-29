using FlightSummaryGenerator.Passenger;
using FlightSummaryGenerator.Validators;
using FlightSummaryGenerator.Validators.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System;
using Xunit;

namespace FlightSummaryGenerator.FunctionalUnitTests
{
    [TestFixture]
    public class AirlineEmpoyeeDetailsTests
    {
        private IValidator _iValidator;
        private IPassengerDetails _iPassengerDetails;
        private AirlineEmployee _airlineEmployee;
        [SetUp]
        public void Setup()
        {
            _iPassengerDetails = Substitute.For<IPassengerDetails>();

            _airlineEmployee = new AirlineEmployee(new FlightSummaryValidator());
        }

        [Test]
        public void ShouldCreate()
        {
            _airlineEmployee.Received().GetPassengerFare(1000);
            _airlineEmployee.Received().GetPassengerFareExceptions();
            NUnit.Framework.Assert.NotNull(_airlineEmployee.Received().GetPassengerFareExceptions().Discount);
        }
    }
}
