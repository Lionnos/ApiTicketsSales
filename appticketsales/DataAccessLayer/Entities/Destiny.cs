using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccessLayer.Generic;

namespace DataAccessLayer.Entities
{
    [Table("destiny")]
    public class Destiny : EntityGeneric
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string idDestiny { get; set; }
        public string city { get; set; }
        public bool state { get; set; }
    }
}

