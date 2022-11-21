using System;
using CapituloInterfaces.Entities;


namespace CapituloInterfaces.Services
{
    class RentalServices
    {
        public double PricePerHour { get; set; }
        public double PricePerDay { get; set; }

        public RentalServices(double pricePerHour, double pricePerDay)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
        }

        public void ProcessInvoice(CarRental carRental)
        { 
            
        }
    }
}
