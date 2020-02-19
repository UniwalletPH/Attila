using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using Attila.Domain.Entities.Tables;
using Attila.Domain.Enums;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipment.Commands
{
    public class RequestEquipmentRestockCommand : IRequest<bool>
    {
        public int Quantity { get; set; }

        public DateTime DateTimeRequest { get; set; }

        public int EquipmentDetailsID { get; set; }

        public EquipmentDetails EquipmentDetails { get; set; }

        public Status Status { get; set; }

        public int UserID { get; set; }

        public class RequestEquipmentRestockCommandHandler : IRequestHandler<RequestEquipmentRestockCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public RequestEquipmentRestockCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(RequestEquipmentRestockCommand request, CancellationToken cancellationToken)
            {
                var _equipmentRestockRequest = new EquipmentRestockRequest
                {
                    Quantity = request.Quantity,
                    DateTimeRequest = DateTime.Now,
                    EquipmentDetailsID = request.EquipmentDetailsID,
                    Status = request.Status,
                    UserID = request.UserID
                };

                dbContext.EquipmentRestockRequests.Add(_equipmentRestockRequest);
                await dbContext.SaveChangesAsync();

                return true;


            }
        }
    }
}

