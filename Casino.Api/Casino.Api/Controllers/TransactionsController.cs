using Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private IRepository<Player> playerRepo;
        private IRepository<Transaction> transRepo;
        private IRepository<TransactionType> transTypeRepo;
        public TransactionsController(IRepository<Player> playerRepo, IRepository<Transaction> transRepo, IRepository<TransactionType> transTypeRepo)
        {
            this.playerRepo = playerRepo;
            this.transRepo = transRepo;
            this.transTypeRepo = transTypeRepo;
        }
        //get all transactions  
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> Get()
        {
            return await Task.FromResult(transRepo.GetAll().ToList());
        }
        //get transaction by id 
        [HttpGet("{Id}")]
        public async Task<ActionResult<Transaction>> Get(int Id)
        {
            var transaction = await Task.FromResult(transRepo.Get(Id));
            if (transaction == null)
            {
                return BadRequest("transaction not found!");
            }
            return transaction;
        }
        //get Transaction by players username 
        [HttpGet("{Username}")]
        public async Task<ActionResult<Transaction>> Get(string Username)
        {
            var player = playerRepo.GetAll().FirstOrDefault(x=>x.fullName.ToLower()==Username.ToLower());
            if (player == null)
                return BadRequest("Player not found!");

            var transaction = transRepo.GetAll().FirstOrDefault(x=>x.playerId== player.ID);
            if (transaction == null)
                return BadRequest("transaction not found!");
            return await Task.FromResult(transaction);
        }
    }
}
