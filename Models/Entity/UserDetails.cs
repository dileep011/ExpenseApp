﻿using System.ComponentModel.DataAnnotations;

namespace ExpenseApp.Models.Entity
{
    public class UserDetails
    {

        [Key]
        public string UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool Role {  get; set; }
        public string? PhoneNo { get; set; }
        
    }
}
