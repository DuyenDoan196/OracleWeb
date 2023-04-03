namespace OracleWeb.Response
{
    public class EmployeeResponse
    {
        public decimal Id { get; set; }
        public string Name { get; set; } = null!;

        public DateTime? Birth { get; set; }

        public string? Address { get; set; }

        public decimal? Gender { get; set; }

        public string? PositionName { get; set; }
    }
}
