using System;
using System.Collections.Generic;

namespace Practice_17_Entity;

public partial class Client
{
    public int Id { get; set; }

    public string SecondName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public int? PhoneNumber { get; set; }

    public string Email { get; set; } = null!;
}
