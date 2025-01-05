using System;
using ExpenseApp.Models.Entity;
using ExpenseApp.Services;
using System.Linq;
using ExpenseApp.Dal;

namespace ExpenseApp.Repository
{
    public class PasswordHasherRepository : IPasswordHasherServiceRepository
    {
        private readonly IPasswordHasherService _passwordHasherService;
        private readonly ExpenseAppDbContext _context;

        public PasswordHasherRepository(IPasswordHasherService passwordHasherService, ExpenseAppDbContext context)
        {
            _passwordHasherService = passwordHasherService;
            _context = context;
        }

        public UserDetails SavePassword(UserDetails userDetails, string password)
        {
            // Hash the password before saving
            string hashedPassword = _passwordHasherService.SavePassword(password);

            // Assuming you have a User entity with a Password property
            if (userDetails != null)
            {
                userDetails.Password = hashedPassword;
                return userDetails;
            }
            return null; // Add this line to ensure all code paths return a value
        }

        public bool ValidatePassword(UserDetails userDetails, string password)
        {
            // Retrieve the user and verify the password
            var user1 = _context.UserDetails.FirstOrDefault(u => u.UserId == userDetails.UserId);
            if (user1 != null)
            {
                return _passwordHasherService.ValidatePassword(userDetails, password);
            }
            return false;
        }
        // Get user by email, phone number, or user ID
        public UserDetails GetUserByIdentifier(string userIdentifier)
        {
            // Check if userIdentifier is a valid email or phone number or user ID
            var user = _context.UserDetails
                .FirstOrDefault(u => u.Email == userIdentifier || u.PhoneNo == userIdentifier || u.UserId == userIdentifier);

            return user;
        }
    }
}
