using System.ComponentModel.DataAnnotations;

namespace ExpenseApp.Models.Entity
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        public string? StateName { get; set; } 
    }
}
