using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallApplicationEF
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public List<Person> Persons { get; set; } = new List<Person>();
    }
}
