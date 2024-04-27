using DataTransferLayer.OtherObjects;

namespace ServiceLayer.Generic
{
    public class SoGeneric<Dto>
    {
        public SoGeneric()
        {
            mo = new DtoMessage();
        }

        public DtoMessage mo { get; set; }
        public Dto dto { get; set; }
        public List<Dto> listDto { get; set; }
    }
}
