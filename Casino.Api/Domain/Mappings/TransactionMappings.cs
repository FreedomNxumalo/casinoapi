using Domain.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Mappings
{
    public class TransactionMappings
    {
        public TransactionMappings(EntityTypeBuilder<Transaction> entityBuilder)
        {
            entityBuilder.HasKey(t => t.ID);
            entityBuilder.Property(t => t.amount).IsRequired();
            entityBuilder.Property(t => t.playerId).IsRequired();
            entityBuilder.Property(t => t.transactionTypeId).IsRequired();
        }
    }
}
