using OracleWeb.Models;

namespace OracleWeb.Interfaces
{
    public interface IPayrollServices
    {
        Task CreateAsync(PayRoll payroll);
        Task UpdateAsync(PayRoll payroll);
        Task DeleteAsync(decimal id);
        Task<PayRoll> GetAsync(decimal id);
        Task<List<PayRoll>> GetAllAsync();
    }
}
