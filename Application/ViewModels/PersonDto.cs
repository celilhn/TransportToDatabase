using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class PersonDto
    {
        public int ID { get; set; }
        public int PersonOldID { get; set; }
        public bool Adult { get; set; }
        public int Gender { get; set; }
        public string KnownForDepartment { get; set; }
        public string Name { get; set; }
        public double Popularity { get; set; }
        public string ProfilePath { get; set; }
        public string Biography { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime Deathday { get; set; }
        public object Homepage { get; set; }
        public string ImdbId { get; set; }
    }
}
