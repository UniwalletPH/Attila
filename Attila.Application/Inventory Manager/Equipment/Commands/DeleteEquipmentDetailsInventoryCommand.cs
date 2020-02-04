using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Equipment.Commands
{
    public class DeleteEquipmentDetailsInventoryCommand : IRequest<bool>
    {
        private readonly int deleteSearchedID;
        public DeleteEquipmentDetailsInventoryCommand(int deleteSearchedID)
        {
            this.deleteSearchedID = deleteSearchedID;
        }

        public class DeleteEquipmentDetailsInventoryCommandHandler : IRequestHandler<DeleteEquipmentDetailsInventoryCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public DeleteEquipmentDetailsInventoryCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<bool> Handle(DeleteEquipmentDetailsInventoryCommand request, CancellationToken cancellationToken)
            {
                var _deleteEquipmentDetails = dbContext.EquipmentsInventory.Find(request.deleteSearchedID);

                if (_deleteEquipmentDetails != null)
                {
                    dbContext.EquipmentsInventory.Remove(_deleteEquipmentDetails);
                }
                else
                {
                    throw new Exception("Equipment ID does not exist!");
                }

                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
