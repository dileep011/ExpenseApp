using System.ComponentModel.DataAnnotations;

namespace ExpenseApp.Models.Entity
{
    public class Login
    {
        [Key]
        public string UserIdentifier { get; set; } // Can be email, phone, or user ID
        public string Password { get; set; }
        

    }
}
