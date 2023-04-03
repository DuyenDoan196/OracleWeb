namespace OracleWeb.Request
{
    public class EmployeeRequest
    {
        public string Name { get; set; } = null!;

        public DateTime? Birth { get; set; }

        public string? Address { get; set; }

        public decimal? Gender { get; set; }

        public decimal? PositonId { get; set; }
    }
}
