using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_18_Patterns.Models
{
    class Amphibian : IAnimal {
        public string Class { get; set; }
        public string Order { get; set; }
        public string Family { get; set; }
        public string Species { get; set; }
    }
}
