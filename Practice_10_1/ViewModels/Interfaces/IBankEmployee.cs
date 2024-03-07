using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_10_1.ViewModels
{
    internal interface IBankEmployee
    {
        string Name { get; set; }

        void UpdateClientsFromDB();
    }
}
