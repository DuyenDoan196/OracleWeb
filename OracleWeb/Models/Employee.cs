using System;
using System.Collections.Generic;

namespace OracleWeb.Models;

public partial class Employee
{
    public decimal EmployeeId { get; set; } // defaul = 0
    //db tự sinh db

    public string Name { get; set; } = null!;

    public DateTime? Birth { get; set; }

    public string? Address { get; set; }

    public decimal? Gender { get; set; }

    public bool isDelete { get; set; } = false;

    public decimal? PositonId { get; set; }

    public virtual ICollection<PayRoll> PayRolls { get; } = new List<PayRoll>();

    public virtual Positon? Positon { get; set; }

    public virtual ICollection<Timekeeping> Timekeepings { get; } = new List<Timekeeping>();
}
