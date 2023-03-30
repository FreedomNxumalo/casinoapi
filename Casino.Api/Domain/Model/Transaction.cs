using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class Transaction : BaseEntity
    {
        public decimal amount { get; set; }
        public int playerId { get; set; }
        public int transactionTypeId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
