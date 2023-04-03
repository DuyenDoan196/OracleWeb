using OracleWeb.Request;
using OracleWeb.Response;

namespace OracleWeb.Interfaces
{
    public interface IEmployeeServices
    {
        //db tra ve response
        Task<List<EmployeeResponse>> GetAllEmployeeAsync();
        Task<EmployeeResponse> GetEmployeeAsync(decimal id);
        Task CreateEmployeeAsync(EmployeeRequest employee);
        Task UpdateEmployeeAsync(decimal id, EmployeeRequest employee);
        Task DeleteEmployeeAsync(decimal id);
    }
}
