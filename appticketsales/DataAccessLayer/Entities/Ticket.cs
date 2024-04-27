using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    [Table("ticket")]
    public class Ticket
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string idTicket { get; set; }
        public string idSale { get; set; }
        public string idProgramming { get; set; }
        public string idSubsidiary { get; set; }
        public string origin { get; set; }
        public string destination { get; set; }
        public int seatNumber { get; set; }
        public DateTime registerDate { get; set; }
        public DateTime travelDate { get; set; }
        public TimeSpan travelTime { get; set; }
        public Decimal price { get; set; }
        public string state { get; set; }
        public string description { get; set; }
    }
}

