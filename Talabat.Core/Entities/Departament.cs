using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entities
{
    public class Departament : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Courses> Courses { get; set; }

    }
}
