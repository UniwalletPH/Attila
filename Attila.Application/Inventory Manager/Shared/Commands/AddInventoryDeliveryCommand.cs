using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Shared.Queries;
using Attila.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Shared.Commands
{
    public class AddInventoryDeliveryCommand : IRequest<bool>
    {
        public InventoriesDeliveryVM MyInventoriesDeliveryVM { get; set; }

        public class AddInventoryDeliveryCommandHandler : IRequestHandler<AddInventoryDeliveryCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public AddInventoryDeliveryCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddInventoryDeliveryCommand request, CancellationToken cancellationToken)
            {
                Delivery _equipmentRestock = new Delivery
                {
                    DeliveryDate = request.MyInventoriesDeliveryVM.DeliveryDate,
                    ReceiptImage = request.MyInventoriesDeliveryVM.ReceiptImage,
                    DeliveryPrice = request.MyInventoriesDeliveryVM.DeliveryPrice,
                    SupplierID = request.MyInventoriesDeliveryVM.SupplierDetailsID,
                    Remarks = request.MyInventoriesDeliveryVM.Remarks
                };

                dbContext.Deliveries.Add(_equipmentRestock);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
