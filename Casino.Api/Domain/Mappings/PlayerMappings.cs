using Domain.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Mappings
{
    public class PlayerMappings
    {
        public PlayerMappings(EntityTypeBuilder<Player> entityBuilder)
        {
            entityBuilder.HasKey(t => t.ID);
            entityBuilder.Property(t => t.amount).IsRequired();
            entityBuilder.Property(t => t.isActive).IsRequired();
        }
    }
}
