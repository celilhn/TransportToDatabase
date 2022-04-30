using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("People")]
    public class Person : ExtendedBaseModel
    {
        [Column(TypeName = "int")]
        public int PersonOldID { get; set; }
        [Column(TypeName = "tinyint")]
        public bool Adult { get; set; }
        [Column(TypeName = "tinyint")]
        public int Gender { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string KnownForDepartment { get; set; }
        [Column(TypeName = "varchar(180)")]
        public string Name { get; set; }
        [Column(TypeName = "float")]
        public double Popularity { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string ProfilePath { get; set; }
        [Column(TypeName = "varchar(9000)")]
        public string Biography { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ?Birthday { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ?Deathday { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string Homepage { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string ImdbId { get; set; }
    }
}
