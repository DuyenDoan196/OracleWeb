using Microsoft.EntityFrameworkCore;
using OracleWeb.Interfaces;
using OracleWeb.Models;

namespace OracleWeb.Services
{
    public class TimekeepingServices : ITimekeepingServices
    {
        private readonly ModelContext _context;
        public TimekeepingServices(ModelContext context) {
            _context = context;
        }

        public async Task CreateAsync(Timekeeping timekeeping)
        {
            try
            {
                await _context.Timekeepings.AddAsync(timekeeping);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex) {
                throw ex;
            }
        }

        public async Task DeleteAsync(decimal id)
        {
            var result = await _context.Timekeepings.Where(e => e.TimekeepingId == id && e.isDelete != true)
                .FirstOrDefaultAsync();
            if(result == null)
            {
                throw new Exception("Not Found");
            }
            result.isDelete = true;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Timekeeping>> GetAllAsync()
        {
            var list = await _context.Timekeepings.Where(e => e.isDelete != true)
                .ToListAsync();
            return list;
        }

        public async Task<Timekeeping> GetAsync(decimal id)
        {
            var res = await _context.Timekeepings.Where(e => e.isDelete != true && e.TimekeepingId == id)
                .FirstOrDefaultAsync();
            if(res == null)
            {
                throw new Exception("Not Found");
            }
            return res;
        }

        public async Task UpdateAsync(Timekeeping timekeeping)
        {
            var res = await _context.Timekeepings.Where(e => e.isDelete != true)
                .FirstOrDefaultAsync();
            if(res != null)
            {
                res.CheckIn = timekeeping.CheckIn;
                res.CheckOut = timekeeping.CheckOut;
                res.TotalHours = timekeeping.TotalHours;
                await _context.SaveChangesAsync();
            }
            throw new Exception("Not Found");
        }
    }
}
