
namespace DataTransferLayer.Objects
{
    public class DtoProgramming
    {
        public string idProgramming { get; set; }
        public string idOrigin { get; set; }
        public string idDestiny { get; set; }
        public string idVehicle { get; set; }
        public DateTime programmingDate { get; set; }
        public TimeSpan programmingHour { get; set; }
        public bool state { get; set; }
    }
}
