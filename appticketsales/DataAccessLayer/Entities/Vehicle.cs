using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccessLayer.Generic;

namespace DataAccessLayer.Entities
{
    [Table("vehicle")]
    public class Vehicle : EntityGeneric
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string idVehicle { get; set; }
        public string plate  { get; set;}
        public string model { get; set; }
        public int seats { get; set; }
        public bool state { get; set; }
        public string description { get; set; }
    }
    
}
