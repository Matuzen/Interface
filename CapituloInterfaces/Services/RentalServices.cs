using System;
using CapituloInterfaces.Entities;


namespace CapituloInterfaces.Services
{
    class RentalServices
    {
        public double PricePerHour { get; set; }
        public double PricePerDay { get; set; }

        private BrazilTaxService brazilTaxService = new BrazilTaxService();

        public RentalServices(double pricePerHour, double pricePerDay)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
        }

        public void ProcessInvoice(CarRental carRental)
        {
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);     // duração da minha locação
            double basicPayment = 0.0;       // calcular o pagamento básico

            if (duration.TotalHours <= 12)         // se a duração for até 12h
            {
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);        // Math.Ceiling arredonda pra cima
            }

            else
            {
                basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
            }

            // Calcular o valor do imposto
            double tax = brazilTaxService.Tax(basicPayment);

            // Intanciar o Invoice e associar com o CarRental
            carRental.Invoice = new Invoice(basicPayment, tax);     // processar o invoice
        }
    }
}
