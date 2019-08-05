using System;

namespace WD_Tests.WizzAir
{
    public class FlightDetail
    {
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public DateTime? DepartureDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int Passengers { get; set; }
    }
}
