using System.ComponentModel.DataAnnotations;

namespace DataTransferLayer.Objects
{
    public class DtoAuthentication
    {
        public string idUser { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
