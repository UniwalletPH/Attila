using Attila.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Infrastructure.Persistence.Configurations
{
    public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.HasData(new Equipment
            { 
                ID = 1,
                Code = "PCX-001",
                Name = "Monoblock Chair",
                RentalFee = 50,
                EquipmentType = EquipmentType.NonConsumable,
                UnitType = UnitType.Piece
            });

            builder.HasData(new Equipment
            { 
                ID = 2,
                Code = "QMN-002",
                Name = "Monoblock Table",
                RentalFee = 100,
                EquipmentType = EquipmentType.NonConsumable,
                UnitType = UnitType.Piece
            });

        }
    }
}
