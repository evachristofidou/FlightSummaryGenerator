using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSummaryGenerator.Validators.Interfaces
{
    public interface  IValidator
    {
        bool isValid(string value);
    }
}
