using ExpenseApp.Dal;
using ExpenseApp.Models.Entity;

namespace ExpenseApp.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ExpenseAppDbContext _context;

        public ExpenseRepository(ExpenseAppDbContext context)
        {
            _context = context;
        }
        List<ExpenseDetails> IExpenseRepository.GetAllExpenseDetails()
        {
            return _context.ExpenseDetails.ToList();
        }

        List<ExpenseDetails> IExpenseRepository.GetExpenseDetailsByCity(int cityId)
        {
            return _context.ExpenseDetails.Where(e =>e.CityId == cityId).ToList();
        }

        public List<ExpenseDetails> GetExpenseDetailsByUserId(string id)
        {
            return _context.ExpenseDetails.Where(e => e.UserId == id).ToList();
        }
    }
}
