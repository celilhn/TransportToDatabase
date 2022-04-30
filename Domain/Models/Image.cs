using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Images")]
    public class Image : ExtendedBaseModel
    {
        [Column(TypeName = "int")]
        public int OwnerID { get; set; }
        [Column(TypeName = "float")]
        public double AspectRatio { get; set; }
        [Column(TypeName = "int")]
        public int Height { get; set; }
        [Column(TypeName = "varchar(180)")]
        public string Iso6391 { get; set; }
        [Column(TypeName = "varchar(180)")]
        public string FilePath { get; set; }
        [Column(TypeName = "float")]
        public double VoteAverage { get; set; }
        [Column(TypeName = "int")]
        public int VoteCount { get; set; }
        [Column(TypeName = "int")]
        public int Width { get; set; }
        [Column(TypeName = "tinyint")]
        public int Type { get; set; }
    }
}
