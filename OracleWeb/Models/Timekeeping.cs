using System;
using System.Collections.Generic;

namespace OracleWeb.Models;

public partial class Timekeeping
{
    public decimal TimekeepingId { get; set; }

    public DateTime? CheckIn { get; set; }

    public DateTime? CheckOut { get; set; }

    public decimal? TotalHours { get; set; }

    public bool isDelete { get; set; } = false;

    public decimal? EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }
}
