using Domain.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Mappings
{
    public class TransactionTypeMappings
    {
        public TransactionTypeMappings(EntityTypeBuilder<TransactionType> entityBuilder)
        {
            entityBuilder.HasKey(t => t.ID);
            entityBuilder.Property(t => t.transactionType).IsRequired();
        }
    }
}
