using Microsoft.EntityFrameworkCore;
using OracleWeb.Interfaces;
using OracleWeb.Models;

namespace OracleWeb.Services
{
    public class PayrollServices : IPayrollServices
    {
        private readonly ModelContext _context;
        public PayrollServices(ModelContext context)
        {//contructor
            _context = context;
        }
        public async Task CreateAsync(PayRoll payroll)
        {
            try
            {
                await _context.PayRolls.AddAsync(payroll);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Something went wrong!");
            }
        }

        public async Task DeleteAsync(decimal id)
        {
            var payrol = await _context.PayRolls.Where(p => p.PayRollId == id && p.isDelete != true).FirstOrDefaultAsync();
            if (payrol != null)
            {
                payrol.isDelete = true;
                await _context.SaveChangesAsync();
            }

            throw new Exception("Not Found This Payroll");
        }

        public async Task<List<PayRoll>> GetAllAsync()
        {
            var payrolls = await _context.PayRolls.Where(e => e.isDelete != true)
                .ToListAsync();
            return payrolls;
        }

        public async Task<PayRoll> GetAsync(decimal id)
        {
            var payrolls = await _context.PayRolls.Where(e => e.PayRollId == id && e.isDelete != true)
                .FirstOrDefaultAsync();
            if(payrolls != null)
            {
                payrolls.isDelete = true;
                await _context.SaveChangesAsync();
            }
            throw new Exception("Not Found This Payroll");
        }

        public async Task UpdateAsync(PayRoll payroll)
        {
            var payrolls = await _context.PayRolls.Where(e => e.PayRollId == payroll.PayRollId && e.isDelete != true)
                .FirstOrDefaultAsync();
            if (payrolls != null)
            {
                payrolls.TotalHourInAMonth = payroll.TotalHourInAMonth;
                payrolls.Coefficients = payroll.Coefficients;
                payrolls.TotalSalary = payroll.TotalSalary;
                payrolls.DatePaid = payroll.DatePaid;
                await _context.SaveChangesAsync();
            }
            throw new Exception("Not Found This Payroll");
        }
    }
}
