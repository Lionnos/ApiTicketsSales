using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccessLayer.Generic;

namespace DataAccessLayer.Entities
{
    [Table("origin")]
    public class Origin : EntityGeneric
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string idOrigin { get; set; }
        public string city { get; set; }
        public bool state { get; set; }
    }
}
