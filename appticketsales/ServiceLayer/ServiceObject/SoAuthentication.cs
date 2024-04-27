using DataTransferLayer.Objects;
using ServiceLayer.Generic;

namespace ServiceLayer.ServiceObject
{
    public class SoAuthentication : SoGeneric<DtoAuthentication>
    {
        public string token { get; set; }
        public string refreshToken { get; set; }
    }
}
