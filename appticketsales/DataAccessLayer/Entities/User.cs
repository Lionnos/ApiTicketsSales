using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccessLayer.Generic;

namespace DataAccessLayer.Entities
{
    [Table("user")]
    public class User : EntityGeneric
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string idUser { get; set; }
        public string idSubsidiary { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string surName { get; set; }
        public string dni { get; set; }
        public DateTime birthDate { get; set; }
        public bool gender { get; set; }

        #region parents
        public Subsidiary Subsidiary { get; set; } = null!;
        #endregion
    }
}

