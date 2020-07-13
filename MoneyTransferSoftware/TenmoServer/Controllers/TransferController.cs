using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenmoServer.DAO;
using TenmoServer.Models;

namespace TenmoServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ITransferDAO transferDAO;
        private readonly IAccountDAO accountDAO;
        private readonly IUserDAO userDAO;

        public TransferController(ITransferDAO transferDAO, IAccountDAO accountDAO, IUserDAO userDAO)
        {
            this.transferDAO = transferDAO;
            this.accountDAO = accountDAO;
            this.userDAO = userDAO;
        }

        [HttpGet]
        public List<User> ListUsers()
        {
            return userDAO.GetUsers();
        }

        [HttpGet("{transferId}")]
        public ActionResult<TransferWithDetails> GetTransferById(int transferId)
        {
            TransferWithDetails transfer = transferDAO.GetTransfer(transferId);
            if (transfer != null)
            {
                return Ok(transfer);
            }
            else
            {
                return NotFound("Transfer does not exist.");
            }
        }

        [HttpGet("history")]
        public ActionResult<List<TransferWithDetails>> ListTransfers()
        {
            int userId = GetId();
            var transferHistory = transferDAO.GetTransferHistory(userId);

            if (transferHistory != null)
            {
                return Ok(transferHistory);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public ActionResult<TransferWithDetails> SendMoney(NewTransfer nt)
        {
            int userId = GetId();
            Account accountFrom = accountDAO.GetAccount(userId);

            if (accountFrom == null)
            {
                return NotFound("Account does not exist");
            }
            if (accountFrom.Balance >= nt.Amount)
            {
                TransferWithDetails result = transferDAO.SendMoney(userId, nt.ReceiverAccount, nt.Amount);

                return Ok(result);
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