using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("Crews")]
    public class Crew : ExtendedBaseModel
    {
        [Column(TypeName = "int")]
        public int PersonID { get; set; }
        [Column(TypeName = "int")]
        public int MediaID { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string Department { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Job { get; set; }
        [Column(TypeName = "int")]
        public int EpisodeCount { get; set; }
        [Column(TypeName = "tinyint")]
        public int Type { get; set; }
    }
}
