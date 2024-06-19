using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_18_Patterns.Models
{
    interface IAnimal
    {
        string Class { get; set; }
        string Order { get; set; }
        string Family { get; set; }
        string Species { get; set; }
    }
}
