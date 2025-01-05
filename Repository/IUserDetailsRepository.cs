using ExpenseApp.Models.Entity;

namespace ExpenseApp.Repository
{
    public interface IUserDetailsRepository
    {
        string AddUserDetails(UserDetails userDetails); 
        UserDetails GetUserDetails(string id);
        UserDetails UpdateUserDetails(UserDetails userDetails);





    }
}
