using ExpenseApp.Dal;
using ExpenseApp.Models.Entity;
using ExpenseApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseApp.Controllers
{
    [Route("api/[Expensecontroller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseRepository _expenseRepository;
        public ExpenseController (IExpenseRepository repository)
        {
             _expenseRepository = repository;
        }
        [HttpGet("GetAllExpenses")]
        public List<ExpenseDetails> GetExpenseDetails()
        {
            var expenseDeatils = _expenseRepository.GetAllExpenseDetails();
            return expenseDeatils;
        }
        [HttpPost("GetAllExpensesByUser")]
        public List<ExpenseDetails> GetExpenseDetailsByUser([FromBody] string userId)
        {
            return _expenseRepository.GetExpenseDetailsByUserId(userId);
        }
        [HttpPost("GetAllExpensesByCity")]
        public List<ExpenseDetails> GetExpenseDetailsByCity([FromBody] int city)
        {
            return _expenseRepository.GetExpenseDetailsByCity(city);
        }
    }
}
