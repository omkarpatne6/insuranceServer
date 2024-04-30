using System;
using System.Collections.Generic;

namespace Insurance_server.Models;

public partial class EmployeeDetail
{
    public int Id { get; set; }

    public int? Eid { get; set; }

    public string? Email { get; set; }

    public string? Name { get; set; }

    public string? CompanyName { get; set; }

    public virtual UserLoginDetail? EidNavigation { get; set; }
}
