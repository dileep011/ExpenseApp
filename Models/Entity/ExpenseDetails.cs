using System.ComponentModel.DataAnnotations;

namespace ExpenseApp.Models.Entity
{
    public class ExpenseDetails
    {
        [Key]
        public int id { get; set; }
        public int ExpenseId { get; set; }
        public string? UserId { get; set; }
        public string? Description { get; set; }
        public decimal? Amount { get; set; }
        public int CityId { get; set; }
        public DateTime DateTime { get; set; }
        public int StateId { get; set; }
        
        

    }
}
