﻿using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Equipments.Queries;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipments.Commands
{
    public class AddEquipmentDetailsCommand : IRequest<bool>
    {
        public EquipmentsDetailsVM MyEquipmentsDetailsVM { get; set; }

        public class AddEquipmentDetailsCommandHandler : IRequestHandler<AddEquipmentDetailsCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public AddEquipmentDetailsCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddEquipmentDetailsCommand request, CancellationToken cancellationToken)
            {
                Equipment _equipmentDetails = new Equipment
                {
                    Code = request.MyEquipmentsDetailsVM.Code,
                    Name = request.MyEquipmentsDetailsVM.Name,
                    Description = request.MyEquipmentsDetailsVM.Description,
                    RentalFee = request.MyEquipmentsDetailsVM.RentalFee,
                    UnitType = request.MyEquipmentsDetailsVM.UnitType,
                    EquipmentType = request.MyEquipmentsDetailsVM.EquipmentType,
                    CreatedOn = DateTime.Now
                };

                dbContext.Equipments.Add(_equipmentDetails);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
