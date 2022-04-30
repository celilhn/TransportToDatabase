using Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("KnownFors")]
    public class KnownFor : ExtendedBaseModel
    {
        [Column(TypeName = "int")]
        public int PersonID { get; set; }
        [Column(TypeName = "int")]
        public int MediaID { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string MediaType { get; set; }
    }
}
