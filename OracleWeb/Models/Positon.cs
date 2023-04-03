using System;
using System.Collections.Generic;

namespace OracleWeb.Models;

public partial class Positon
{
    public decimal PositonId { get; set; }

    public string? Name { get; set; }

    public decimal? Salary { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
