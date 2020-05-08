using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Shared.Queries;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Shared.Commands
{
    public class UploadReceiptImageCommand : IRequest<bool>
    {
        public InventoriesDeliveryVM MyInventoriesDeliveryVM { get; set; }

        public class UploadReceiptImageCommandHandler : IRequestHandler<UploadReceiptImageCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public UploadReceiptImageCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(UploadReceiptImageCommand request, CancellationToken cancellationToken)
            {
                var delivery = dbContext.Deliveries.Find(request.MyInventoriesDeliveryVM.ID);
                delivery.ReceiptImage = request.MyInventoriesDeliveryVM.ReceiptImage;


                 
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
