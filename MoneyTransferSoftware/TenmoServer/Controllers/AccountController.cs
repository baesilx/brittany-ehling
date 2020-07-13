using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TenmoServer.DAO;
using TenmoServer.Models;
using TenmoServer.Security;

namespace TenmoServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountDAO accountDAO;
        public AccountController(IAccountDAO accountDAO)
        {
            this.accountDAO = accountDAO;
        }

        [HttpGet]
        public ActionResult<Account> GetAccount()
        {
            int userId = GetId(); //Calling GetId() and assigning the result to userId

            Account account = accountDAO.GetAccount(userId); //assigning the account with userId to account object

            if (account != null)
            {
                return Ok(account);
            }
            else
            {
                return NotFound();
            }
        }
        public int GetId()
        {
            int userId = 0;
            var tokenId = User.FindFirst("sub").Value;

            int.TryParse(tokenId, out userId);

            return userId;
        }
    }
}
