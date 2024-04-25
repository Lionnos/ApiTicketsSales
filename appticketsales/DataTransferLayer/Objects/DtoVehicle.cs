using DataTransferLayer.Generic;

namespace DataTransferLayer.Objects
{
    public class DtoVehicle : DtoGeneric
    {
        public string idVehicle { get; set; }
        public string plate { get; set; }
        public string model { get; set; }
        public int seats { get; set; }
        public bool state { get; set; }
        public string description { get; set; }
    }
}
