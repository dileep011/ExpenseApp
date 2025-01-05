using ExpenseApp.Models.Entity;

namespace ExpenseApp.Services
{
    public interface IPasswordHasherService
    {
        string SavePassword(string password);
        bool ValidatePassword(UserDetails userDetails, string passwordToVerify);
    }
}
