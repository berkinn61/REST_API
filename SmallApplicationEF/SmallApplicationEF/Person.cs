using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallApplicationEF
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string PLZ { get; set; } = null!;
        public City City { get; set; } = null!;
    }
}
