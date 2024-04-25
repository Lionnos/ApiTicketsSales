using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    [Table("client")]
    public class Client
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string idClient { get; set; }
        public string identityCard { get; set; }
        public string numberCard { get; set; }
        public string firstName { get; set; }
        public string surName { get; set; }
        public bool gender { get; set; }
        public string cellPhone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
    }
}

