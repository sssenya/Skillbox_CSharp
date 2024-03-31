﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_12_1.Models.Interfaces
{
    internal interface IBankAccount
    {
        double Balance { get; set; }
        double Percent { get; set; }
        DateTime OpeningDate { get; set; }
    }
}
