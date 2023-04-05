using Microsoft.EntityFrameworkCore;
using OracleWeb.Interfaces;
using OracleWeb.Models;
using OracleWeb.Request;
using OracleWeb.Response;

namespace OracleWeb.Services
{
    public class EmployeeServices : IEmployeeServices
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

        public async Task DeleteEmployeeAsync(decimal id)
        {
            var result = await _context.Employees
                .Where(e => e.PositonId == id && e.isDelete != true)
                .FirstOrDefaultAsync();
            if (result == null)
            {
                throw new Exception("Not Found This Employee!");
            }
            result.isDelete = true;
            await _context.SaveChangesAsync();
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

        public async Task<EmployeeResponse> GetEmployeeAsync(decimal id)
        {
            var employee = await _context.Employees
                .Where(e=> e.PositonId == id && e.isDelete !=true)
                .Include(e => e.Positon)
                .Select(e => new EmployeeResponse
                {
                    Id = e.EmployeeId,
                    Name = e.Name,
                    Birth = e.Birth,
                    Gender = e.Gender,
                    Address = e.Address,
                    PositionName = e.Positon.Name
                }).FirstOrDefaultAsync();
            if(employee == null)
            {
                throw new Exception("Not Found This Employeee!");
            }    
            return employee;
        }

        public async Task UpdateEmployeeAsync(decimal id, EmployeeRequest employee)
        {
            var result = await _context.Employees
                .Where(e => e.PositonId == id && e.isDelete != true)
                .FirstOrDefaultAsync();
            if(result == null)
            {
                throw new Exception("Not Found This Employee!");
            }
            result.Name = employee.Name ?? result.Name;
            result.Birth = employee.Birth ?? result.Birth;
            result.Address = employee.Address ?? result.Address;
            result.Gender = employee.Gender ?? result.Gender;
            result.EmployeeId = employee.PositonId;
            await _context.SaveChangesAsync();
        }
    }
}
