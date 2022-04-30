using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Casts")]
    public class Cast : ExtendedBaseModel
    {
        [Column(TypeName = "int")]
        public int PersonID { get; set; }
        [Column(TypeName = "int")]
        public int MediaID { get; set; }
        [Column(TypeName = "varchar(1000)")]
        public string Character { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string CreditId { get; set; }
        [Column(TypeName = "int")]
        public int Order { get; set; }
        [Column(TypeName = "int")]
        public int EpisodeCount { get; set; }
        [Column(TypeName = "tinyint")]
        public int Type { get; set; }
    }
}
