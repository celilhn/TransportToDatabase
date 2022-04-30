using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class ImageDto
    {
        public int ID { get; set; }
        public int OwnerID { get; set; }
        public double AspectRatio { get; set; }
        public int Height { get; set; }
        public string Iso6391 { get; set; }
        public string FilePath { get; set; }
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }
        public int Width { get; set; }
        public int Type { get; set; }
    }
}
