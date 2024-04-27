namespace DataTransferLayer.Objects
{
    public class DtoSubsidiary
    {
        public string idSubsidiary { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string cellPhone { get; set; }
        public string email { get; set; }
        public string openingHours { get; set; }
        public string manager { get; set; }
        public string description { get; set; }

        #region childs
        public ICollection<DtoUser> childDtoUser { get; set; } = new List<DtoUser>();
        #endregion
    }
}
