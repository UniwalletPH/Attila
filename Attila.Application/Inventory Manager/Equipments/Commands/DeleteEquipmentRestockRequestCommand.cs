using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipments.Commands
{
    public class DeleteEquipmentRestockRequestCommand : IRequest<bool>
    {
        public int DeleteRequestID { get; set; }

        public class DeleteEquipmentRestockRequestCommandHandler : IRequestHandler<DeleteEquipmentRestockRequestCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public DeleteEquipmentRestockRequestCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<bool> Handle(DeleteEquipmentRestockRequestCommand request, CancellationToken cancellationToken)
            {
                var _getEquipmentRestockRequest = dbContext.EquipmentRestockRequests.Find(request.DeleteRequestID);

                if (_getEquipmentRestockRequest != null)
                {
                    var _getEquipmentRestockCollection = dbContext.EquipmentRequestCollections.Where(a => a.EquipmentRestockRequestID == request.DeleteRequestID).ToList();

                    dbContext.EquipmentRestockRequests.Remove(_getEquipmentRestockRequest);
                    dbContext.EquipmentRequestCollections.RemoveRange(_getEquipmentRestockCollection);

                }
                else
                {
                    throw new Exception("Request ID does not exist!");
                }

                await dbContext.SaveChangesAsync();
                return true;
            }
        }
    }
}
