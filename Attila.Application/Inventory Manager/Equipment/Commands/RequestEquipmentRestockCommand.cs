﻿using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipment.Commands
{
    public class RequestEquipmentRestockCommand : IRequest<bool>
    {
        public int RequestEquipmentID { get; set; }
        public EquipmentRestockRequest MyEquipmentRestockRequest { get; set; }

        public class RequestEquipmentRestockCommandHandler : IRequestHandler<RequestEquipmentRestockCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public RequestEquipmentRestockCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(RequestEquipmentRestockCommand request, CancellationToken cancellationToken)
            {
                var _searchRequestEquipmentId = dbContext.EquipmentsDetails.Find(request.RequestEquipmentID);

                if (_searchRequestEquipmentId != null)
                {
                    EquipmentRestockRequest _equipmentRestockRequest = new EquipmentRestockRequest
                    {
                        Quantity = request.MyEquipmentRestockRequest.Quantity,
                        DateTimeRequest = DateTime.Now,
                        EquipmentDetailsID = request.MyEquipmentRestockRequest.EquipmentDetailsID,
                        Status = 0,
                        UserID = request.MyEquipmentRestockRequest.UserID
                    };

                    dbContext.EquipmentRestockRequests.Add(_equipmentRestockRequest);
                    await dbContext.SaveChangesAsync();

                    return true;
                }

                else
                {
                    throw new Exception("Equipment Details ID does not exist!");
                }
                
            }
        }
    }
}

