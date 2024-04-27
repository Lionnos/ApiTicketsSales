using DataTransferLayer.Generic;

namespace DataTransferLayer.Objects
{
    public class DtoOrigin : DtoGeneric
    {
        public string idOrigin { get; set; }
        public string city { get; set; }
        public bool state { get; set; }
    }
}
