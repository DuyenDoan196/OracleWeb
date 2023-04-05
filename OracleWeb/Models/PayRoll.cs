using System;
using System.Collections.Generic;

namespace OracleWeb.Models;

public partial class PayRoll
{
    public decimal PayRollId { get; set; }

    public decimal? TotalHourInAMonth { get; set; }

    public decimal? Coefficients { get; set; }

    public decimal? TotalSalary { get; set; }

    public DateTime? DatePaid { get; set; }

    public bool isDelete { get; set; } = false;

    public decimal? EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }
}
