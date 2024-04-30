using System;
using System.Collections.Generic;

namespace Insurance_server.Models;

public partial class PolicyDetail
{
    public int PolicyId { get; set; }

    public string? PolicyName { get; set; }

    public string? PolicyType { get; set; }

    public string? CoverageDetails { get; set; }

    public short? RemainingTenure { get; set; }

    public int? Eid { get; set; }

    public virtual UserLoginDetail? EidNavigation { get; set; }
}
