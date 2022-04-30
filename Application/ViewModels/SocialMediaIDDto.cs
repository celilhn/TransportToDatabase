using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SocialMediaIDDto
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public string FreebaseMid { get; set; }
        public string FreebaseId { get; set; }
        public string ImdbId { get; set; }
        public int TvrageId { get; set; }
        public string FacebookId { get; set; }
        public string InstagramId { get; set; }
        public string TwitterId { get; set; }
    }
}
