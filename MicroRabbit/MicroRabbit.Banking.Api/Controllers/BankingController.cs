using MicriRabbit.Banking.Domain.Models;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.ModelsDTO;
using Microsoft.AspNetCore.Mvc;

namespace MicroRabbit.Banking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankingController : ControllerBase
    {
        private IAccountServices _accountService;

        public BankingController(IAccountServices accountServices)
        {
            _accountService = accountServices;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Account>> Get()
        {
            return Ok(_accountService.GetAccounts());
        }

        [HttpPost]
        public IActionResult Post([FromBody] AccoutTransfer accountTransfer)
        {
            _accountService.Tranfer(accountTransfer);
            return Ok(accountTransfer);
        }
    }
}
