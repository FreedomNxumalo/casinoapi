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
    [Route("api/player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private IRepository<Player> playerRepo;
        private IRepository<Transaction> transRepo;
        private IRepository<TransactionType> transTypeRepo;
        public PlayerController(IRepository<Player> playerRepo, IRepository<Transaction> transRepo, IRepository<TransactionType> transTypeRepo)
        {
            this.playerRepo = playerRepo;
            this.transRepo = transRepo;
            this.transTypeRepo = transTypeRepo;
        }
        //get all players 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> Get()
        {
            return await Task.FromResult(playerRepo.GetAll().ToList());
        }
        //get player by id 
        [HttpGet("{Id}")]
        public async Task<ActionResult<Player>> Get(int Id)
        {
            var player = await Task.FromResult(playerRepo.Get(Id));
            if (player == null)
                return BadRequest("Player not found!");
            return player;
        }

        //update players balance 
        [HttpPost]
        public async Task<ActionResult<Player>> Post(int id,Transaction  transaction)
        {
            var player = playerRepo.Get(id);
            if (player == null)
                return BadRequest("Player not found!");
            if(transaction.amount<0)
                return BadRequest("Transaction amount can not be negative!");
            if (transaction.amount > player.amount)
                return BadRequest("Transaction amount can not be greater than players balance!");
            try
            {
                var transactionType = transTypeRepo.Get(transaction.transactionTypeId);
                Transaction model = new Transaction()
                {
                    transactionTypeId = transactionType.ID,
                    amount = transaction.amount,
                    playerId = player.ID,
                    DateCreated = DateTime.Now
                };
                transRepo.Insert(model);
                //update players balance 
                player.amount = player.amount - transaction.amount;
                playerRepo.Update(player);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return await Task.FromResult(player);
        }

    }
}
