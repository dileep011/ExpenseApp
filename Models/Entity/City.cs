using System.ComponentModel.DataAnnotations;

namespace ExpenseApp.Models.Entity
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string? CityName { get; set; }
        public int StateId { get; set; }
    }
}
