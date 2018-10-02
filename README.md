# Flight Summary Generator

A console program that generates and outputs flight summary data.
Making use of SOLID Formatting principles.<br>
 Creational pattern used: Factory Method

- While launching the Console Program, the user is prompted to add a Valid Filename for the InputFile.
- After the Summary of the File has been generated, the "FlightSummary.txt" is generated under 
  the Windows Explorer "Documents" Folder.

### Possible Improvements and Enhancements

- Further validations for the inputfile values can be added through Dependency Injection of FlightSummaryValidator.
- More Extensive Tests can be added to validate handling of null or invalid values for the Passenger entities.


##### Input & Output Example
Input file <br>
add route London Dublin 100 150<br>
add aircraft Gulfstream-G550 8<br>
add passenger general Mark<br>
add passenger general Tom<br>
add passenger general James<br>
add passenger airline Trevor<br>
add passenger loyalty Alan 50 FALSE FALSE<br>
add passenger loyalty Susie 40 TRUE FALSE<br>
add passenger loyalty Joan 100 FALSE TRUE<br>
add passenger general Jack<br>

Output file<br>
{<br>
  "passengers": 8,<br>
  "generalPassengers": 4,<br>
  "airlinePassengers": 1,<br>
  "loyaltyPassengers": 3,<br>
  "bags": 9,<br>
  "loyaltyPointsUsed": 40,<br>
  "costOfFlight": 800,<br>
  "revenueBeforeDiscounts": 1200,<br>
  "revenueAfterDiscounts": 1010,<br>
  "canFlightProceed": true<br>
}




