﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_10_1.ViewModels
{
    internal interface IClientInfo
    {
        Client Client { get; }
        string FirstName { get; }
        string SecondName { get; }
        string MiddleName { get; }
        string PhoneNumber { get; }
        string PassportNumber { get; }
        bool CanChangeName { get; }
        bool CanChangePassport { get; }
        bool CanChangePhone { get; }

        Client GetUpdatedClient();
    }
}
