using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entities
{
   public class Courses :BaseEntity
    {
        public string Crs_name { get; set; }
        public string crs_desc { get; set; }
        public int Duration { get; set; }
    }
}
