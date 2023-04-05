using OracleWeb.Models;
using OracleWeb.Request;
using OracleWeb.Response;

namespace OracleWeb.Interfaces
{
    public interface ITimekeepingServices
    {
        Task<List<Timekeeping>> GetAllAsync();
        Task<Timekeeping> GetAsync(decimal id);
        Task CreateAsync(Timekeeping timekeeping);
        Task UpdateAsync(Timekeeping timekeeping);
        Task DeleteAsync(decimal id);
    }
}
