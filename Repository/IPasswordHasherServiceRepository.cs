using ExpenseApp.Models.Entity;

namespace ExpenseApp.Repository
{
    public interface IPasswordHasherServiceRepository
    {
        UserDetails SavePassword(UserDetails userDetails,  string password);
        bool ValidatePassword(UserDetails userDetails, string password);
        public UserDetails GetUserByIdentifier(string userIdentifier);
    }
}
