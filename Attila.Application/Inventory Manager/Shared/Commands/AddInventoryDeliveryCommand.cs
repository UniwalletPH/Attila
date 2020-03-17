﻿using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
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
                DeliveryDetails _equipmentRestock = new DeliveryDetails
                {
                    DeliveryDate = request.MyInventoriesDeliveryVM.DeliveryDate,
                    ReceiptImage = request.MyInventoriesDeliveryVM.ReceiptImage,
                    DeliveryPrice = request.MyInventoriesDeliveryVM.DeliveryPrice,
                    SupplierDetailsID = request.MyInventoriesDeliveryVM.SupplierDetailsID,
                    Remarks = request.MyInventoriesDeliveryVM.Remarks
                };

                dbContext.DeliveryDetails.Add(_equipmentRestock);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
