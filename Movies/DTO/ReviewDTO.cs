using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.DTO
{
    public class ReviewDTO
    {
        public int RevId { get; set; }
        public string ReviewContent { get; set; }
        public string ReviewForMovie { get; set; }
    }
}
