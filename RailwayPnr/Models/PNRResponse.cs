namespace RailwayPnr.Models
{
    public class PNRResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public long Timestamp { get; set; }
        public PNRData Data { get; set; }
    }

    public class PNRData
    {
        public string Pnr { get; set; }
        public string TrainNo { get; set; }
        public string TrainName { get; set; }
        public string Doj { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string ReservationUpto { get; set; }
        public string BoardingPoint { get; set; }
        public string Class { get; set; }
        public Passenger[] PassengerStatus { get; set; }
    }

    public class Passenger
    {
        public string Number { get; set; }
        public string BookingStatus { get; set; }
        public string BookingBerthCode { get; set; }
        public string CurrentStatusNew { get; set; }
    }
}
