using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    [Table("sale")]
    public class Sale
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string idSale { get; set; }

        public string idClient { get; set; }
        public string serie { get; set; }
        public DateTime resgisterDate { get; set; }
        public DateTime travelDate { get; set; }
        public TimeSpan travelTime { get; set; }
        public Decimal totalPrice { get; set; }
        public string state { get; set; }
        public string description { get; set; }
    }
}

