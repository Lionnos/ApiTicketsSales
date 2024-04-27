using DataTransferLayer.Objects;
using ServiceLayer.Generic;

namespace ServiceLayer.ServiceObject
{
    public class SoUser : SoGeneric<DtoUser>
    {
        public DtoUser dtoUser { get; set; }
        public List<DtoUser> listDtoUser { get; set; }
    }
}
