using System;
using System.Globalization;
using Interfaces.Entities;
using Interfaces.Services;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter data rent");
            Console.Write("Car model: ");
            string model = Console.ReadLine();

            Console.Write("Pick up (dd/mm/yyyy hh/mm): ");
            DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm",CultureInfo.InvariantCulture);
            Console.Write("Return (dd/mm/yyyy hh/mm): ");
            DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.Write("Priece per hour: ");
            double priceHour = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
            Console.Write("Priece per day: ");
            double priceDay = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            
            CarRental carRental = new CarRental(start, finish, new Vehicle(model));
            RentalService rentalService = new RentalService(priceHour, priceDay,new BrazilTaxService());

            rentalService.ProcessInvoice(carRental);

            Console.WriteLine("invoice: ");
            Console.WriteLine(carRental.Invoice);
                       
        }
    }
}
