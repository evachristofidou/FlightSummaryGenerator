using FlightSummaryGenerator.Passenger;
using FlightSummaryGenerator.Passenger.LoyaltyBenefitss;
using FlightSummaryGenerator.Validators;
using FlightSummaryGenerator.Validators.Interfaces;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Linq;

namespace FlightSummaryGenerator
{
    class Program
    {
        /// <summary>
        /// Main Program state.
        /// Accepts and validates filename and file location.
        /// Processes and generates Flight Summary Report.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string userInput;
            Console.Write("Enter a valid FilePath value: ");
            userInput = Console.ReadLine();
            string line;
            int totalSeats = 0;
            decimal ticketPrice = 0;
            decimal costPerCustomer = 0;
            FlightSummaryModel flightSummary = new FlightSummaryModel();

            try
            {
                if (!File.Exists(userInput))
                {
                    Main(new string[] { "" });
                }
                //Pass the file path and file name to the StreamReader constructor
                //Reads Files and generates PassengerDetails
                using (StreamReader reader = new StreamReader(userInput))
                {
                    decimal discount = 0;
                    int lineNumber = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (lineNumber == 0)
                        {
                            costPerCustomer = Convert.ToDecimal(line.Split(' ')[4]);
                            ticketPrice = Convert.ToDecimal(line.Split(' ')[5]);
                        }
                        if (lineNumber == 1)
                        {
                            totalSeats = Convert.ToInt32(line.Split(' ')[3]);
                        }
                        if (lineNumber >= 2)
                        {
                            string[] passengerValues = line.Split(' ');
                            string passengerId = passengerValues[2];
                            bool isUsingLoyalty = passengerValues.Length <= 4 ? false : Convert.ToBoolean(passengerValues[5]);
                            int loyaltyPoints = passengerValues.Length <= 4 ? 0 : Convert.ToInt32(passengerValues[4]);
                            bool hasExtraBags = passengerValues.Length <= 4 ? false : Convert.ToBoolean(passengerValues[6]);


                            IPassengerDetails passenger = GetPassengerType(passengerId, isUsingLoyalty, loyaltyPoints, hasExtraBags);
                            flightSummary.AirlinePassengers += passengerValues[2] == "airline" ? 1 : 0;
                            flightSummary.LoyaltyPassengers += passengerValues[2] == "loyalty" ? 1 : 0;
                            flightSummary.GeneralPassengers += passengerValues[2] == "general" ? 1 : 0;
                            flightSummary.passengers += 1;
                            flightSummary.bags += passenger.GetPassengerFareExceptions().loyaltyBenefits.GetExtraBagsCount();
                            flightSummary.revenueAfterDiscounts += passenger.GetPassengerFare(ticketPrice);
                            discount += passenger.GetPassengerFareExceptions().Discount + passenger.GetPassengerFareExceptions().loyaltyBenefits.GetLoyaltyPointsUsed();
                            flightSummary.LoyaltyPointsUsed += passenger.GetPassengerFareExceptions().loyaltyBenefits.GetLoyaltyPointsUsed();
                            flightSummary.costOffFlight += costPerCustomer;
                        }

                        lineNumber++;
                    }
                    flightSummary.revenueBeforeDiscounts = flightSummary.revenueAfterDiscounts + discount;

                }

                //Checks and validates whether Flight can Proceed or not
                flightSummary.canFlightProceed = flightSummary.revenueAfterDiscounts > flightSummary.costOffFlight
                    && flightSummary.passengers <= totalSeats ? true : false;

                ///Writes output to TXT File on MyDocuments Folder
                string flightSummaryOutput = JsonConvert.SerializeObject(flightSummary);
                string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(mydocpath, "FlightSummary.txt")))
                {
                    outputFile.WriteLine(flightSummaryOutput);
                }


                Console.Write("Press Enter Key to Exit the program");
                string cmong = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }


        /// <summary>
        /// Passenger Factory method.
        /// Initializes instance of Passenger Class.
        /// </summary>
        /// <param name="passengerId"></param>
        /// <param name="isUsingLoyalty"></param>
        /// <param name="LoyaltyPoints"></param>
        /// <param name="hasExtraBags"></param>
        /// <returns></returns>
        private static IPassengerDetails GetPassengerType(string passengerId, bool isUsingLoyalty, int LoyaltyPoints, bool hasExtraBags)
        {
            IPassengerDetails passenger;
            switch (passengerId)
            {
                case "airline":
                    passenger = new AirlineEmployee(new FlightSummaryValidator());
                    break;
                case "general":
                    passenger = new GeneralPassenger(new FlightSummaryValidator());
                    break;
                case "loyalty":
                    passenger = new LoyaltyMember(new LoyaltyBenefits(isUsingLoyalty, LoyaltyPoints, hasExtraBags), new FlightSummaryValidator());
                    break;
                default: throw new Exception();
            }
            return passenger;
        }
    }
}
