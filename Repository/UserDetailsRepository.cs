using ExpenseApp.Dal;
using ExpenseApp.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ExpenseApp.Repository
{
    public class UserDetailsRepository : IUserDetailsRepository
    {
        private readonly ExpenseAppDbContext _context;
        


        public UserDetailsRepository(ExpenseAppDbContext context)
        {
            _context = context;
            
        }

        string IUserDetailsRepository.AddUserDetails(UserDetails userDetails)
        {
            _context.UserDetails.Add(userDetails);
            _context.SaveChanges();
            return userDetails.UserId;
        }

        public UserDetails GetUserDetails(string id)
        {
            return _context.UserDetails
                           .Where(e => e.UserId == id)
                           .FirstOrDefault();
        }

        public UserDetails UpdateUserDetails(UserDetails userDetails)
        {
            var existingUserByEmail = _context.UserDetails
                .FirstOrDefault(u => u.Email == userDetails.Email && u.UserId != userDetails.UserId);

            var existingUserByPhone = _context.UserDetails
                .FirstOrDefault(u => u.PhoneNo == userDetails.PhoneNo && u.UserId != userDetails.UserId);

            if (existingUserByEmail != null)
            {
                throw new InvalidOperationException($"A user with the email '{userDetails.Email}' already exists.");
            }

            if (existingUserByPhone != null)
            {
                throw new InvalidOperationException($"A user with the phone number '{userDetails.PhoneNo}' already exists.");
            }

            var existingUser = _context.UserDetails
                .FirstOrDefault(u => u.UserId == userDetails.UserId);

            if (existingUser == null)
            {
                return null; // User not found
            }

            // Update the existing user's details
            existingUser.Name = userDetails.Name;
            existingUser.Email = userDetails.Email;
            existingUser.Password = userDetails.Password;
            existingUser.Role = userDetails.Role;
            existingUser.PhoneNo = userDetails.PhoneNo;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new InvalidOperationException("The user details were modified by another process. Please try again.");
            }

            return existingUser;
        }


    }
}
