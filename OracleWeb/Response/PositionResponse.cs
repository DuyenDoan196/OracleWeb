using OracleWeb.Models;

namespace OracleWeb.Response
{
    public class PositionResponse
    {
        public decimal? Id { get; set; }

        public string? Name { get; set; }

        public decimal? Salary { get; set; }

        public virtual List<string>? EmployeesName { get; set; }
    }
}
