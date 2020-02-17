using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipment.Commands
{
    public class DeleteEquipmentDetailsCommand : IRequest<bool>
    {
        public int DeleteSearchedID { get; set; }

        public class DeleteEquipmentDetailsCommandHandler : IRequestHandler<DeleteEquipmentDetailsCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public DeleteEquipmentDetailsCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<bool> Handle(DeleteEquipmentDetailsCommand request, CancellationToken cancellationToken)
            {
                var _deleteEquipmentDetails = dbContext.EquipmentsDetails.Find(request.DeleteSearchedID);

                if (_deleteEquipmentDetails != null)
                {
                    dbContext.EquipmentsDetails.Remove(_deleteEquipmentDetails);

                    var _deleteEquipmentInventory = dbContext.EquipmentsInventory.Where(a => a.EquipmentDetailsID == request.DeleteSearchedID).ToList();
                    dbContext.EquipmentsInventory.RemoveRange(_deleteEquipmentInventory);

                    await dbContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    throw new Exception("Equipment ID does not exist!");
                }
            }
        }
    }
}
