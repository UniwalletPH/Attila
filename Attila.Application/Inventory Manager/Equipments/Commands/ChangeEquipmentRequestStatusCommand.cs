using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipments.Commands
{
    public class ChangeEquipmentRequestStatusCommand : IRequest<bool>
    {
        public int ID { get; set; }
        public class ChangeEventStatusCommandHandler : IRequestHandler<ChangeEquipmentRequestStatusCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public ChangeEventStatusCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(ChangeEquipmentRequestStatusCommand request, CancellationToken cancellationToken)
            {
                var _Restock= dbContext.EquipmentRestockRequests.Find(request.ID);

                _Restock.Status = Status.ForApproval;
                await dbContext.SaveChangesAsync();


                return true;

            }
        }
    }
}
