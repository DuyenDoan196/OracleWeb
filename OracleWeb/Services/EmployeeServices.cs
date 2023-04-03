using Microsoft.EntityFrameworkCore;
using OracleWeb.Interfaces;
using OracleWeb.Models;
using OracleWeb.Request;
using OracleWeb.Response;

namespace OracleWeb.Services
{
    public class EmployeeServices : IEmployeeServices//control .
    {
        private readonly ModelContext _context;
        //contructor
        public EmployeeServices (ModelContext context)
        {
            _context = context;

        }
        public async Task CreateEmployeeAsync(EmployeeRequest employee)
        {
            if (employee.Name != null && employee.Name.Length > 0)
            {
                var newEmployee = new Employee
                {
                    Name = employee.Name,
                    Birth = employee.Birth,
                    Gender = employee.Gender,
                    Address = employee.Address,
                    PositonId = employee.PositonId,

                };
                await _context.Employees.AddAsync(newEmployee);
                await _context.SaveChangesAsync();
            }
        }

        public Task DeleteEmployeeAsync(decimal id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EmployeeResponse>> GetAllEmployeeAsync()
        {
            var employees = await _context.Employees
                .Include(e => e.Positon)
                .Select(e => new EmployeeResponse
                {
                    Id = e.EmployeeId,
                    Name = e.Name,
                    Birth = e.Birth,
                    Gender = e.Gender,
                    Address = e.Address,
                    PositionName = e.Positon.Name
                }).ToListAsync();
            return employees;
        }

        public Task<EmployeeResponse> GetEmployeeAsync(decimal id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmployeeAsync(decimal id, EmployeeRequest employee)
        {
            throw new NotImplementedException();
        }
    }
}
