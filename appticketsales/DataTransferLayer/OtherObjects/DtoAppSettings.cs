namespace DataTransferLayer.OtherObjects
{
    public class DtoAppSettings
    {
        public string connetionStringsMySql { get; set; }
        public string originAudience { get; set; }
        public string originIssuer { get; set; }
        public string jwtSecret { get; set; }
    }
}
