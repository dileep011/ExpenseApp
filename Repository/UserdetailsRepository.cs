using ExpenseApp.Models.Entity;

namespace ExpenseApp.Repository
{
    public class UserdetailsRepository : IUserRepository
    {
        private readonly
        UserDetails IUserRepository.Delete(int UserId)
        {
            throw new NotImplementedException();
        }

        List<UserDetails> IUserRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        UserDetails IUserRepository.GetById(int UserId)
        {
            throw new NotImplementedException();
        }

        UserDetails IUserRepository.Login(int UserId, string Password)
        {
            throw new NotImplementedException();
        }

        UserDetails IUserRepository.Register(UserDetails userDetails)
        {
            throw new NotImplementedException();
        }

        UserDetails IUserRepository.Update(UserDetails userDetails)
        {
            throw new NotImplementedException();
        }
    }
}
