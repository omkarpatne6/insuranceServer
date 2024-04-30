using System;
using System.Collections.Generic;

namespace Insurance_server.Models;

public partial class PaymentDetail
{
    public int PaymentId { get; set; }

    public string? CardOwnerName { get; set; }

    public string? CardNumber { get; set; }

    public string? SecurityCode { get; set; }

    public DateOnly? ValidThrough { get; set; }

    public int? Eid { get; set; }

    public virtual UserLoginDetail? EidNavigation { get; set; }
}
