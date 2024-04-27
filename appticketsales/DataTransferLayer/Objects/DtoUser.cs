using DataTransferLayer.Generic;

namespace DataTransferLayer.Objects
{
    public class DtoUser : DtoGeneric
    {
        public string idUser { get; set; }
        public string idSubsidiary { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string surName { get; set; }
        public string dni { get; set; }
        public DateTime birthDate { get; set; }
        public bool gender { get; set; }


        #region parents
        public DtoSubsidiary DtoSubsidiary { get; set; } = null!;
        #endregion
    }
}
