using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Food.Commands
{
    public class AddFoodRestockCommand : IRequest<bool>
    {
        public DateTime DeliveryDate { get; set; }

        public byte[] ReceiptImage { get; set; }

        public decimal DeliveryPrice { get; set; }

        public string Remarks { get; set; }

        public class AddFoodRestockCommandHandler : IRequestHandler<AddFoodRestockCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public AddFoodRestockCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddFoodRestockCommand request, CancellationToken cancellationToken)
            {
                FoodRestock _foodRestock = new FoodRestock
                {
                    DeliveryDate = request.DeliveryDate,
                    ReceiptImage = request.ReceiptImage,
                    DeliveryPrice = request.DeliveryPrice,
                    Remarks = request.Remarks
                };

                dbContext.FoodsRestock.Add(_foodRestock);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
