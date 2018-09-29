using FlightSummaryGenerator.Validators.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSummaryGenerator.Validators
{
   public class FlightSummaryValidator:IValidator
    {
            public bool isValid(string message)
        {
            return !String.IsNullOrEmpty(message);
        }
    }
}
