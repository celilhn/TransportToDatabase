using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class CrewDto
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public int MediaID { get; set; }
        public string Department { get; set; }
        public string Job { get; set; }
        public int EpisodeCount { get; set; }
        public int Type { get; set; }
    }
}
