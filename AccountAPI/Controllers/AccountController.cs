using AccountAPI.Models;
using AccountAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AccountAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountRepository accountRepository;
        public AccountController()
        {
            accountRepository = new AccountRepository();
        }

        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            var users = accountRepository.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUsers(int id)
        {
            var user = accountRepository.GetUsersById(id);
            return Ok(user);
        }
    }
}