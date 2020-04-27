using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Foods.Queries;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Foods.Commands
{
    public class AddFoodRequestCollectionCommand : IRequest<bool>
    {
        public int FoodRestockID { get; set; }

        public FoodsRestockRequestVM MyFoodRestockRequestVM { get; set; }

        public class AddFoodRequestCollectionCommandHandler : IRequestHandler<AddFoodRequestCollectionCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public AddFoodRequestCollectionCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<bool> Handle(AddFoodRequestCollectionCommand request, CancellationToken cancellationToken)
            {
                foreach (var item in request.MyFoodRestockRequestVM.FoodRequestCollection)
                {
                    FoodRequestCollection _foodRequestCollection = new FoodRequestCollection
                    {
                        FoodID = item.FoodID,
                        FoodRestockRequestID = request.FoodRestockID,
                        Quantity = item.Quantity
                    };

                    dbContext.FoodRequestCollections.Add(_foodRequestCollection);
                }

                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
