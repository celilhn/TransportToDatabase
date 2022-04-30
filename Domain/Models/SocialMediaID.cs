using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("SocialMediaIDs")]
    public class SocialMediaID : ExtendedBaseModel
    {
        [Column(TypeName = "int")]
        public int PersonID { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string FreebaseMid { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string FreebaseId { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string ImdbId { get; set; }
        [Column(TypeName = "int")]
        public int TvrageId { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string FacebookId { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string InstagramId { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string TwitterId { get; set; }
    }
}
