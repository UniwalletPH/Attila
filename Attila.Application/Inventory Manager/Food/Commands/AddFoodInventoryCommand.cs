using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Food.Commands
{
    public class AddFoodInventoryCommand : IRequest<bool>
    {
        public int Quantity { get; set; }

        public DateTime ExpirationDate { get; set; }

        public DateTime EncodingDate { get; set; }

        public decimal ItemPrice { get; set; }

        public string Remarks { get; set; }

        public int UserID { get; set; }

        public int FoodDetailsID { get; set; }

        public int FoodRestockID { get; set; }

        public class AddFoodInventoryCommandHandler : IRequestHandler<AddFoodInventoryCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public AddFoodInventoryCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddFoodInventoryCommand request, CancellationToken cancellationToken)
            {
                FoodInventory _foodInventory = new FoodInventory
                {
                    Quantity = request.Quantity,
                    ExpirationDate = request.ExpirationDate,
                    EncodingDate = request.EncodingDate,
                    ItemPrice = request.ItemPrice,
                    Remarks = request.Remarks,
                    UserID = request.UserID,
                    FoodDetailsID = request.FoodDetailsID,
                    FoodRestockID = request.FoodRestockID
                };

                dbContext.FoodsInventory.Add(_foodInventory);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
