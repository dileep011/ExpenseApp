using ExpenseApp.Models.Entity;

namespace ExpenseApp.Repository
{
    public interface IExpenseRepository
    {
        List<ExpenseDetails> GetAllExpenseDetails();
        List<ExpenseDetails> GetExpenseDetailsByUserId(string UserId);
        List<ExpenseDetails> GetExpenseDetailsByCity(int CityId);

    }
}
