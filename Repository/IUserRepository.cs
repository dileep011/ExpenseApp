using ExpenseApp.Models.Entity;

namespace ExpenseApp.Repository
{
    public interface IUserRepository
    {
        List<UserDetails> GetAll();
        UserDetails GetById(int UserId);
        UserDetails Register(UserDetails userDetails);
        UserDetails Update(UserDetails userDetails);
        UserDetails Delete(int UserId);
        UserDetails Login(int UserId,string Password);
        
    }
}
