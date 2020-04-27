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
    public class AddFoodRequestCommand : IRequest<int>
    {
        public int ID { get; set; }

        public class AddFoodRequestCommandHandler : IRequestHandler<AddFoodRequestCommand, int>
        {
            private readonly IAttilaDbContext dbContext;
            public AddFoodRequestCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<int> Handle(AddFoodRequestCommand request, CancellationToken cancellationToken)
            {
                FoodRestockRequest _foodRestockRequest = new FoodRestockRequest
                {
                    DateTimeRequest = DateTime.Now,
                    Status = Status.Processing,
                    InventoryManagerID = request.ID
                };

                dbContext.FoodRestockRequests.Add(_foodRestockRequest);
                await dbContext.SaveChangesAsync();

                return _foodRestockRequest.ID;
            }
        }
    }
}
