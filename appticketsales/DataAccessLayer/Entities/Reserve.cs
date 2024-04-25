using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    [Table("reserve")]
    public class Reserve
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string idReserver { get; set; }
        public string idClient { get; set; }
        public string idProgramming { get; set; }
        public string serie { get; set; }
        public DateTime resgisterDate { get; set; }
        public DateTime travelDate { get; set; }
        public TimeSpan travelTime { get; set; }
        public Decimal advancement { get; set; }
        public string state { get; set; }
        public string description { get; set; }
    }
}

