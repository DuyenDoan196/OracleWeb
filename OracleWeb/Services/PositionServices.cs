using Microsoft.EntityFrameworkCore;
using OracleWeb.Helper;
using OracleWeb.Interfaces;
using OracleWeb.Models;
using OracleWeb.Request;
using OracleWeb.Response;

namespace OracleWeb.Services
{
    public class PositionServices : IPositionServices
    {
        private readonly ModelContext _context;
        public PositionServices(ModelContext context)
        {//contructor
            _context = context;
        }
        public async Task CreatePositionAsync(PositionRequest position)
        {
            if(position.Name != null && position.Name.Length > 0)
            {
                var newPosition = new Positon
                {
                    PositonId = StringHepler.GenerateId(),
                    Name = position.Name,
                    Salary = position.Salary,
                };
                await _context.Positons.AddAsync(newPosition);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletePositionAsync(decimal id)
        {
            var position = await _context.Positons.Where(p=>p.PositonId == id && p.isDelete != true).FirstOrDefaultAsync();
            if(position != null)
            {
                position.isDelete = true;
                await _context.SaveChangesAsync();
            }
            throw new Exception("Can not found this position id :" + id);
        }

        public async Task<List<PositionResponse>> GetAllPositionAsync()
        {
            var positions = await _context.Positons
                .Where(e=>e.isDelete != true)
                .Include(e => e.Employees)
                .Select(e => new PositionResponse
                {
                    Id = e.PositonId,
                    Name = e.Name,
                    Salary = e.Salary,
                    EmployeesName = e.Employees.Select(em => em.Name).ToList(),
                }).ToListAsync();
            return positions;
        }
        // sd hàm bất động bộ() dưới db lên
        public async Task<PositionResponse> GetPositionAsync(decimal id)
        {
            var position = await _context.Positons.Where(p => p.PositonId == id && p.isDelete != true)
                .Select(p => new PositionResponse
                {
                    Name = p.Name,
                    Salary = p.Salary,
                    EmployeesName = p.Employees.Select(e => e.Name).ToList(),
                })
                .FirstOrDefaultAsync();
            if(position != null)
            {
                return position;
            }
            throw new Exception("Can not found this position");
        }

        public async Task UpdatePositionAsync(decimal id, PositionRequest position)
        {
            var positionUpdate = await _context.Positons.Where( p => p.PositonId == id && p.isDelete != true).FirstOrDefaultAsync();
            if(positionUpdate != null)
            {
                positionUpdate.Name = position.Name ?? positionUpdate.Name;
                positionUpdate.Salary = position.Salary ?? positionUpdate.Salary;
                await _context.SaveChangesAsync();
            }
            throw new Exception("Can not found this position");
        }
    }
}
