using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Request
{
    public class AddReview
    {
        public int MovId { get; set; }

        public string Reviews
        {
            get; set;
        }
    }
}
